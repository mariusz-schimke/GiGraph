using GiGraph.Dot.Examples.Basic;
using GiGraph.Dot.Extensions;

var graph = HelloWorld.Generate();

// build a graph as string
Console.WriteLine(graph.ToDot());

// or save it to a file (.gv and .dot are the default extensions)
var path = Path.GetFullPath("example.gv");
await graph.SaveAsync(path);

Console.WriteLine();
Console.WriteLine($"File path: {path}");