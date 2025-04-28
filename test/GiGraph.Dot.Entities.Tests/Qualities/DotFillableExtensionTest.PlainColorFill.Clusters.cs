using System.Drawing;
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

        graph.Clusters.Add("", c =>
                c.Style.SetStyleOptions(DotClusterFillStyle.None, DotBorderStyle.Solid, DotBorderWeight.Bold, DotCornerStyle.Rounded, true)
            )
            .SetPlainFill(Color.Red);

        graph.Clusters.Style.SetStyleOptions(DotClusterFillStyle.None, DotBorderStyle.Solid, DotBorderWeight.Bold, DotCornerStyle.Rounded, true);
        graph.Clusters.SetPlainFill(Color.Red);

        Snapshot.Match(graph.ToDot(), "gradient_fill_on_clusters_with_other_styles_set");
    }

    [Fact]
    public void sets_plain_color_fill_on_cluster()
    {
        var graph = new DotGraph();
        graph.Clusters.Add("").SetPlainFill(Color.Red);
        Snapshot.Match(graph.ToDot(), "plain_color_fill_on_cluster");
    }

    [Fact]
    public void sets_plain_color_fill_on_cluster_collection()
    {
        var graph = new DotGraph();
        graph.Clusters.SetPlainFill(Color.Red);
        Snapshot.Match(graph.ToDot(), "plain_color_fill_on_cluster_collection");
    }
}