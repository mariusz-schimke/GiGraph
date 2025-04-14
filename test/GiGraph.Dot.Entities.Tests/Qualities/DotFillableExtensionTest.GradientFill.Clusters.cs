using System.Drawing;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Colors;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Qualities;

public partial class DotFillableExtensionTest
{
    [Fact]
    public void sets_gradient_fill_on_cluster()
    {
        var graph = new DotGraph();

        graph.Clusters.Add("").SetGradientFill(new DotGradientColor(Color.Red, Color.Brown));
        graph.Clusters.Add("").SetGradientFill(new DotGradientColor(Color.Red, Color.Brown), 45);

        Snapshot.Match(graph.ToDot(), "gradient_fill_on_clusters");

        graph.Clusters.Clear();

        // an overload (with the same result)
        graph.Clusters.Add("").SetGradientFill(Color.Red, Color.Brown);
        graph.Clusters.Add("").SetGradientFill(Color.Red, Color.Brown, 45);

        Snapshot.Match(graph.ToDot(), "gradient_fill_on_clusters");
    }

    [Fact]
    public void sets_gradient_fill_on_cluster_collection()
    {
        var graph = new DotGraph();
        graph.Clusters.SetGradientFill(new DotGradientColor(Color.Red, Color.Brown));
        Snapshot.Match(graph.ToDot(), "gradient_fill_on_cluster_collection");
    }

    [Fact]
    public void sets_gradient_fill_with_angle_on_cluster_collection()
    {
        var graph = new DotGraph();
        graph.Clusters.SetGradientFill(new DotGradientColor(Color.Red, Color.Brown), 45);
        Snapshot.Match(graph.ToDot(), "gradient_fill_on_cluster_collection_with_angle");
    }
}