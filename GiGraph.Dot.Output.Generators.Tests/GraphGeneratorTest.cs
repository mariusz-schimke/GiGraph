using System.Drawing;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Edges.Enums;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Entities.Types.Styles;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Output.Options;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Output.Generators.Tests
{
    public class AttributeGeneratorsTest
    {
        private static DotGraph GetCompleteGraph(bool directed)
        {
            var graph = new DotGraph("graph1", directed);

            graph.Attributes.Comment = "graph_comment";
            graph.Clusters.Attributes.AllowEdgeClipping = true;
            graph.Clusters.Attributes.FillColor = Color.Brown;

            graph.Nodes.Attributes.Color = Color.Red;
            graph.Nodes.Attributes.Label = "node_label";

            graph.Edges.Attributes.Color = Color.Blue;
            graph.Edges.Attributes.Label = "edge_label";


            graph.Nodes.Add("node3", attrs =>
            {
                attrs.Shape = DotNodeShape.Assembly;
                attrs.Style.BorderWeight = DotBorderWeight.Bold;
            });

            graph.Nodes.Add(attrs =>
            {
                attrs.Shape = DotNodeShape.Box;
                attrs.Style.BorderWeight = DotBorderWeight.Bold;
                attrs.Style.BorderStyle = DotBorderStyle.Dashed;
            }, "node1", "node2");


            graph.Edges.Add("node6", "node7", edge =>
            {
                edge.Tail.Port.Name = "port6";
                edge.Tail.Port.CompassPoint = DotCompassPoint.East;

                edge.Attributes.Color = Color.Gold;
                edge.Attributes.Style.LineStyle = DotLineStyle.Dotted;
            });

            graph.Edges.AddSequence(edge =>
            {
                edge.Attributes.Constrain = true;
                edge.Attributes.Style.LineStyle = DotLineStyle.Solid;
            }, "node4", DotSubgraph.FromNodes("snode1", "snode2"), "node5");

            graph.Edges.AddSequence(edge =>
            {
                edge.Attributes.Color = Color.Beige;
                edge.Attributes.Style.Invisible = true;
            }, "node1", "node2", "node3");

            graph.Subgraphs.Add().Id = "Subgraph2";
            graph.Subgraphs.Add().Id = "Subgraph1";

            graph.Clusters.Add("Cluster2");
            graph.Clusters.Add("Cluster1");

            return graph;
        }

        private static DotGraph GetSectionedGraph(bool directed)
        {
            var graph = new DotGraph("graph1", directed);

            graph.Annotation = "graph comment";

            graph.Nodes.Attributes.Label = "node label";
            graph.Edges.Attributes.Label = "edge label";
            graph.Clusters.Attributes.AllowEdgeClipping = true;

            graph.Nodes.Add("node1");
            graph.Edges.Add("node1", "node2");

            graph.Subgraphs.Add(sg =>
            {
                sg.Annotation = "subgraph comment";
                sg.Attributes.Rank = DotRank.Min;

                sg.Subsections.Add(ss =>
                {
                    ss.Annotation = "subgraph subsection comment";
                    ss.Attributes.Rank = DotRank.Max;
                });
            });

            graph.Clusters.Add("cluster1", c =>
            {
                c.Annotation = "cluster comment";
                c.Attributes.Color = Color.Blue;

                c.Subsections.Add(ss =>
                {
                    ss.Annotation = "cluster subsection comment";
                    ss.Attributes.Color = Color.Magenta;
                });
            });

            return graph;
        }

        private static DotGraph GetAnnotatedGraph()
        {
            var graph = new DotGraph();

            // graph
            graph.Annotation = "graph";
            graph.Attributes.Annotation = "graph attributes";
            graph.Attributes.Set(a => a.Label, "Foo Graph").Annotation = "label";

            // node defaults
            graph.Nodes.Attributes.Annotation = "global node attributes";
            graph.Nodes.Attributes.Shape = DotNodeShape.Rectangle;

            // nodes
            graph.Nodes.Annotation = "nodes";
            graph.Nodes.Add("foo", attrs =>
            {
                attrs.Annotation = "node attributes";
                attrs.Set(a => a.Label, "foo").Annotation = "label";
            }).Annotation = "node comment";

            // edge defaults
            graph.Edges.Attributes.Annotation = "global edge attributes";
            graph.Edges.Attributes.Head.Arrowhead = DotArrowheadShape.Curve;

            // edges
            graph.Edges.Annotation = "edges";
            graph.Edges.Add("foo", "bar", edge =>
            {
                edge.Head.Annotation = "head";
                edge.Tail.Annotation = "tail";

                edge.Attributes.Annotation = "edge attributes";
                edge.Attributes.Set(a => a.Color, Color.Red).Annotation = "color";
            }).Annotation = "edge comment";

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

            return graph;
        }

        [Fact]
        public void graph_with_all_possible_elements_is_rendered_according_to_default_rules_and_options()
        {
            var graph = GetCompleteGraph(directed: true);
            var dot = graph.Build();

            Snapshot.Match(dot, "directed_graph_default_options.gv");
        }

        [Fact]
        public void graph_with_all_possible_elements_is_rendered_ordered_according_to_rules_and_options()
        {
            var graph = GetCompleteGraph(directed: true);

            var options = new DotSyntaxOptions
            {
                SortElements = true
            };
            var dot = graph.Build(syntaxOptions: options);

            Snapshot.Match(dot, "directed_graph_sorted.gv");
        }

        [Fact]
        public void graph_with_all_possible_elements_is_rendered_with_quoted_ids_based_on_options()
        {
            var graph = GetCompleteGraph(directed: true);

            var options = new DotSyntaxOptions
            {
                PreferQuotedIdentifiers = true
            };
            var dot = graph.Build(syntaxOptions: options);

            Snapshot.Match(dot, "directed_graph_quoted_identifiers.gv");
        }

        [Fact]
        public void renders_empty_graph_in_expected_format()
        {
            var graph = new DotGraph();
            var dot = graph.Build();

            Snapshot.Match(dot, "directed_empty_graph_default_options.gv");
        }

        [Fact]
        public void renders_empty_graph_in_expected_single_line_format()
        {
            var graph = new DotGraph();

            var options = new DotFormattingOptions
            {
                SingleLine = true
            };

            var dot = graph.Build(options);
            Snapshot.Match(dot, "directed_empty_graph_single_line.gv");
        }

        [Fact]
        public void renders_graph_subgraph_and_cluster_subsections()
        {
            var graph = GetSectionedGraph(directed: true);

            var dot = graph.Build();
            Snapshot.Match(dot, "directed_sectioned_graph_default_options.gv");
        }

        [Fact]
        public void renders_graph_with_correct_default_format_annotation()
        {
            var graph = GetAnnotatedGraph();

            var dot = graph.Build();
            Snapshot.Match(dot, "annotated_graph_default_options.gv");
        }

        [Fact]
        public void renders_single_line_graph_with_correct_default_format_annotation()
        {
            var graph = GetAnnotatedGraph();

            var options = new DotFormattingOptions
            {
                SingleLine = true
            };
            var dot = graph.Build(options);

            Snapshot.Match(dot, "annotated_graph_default_options_single_line.gv");
        }

        [Fact]
        public void renders_graph_with_correct_block_annotation()
        {
            var graph = GetAnnotatedGraph();

            var options = new DotSyntaxOptions
            {
                Comments =
                {
                    PreferBlockComments = true
                }
            };

            var dot = graph.Build(syntaxOptions: options);
            Snapshot.Match(dot, "annotated_graph_block_comments.gv");
        }

        [Fact]
        public void renders_directed_edges()
        {
            var graph = new DotGraph();
            graph.Edges.AddLoop("a");

            var dot = graph.Build();
            Snapshot.Match(dot, "directed_graph_edge.gv");
        }

        [Fact]
        public void renders_undirected_edges()
        {
            var graph = new DotGraph(directed: false);
            graph.Edges.AddLoop("a");

            var dot = graph.Build();
            Snapshot.Match(dot, "undirected_graph_edge.gv");
        }
    }
}