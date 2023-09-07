using System.Drawing;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Output.Options;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Output.Tests.EntityPadding;

public class DotNodeWithMultilineAttributesTest
{
    [Fact]
    public void single_node_has_no_padding_when_it_contains_multiline_attributes()
    {
        var graph = new DotGraph();

        graph.Nodes.Add(
            "node1",
            node => node.Font.Size = 10
        );

        var formatting = new DotFormattingOptions { Nodes = { SingleLineAttributeLists = false } };
        Snapshot.Match(graph.Build(formatting), "single_node_with_multiline_attributes_without_padding.gv");

        formatting.SingleLine = true;
        Snapshot.Match(graph.Build(formatting), "single_node_with_multiline_attributes_without_padding_single_line.gv");
    }

    [Fact]
    public void single_node_has_no_padding_when_it_contains_no_attributes()
    {
        var graph = new DotGraph();

        graph.Nodes.Add("node1");

        var formatting = new DotFormattingOptions { Nodes = { SingleLineAttributeLists = false } };
        Snapshot.Match(graph.Build(formatting), "single_node_without_attributes_without_padding.gv");

        formatting.SingleLine = true;
        Snapshot.Match(graph.Build(formatting), "single_node_without_attributes_without_padding_single_line.gv");
    }

    [Fact]
    public void nodes_have_no_padding_when_they_contain_no_attributes()
    {
        var graph = new DotGraph();

        graph.Nodes.Add("node1");
        graph.Nodes.Add("node2");

        var formatting = new DotFormattingOptions { Nodes = { SingleLineAttributeLists = false } };
        Snapshot.Match(graph.Build(formatting), "nodes_without_attributes_without_padding.gv");

        formatting.SingleLine = true;
        Snapshot.Match(graph.Build(formatting), "nodes_without_attributes_without_padding_single_line.gv");
    }

    [Fact]
    public void nodes_have_padding_when_they_contain_multiline_attributes()
    {
        var graph = new DotGraph();

        graph.Nodes.Add("node1").Color = Color.Red;
        graph.Nodes.Add("node2").Font.Size = 10;
        graph.Nodes.Add("node3").Font.Name = "arial";

        var formatting = new DotFormattingOptions { Nodes = { SingleLineAttributeLists = false } };
        Snapshot.Match(graph.Build(formatting), "nodes_with_attributes_with_padding.gv");

        formatting.SingleLine = true;
        Snapshot.Match(graph.Build(formatting), "nodes_with_attributes_with_padding_single_line.gv");
    }

    [Fact]
    public void first_node_has_bottom_padding_only_when_it_contain_multiline_attributes()
    {
        var graph = new DotGraph();

        graph.Nodes.Add("node1").Color = Color.Red;
        graph.Nodes.Add("node2");
        graph.Nodes.Add("node3");

        var formatting = new DotFormattingOptions { Nodes = { SingleLineAttributeLists = false } };
        Snapshot.Match(graph.Build(formatting), "node_with_attributes_with_bottom_padding.gv");

        formatting.SingleLine = true;
        Snapshot.Match(graph.Build(formatting), "node_with_attributes_with_bottom_padding_single_line.gv");
    }

    [Fact]
    public void last_node_has_bottom_padding_only_when_it_contain_multiline_attributes()
    {
        var graph = new DotGraph();

        graph.Nodes.Add("node1");
        graph.Nodes.Add("node2");
        graph.Nodes.Add("node3").Color = Color.Red;

        var formatting = new DotFormattingOptions { Nodes = { SingleLineAttributeLists = false } };
        Snapshot.Match(graph.Build(formatting), "node_with_attributes_with_top_padding.gv");

        formatting.SingleLine = true;
        Snapshot.Match(graph.Build(formatting), "node_with_attributes_with_top_padding_single_line.gv");
    }
}