using System.Drawing;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Output.Options;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Output.Tests.EntityPadding;

public class DotGraphWithMultilineGlobalAttributesTest
{
    [Fact]
    public void renders_graph_with_multiline_global_graph_attribute_list()
    {
        var graph = CreateGraph();

        var formatting = new DotFormattingOptions
        {
            GlobalAttributes = { SingleLineGraphAttributeList = false }
        };

        var syntax = new DotSyntaxOptions
        {
            Graph = { AttributesAsStatements = false }
        };

        Snapshot.Match(graph.ToDot(formatting, syntax), "graph_with_multiline_global_graph_attribute_list.gv");

        formatting.SingleLine = true;
        Snapshot.Match(graph.ToDot(formatting, syntax), "graph_with_multiline_global_graph_attribute_list_single_line.gv");
    }

    [Fact]
    public void renders_graph_with_single_line_global_graph_attribute_list()
    {
        var graph = CreateGraph();

        var formatting = new DotFormattingOptions
        {
            GlobalAttributes = { SingleLineGraphAttributeList = true }
        };

        var syntax = new DotSyntaxOptions
        {
            Graph = { AttributesAsStatements = false }
        };

        Snapshot.Match(graph.ToDot(formatting, syntax), "graph_with_single_line_global_graph_attribute_list.gv");

        formatting.SingleLine = true;
        Snapshot.Match(graph.ToDot(formatting, syntax), "graph_with_single_line_global_graph_attribute_list_single_line.gv");
    }

    [Fact]
    public void renders_graph_with_multiline_global_node_attribute_list()
    {
        var graph = CreateGraph();

        var formatting = new DotFormattingOptions
        {
            GlobalAttributes = { SingleLineNodeAttributeList = false }
        };

        var syntax = new DotSyntaxOptions
        {
            Graph = { AttributesAsStatements = false }
        };

        Snapshot.Match(graph.ToDot(formatting, syntax), "graph_with_multiline_global_node_attribute_list.gv");

        formatting.SingleLine = true;
        Snapshot.Match(graph.ToDot(formatting, syntax), "graph_with_multiline_global_node_attribute_list_single_line.gv");
    }

    [Fact]
    public void renders_graph_with_multiline_global_edge_attribute_list()
    {
        var graph = CreateGraph();

        var formatting = new DotFormattingOptions
        {
            GlobalAttributes = { SingleLineEdgeAttributeList = false }
        };

        var syntax = new DotSyntaxOptions
        {
            Graph = { AttributesAsStatements = false }
        };

        Snapshot.Match(graph.ToDot(formatting, syntax), "graph_with_multiline_global_edge_attribute_list.gv");

        formatting.SingleLine = true;
        Snapshot.Match(graph.ToDot(formatting, syntax), "graph_with_multiline_global_edge_attribute_list_single_line.gv");
    }

    [Fact]
    public void renders_graph_with_multiline_global_attribute_lists()
    {
        var graph = CreateGraph();

        var formatting = new DotFormattingOptions
        {
            GlobalAttributes = { SingleLineAttributeLists = false }
        };

        var syntax = new DotSyntaxOptions
        {
            Graph = { AttributesAsStatements = false }
        };

        Snapshot.Match(graph.ToDot(formatting, syntax), "graph_with_multiline_global_attribute_lists.gv");

        formatting.SingleLine = true;
        Snapshot.Match(graph.ToDot(formatting, syntax), "graph_with_multiline_global_attribute_lists_single_line.gv");
    }

    private static DotGraph CreateGraph()
    {
        var graph = new DotGraph();
        graph.Font.Set("arial", 10, Color.Red);
        graph.Nodes.Font.Set("arial", 10, Color.Red);
        graph.Edges.Font.Set("arial", 10, Color.Red);
        return graph;
    }
}