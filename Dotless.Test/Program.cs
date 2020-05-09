using Dotless.Attributes;
using Dotless.Core;
using Dotless.DotWriters.Options;
using Dotless.DotWriters.StringWriter;
using Dotless.EntityGenerators.GraphGenerators;
using Dotless.EntityGenerators.Options;
using Dotless.Graphs;
using Dotless.Nodes;
using System;
using System.Drawing;
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
                //SingleLineOutput = true
            };

            var go = new DotGenerationOptions
            {

            };

            var graph = new DotGraph()
            {
                IsStrict = true,
                IsDirected = true,
                Id = "Graph1"
            };

            AddAttributes(graph);
            AddNodes(graph);
            AddEdges(graph);

            var streamWriter = new StreamWriter(Console.OpenStandardOutput());
            var sw = new DotStringWriter(streamWriter, fo);

            var graphWriter = DotGraphGeneratorFactory.CreateDefault(go, new DotSyntaxRules());

            var stringWriter = new DotGraphStringWriterFactory(sw, fo);
            graphWriter.Write(graph, stringWriter);

            streamWriter.Dispose();

            // Console.WriteLine(dotGraph.ToString(fo, fo));

            Console.ReadLine();
        }

        private static void AddEdges(DotGraph graph)
        {
            graph.Edges.Add("node1", "node2");
        }

        private static void AddAttributes(DotGraph graph)
        {
            graph.Label = "My graph";
            graph.Color = Color.Black;
            graph.BackgroundColor = Color.BlueViolet;
        }

        private static void AddNodes(DotGraph graph)
        {
            graph.Nodes.Add(new DotNode("node1")
            {
                Label = "my label"
            });

            //graph.Nodes.Add(new DotNode("node2")
            //{
            //    Label = new DotHtmlLabel("<b>text</b>")
            //});

            graph.Nodes.Add(new DotNode("node3")
            {
                Label = new DotTextLabelAttribute("label")
            }).Attributes.SetAttribute(new DotTextLabelAttribute("label2"));

            graph.Nodes.Add(new DotNode("node 4"));
        }
    }
}
