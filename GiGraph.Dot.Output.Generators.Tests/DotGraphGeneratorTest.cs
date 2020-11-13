using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Output.Options;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Output.Generators.Tests
{
    public class DotGraphGeneratorTest
    {
        [Fact]
        public void graph_with_all_possible_elements_is_rendered_according_to_default_rules_and_options()
        {
            var graph = DotGraphFactory.CreateCompleteGraph(directed: true);
            var dot = graph.Build();

            Snapshot.Match(dot, "directed_graph_default_options.gv");
        }

        [Fact]
        public void graph_with_all_possible_elements_is_rendered_ordered_according_to_rules_and_options()
        {
            var graph = DotGraphFactory.CreateCompleteGraph(directed: true);

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
            var graph = DotGraphFactory.CreateCompleteGraph(directed: true);

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
            var graph = DotGraphFactory.CreateSectionedGraph(directed: true);

            var dot = graph.Build();
            Snapshot.Match(dot, "directed_sectioned_graph_default_options.gv");
        }

        [Fact]
        public void renders_graph_with_correct_default_format_annotation()
        {
            var graph = DotGraphFactory.CreateAnnotatedGraph();

            var dot = graph.Build();
            Snapshot.Match(dot, "annotated_graph_default_options.gv");
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
        public void renders_graph_with_correct_block_annotation()
        {
            var graph = DotGraphFactory.CreateAnnotatedGraph();

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