using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Qualities;

public partial class DotStylableEdgeExtensionTest
{
    [Fact]
    public void sets_tapered_style_on_edge_and_edge_collection()
    {
        var graph = new DotGraph();

        graph.Edges.Style.SetTaperedLineStyle(4);
        graph.Edges.Add("a", "b").Style.SetTaperedLineStyle(4);

        Snapshot.Match(graph.ToDot(), "tapered_edge_and_edge_collection");
    }
}