using System.Drawing;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Colors;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Qualities;

public partial class DotStripeFillableExtensionTest
{
    [Fact]
    public void sets_striped_fill_on_individual_clusters()
    {
        var graph = new DotGraph();

        graph.Clusters.Add("").Style.SetStripedFill(Color.Red, Color.Blue);
        graph.Clusters.Add("").Style.SetStripedFill(new DotMulticolor(Color.Red, Color.Blue));

        Snapshot.Match(graph.ToDot(), "striped_fill_on_individual_clusters");
    }

    [Fact]
    public void sets_striped_fill_on_cluster_collection()
    {
        var graph = new DotGraph();
        graph.Clusters.Style.SetStripedFill(Color.Red, Color.Blue);
        Snapshot.Match(graph.ToDot(), "striped_fill_on_cluster_collection_params");

        graph = new DotGraph();
        graph.Clusters.Style.SetStripedFill(new DotMulticolor(Color.Red, Color.Blue));
        Snapshot.Match(graph.ToDot(), "striped_fill_on_cluster_collection_multicolor");
    }
}