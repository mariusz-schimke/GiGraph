using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Generators.Options;
using GiGraph.Dot.Writers.Options;
using System;
using System.Drawing;

namespace GiGraph
{
    // TODO: przejrzec wszystkie metody, czy powinny lub nie powinny byc wirtualne
    // TODO: przejrzeć klasy, czy powinny miec interfejsy
    // TODO: customowe węzły HTML (shape none, margin 0): https://www.graphviz.org/doc/info/shapes.html#polygon
    // TODO: atrybuty można określic też raz dla wielu elementów, np. myNode1, myNode2, myNode3 [shape="box", style="filled, rounded"]

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
                // PreferQuotedIdentifiers = true
            };
            //go.Subgraphs.PreferExplicitKeyword = true;

            var graph = new DotGraph()
            {
                IsStrict = true,
                IsDirected = true,
                Id = "Graph1"
            };

            graph.Attributes.Layout = DotRankDirection.LeftToRight;

            AddAttributes(graph);
            AddNodeDefaults(graph);
            AddEdgeDefaults(graph);
            AddNodes(graph);
            AddEdges(graph);
            AddSubgraphs(graph);
            AddClusters(graph);

            Console.WriteLine(graph.Build(fo, go));
            graph.SaveToFile(@"C:\Temp\gigraph.gv", fo, go);

            Console.ReadLine();
        }

        private static void AddAttributes(DotGraph graph)
        {
            graph.Attributes.LabelHtml = "My graph";
            graph.Attributes.BackgroundColor = Color.BlueViolet;

            graph.Attributes.Set("shape", "rect");
        }

        private static void AddNodeDefaults(DotGraph graph)
        {
            graph.NodeDefaults.Color = Color.Red;
            graph.NodeDefaults.Style = DotStyle.Bold | DotStyle.Dotted;
        }

        private static void AddEdgeDefaults(DotGraph graph)
        {
            graph.EdgeDefaults.Color = Color.Green;
            graph.EdgeDefaults.ArrowHead = DotArrowType.Tee;
            graph.EdgeDefaults.ArrowTail = DotArrowType.Diamond;
            graph.EdgeDefaults.ArrowSize = 0.9;
            graph.EdgeDefaults.ArrowDirection = DotArrowDirection.Backward;
            graph.EdgeDefaults.Decorate = true;
        }

        private static void AddNodes(DotGraph graph)
        {
            var node1 = graph.Nodes.Add("node1", n =>
            {
                n.Attributes.Label = "my label";
                n.Attributes.Shape = DotShape.Hexagon;
                n.Attributes.Style = DotStyle.Default;
            });

            //graph.Nodes.Add(new DotNode("node2")
            //{
            //    Label = new DotHtmlLabel("<b>text</b>")
            //});

            graph.Nodes.Add("node3", n =>
            {
                n.Attributes.Label = "some label";
            })
            .Attributes.Set("color", "red");

            graph.Nodes.Add(new DotNode("node 4"));
        }

        private static void AddEdges(DotGraph graph)
        {
            var edge1 = graph.Edges.Add("node1", "node2",
                e => e.Attributes.Label = "edge label");
        }

        private static void AddSubgraphs(DotGraph graph)
        {
            var subgraph1 = new DotSubgraph("");
            var subgraph2 = new DotSubgraph(rank: DotRank.Same);
            subgraph1.Subgraphs.Add(subgraph2);

            subgraph2.Nodes.Add(n => n.Attributes.Color = Color.Red, "snode1", "snode2");

            subgraph1.Edges.Add("snode1", "snode2");

            graph.Subgraphs.Add(subgraph1);
        }

        private static void AddClusters(DotGraph graph)
        {
            var cluster1 = new DotCluster();
            var cluster2 = new DotCluster("sgc2");
            cluster1.Subgraphs.Add(cluster2);

            graph.Subgraphs.Add(cluster1);
        }
    }
}
