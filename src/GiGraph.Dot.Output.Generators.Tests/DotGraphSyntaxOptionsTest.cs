using System.Drawing;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Output.Options;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Output.Generators.Tests
{
    public class DotGraphSyntaxOptionsTest
    {
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
        public void renders_graph_with_correct_hash_annotation()
        {
            var graph = DotGraphFactory.CreateAnnotatedGraph();

            var options = new DotSyntaxOptions
            {
                Comments =
                {
                    PreferHashForSingleLineComments = true
                }
            };

            var dot = graph.Build(syntaxOptions: options);
            Snapshot.Match(dot, "annotated_graph_hash_comments.gv");
        }

        [Fact]
        public void renders_graph_with_correctly_with_custom_attribute_options()
        {
            var graph = DotGraphFactory.CreateCompleteGraph(directed: true);

            var options = new DotSyntaxOptions
            {
                Attributes =
                {
                    PreferExplicitSeparator = false,
                    PreferQuotedKey = true,
                    PreferQuotedValue = true,
                    PreferGraphAttributesAsStatements = false
                }
            };

            var dot = graph.Build(syntaxOptions: options);
            Snapshot.Match(dot, "directed_graph_attributes_separator_quoted_key_quoted_value_graph_attributes_single_statement.gv");
        }

        [Fact]
        public void renders_graph_with_correctly_with_custom_cluster_id_separator()
        {
            var graph = new DotGraph();
            graph.Clusters.Add("id");

            var options = new DotSyntaxOptions
            {
                Clusters =
                {
                    ClusterIdSeparator = "__"
                }
            };

            var dot = graph.Build(syntaxOptions: options);
            Snapshot.Match(dot, "undirected_graph_custom_cluster_id_separator.gv");
        }

        [Fact]
        public void renders_graph_with_correctly_with_colors_as_hex()
        {
            var graph = new DotGraph();
            graph.Canvas.BackgroundColor = Color.Brown;

            var options = new DotSyntaxOptions
            {
                Colors =
                {
                    PreferName = false
                }
            };

            var dot = graph.Build(syntaxOptions: options);
            Snapshot.Match(dot, "graph_with_colors_as_hex.gv");
        }

        [Fact]
        public void renders_graph_with_explicitly_declared_subgraphs()
        {
            var graph = new DotGraph();
            graph.Subgraphs.Add();
            graph.Edges.AddOneToMany("a", "b", "c");

            var options = new DotSyntaxOptions
            {
                Subgraphs = { PreferExplicitDeclaration = true },
                Edges = { PreferExplicitSubgraphDeclaration = true }
            };

            var dot = graph.Build(syntaxOptions: options);
            Snapshot.Match(dot, "graph_with_explicitly_declared_subgraphs.gv");
        }

        [Fact]
        public void renders_graph_with_statement_delimiters()
        {
            var graph = DotGraphFactory.CreateCompleteGraph(directed: true);

            var options = new DotSyntaxOptions
            {
                PreferStatementDelimiter = true
            };

            var dot = graph.Build(syntaxOptions: options);
            Snapshot.Match(dot, "graph_with_statement_delimiters.gv");
        }
    }
}