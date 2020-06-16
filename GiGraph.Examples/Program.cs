using System;
using GiGraph.Dot.Extensions; // Build(), SaveToFile()
using GiGraph.Examples.Basic;

namespace GiGraph.Examples
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var graph = HelloWorld.Generate();

            // build a graph as string
            Console.WriteLine(graph.Build());

            // or save it to a file (.gv and .dot are the default extensions)
            graph.SaveToFile("example.gv");
        }
    }
}