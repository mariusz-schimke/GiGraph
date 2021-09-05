using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Output.Options;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Output.Tests.EntityPadding
{
    public class DotEdgeWithMultilineAttributesTest
    {
        [Fact]
        public void single_edge_has_no_padding_when_it_contains_multiline_attributes()
        {
            var graph = new DotGraph();

            graph.Edges.AddLoop(
                "node1",
                edge => edge.Font.Size = 10
            );

            var formatting = new DotFormattingOptions { Edges = { SingleLineAttributeLists = false } };
            Snapshot.Match(graph.Build(formatting), "single_edge_with_multiline_attributes_without_padding.gv");

            formatting.SingleLine = true;
            Snapshot.Match(graph.Build(formatting), "single_edge_with_multiline_attributes_without_padding_single_line.gv");
        }

        [Fact]
        public void single_edge_has_no_padding_when_it_contains_no_attributes()
        {
            var graph = new DotGraph();

            graph.Edges.AddLoop("node1");

            var formatting = new DotFormattingOptions { Edges = { SingleLineAttributeLists = false } };
            Snapshot.Match(graph.Build(formatting), "single_edge_without_attributes_without_padding.gv");

            formatting.SingleLine = true;
            Snapshot.Match(graph.Build(formatting), "single_edge_without_attributes_without_padding_single_line.gv");
        }

        [Fact]
        public void edges_have_no_padding_when_they_contain_no_attributes()
        {
            var graph = new DotGraph();

            graph.Edges.AddLoop("node1");
            graph.Edges.AddLoop("node2");

            var formatting = new DotFormattingOptions { Edges = { SingleLineAttributeLists = false } };
            Snapshot.Match(graph.Build(formatting), "edges_without_attributes_without_padding.gv");

            formatting.SingleLine = true;
            Snapshot.Match(graph.Build(formatting), "edges_without_attributes_without_padding_single_line.gv");
        }
    }
}