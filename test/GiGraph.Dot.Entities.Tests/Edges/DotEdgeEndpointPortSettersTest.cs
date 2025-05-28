using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Edges;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Edges;

public class DotEdgeEndpointPortSettersTest
{
    [Fact]
    public void sets_port_variants()
    {
        var graph = new DotGraph();

        graph.Edges.Head.SetCompassPoint(DotCompassPoint.East);
        graph.Edges.Tail.SetPort("port");

        var edge = graph.Edges.Add("node1", "node2");
        edge.Head.SetPort("port1", DotCompassPoint.NorthWest);
        edge.Tail.SetPort("port2", DotCompassPoint.SouthEast);

        Snapshot.Match(graph.ToDot(), "edge_endpoints_ports");
    }
}