namespace SKBKontur.Cabinet.IoCComparer.Tests.SyntaxTests;

public class Lazy
{
    public Lazy()
    {
        Console.WriteLine("Lazy");
    }
}

public class NotLazy
{
    public NotLazy()
    {
        Console.WriteLine("Not really");
    }
}

public class LazyRegistration {
    private readonly ContainerBuilder _autofacContainerBuilder = new ContainerBuilder();
    private readonly DryIoc.IContainer _dryIocContainer = new Container();
    private readonly IServiceCollection _microsoftContainer = new ServiceCollection();
    
    [Test]
    public void Autofac_SingleImplementationResolve_Success()
    {
        _autofacContainerBuilder.RegisterType<Lazy>();         // Lazy
        _autofacContainerBuilder.Register(_ => new Lazy());    // Lazy
        _autofacContainerBuilder.RegisterInstance(new NotLazy()); // Not lazy
    
        _autofacContainerBuilder.Build();
    }
    
    [Test]
    public void DryIoc_SingleImplementationResolve_Success()
    {
        _dryIocContainer.Register<Lazy>();         // Lazy
        _dryIocContainer.RegisterInstance(new NotLazy()); // Not lazy
    }
    
    [Test]
    public void MicrosoftDI_SingleImplementationResolve_Success()
    {
        _microsoftContainer.AddTransient<Lazy>(); // Lazy
        _microsoftContainer.AddTransient<Lazy>(_ => new Lazy()); // Lazy
        //_microsoftContainer.AddTransient<NotLazy>(new Lazy()); Not Supported
        
        _microsoftContainer.BuildServiceProvider();
    }
}