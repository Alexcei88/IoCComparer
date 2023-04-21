namespace SKBKontur.Cabinet.IoCComparer.Tests.SyntaxTests;

public class InstanceRegistration // aka ConstructorRegistration
{
    private readonly ContainerBuilder _autofacContainerBuilder = new ContainerBuilder();
    private readonly DryIoc.IContainer _dryIocContainer = new Container();
    private readonly IServiceCollection _microsoftContainer = new ServiceCollection();

    [Test]
    public void Autofac_InstanceResolve_Success()
    {
        _autofacContainerBuilder.RegisterInstance(new Instance { SomeProperty = 1234 }).As<IInstance>();
        var container = _autofacContainerBuilder.Build();
        var instance = container.Resolve<IInstance>();
        
        Assert.That(instance.SomeProperty, Is.Not.EqualTo(new Instance().SomeProperty));
        Assert.That(instance.SomeProperty, Is.EqualTo(1234));
    }

    [Test]
    public void DryIoc_InstanceResolve_Success()
    {
        _dryIocContainer.RegisterInstance<IInstance>(new Instance { SomeProperty = 1234 });
        var instance = _dryIocContainer.Resolve<IInstance>();
        
        Assert.That(instance.SomeProperty, Is.Not.EqualTo(new Instance().SomeProperty));
        Assert.That(instance.SomeProperty, Is.EqualTo(1234));
    }
    
    [Test]
    public void MicrosoftDI_InstanceResolve_Success()
    {
        _microsoftContainer.AddTransient<IInstance>(_ => new Instance { SomeProperty = 1234 });
        var container = _microsoftContainer.BuildServiceProvider();
        var instance = container.GetService<IInstance>();
        
        Assert.That(instance!.SomeProperty, Is.Not.EqualTo(new Instance().SomeProperty));
        Assert.That(instance.SomeProperty, Is.EqualTo(1234));
    }
}