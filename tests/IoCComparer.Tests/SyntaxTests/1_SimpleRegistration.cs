namespace SKBKontur.Cabinet.IoCComparer.Tests.SyntaxTests;

public class SimpleRegistration
{
    private readonly ContainerBuilder _autofacContainerBuilder = new ContainerBuilder();
    private readonly DryIoc.IContainer _dryIocContainer = new Container();
    private readonly IServiceCollection _microsoftContainer = new ServiceCollection();

    [Test]
    public void Autofac_SingleImplementationResolve_Success()
    {
        _autofacContainerBuilder.RegisterType<Single>().As<ISingle>();
        var container = _autofacContainerBuilder.Build();
        
        Assert.That(container.Resolve<ISingle>(), Is.TypeOf<Single>());
    }
    
    [Test]
    public void DryIoc_SingleImplementationResolve_Success()
    {
        _dryIocContainer.Register<ISingle, Single>();
        
        Assert.That(_dryIocContainer.Resolve<ISingle>(), Is.TypeOf<Single>());
    }
    
    [Test]
    public void MicrosoftDI_SingleImplementationResolve_Success()
    {
        _microsoftContainer.AddTransient<ISingle, Single>();
        var serviceProvider = _microsoftContainer.BuildServiceProvider();
        
        Assert.That(serviceProvider.GetService<ISingle>(), Is.TypeOf<Single>());
    }
}