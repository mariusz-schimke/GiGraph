using Gigraph.Dot.Entities.Attributes.LabelAttributes;
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
    // TODO: customowe węzły HTML (shape none, margin 0): https://www.graphviz.org/doc/info/shapes.html#polygon

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
            graph.Attributes.Label = "My graph";
            graph.Attributes.BackgroundColor = Color.BlueViolet;

            graph.Attributes.Set("shape", "star");
        }

        private static void AddNodes(DotGraph graph)
        {
            graph.Nodes.Add("node1", n =>
            {
                n.Attributes.Label = "my label";
            });

            //graph.Nodes.Add(new DotNode("node2")
            //{
            //    Label = new DotHtmlLabel("<b>text</b>")
            //});

            graph.Nodes.Add("node3", n =>
            {
                n.Attributes.Label = new DotTextLabelAttribute("label");
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
            var subgraph1 = new DotSubgraph();
            var subgraph2 = new DotSubgraph("sg2");
            subgraph1.Subgraphs.Add(subgraph2);

            var cluster1 = new DotCluster();
            var cluster2 = new DotCluster("sgc2");
            cluster1.Clusters.Add(cluster2);

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
            graph.Clusters.Add(cluster1);
            //graph.Subgraphs.Add(cluster2);
        }
    }
}
