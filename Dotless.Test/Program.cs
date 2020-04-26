using Dotless.Attributes;
using Dotless.Graphs;
using System;

namespace Dotless
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DotHtmlLabel htmlLabel = "HTML label";
            DotLabel label = "Text \" \\label";

            var dotGraph = new DotGraph("test graph", isDirected: true, isStrict: true);

            Console.WriteLine($"{label}");
            Console.WriteLine($"{htmlLabel}");
            Console.WriteLine($"{label == htmlLabel}");

            Console.WriteLine();
            Console.WriteLine(dotGraph.ToString(true));

            Console.ReadLine();
        }
    }
}
