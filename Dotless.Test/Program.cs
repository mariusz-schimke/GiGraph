using Dotless.Attributes;
using Dotless.DotWriters.Options;
using Dotless.DotWriters.StringWriter;
using Dotless.EntityGenerators.GraphGenerators;
using Dotless.EntityGenerators.Options;
using Dotless.Graphs;
using Dotless.Nodes;
using System;
using System.IO;
using System.Linq;

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

            AddAttributes(graph);
            AddNodes(graph);

            var streamWriter = new StreamWriter(Console.OpenStandardOutput());
            var sw = new DotStringWriter(streamWriter, fo);

            var stringWriter = new DotGraphStringWriter(sw, fo, level: 0);

            var graphWriter = DotGraphGeneratorFactory.CreateDefault();
            graphWriter.Write(graph, stringWriter);

            streamWriter.Dispose();

            // Console.WriteLine(dotGraph.ToString(fo, fo));

            Console.ReadLine();
        }

        private static void AddAttributes(DotGraph graph)
        {
            graph.Label = "My graph";
            //graph.Attributes.SetAttribute(new DotTextLabel("My label"));
        }

        private static void AddNodes(DotGraph graph)
        {
            graph.Nodes.Add(new DotNode("node1")
            {
                Label = "my label"
            });

            graph.Nodes.Add(new DotNode("node2")
            {
                Label = new DotHtmlLabel("<b>text</b>")
            });

            graph.Nodes.Add(new DotNode("node3")
            {
                Label = new DotTextLabel("label")
            }).Attributes.SetAttribute(new DotTextLabel("label2"));

            graph.Nodes.Add(new DotNode("node 4"));
        }
    }
}
