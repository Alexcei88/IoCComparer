using SKBKontur.Cabinet.IoCComparer.Tests.DummyClasses.Decorators;

namespace SKBKontur.Cabinet.IoCComparer.Tests.SyntaxTests;

public class Decoration {
    private readonly ContainerBuilder _autofacContainerBuilder = new ContainerBuilder();
    private readonly DryIoc.IContainer _dryIocContainer = new Container();
    private readonly IServiceCollection _microsoftContainer = new ServiceCollection();
    
    [Test]
    public void Autofac_Decorating_Success()
    {
        _autofacContainerBuilder.RegisterType<Instance>().As<IInstance>();
        _autofacContainerBuilder.RegisterType<Example>().As<IExample>();
        _autofacContainerBuilder.RegisterDecorator<ExampleDecorator, IExample>();
        
        var container = _autofacContainerBuilder.Build();
        var decorator = container.Resolve<IExample>();
        decorator.A();
        decorator.B();
    }

    [Test]
    public void DryIoc_Decorating_Success()
    {
        _dryIocContainer.Register<IInstance, Instance>();
        _dryIocContainer.Register<IWithProperty, WithProperty>();
        var withProperty = _dryIocContainer.Resolve<IWithProperty>();
        
        Assert.That(withProperty, Is.InstanceOf<WithProperty>());
        Assert.That(withProperty.Instance, Is.TypeOf<Instance>());
    }
    
    [Test]
    public void MicrosoftDI_WithScrutor_Decorating_Success()
    {
        _microsoftContainer.AddTransient<IInstance, Instance>();
        _microsoftContainer.AddTransient<IExample, Example>();
        _microsoftContainer.Decorate<IExample, ExampleDecorator>();
        
        var container = _microsoftContainer.BuildServiceProvider();
        var decorator = container.GetService<IExample>();
        decorator!.A();
        decorator.B();
    } 
}