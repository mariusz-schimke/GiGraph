using Dotless.Attributes;
using Dotless.DotBuilders;
using Dotless.Generators;
using Dotless.GraphElements;
using Dotless.Graphs;
using System;

namespace Dotless
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var wo = new DotTokenWriterOptions
            {
                //SingleLine = true,
                //TokenSpacing = 0
            };

            var go = new DotEntityGeneratorOptions()
            {
            };

            go.Attributes.PreferQuotedValue = false;

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

            dotGraph.Nodes.Add(new DotGraphNode("myNode")
            {
                Label = new DotTextLabel("label")
            });

            dotGraph.Nodes.Add(new DotGraphNode("myNode")
            {
                Label = new DotTextLabel("graph")
            });

            Console.WriteLine(dotGraph.ToString(wo, go));

            Console.ReadLine();
        }
    }
}
