namespace SKBKontur.Cabinet.IoCComparer.Tests.DummyClasses.DummyAssembly;

public interface IWithMethod
{
    public void SetSomething(IInstance instance);
    public IInstance GetSomething();
}

public class WithMethod : IWithMethod
{
    private IInstance Instance;
    
    public void SetSomething(IInstance something)
    {
        Instance = something;
    }

    public IInstance GetSomething()
    {
        return Instance;
    }
}