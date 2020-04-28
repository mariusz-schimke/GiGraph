using Dotless.Attributes;
using Dotless.DotBuilders;
using Dotless.GraphElements;
using Dotless.Graphs;
using System;

namespace Dotless
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var o = new TokenWriterOptions
            {
                SingleLine = true,
                TokenSpacing = 0
            };

            var dotGraph = new Graph()
            {
                IsStrict = true,
                Name = "My \"awesome\" \r\ngraph"
            };

            dotGraph.Nodes.Add(new GraphNode("my \"node")
            {
                Label = "my label"
            });

            dotGraph.Nodes.Add(new GraphNode("my \"node")
            {
                Label = new HtmlLabel("<b>text<b>")
            });

            Console.WriteLine(dotGraph.ToString(o));

            Console.ReadLine();
        }
    }
}
