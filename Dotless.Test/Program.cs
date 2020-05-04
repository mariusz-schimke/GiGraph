using Dotless.Attributes;
using Dotless.DotWriters.Options;
using Dotless.DotWriters.StringWriter;
using Dotless.EntityGenerators.GraphGenerators;
using Dotless.EntityGenerators.Options;
using Dotless.Graphs;
using Dotless.Nodes;
using System;
using System.IO;

namespace Dotless
{
    // TODO: przejrzec wszystkie metody, czy powinny lub nie powinny byc wirtualne
    // TODO: przejrzeć klasy, czy powinny miec interfejsy (np. TokenWriter itp.)



    internal class Program
    {
        private static void Main(string[] args)
        {
            var fo = new DotFormattingOptions
            {
                //SingleLine = true,
                //TokenSpacing = 0
            };

            var wo = new DotGenerationOptions()
            {
            };

            wo.Attributes.PreferQuotedValue = false;

            var graph = new DotGraph()
            {
                IsStrict = true,
                Id = "My \"awesome\" graph"
            };

            graph.Nodes.Add(new DotNode("my \"node")
            {
                Label = "my label"
            });

            graph.Nodes.Add(new DotNode("my \"node")
            {
                Label = new DotHtmlLabel("<b>text<b>")
            });

            graph.Nodes.Add(new DotNode("myNode")
            {
                Label = new DotTextLabel("label")
            });

            graph.Nodes.Add(new DotNode("myNode")
            {
                Label = new DotTextLabel("graph")
            });

            var sw = new StreamWriter(Console.OpenStandardOutput());

            var stringWriter = new DotStringWriter.GraphContext(sw, fo, level: 0, graph.IsStrict, graph.IsDirected, graph.Id, quoteName: true);

            var graphWriter = DotGraphGeneratorFactory.CreateDefault();
            graphWriter.Write(graph, stringWriter);

            sw.Dispose();

            // Console.WriteLine(dotGraph.ToString(fo, fo));

            Console.ReadLine();
        }
    }
}
