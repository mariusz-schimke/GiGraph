using System;
using System.Drawing;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Types.Arrowheads;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.Nodes;
using GiGraph.Dot.Types.Ranks;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Output.Tests
{
    public class DotGraphFactory
    {
        public static DotGraph CreateCompleteGraph(bool directed)
        {
            var graph = new DotGraph("graph1", directed);

            graph.Comment = "graph_comment";
            graph.Clusters.AllowEdgeClipping = true;
            graph.Clusters.FillColor = Color.Brown;


            graph.Subgraphs.Add("Subgraph2", sg =>
            {
                sg.NodeRank = DotRank.Max;

                sg.Nodes.Color = Color.Chartreuse;
                sg.Nodes.Label = "nodes_label";

                sg.Edges.Color = Color.Chocolate;
                sg.Edges.Label = "edges_label";
            });

            graph.Subgraphs.Add("Subgraph1");


            graph.Clusters.Add("Cluster2", cluster =>
            {
                cluster.Label = "cluster label";
                cluster.Padding = 10;

                cluster.Nodes.Color = Color.Chartreuse;
                cluster.Nodes.Label = "nodes label";

                cluster.Edges.Color = Color.Chocolate;
                cluster.Edges.Label = "edges label";
            });

            graph.Clusters.Add("Cluster1");


            graph.Nodes.Color = Color.Red;
            graph.Nodes.Label = "node_label";

            graph.Edges.Color = Color.Blue;
            graph.Edges.Label = "edge_label";

            graph.Nodes.Add("no_attributes");
            graph.Nodes.Add("node3", node =>
            {
                node.Shape = DotNodeShape.Assembly;
                node.Style.BorderWeight = DotBorderWeight.Bold;
            });

            graph.Nodes.AddGroup(nodeGroup =>
            {
                nodeGroup.Shape = DotNodeShape.Box;
                nodeGroup.Style.BorderWeight = DotBorderWeight.Bold;
                nodeGroup.Style.BorderStyle = DotBorderStyle.Dashed;
            }, "node1", "node2");

            graph.Edges.AddLoop("no_attributes");
            graph.Edges.Add("node6", "node7", edge =>
            {
                edge.Tail.Endpoint.Port = new DotEndpointPort("port6", DotCompassPoint.East);
                edge.Color = Color.Gold;
                edge.Style.LineStyle = DotLineStyle.Dotted;
            });

            graph.Edges.AddSequence(edge =>
            {
                edge.Constrain = true;
                edge.Style.LineStyle = DotLineStyle.Solid;
            }, "node4", DotSubgraph.FromNodes("snode1", "snode2"), "node5");

            graph.Edges.AddSequence(edge =>
            {
                edge.Color = Color.Beige;
                edge.Style.Invisible = true;
            }, "node1", "node2", "node3");

            graph.Edges.Add(
                new DotEndpointGroup(
                    new DotEndpoint("node1"),
                    new DotClusterEndpoint("cluster1"),
                    new DotClusterEndpoint(null)
                ),
                new DotSubgraphEndpoint("node3", "node4")
            );

            return graph;
        }

        public static DotGraph CreateSectionedGraph(bool directed)
        {
            var graph = new DotGraph("graph1", directed);

            graph.Annotation = "graph comment";

            graph.Nodes.Label = "node label";
            graph.Edges.Label = "edge label";
            graph.Clusters.AllowEdgeClipping = true;

            graph.Nodes.Add("node1");
            graph.Edges.Add("node1", "node2");

            graph.Subgraphs.Add(sg =>
            {
                sg.Annotation = "subgraph comment";
                sg.NodeRank = DotRank.Min;

                sg.Subsections.Add(ss =>
                {
                    ss.Annotation = "subgraph subsection comment";
                    ss.NodeRank = DotRank.Max;
                });
            });

            graph.Clusters.Add("cluster1", c =>
            {
                c.Annotation = "cluster comment";
                c.Color = Color.Blue;

                c.Subsections.Add(ss =>
                {
                    ss.Annotation = "cluster subsection comment";
                    ss.Color = Color.Magenta;
                });
            });

            graph.Subsections.Add(ss =>
            {
                ss.Annotation = "graph section comment";
                ss.Canvas.BackgroundColor = Color.Blue;
                ss.Nodes.Add("section 1 node");
                ss.Edges.AddLoop("section 1 node");
            });

            return graph;
        }

        public static DotGraph CreateAnnotatedGraph()
        {
            var graph = new DotGraph();

            // graph
            graph.Annotation = $"graph{Environment.NewLine}comment";
            graph.Attributes.Annotation = $"graph attributes{Environment.NewLine}comment";
            graph.Attributes.SetValue(a => a.Label, "Foo Graph").Annotation = "label";
            graph.Attributes.SetValue(a => a.Comment, "comment").Annotation = "comment";

            // node defaults
            graph.Nodes.Attributes.Annotation = "global node attributes";
            graph.Nodes.Shape = DotNodeShape.Rectangle;
            graph.Nodes.Geometry.Distortion = 2;

            // nodes
            graph.Nodes.Annotation = "nodes";
            graph.Nodes.Add("foo", node =>
            {
                node.Annotation = "node comment";
                node.Attributes.Annotation = "node attributes";
                node.Attributes.SetValue(a => a.Label, "foo").Annotation = "label";
            });

            graph.Nodes.AddGroup(new[] { "foo", "bar", "baz" }, node =>
            {
                node.Annotation = "node group comment";
                node.Attributes.Annotation = "node group attributes";
                node.Attributes.SetValue(a => a.Label, "foo").Annotation = "label";
            });

            // edge defaults
            graph.Edges.Attributes.Annotation = "global edge attributes";
            graph.Edges.Head.Arrowhead = DotArrowheadShape.Curve;

            // edges
            graph.Edges.Annotation = "edges";
            graph.Edges.Add("foo", "bar", edge =>
            {
                edge.Annotation = "edge comment";

                edge.Head.Endpoint.Annotation = "head";
                edge.Tail.Endpoint.Annotation = "tail";

                edge.Attributes.Annotation = "edge attributes";
                edge.Attributes.Set(a => a.Color, Color.Red).Annotation = "color";
            });

            graph.Edges.AddSequence(new[] { "foo", "bar", "baz" }, edge =>
            {
                var i = 1;
                foreach (var endpoint in edge.Endpoints)
                {
                    endpoint.Annotation = $"endpoint {i++}";
                }

                edge.Annotation = "edge sequence comment";
                edge.Attributes.Annotation = "edge sequence attributes";
                edge.Attributes.Set(a => a.Color, Color.Red).Annotation = "color";
            });

            // endpoint groups / endpoint subgraphs / clusters as endpoints
            var endpointGroup = new DotEndpointGroup(
                new DotEndpoint("node1"),
                new DotClusterEndpoint("cluster1")
            );
            endpointGroup.Endpoints[0].Annotation = "node1";
            endpointGroup.Endpoints[1].Annotation = "cluster1";

            graph.Edges.Add(
                endpointGroup,
                new DotSubgraphEndpoint("node3", "node4"),
                edge =>
                {
                    edge.Annotation = "edge comment";
                    edge.Head.Endpoint.Annotation = "head subgraph endpoint";
                    edge.Tail.Endpoint.Annotation = "tail endpoint group";
                }
            );

            // subsections
            graph.Subsections.Add(sub =>
            {
                sub.Annotation = "subsection 1";

                // clusters
                sub.Clusters.Annotation = "clusters";
                sub.Clusters.Add("cluster 1").Annotation = "cluster";

                // subgraphs
                sub.Subgraphs.Annotation = "subgraphs";
                sub.Subgraphs.Add().Annotation = "subgraph";
            });

            graph.Subsections.Add(sub =>
            {
                sub.Annotation = string.Empty;
            });

            return graph;
        }
    }
}