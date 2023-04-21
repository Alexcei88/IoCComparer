using SKBKontur.Cabinet.IoCComparer.Tests.DummyClasses.RegisterModule;
using SKBKontur.Cabinet.IoCComparer.Tests.DummyClasses.RegisterModule.Autofac;
using SKBKontur.Cabinet.IoCComparer.Tests.DummyClasses.RegisterModule.DryIoc;

namespace SKBKontur.Cabinet.IoCComparer.Tests.SyntaxTests;

public class ModuleRegistration {
    private readonly ContainerBuilder _autofacContainerBuilder = new ContainerBuilder();
    private readonly DryIoc.IContainer _dryIocContainer = new Container();
    private readonly IServiceCollection _microsoftContainer = new ServiceCollection();
    
    [Test]
    public void Autofac_ModuleRegistration_Success()
    {
        _autofacContainerBuilder.RegisterModule(new AutofacModule());
        var container = _autofacContainerBuilder.Build();
        
        Assert.That(container.Resolve<IAutofacModuleElement1>(), Is.TypeOf<AutofacModuleElement1>());
        Assert.That(container.Resolve<IAutofacModuleElement2>(), Is.TypeOf<AutofacModuleElement2>());
    }

    [Test]
    public void DryIoc_ModuleRegistration_Success()
    {
        _dryIocContainer.RegisterMany<DryIocModule>();

        foreach (var module in _dryIocContainer.ResolveMany<IModule>())
            module.Load(_dryIocContainer);
        
        Assert.That(_dryIocContainer.Resolve<IDryIocModuleElement1>(), Is.TypeOf<DryIocModuleElement1>());
        Assert.That(_dryIocContainer.Resolve<IDryIocModuleElement2>(), Is.TypeOf<DryIocModuleElement2>());
    }
    
    [Test]
    public void MicrosoftDI_ModuleRegistration_Success()
    {
        // Not Supported
        Assert.Fail();
    }
}