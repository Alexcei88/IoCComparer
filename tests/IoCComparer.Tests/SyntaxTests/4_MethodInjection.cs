namespace SKBKontur.Cabinet.IoCComparer.Tests.SyntaxTests;

public class MethodInjection {
    private readonly ContainerBuilder _autofacContainerBuilder = new ContainerBuilder();
    private readonly DryIoc.IContainer _dryIocContainer = new Container();
    private readonly IServiceCollection _microsoftContainer = new ServiceCollection();
    
    [Test]
    public void Autofac_MethodInjection_Success()
    {
        _autofacContainerBuilder.RegisterType<Instance>().As<IInstance>();
        _autofacContainerBuilder.Register<IWithMethod>(c =>
        {
            var withMethod = new WithMethod();
            withMethod.SetSomething(c.Resolve<IInstance>());
            return withMethod;
        });
        var container = _autofacContainerBuilder.Build();
        var withMethod = container.Resolve<IWithMethod>();
        
        Assert.That(withMethod, Is.InstanceOf<IWithMethod>());
        Assert.That(withMethod.GetSomething(), Is.TypeOf<Instance>());
    }

    [Test]
    public void DryIoc_MethodInjection_Success()
    {
        _dryIocContainer.Register<IInstance, Instance>();
        _dryIocContainer.RegisterDelegate<IWithMethod>(c =>
        {
            var withMethod = new WithMethod();
            withMethod.SetSomething(c.Resolve<IInstance>());
            return withMethod;
        });
        var withMethod = _dryIocContainer.Resolve<IWithMethod>();
        
        Assert.That(withMethod, Is.InstanceOf<IWithMethod>());
        Assert.That(withMethod.GetSomething(), Is.TypeOf<Instance>());
    }
    
    [Test]
    public void MicrosoftDI_MethodInjection_Success()
    {
        _microsoftContainer.AddTransient<IInstance, Instance>();
        _microsoftContainer.AddTransient<IWithMethod>(c =>
        {
            var withMethod = new WithMethod();
            withMethod.SetSomething(c.GetService<IInstance>()!);
            return withMethod;
        });
        
        var container = _microsoftContainer.BuildServiceProvider();
        var withMethod = container.GetService<IWithMethod>();

        Assert.That(withMethod, Is.InstanceOf<IWithMethod>());
        Assert.That(withMethod!.GetSomething(), Is.TypeOf<Instance>());
    }
}