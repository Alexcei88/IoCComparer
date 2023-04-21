namespace SKBKontur.Cabinet.IoCComparer.Tests.SyntaxTests;

public class PropertyInjection {
    private readonly ContainerBuilder _autofacContainerBuilder = new ContainerBuilder();
    private DryIoc.IContainer _dryIocContainer = new Container();
    private readonly IServiceCollection _microsoftContainer = new ServiceCollection();
    
    [Test]
    public void Autofac_PropertyInjection_Success()
    {
        _autofacContainerBuilder.RegisterType<Instance>().As<IInstance>();
        _autofacContainerBuilder.RegisterType<WithProperty>().As<IWithProperty>().PropertiesAutowired();
        var container = _autofacContainerBuilder.Build();
        var withProperty = container.Resolve<IWithProperty>();
        
        Assert.That(withProperty, Is.InstanceOf<WithProperty>());
        Assert.That(withProperty.Instance, Is.TypeOf<Instance>());
    }

    [Test]
    public void DryIoc_PropertyInjection_Success()
    {
        _dryIocContainer = new Container(Rules.Default.With(propertiesAndFields: PropertiesAndFields.All()));
        _dryIocContainer.Register<IInstance, Instance>();
        _dryIocContainer.Register<IWithProperty, WithProperty>();
        var withProperty = _dryIocContainer.Resolve<IWithProperty>();
        
        Assert.That(withProperty, Is.InstanceOf<WithProperty>());
        Assert.That(withProperty.Instance, Is.TypeOf<Instance>());
    }
    
    [Test]
    public void MicrosoftDI_PropertyInjection_Success()
    {
        // Not Supported
        // "We're not going to add property injection to the default implementation.
        // You should add use one of the 3rd party containers supported by the M.E.DI contract."
        Assert.Fail();
    }
}