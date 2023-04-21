using System.Diagnostics;

namespace SKBKontur.Cabinet.IoCComparer.Tests.SyntaxTests;

public class ActivationEvent {
    private readonly ContainerBuilder _autofacContainerBuilder = new ContainerBuilder();
    private readonly DryIoc.IContainer _dryIocContainer = new Container();
    private readonly IServiceCollection _microsoftContainer = new ServiceCollection();
    
    [Test]
    public void Autofac_PropertyInjection_Success()
    {
        _autofacContainerBuilder.RegisterType<Stopwatch>()
            .OnActivated(e => e.Instance.Start());
        var container = _autofacContainerBuilder.Build();
        var sw = container.Resolve<Stopwatch>();
        
        Assert.That(sw.IsRunning);
    }

    [Test]
    public void DryIoc_PropertyInjection_Success()
    {
        _dryIocContainer.Register<Stopwatch, Stopwatch>();
        _dryIocContainer.RegisterInitializer<Stopwatch>((sw, resolver) => sw.Start());
        var sw = _dryIocContainer.Resolve<Stopwatch>();

        Assert.That(sw.IsRunning);
    }
    
    [Test]
    public void MicrosoftDI_PropertyInjection_Success()
    {
        // Not Supported I think?
    }
}