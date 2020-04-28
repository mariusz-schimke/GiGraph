using Dotless.Attributes;
using Dotless.GraphElements;
using Dotless.Graphs;
using System;

namespace Dotless
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            HtmlLabel htmlLabel = (string)null!;
            Label label = "Text \" \\label" + htmlLabel;

            var dotGraph = new Graph();

            var node = new GraphNode("my_node")
            {
                Label = "my label"
            };
            dotGraph.Nodes.Add(node);

            Console.WriteLine($"{label}");
            Console.WriteLine($"{htmlLabel}");

            Console.WriteLine();
            Console.WriteLine(dotGraph.ToString());

            Console.ReadLine();
        }
    }
}
