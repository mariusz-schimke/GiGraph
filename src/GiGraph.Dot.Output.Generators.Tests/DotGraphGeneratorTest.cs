using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
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
        public void renders_empty_graph_in_expected_format()
        {
            var graph = new DotGraph();
            var dot = graph.Build();

            Snapshot.Match(dot, "empty_graph_default_options.gv");
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

        [Fact]
        public void renders_strict_directed_graph()
        {
            var graph = new DotGraph(strict: true);
            var dot = graph.Build();
            Snapshot.Match(dot, "strict_directed_graph.gv");
        }

        [Fact]
        public void renders_graph_with_html_attribute_value_in_angle_brackets()
        {
            var graph = new DotGraph();
            graph.Nodes.Attributes.Label = "<TABLE></TABLE>".AsHtml();

            var dot = graph.Build();
            Snapshot.Match(dot, "graph_with_html_attribute.gv");
        }

        [Fact]
        public void renders_graph_with_appropriately_escaped_identifiers()
        {
            var id = "a bcd \" \\ \r\n \r \n h ij < > { } | \\";
            var graph = new DotGraph(id);

            graph.Nodes.Add(id);
            graph.Edges.AddLoop(id);
            graph.Subgraphs.Add().Id = id;
            graph.Clusters.Add(id);

            var dot = graph.Build();
            Snapshot.Match(dot, "graph_with_escaped_identifiers.gv");
        }
    }
}