namespace SKBKontur.Cabinet.IoCComparer.Tests.DummyClasses.DummyAssembly;

public interface IWithProperty
{
    public IInstance Instance { get; set; }
}

public class WithProperty : IWithProperty
{
    public IInstance Instance { get; set; }
}