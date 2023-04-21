namespace SKBKontur.Cabinet.IoCComparer.Tests.DummyClasses.RegisterModule.Autofac;

public class AutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<AutofacModuleElement1>().As<IAutofacModuleElement1>();
        builder.RegisterType<AutofacModuleElement2>().As<IAutofacModuleElement2>();
    }
}