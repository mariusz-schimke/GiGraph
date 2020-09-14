using System;
using GiGraph.Dot.Examples.Basic;
using GiGraph.Dot.Extensions;

namespace GiGraph.Dot.Examples
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var graph = HelloWorld.Generate();

            var mapping = graph.Nodes.Attributes.GetPropertyKeyMapping();

            // build a graph as string
            Console.WriteLine(graph.Build());

            // or save it to a file (.gv and .dot are the default extensions)
            graph.SaveToFile("example.gv");
        }
    }
}