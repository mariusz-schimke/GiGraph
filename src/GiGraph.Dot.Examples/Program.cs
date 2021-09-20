using System;
using GiGraph.Dot.Examples.Basic;
using GiGraph.Dot.Extensions;

var graph = HelloWorld.Generate();

// build a graph as string
Console.WriteLine(graph.Build());

// or save it to a file (.gv and .dot are the default extensions)
await graph.SaveToFileAsync("example.gv");