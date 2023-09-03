using System.Drawing;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Colors;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Qualities;

public partial class DotStripableExtensionTest
{
    [Fact]
    public void sets_striped_fill_on_individual_clusters()
    {
        var graph = new DotGraph();

        graph.Clusters.Add().SetStripedFill(Color.Red, Color.Blue);
        graph.Clusters.Add().SetStripedFill(new DotMultiColor(Color.Red, Color.Blue));

        Snapshot.Match(graph.Build(), "striped_fill_on_individual_clusters");
    }

    [Fact]
    public void sets_striped_fill_on_cluster_collection()
    {
        var graph = new DotGraph();
        graph.Clusters.SetStripedFill(Color.Red, Color.Blue);
        Snapshot.Match(graph.Build(), "striped_fill_on_cluster_collection_params");

        graph = new DotGraph();
        graph.Clusters.SetStripedFill(new DotMultiColor(Color.Red, Color.Blue));
        Snapshot.Match(graph.Build(), "striped_fill_on_cluster_collection_multicolor");
    }
}