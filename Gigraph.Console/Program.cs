using Gigraph.Dot.Entities.Attributes;
using Gigraph.Dot.Entities.Graphs;
using Gigraph.Dot.Entities.Nodes;
using Gigraph.Dot.Entities.Subgraphs;
using Gigraph.Dot.Extensions;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Writers.Options;
using System;
using System.Drawing;

namespace Gigraph
{
    // TODO: przejrzec wszystkie metody, czy powinny lub nie powinny byc wirtualne
    // TODO: przejrzeć klasy, czy powinny miec interfejsy
    // TODO: "node [style=filled];" - obsłużyć domyślne style węzłów i krawędzi

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
            AddSubgraphs(graph);

            Console.WriteLine(graph.Build(fo, go));
            graph.SaveToFile(@"C:\Temp\gigraph.gv");

            Console.ReadLine();
        }

        private static void AddAttributes(DotGraph graph)
        {
            graph.Label = "My graph";
            graph.Color = Color.Black;
            graph.BackgroundColor = Color.BlueViolet;

            graph.Attributes.Set("shape", "star");
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
            })
            .Attributes.Set("color", "red");

            graph.Nodes.Add(new DotNode("node 4"));
        }

        private static void AddEdges(DotGraph graph)
        {
            graph.Edges.Add("node1", "node2");
        }

        private static void AddSubgraphs(DotGraph graph)
        {
            var subgraph1 = new DotSubgraph(isCluster: false);
            var subgraph2 = new DotSubgraph("sg2", isCluster: false);
            subgraph1.Subgraphs.Add(subgraph2);

            var cluster1 = new DotSubgraph();
            var cluster2 = new DotSubgraph("sgc2");
            cluster1.Subgraphs.Add(cluster2);

            foreach (var attr in graph.Attributes)
            {
                cluster2.Attributes.Set(attr);
            }

            foreach (var node in graph.Nodes)
            {
                cluster2.Nodes.Add(node);
            }

            graph.Subgraphs.Add(subgraph1);
            //graph.Subgraphs.Add(subgraph2);
            graph.Subgraphs.Add(cluster1);
            //graph.Subgraphs.Add(cluster2);
        }
    }
}
