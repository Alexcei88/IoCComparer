using System.ComponentModel.Composition; // for the Export and Import attributes

namespace SKBKontur.Cabinet.IoCComparer.Tests.DummyClasses.DummyAssembly;

public interface IAssemblyScanning1
{
    
}

public interface IAssemblyScanning2
{
    
}

[Export(typeof(IAssemblyScanning1))]
[Export(typeof(IAssemblyScanning2))]
public class AssemblyScanningExample : IAssemblyScanning1, IAssemblyScanning2
{
    
}