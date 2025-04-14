using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Output.Options;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Output.Tests.EntityPadding;

public class DotEdgeWithSubgraphEndpointsTest
{
    [Fact]
    public void edge_has_no_padding_when_it_contains_no_subgraph_endpoints()
    {
        var graph = new DotGraph();

        graph.Edges.AddSequence(
            new DotEndpointGroup(
                new DotEndpoint("node1"),
                new DotClusterEndpoint("cluster1"),
                new DotClusterEndpoint("")
            ),
            new DotEndpointGroup(
                new DotEndpoint("node2"),
                new DotClusterEndpoint("cluster2"),
                new DotClusterEndpoint("")
            ),
            new DotEndpoint("node3", "port1")
        );

        var formatting = new DotFormattingOptions { Edges = { SingleLineSubgraphs = false } };
        Snapshot.Match(graph.ToDotString(formatting), "single_edge_without_padding.gv");

        formatting.SingleLine = true;
        Snapshot.Match(graph.ToDotString(formatting), "single_edge_without_padding_single_line.gv");
    }

    [Fact]
    public void edges_have_no_padding_when_they_contain_no_subgraph_endpoints()
    {
        var graph = new DotGraph();

        graph.Edges.AddSequence(
            new DotEndpointGroup(
                new DotEndpoint("node1"),
                new DotClusterEndpoint("cluster1"),
                new DotClusterEndpoint("")
            ),
            new DotEndpointGroup(
                new DotEndpoint("node2"),
                new DotClusterEndpoint("cluster2"),
                new DotClusterEndpoint("")
            ),
            new DotEndpoint("node3", "port1")
        );

        graph.Edges.AddLoop("node4");
        graph.Edges.AddLoop("node5");

        var formatting = new DotFormattingOptions { Edges = { SingleLineSubgraphs = false } };
        Snapshot.Match(graph.ToDotString(formatting), "edges_without_padding.gv");

        formatting.SingleLine = true;
        Snapshot.Match(graph.ToDotString(formatting), "edges_without_padding_single_line.gv");
    }

    [Fact]
    public void edge_has_padding_when_it_contains_subgraph_endpoints()
    {
        var graph = new DotGraph();

        for (var i = 0; i < 3; i++)
        {
            graph.Edges.AddSequence(
                new DotEndpointGroup(
                    new DotEndpoint("node1"),
                    new DotClusterEndpoint("cluster1"),
                    new DotClusterEndpoint("")
                ),
                new DotSubgraphEndpoint("node2", "node3")
            );
        }

        graph.Edges.AddLoop("node4");
        graph.Edges.AddLoop("node5");

        var formatting = new DotFormattingOptions { Edges = { SingleLineSubgraphs = false } };
        Snapshot.Match(graph.ToDotString(formatting), "edges_with_padding.gv");

        formatting.SingleLine = true;
        Snapshot.Match(graph.ToDotString(formatting), "edges_with_padding_single_line.gv");
    }

    [Fact]
    public void first_edge_has_no_top_padding()
    {
        var graph = new DotGraph();

        graph.Edges.AddSequence(
            new DotEndpointGroup(
                new DotEndpoint("node1"),
                new DotClusterEndpoint("cluster1"),
                new DotClusterEndpoint("")
            ),
            new DotSubgraphEndpoint("node2", "node3")
        );

        graph.Edges.AddLoop("node4");
        graph.Edges.AddLoop("node5");

        var formatting = new DotFormattingOptions { Edges = { SingleLineSubgraphs = false } };
        Snapshot.Match(graph.ToDotString(formatting), "edge_with_bottom_padding.gv");

        formatting.SingleLine = true;
        Snapshot.Match(graph.ToDotString(formatting), "edge_with_bottom_padding_single_line.gv");
    }

    [Fact]
    public void last_edge_has_no_bottom_padding()
    {
        var graph = new DotGraph();

        graph.Edges.AddLoop("node1");
        graph.Edges.AddLoop("node2");

        graph.Edges.AddSequence(
            new DotEndpointGroup(
                new DotEndpoint("node3"),
                new DotClusterEndpoint("cluster1"),
                new DotClusterEndpoint("")
            ),
            new DotSubgraphEndpoint("node4", "node5")
        );


        var formatting = new DotFormattingOptions { Edges = { SingleLineSubgraphs = false } };
        Snapshot.Match(graph.ToDotString(formatting), "edge_with_top_padding.gv");

        formatting.SingleLine = true;
        Snapshot.Match(graph.ToDotString(formatting), "edge_with_top_padding_single_line.gv");
    }
}