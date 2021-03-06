using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Output.Options;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Output.Generators.Tests
{
    public class DotGraphFormattingOptionsTest
    {
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
        public void renders_single_line_graph_with_correct_default_format_annotation()
        {
            var graph = DotGraphFactory.CreateAnnotatedGraph();

            var options = new DotFormattingOptions
            {
                SingleLine = true
            };

            var dot = graph.Build(options);
            Snapshot.Match(dot, "annotated_graph_default_options_single_line.gv");
        }

        [Fact]
        public void renders_graph_with_custom_indentation_and_line_break()
        {
            var graph = DotGraphFactory.CreateAnnotatedGraph();
            graph.Id = "graph1";

            var options = new DotFormattingOptions
            {
                IndentationChar = '\t',
                IndentationSize = 2,
                IndentationLevel = 1,
                LineBreak = "\n"
            };

            var dot = graph.Build(options);
            Snapshot.Match(dot, "graph_with_custom_indentation_and_line_break.gv");
        }

        [Fact]
        public void renders_graph_with_single_line_clusters()
        {
            var graph = new DotGraph();

            graph.Clusters.Add("cluster1", x =>
            {
                x.Attributes.ObjectId = "id";
                x.Nodes.Add("node").Attributes.Comment = "comment";
                x.Edges.AddLoop("node").Attributes.Directions = DotEdgeDirections.Backward;
            });

            var options = new DotFormattingOptions
            {
                Clusters =
                {
                    SingleLine = true
                }
            };

            var dot = graph.Build(options);
            Snapshot.Match(dot, "graph_with_single_line_clusters.gv");
        }

        [Fact]
        public void renders_graph_with_multiline_global_graph_attribute_list()
        {
            var graph = DotGraphFactory.CreateAnnotatedGraph();

            var formatting = new DotFormattingOptions
            {
                GlobalAttributes = { SingleLineAttributeLists = false }
            };

            var syntax = new DotSyntaxOptions
            {
                Attributes = { PreferGraphAttributesAsStatements = false }
            };

            var dot = graph.Build(formatting, syntax);
            Snapshot.Match(dot, "graph_with_multiline_global_graph_attribute_list.gv");
        }

        [Fact]
        public void renders_graph_with_multiline_global_node_attribute_list()
        {
            var graph = DotGraphFactory.CreateAnnotatedGraph();

            var options = new DotFormattingOptions
            {
                GlobalAttributes = { SingleLineNodeAttributeList = false }
            };

            var dot = graph.Build(options);
            Snapshot.Match(dot, "graph_with_multiline_global_node_attribute_list.gv");
        }

        [Fact]
        public void renders_graph_with_multiline_node_attribute_list()
        {
            var graph = DotGraphFactory.CreateAnnotatedGraph();

            var options = new DotFormattingOptions
            {
                Nodes = { SingleLineAttributeLists = false }
            };

            var dot = graph.Build(options);
            Snapshot.Match(dot, "graph_with_multiline_node_attribute_list.gv");
        }

        [Fact]
        public void renders_graph_with_multiline_global_edge_attribute_list()
        {
            var graph = DotGraphFactory.CreateAnnotatedGraph();

            var options = new DotFormattingOptions
            {
                GlobalAttributes = { SingleLineEdgeAttributeList = false }
            };

            var dot = graph.Build(options);
            Snapshot.Match(dot, "graph_with_multiline_global_edge_attribute_list.gv");
        }

        [Fact]
        public void renders_graph_with_multiline_edge_attribute_list()
        {
            var graph = DotGraphFactory.CreateAnnotatedGraph();

            var options = new DotFormattingOptions
            {
                Edges = { SingleLineAttributeLists = false }
            };

            var dot = graph.Build(options);
            Snapshot.Match(dot, "graph_with_multiline_edge_attribute_list.gv");
        }

        [Fact]
        public void renders_graph_with_multiline_global_attribute_lists()
        {
            var graph = DotGraphFactory.CreateAnnotatedGraph();

            var formatting = new DotFormattingOptions
            {
                GlobalAttributes = { SingleLineAttributeLists = false }
            };

            var syntax = new DotSyntaxOptions
            {
                Attributes = { PreferGraphAttributesAsStatements = false }
            };

            var dot = graph.Build(formatting, syntax);
            Snapshot.Match(dot, "graph_with_multiline_global_attribute_lists.gv");
        }

        [Fact]
        public void renders_graph_with_single_line_subgraphs()
        {
            var graph = new DotGraph();

            graph.Subgraphs.Add(DotRank.Max, x =>
            {
                x.Nodes.Add("node").Attributes.Comment = "comment";
                x.Edges.AddLoop("node").Attributes.Directions = DotEdgeDirections.Backward;
            });

            var options = new DotFormattingOptions
            {
                Subgraphs =
                {
                    SingleLine = true
                }
            };

            var dot = graph.Build(options);
            Snapshot.Match(dot, "graph_with_single_line_subgraphs.gv");
        }

        [Fact]
        public void renders_graph_with_multiline_edge_subgraphs()
        {
            var graph = new DotGraph();

            graph.Edges.AddOneToMany("a", "b", "c");
            graph.Edges.AddOneToMany("d", "e", "f").Head.Subgraph.Id = "subgraph1";

            graph.Edges.AddManyToMany(new[] { "g", "h" }, new[] { "i", "j" }, e =>
            {
                e.Head.Subgraph.Id = "head";
                e.Tail.Subgraph.Id = "tail";
            });

            graph.Edges.AddManyToMany(new[] { "k", "l" }, new[] { "m", "n" }, e =>
            {
                e.Head.Annotation = "head subgraph comment";
                e.Tail.Annotation = "tail subgraph comment";

                e.Head.Subgraph.Id = "head";
                e.Tail.Subgraph.Id = "tail";
            });

            graph.Edges.AddManyToMany(new[] { "o", "p" }, "q", "r");

            var options = new DotFormattingOptions
            {
                Edges =
                {
                    SingleLineSubgraphs = false
                }
            };

            var dot = graph.Build(options);
            Snapshot.Match(dot, "graph_with_multiline_edge_subgraphs.gv");
        }

        [Fact]
        public void renders_graph_with_custom_text_encoder()
        {
            var graph = DotGraphFactory.CreateAnnotatedGraph();
            graph.Id = "graph1";

            var options = new DotFormattingOptions
            {
                TextEncoder = (value, token) => value.ToUpper()
            };

            var dot = graph.Build(options);
            Snapshot.Match(dot, "graph_with_custom_text_encoder.gv");

            options.TextEncoder = (s, type) => $"{type}\n";
            dot = graph.Build(options);
            Snapshot.Match(dot, "graph_with_custom_text_encoder_tokens.gv");
        }
    }
}