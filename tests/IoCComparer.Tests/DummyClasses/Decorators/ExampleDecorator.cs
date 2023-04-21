namespace SKBKontur.Cabinet.IoCComparer.Tests.DummyClasses.Decorators;

public class ExampleDecorator : IExample
{
    private readonly IExample _example;
    private readonly IInstance _instance;
    public ExampleDecorator(IExample example, IInstance instance)
    {
        _example = example;
        _instance = instance;
    }
    public void A()
    {
        _instance.DoSomething();
        Console.WriteLine("Decorated 'A' Method");
        _example.A();
    }

    public void B()
    {
        _instance.DoSomething();
        Console.WriteLine("Decorated 'B' Method");
        _example.B();
    }
}