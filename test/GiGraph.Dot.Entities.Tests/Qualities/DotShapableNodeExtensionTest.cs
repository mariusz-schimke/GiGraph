using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Qualities;

public class DotShapableNodeExtensionTest
{
    [Fact]
    public void sets_striped_fill_on_individual_nodes()
    {
        var graph = new DotGraph();

        graph.Nodes.Add("node1").SetPolygonalShape(6, true, 2, 30, 10, 5);
        graph.Nodes.Add("node2").SetPolygonalShape(new(6, true, 2, 30, 10, 5));

        Snapshot.Match(graph.Build(), "polygonal_nodes");
    }
}