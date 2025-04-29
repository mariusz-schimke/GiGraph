using System.Drawing;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.Graphs.Layout.Spacing;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Output.Tests;

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

        var dot = graph.ToDot(options);
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

        var dot = graph.ToDot(options);
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

        var dot = graph.ToDot(options);
        Snapshot.Match(dot, "graph_with_custom_indentation_and_line_break.gv");
    }

    [Fact]
    public void renders_graph_with_single_line_clusters()
    {
        var graph = new DotGraph();

        graph.Clusters.Add("cluster1", x =>
        {
            x.ObjectId = "id";
            x.Nodes.Add("node").Comment = "comment";
            x.Edges.AddLoop("node").Directions = DotEdgeDirections.Backward;
        });

        var options = new DotFormattingOptions
        {
            Clusters =
            {
                SingleLine = true
            }
        };

        var dot = graph.ToDot(options);
        Snapshot.Match(dot, "graph_with_single_line_clusters.gv");
    }

    [Fact]
    public void renders_graph_with_single_line_subgraphs()
    {
        var graph = new DotGraph();

        graph.Subgraphs.Add(DotRank.Max, x =>
        {
            x.Nodes.Add("node").Comment = "comment";
            x.Edges.AddLoop("node").Directions = DotEdgeDirections.Backward;
        });

        var options = new DotFormattingOptions
        {
            Subgraphs =
            {
                SingleLine = true
            }
        };

        var dot = graph.ToDot(options);
        Snapshot.Match(dot, "graph_with_single_line_subgraphs.gv");
    }

    [Fact]
    public void renders_graph_with_multiline_edge_subgraphs()
    {
        var graph = CreateGraphWithMultilineEdgeSubgraphs();

        var options = new DotFormattingOptions
        {
            Edges =
            {
                SingleLineSubgraphs = false
            }
        };

        var dot = graph.ToDot(options);
        Snapshot.Match(dot, "graph_with_multiline_edge_subgraphs.gv");
    }

    [Fact]
    public void renders_graph_with_multiline_edge_subgraphs_and_attributes()
    {
        var graph = CreateGraphWithMultilineEdgeSubgraphs();

        foreach (var edge in graph.Edges)
        {
            edge.Style.Color = Color.Wheat;
        }

        var options = new DotFormattingOptions
        {
            Edges =
            {
                SingleLineSubgraphs = false
            }
        };

        var dot = graph.ToDot(options);
        Snapshot.Match(dot, "graph_with_multiline_edge_subgraphs_and_attributes.gv");
    }

    [Fact]
    public void renders_graph_with_multiline_edge_subgraphs_and_multiline_attributes()
    {
        var graph = CreateGraphWithMultilineEdgeSubgraphs();

        foreach (var edge in graph.Edges)
        {
            edge.Style.Color = Color.Wheat;
        }

        var options = new DotFormattingOptions
        {
            Edges =
            {
                SingleLineSubgraphs = false,
                SingleLineAttributeLists = false
            }
        };

        var dot = graph.ToDot(options);
        Snapshot.Match(dot, "graph_with_multiline_edge_subgraphs_and_multiline_attributes.gv");
    }

    [Fact]
    public void renders_graph_with_custom_text_encoder()
    {
        var graph = DotGraphFactory.CreateAnnotatedGraph();
        graph.Id = "graph1";

        var options = new DotFormattingOptions
        {
            TextEncoder = (value, _) => value?.ToUpper()
        };

        var dot = graph.ToDot(options);
        Snapshot.Match(dot, "graph_with_custom_text_encoder.gv");

        options.TextEncoder = (_, type) => $"{type}\n";
        dot = graph.ToDot(options);
        Snapshot.Match(dot, "graph_with_custom_text_encoder_tokens.gv");
    }

    private static DotGraph CreateGraphWithMultilineEdgeSubgraphs()
    {
        var graph = new DotGraph();

        graph.Edges.AddOneToMany("a", "b", "c");
        graph.Edges.AddOneToMany("d", "e", "f").Head.Endpoint.Subgraph.Id = "subgraph1";

        graph.Edges.AddManyToMany(["g", "h"], ["i", "j"], e =>
        {
            e.Head.Endpoint.Subgraph.Id = "head";
            e.Tail.Endpoint.Subgraph.Id = "tail";
        });

        graph.Edges.AddManyToMany(["k", "l"], ["m", "n"], e =>
        {
            e.Head.Endpoint.Annotation = "head subgraph comment";
            e.Tail.Endpoint.Annotation = "tail subgraph comment";

            e.Head.Endpoint.Subgraph.Id = "head";
            e.Tail.Endpoint.Subgraph.Id = "tail";
        });

        graph.Edges.AddManyToMany(["o", "p"], "q", "r");

        return graph;
    }
}