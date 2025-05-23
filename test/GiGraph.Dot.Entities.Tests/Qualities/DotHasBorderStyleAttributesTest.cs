using System.Drawing;
using GiGraph.Dot.Entities.Clusters;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Colors;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Qualities;

public class DotHasBorderStyleAttributesTest
{
    [Fact]
    public void node_border_style_setter_sets_all_properties()
    {
        var node = new DotNode("n");
        Assert.Null(node.Style.Color);
        Assert.Null(node.Style.BorderWidth);

        node.Style.SetBorderStyle(Color.Aquamarine, 2.0);
        Assert.Equal(Color.Aquamarine, ((DotColor?) node.Style.Color)!.Color);
        Assert.Equal(2.0, node.Style.BorderWidth);
    }

    [Fact]
    public void cluster_border_style_setter_sets_all_properties()
    {
        var cluster = new DotCluster("c");
        Assert.Null(cluster.Style.Color);
        Assert.Null(cluster.Style.BorderWidth);

        cluster.Style.SetBorderStyle(Color.Aquamarine, 2.1);
        Assert.Equal(Color.Aquamarine, ((DotColor?) cluster.Style.Color)!.Color);
        Assert.Equal(2.1, cluster.Style.BorderWidth);
    }

    [Fact]
    public void graph_clusters_border_style_setter_sets_all_properties()
    {
        var graph = new DotGraph();
        Assert.Null(graph.Clusters.Style.Color);
        Assert.Null(graph.Clusters.Style.BorderWidth);

        graph.Clusters.Style.SetBorderStyle(Color.Aquamarine, 2.2);
        Assert.Equal(Color.Aquamarine, ((DotColor?) graph.Clusters.Style.Color)!.Color);
        Assert.Equal(2.2, graph.Clusters.Style.BorderWidth);
    }
}