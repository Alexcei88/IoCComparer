namespace SKBKontur.Cabinet.IoCComparer.Tests.DummyClasses;

public interface IInstance
{ 
    public int SomeProperty { get; set; }
    public void DoSomething();
}

public class Instance : IInstance
{ 
    public int SomeProperty { get; set; }
    public void DoSomething()
    {
        
    }
}