using System.Drawing;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Output.Options;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Output.Tests.EntityPadding;

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
        Snapshot.Match(graph.ToDot(formatting), "single_edge_with_multiline_attributes_without_padding.gv");

        formatting.SingleLine = true;
        Snapshot.Match(graph.ToDot(formatting), "single_edge_with_multiline_attributes_without_padding_single_line.gv");
    }

    [Fact]
    public void single_edge_has_no_padding_when_it_contains_no_attributes()
    {
        var graph = new DotGraph();

        graph.Edges.AddLoop("node1");

        var formatting = new DotFormattingOptions { Edges = { SingleLineAttributeLists = false } };
        Snapshot.Match(graph.ToDot(formatting), "single_edge_without_attributes_without_padding.gv");

        formatting.SingleLine = true;
        Snapshot.Match(graph.ToDot(formatting), "single_edge_without_attributes_without_padding_single_line.gv");
    }

    [Fact]
    public void edges_have_no_padding_when_they_contain_no_attributes()
    {
        var graph = new DotGraph();

        graph.Edges.AddLoop("node1");
        graph.Edges.AddLoop("node2");

        var formatting = new DotFormattingOptions { Edges = { SingleLineAttributeLists = false } };
        Snapshot.Match(graph.ToDot(formatting), "edges_without_attributes_without_padding.gv");

        formatting.SingleLine = true;
        Snapshot.Match(graph.ToDot(formatting), "edges_without_attributes_without_padding_single_line.gv");
    }

    [Fact]
    public void edges_have_padding_when_they_contain_multiline_attributes()
    {
        var graph = new DotGraph();

        graph.Edges.AddLoop("node1").Style.LineColor = Color.Red;
        graph.Edges.AddLoop("node2").Font.Size = 10;
        graph.Edges.AddLoop("node3").Font.Name = "arial";

        var formatting = new DotFormattingOptions { Edges = { SingleLineAttributeLists = false } };
        Snapshot.Match(graph.ToDot(formatting), "edges_with_attributes_with_padding.gv");

        formatting.SingleLine = true;
        Snapshot.Match(graph.ToDot(formatting), "edges_with_attributes_with_padding_single_line.gv");
    }

    [Fact]
    public void first_edge_has_bottom_padding_only_when_it_contain_multiline_attributes()
    {
        var graph = new DotGraph();

        graph.Edges.AddLoop("node1").Style.LineColor = Color.Red;
        graph.Edges.AddLoop("node2");
        graph.Edges.AddLoop("node3");

        var formatting = new DotFormattingOptions { Edges = { SingleLineAttributeLists = false } };
        Snapshot.Match(graph.ToDot(formatting), "edge_with_attributes_with_bottom_padding.gv");

        formatting.SingleLine = true;
        Snapshot.Match(graph.ToDot(formatting), "edge_with_attributes_with_bottom_padding_single_line.gv");
    }

    [Fact]
    public void last_edge_has_bottom_padding_only_when_it_contain_multiline_attributes()
    {
        var graph = new DotGraph();

        graph.Edges.AddLoop("node1");
        graph.Edges.AddLoop("node2");
        graph.Edges.AddLoop("node3").Style.LineColor = Color.Red;

        var formatting = new DotFormattingOptions { Edges = { SingleLineAttributeLists = false } };
        Snapshot.Match(graph.ToDot(formatting), "edge_with_attributes_with_top_padding.gv");

        formatting.SingleLine = true;
        Snapshot.Match(graph.ToDot(formatting), "edge_with_attributes_with_top_padding_single_line.gv");
    }
}