using System.Drawing;
using GiGraph.Dot.Entities.Clusters.Attributes;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Clusters.Style;
using GiGraph.Dot.Types.Styling;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Qualities;

public partial class DotFillableExtensionTest
{
    [Fact]
    public void does_not_overwrite_other_cluster_style_flags()
    {
        var graph = new DotGraph();

        graph.Clusters
            .Add("", c => SetAllStyleOptions(c.Style))
            .Style
            .SetPlainFill(Color.Red);

        graph.Clusters.Style.FillStyle = DotClusterFillStyle.None;
        graph.Clusters.Style.BorderStyle = DotBorderStyle.Solid;
        graph.Clusters.Style.BorderWeight = DotBorderWeight.Bold;
        graph.Clusters.Style.CornerStyle = DotCornerStyle.Rounded;
        graph.Clusters.Style.Invisible = true;

        graph.Clusters.Style.SetPlainFill(Color.Red);

        Snapshot.Match(graph.ToDot(), "gradient_fill_on_clusters_with_other_styles_set");
    }

    [Fact]
    public void sets_plain_color_fill_on_cluster()
    {
        var graph = new DotGraph();
        graph.Clusters.Add("").Style.SetPlainFill(Color.Red);
        Snapshot.Match(graph.ToDot(), "plain_color_fill_on_cluster");
    }

    [Fact]
    public void sets_plain_color_fill_on_cluster_collection()
    {
        var graph = new DotGraph();
        graph.Clusters.Style.SetPlainFill(Color.Red);
        Snapshot.Match(graph.ToDot(), "plain_color_fill_on_cluster_collection");
    }

    private void SetAllStyleOptions(DotClusterStyleAttributes clusterStyle, DotClusterFillStyle fillStyle = DotClusterFillStyle.None)
    {
        clusterStyle.FillStyle = fillStyle;
        clusterStyle.BorderStyle = DotBorderStyle.Solid;
        clusterStyle.BorderWeight = DotBorderWeight.Bold;
        clusterStyle.CornerStyle = DotCornerStyle.Rounded;
        clusterStyle.Invisible = true;
    }
}