using Dotless.Attributes;
using Dotless.DotWriters.Options;
using Dotless.DotWriters.StringWriter;
using Dotless.EntityGenerators.GraphGenerators;
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

            var graph = new DotGraph()
            {
                IsStrict = true,
                Id = "Graph1"
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
