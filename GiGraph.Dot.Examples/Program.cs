using System;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Output.Options; // Build(), SaveToFile()
using GiGraph.Examples.Basic;

namespace GiGraph.Examples
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var graph = HelloWorld.Generate();

            var options = new DotFormattingOptions()
            {
                //TextEncoder = value => value.Replace("graph", "dududd")
            };

            // build a graph as string
            Console.WriteLine(graph.Build(options));

            // or save it to a file (.gv and .dot are the default extensions)
            graph.SaveToFile("example.gv", options);
        }
    }
}