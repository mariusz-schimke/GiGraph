using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.Edges.Arrowheads;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Edges;

public class DotEdgeTest
{
    [Fact]
    public void is_loop_edge()
    {
        var edge = new DotEdge("a");
        Assert.True(edge.IsLoop);
        Assert.True(edge.IsLoopOn("a"));

        edge = new DotEdge(new DotClusterEndpoint("a"));
        Assert.True(edge.IsLoop);
        Assert.True(edge.IsLoopOn(new DotClusterEndpoint("a")));
        Assert.True(edge.IsLoopOn("a"));
        Assert.False(edge.IsLoopOn("b"));
    }

    [Fact]
    public void is_not_loop_edge()
    {
        var edge = new DotEdge("a", "b");
        Assert.False(edge.IsLoop);
        Assert.False(edge.IsLoopOn("a"));

        edge = new DotEdge("a", new DotClusterEndpoint("a"));
        Assert.False(edge.IsLoop);
        Assert.False(edge.IsLoopOn("a"));

        edge = new DotEdge(new DotClusterEndpoint("a"));
        Assert.False(edge.IsLoopOn(new DotEndpoint("a")));
    }

    [Fact]
    public void all_edge_attribute_types_have_properties_for_head_and_tail_attributes_exposed_and_not_confused()
    {
        // this test makes sure that the head attributes are not replaced with tail attributes implementation or the other way round
        // (because the Head(s) and Tail(s) properties are the same classes, accepting any endpoint attributes implementation as a constructor parameter)

        var graph = new DotGraph();

        // edge collection
        graph.Edges.Head.Arrowhead = DotArrowheadShape.Box;
        graph.Edges.Tail.Arrowhead = DotArrowheadShape.Crow;

        graph.Edges.Head.Hyperlink.Href = "https://www.google.com/search?q=head";
        graph.Edges.Tail.Hyperlink.Href = "https://www.google.com/search?q=tail";

        // ordinary edges
        graph.Edges.AddLoop(
            "edge1",
            edge =>
            {
                edge.Head.Arrowhead = DotArrowheadShape.Box;
                edge.Tail.Arrowhead = DotArrowheadShape.Crow;
                edge.Head.Hyperlink.Href = "https://www.google.com/search?q=head";
                edge.Tail.Hyperlink.Href = "https://www.google.com/search?q=tail";
            }
        );

        // edge sequence
        // this test just makes sure that the head and tail attributes are exposed by the descendant class
        // (not to lose them as a result of some future refactoring)
        graph.Edges.AddSequence(
            ["a", "b", "c"],
            edge =>
            {
                edge.Heads.Port = "head_port";
                edge.Tails.Port = "tail_port";
                edge.Heads.Hyperlink.Href = "https://www.google.com/search?q=head";
                edge.Tails.Hyperlink.Href = "https://www.google.com/search?q=tail";
            }
        );

        Snapshot.Match(graph.ToDot(), "edge_head_and_tail_attributes");
    }

    [Fact]
    public void port_is_rendered_correctly()
    {
        var graph = new DotGraph();

        graph.Edges.Add("a", "b", e => e.Head.Endpoint.Port = null);
        graph.Edges.Add("a", "b", e => e.Head.Endpoint.Port = DotCompassPoint.Center);
        graph.Edges.Add("a", "b", e => e.Head.Endpoint.Port = "portName");
        graph.Edges.Add("a", "b", e => e.Head.Endpoint.Port = new DotEndpointPort("portName", DotCompassPoint.Center));
        graph.Edges.Add("a", "b", e => e.Head.Endpoint.Port = new DotEndpointPort(null, null));

        Snapshot.Match(graph.ToDot(), "edge_head_port_variants");
    }
}