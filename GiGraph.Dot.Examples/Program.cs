using System;
using System.Threading.Tasks;
using GiGraph.Dot.Examples.Basic;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Layout;

namespace GiGraph.Dot.Examples
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var graph = HelloWorld.Generate();

            // build a graph as string
            Console.WriteLine(graph.Build());

            // or save it to a file (.gv and .dot are the default extensions)
            await graph.SaveToFileAsync("example.gv");
        }
    }
}