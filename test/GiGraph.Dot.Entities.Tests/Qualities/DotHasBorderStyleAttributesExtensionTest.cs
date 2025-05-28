using System.Drawing;
using GiGraph.Dot.Entities.Clusters;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Styling;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Qualities;

public class DotHasBorderStyleAttributesExtensionTest
{
    [Fact]
    public void node_border_style_setter_sets_all_properties()
    {
        var node = new DotNode("n");
        TestExtensionMethods(node.Style);
    }

    [Fact]
    public void cluster_border_style_setter_sets_all_properties()
    {
        var cluster = new DotCluster("c");
        TestExtensionMethods(cluster.Style);
    }

    [Fact]
    public void graph_clusters_border_style_setter_sets_all_properties()
    {
        var graph = new DotGraph();
        TestExtensionMethods(graph.Clusters.Style);
    }

    private static void TestExtensionMethods<T>(T entity)
        where T : IDotHasBorderStyleAttributes
    {
        ClearEntity(entity);
        entity.SetBorderStyle(DotBorderStyle.Dashed, 2.1);
        Assert.Equal(DotBorderStyle.Dashed, entity.BorderStyle);
        Assert.Equal(2.1, entity.BorderWidth);

        ClearEntity(entity);
        entity.SetBorderStyle(DotBorderStyle.Dotted, 2.2, Color.Aquamarine);
        Assert.Equal(DotBorderStyle.Dotted, entity.BorderStyle);
        Assert.Equal(2.2, entity.BorderWidth);
        Assert.Equal(Color.Aquamarine, ((DotColor?) entity.Color)!.Color);

        ClearEntity(entity);
        entity.SetBorderStyle(DotBorderStyle.Dotted, DotBorderWeight.Bold);
        Assert.Equal(DotBorderStyle.Dotted, entity.BorderStyle);
        Assert.Equal(DotBorderWeight.Bold, entity.BorderWeight);

        ClearEntity(entity);
        entity.SetBorderStyle(DotBorderStyle.Dotted, DotBorderWeight.Bold, Color.AntiqueWhite);
        Assert.Equal(DotBorderStyle.Dotted, entity.BorderStyle);
        Assert.Equal(DotBorderWeight.Bold, entity.BorderWeight);
        Assert.Equal(Color.AntiqueWhite, ((DotColor?) entity.Color)!.Color);
    }

    private static void ClearEntity<T>(T entity)
        where T : IDotHasBorderStyleAttributes
    {
        entity.BorderStyle = DotBorderStyle.Default;
        entity.BorderWeight = DotBorderWeight.Normal;
        entity.BorderWidth = null;
        entity.Color = null;

        Assert.Equal(DotBorderStyle.Default, entity.BorderStyle);
        Assert.Equal(DotBorderWeight.Normal, entity.BorderWeight);
        Assert.Null(entity.BorderWidth);
        Assert.Null(entity.Color);
    }
}