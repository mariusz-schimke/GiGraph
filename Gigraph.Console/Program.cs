using Gigraph.Dot.Entities.Attributes;
using Gigraph.Dot.Entities.Graphs;
using Gigraph.Dot.Entities.Nodes;
using Gigraph.Dot.Extensions;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Writers.Options;
using System;
using System.Drawing;

namespace Gigraph
{
    // TODO: przejrzec wszystkie metody, czy powinny lub nie powinny byc wirtualne
    // TODO: przejrzeć klasy, czy powinny miec interfejsy

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

            Console.WriteLine(graph.Build(fo, go));
            graph.SaveToFile(@"C:\Temp\gigraph.gv");

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
            }).Attributes.AddOrReplace(new DotTextLabelAttribute("label2"));

            graph.Nodes.Add(new DotNode("node 4"));
        }
    }
}
