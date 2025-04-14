using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Output.Options;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Output.Tests;

public class DotGraphScriptTest
{
    [Fact]
    public void graph_with_all_possible_elements_is_rendered_according_to_default_rules_and_options()
    {
        var graph = DotGraphFactory.CreateCompleteGraph(directed: true);
        var dot = graph.ToDotString();

        Snapshot.Match(dot, "directed_graph_default_options.gv");
    }

    [Fact]
    public void renders_empty_graph_in_expected_format()
    {
        var graph = new DotGraph();
        var dot = graph.ToDotString();

        Snapshot.Match(dot, "empty_graph_default_options.gv");
    }

    [Fact]
    public void renders_graph_subgraph_and_cluster_subsections()
    {
        var graph = DotGraphFactory.CreateSectionedGraph(directed: true);

        var dot = graph.ToDotString();
        Snapshot.Match(dot, "directed_sectioned_graph_default_options.gv");
    }

    [Fact]
    public void renders_graph_with_correct_default_format_annotation()
    {
        var graph = DotGraphFactory.CreateAnnotatedGraph();

        var dot = graph.ToDotString();
        Snapshot.Match(dot, "annotated_graph_default_options.gv");
    }

    [Fact]
    public void renders_graph_with_correct_annotation_and_multiline_attributes()
    {
        var graph = DotGraphFactory.CreateAnnotatedGraph();

        var formatting = new DotFormattingOptions
        {
            GlobalAttributes = { SingleLineAttributeLists = false },
            Nodes = { SingleLineAttributeLists = false },
            Edges = { SingleLineAttributeLists = false }
        };

        var syntax = new DotSyntaxOptions
        {
            Graph = { AttributesAsStatements = false }
        };

        Snapshot.Match(graph.ToDotString(formatting, syntax), "annotated_graph_multiline_attributes.gv");
    }

    [Fact]
    public void renders_directed_edges()
    {
        var graph = new DotGraph();
        graph.Edges.AddLoop("a");

        var dot = graph.ToDotString();
        Snapshot.Match(dot, "directed_graph_edge.gv");
    }

    [Fact]
    public void renders_undirected_edges()
    {
        var graph = new DotGraph(directed: false);
        graph.Edges.AddLoop("a");

        var dot = graph.ToDotString();
        Snapshot.Match(dot, "undirected_graph_edge.gv");
    }

    [Fact]
    public void renders_strict_directed_graph()
    {
        var graph = new DotGraph(strict: true);
        var dot = graph.ToDotString();
        Snapshot.Match(dot, "strict_directed_graph.gv");
    }

    [Fact]
    public void renders_graph_with_html_attribute_value_in_angle_brackets()
    {
        var graph = new DotGraph
        {
            Nodes =
            {
                Label = "<TABLE></TABLE>".AsHtml()
            }
        };

        var dot = graph.ToDotString();
        Snapshot.Match(dot, "graph_with_html_attribute.gv");
    }

    [Fact]
    public void renders_graph_with_appropriately_escaped_identifiers()
    {
        const string id = "a bcd \" \\ \r\n \r \n h ij < > { } | \\";
        var graph = new DotGraph(id);

        graph.Nodes.Add(id);
        graph.Edges.AddLoop(id);
        graph.Subgraphs.Add().Id = id;
        graph.Clusters.Add(id);

        var dot = graph.ToDotString();
        Snapshot.Match(dot, "graph_with_escaped_identifiers.gv");
    }
}