using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions; // the Build() and SaveToFile() extension methods are defined here
using GiGraph.Examples.Basic;
using System;

namespace GiGraph.Examples
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DotGraph graph = HelloWorld.Generate();

            // build a graph as string
            var graphString = graph.Build();
            Console.WriteLine(graphString);

            // or save it to a file (.gv and .dot are the default extensions)
            graph.SaveToFile(@"C:\MyGraphs\hello-world.gv");

            Console.ReadLine();
        }
    }
}
