using Dotless.Attributes;
using Dotless.Graphs;
using System;

namespace Dotless
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            HtmlLabel htmlLabel = "HTML label";
            Label label = "Text \" \\label";

            var dotGraph = new Graph("test graph", isDirected: true, isStrict: true);

            Console.WriteLine($"{label}");
            Console.WriteLine($"{htmlLabel}");
            Console.WriteLine($"{label == htmlLabel}");

            Console.WriteLine();
            Console.WriteLine(dotGraph.ToString(true));

            Console.ReadLine();
        }
    }
}
