using System.Reflection;
using DryIoc.MefAttributedModel;

namespace SKBKontur.Cabinet.IoCComparer.Tests.SyntaxTests;

public class AssemblyScanning {
    private readonly ContainerBuilder _autofacContainerBuilder = new ContainerBuilder();
    private readonly DryIoc.IContainer _dryIocContainer = new Container();
    private readonly IServiceCollection _microsoftContainer = new ServiceCollection();
    
    // class AssemblyScanningExample : IAssemblyRegistration1, IAssemblyRegistration2 //
    
    [Test]
    public void Autofac_AssemblyScanning_Success()
    {
        _autofacContainerBuilder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(AssemblyScanningExample))!)
            .Where(type => type.Name == "AssemblyScanningExample")
            .AsImplementedInterfaces();
        var container = _autofacContainerBuilder.Build();
    
        Assert.That(container.Resolve<IAssemblyScanning1>(), Is.TypeOf<AssemblyScanningExample>());
        Assert.That(container.Resolve<IAssemblyScanning2>(), Is.TypeOf<AssemblyScanningExample>());
    }
    
    [Test]
    public void DryIoc_AssemblyScanning_Success()
    {
        // Only with DryIoc.MefAttributedModel extension
        // and using [Export(typeof(SomeType))] attribute
        // or [ExportMany]
        _dryIocContainer.RegisterExports(Assembly.GetAssembly(typeof(AssemblyScanningExample))!);

        Assert.That(_dryIocContainer.Resolve<IAssemblyScanning1>(), Is.TypeOf<AssemblyScanningExample>());
        Assert.That(_dryIocContainer.Resolve<IAssemblyScanning2>(), Is.TypeOf<AssemblyScanningExample>());
    }
    
    [Test]
    public void MicrosoftDI_WithScrutor_AssemblyScanning_Success()
    {
        var collection = new ServiceCollection();
        collection.Scan(scan => scan
            .FromAssemblyOf<AssemblyScanningExample>()
            .AddClasses(classes => classes.AssignableTo<AssemblyScanningExample>())
            .AsImplementedInterfaces()
            .WithTransientLifetime());
        var container = collection.BuildServiceProvider();
        
        Assert.That(container.GetService<IAssemblyScanning1>(), Is.TypeOf<AssemblyScanningExample>());
        Assert.That(container.GetService<IAssemblyScanning2>(), Is.TypeOf<AssemblyScanningExample>());
    }
}