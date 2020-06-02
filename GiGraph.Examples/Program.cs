using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions; // the Build() and SaveToFile()
using System;
using GiGraph.Examples.Basic;

namespace GiGraph.Examples
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DotGraph graph = WithCustomStyles.Generate();

            // build a graph as string
            Console.WriteLine(graph.Build());

            // or save it to a file (.gv and .dot are the default extensions)
            graph.SaveToFile(@"example.gv");

            Console.ReadLine();
        }
    }
}
