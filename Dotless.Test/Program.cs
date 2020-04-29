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
            var o = new DotTokenWriterOptions
            {
                //SingleLine = true,
                //TokenSpacing = 0
            };

            var dotGraph = new DotGraph()
            {
                IsStrict = true,
                Name = "My \"awesome\" graph"
            };

            dotGraph.Nodes.Add(new DotGraphNode("my \"node")
            {
                Label = "my label"
            });

            dotGraph.Nodes.Add(new DotGraphNode("my \"node")
            {
                Label = new DotHtmlLabel("<b>text<b>")
            });

            Console.WriteLine(dotGraph.ToString(o));

            Console.ReadLine();
        }
    }
}
