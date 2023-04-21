namespace SKBKontur.Cabinet.IoCComparer.Tests.DummyClasses.RegisterModule.DryIoc;

public interface IModule
{
    void Load(IRegistrator builder);
}

public class DryIocModule : IModule
{
    public void Load(IRegistrator builder)
    {
        builder.Register<IDryIocModuleElement1, DryIocModuleElement1>();
        builder.Register<IDryIocModuleElement2, DryIocModuleElement2>();
    }
}