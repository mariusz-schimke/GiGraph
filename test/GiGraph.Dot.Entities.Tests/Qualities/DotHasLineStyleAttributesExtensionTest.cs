using System.Drawing;
using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Styling;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Qualities;

public class DotHasLineStyleAttributesExtensionTest
{
    [Fact]
    public void extension_methods_work_on_edge()
    {
        var edge = new DotEdge("n1", "n2");
        TestExtensionMethods(edge.Style);
    }

    private static void TestExtensionMethods<T>(T entity)
        where T : IDotHasLineStyleAttributes
    {
        ClearEntity(entity);
        entity.SetLineStyle(DotLineStyle.Dashed, 2.1);
        Assert.Equal(DotLineStyle.Dashed, entity.LineStyle);
        Assert.Equal(2.1, entity.LineWidth);

        ClearEntity(entity);
        entity.SetLineStyle(DotLineStyle.Dotted, 2.2, Color.Aquamarine);
        Assert.Equal(DotLineStyle.Dotted, entity.LineStyle);
        Assert.Equal(2.2, entity.LineWidth);
        Assert.Equal(Color.Aquamarine, ((DotColor?) entity.LineColor)!.Color);

        ClearEntity(entity);
        entity.SetLineStyle(DotLineStyle.Dotted, DotLineWeight.Bold);
        Assert.Equal(DotLineStyle.Dotted, entity.LineStyle);
        Assert.Equal(DotLineWeight.Bold, entity.LineWeight);

        ClearEntity(entity);
        entity.SetLineStyle(DotLineStyle.Dotted, DotLineWeight.Bold, Color.AntiqueWhite);
        Assert.Equal(DotLineStyle.Dotted, entity.LineStyle);
        Assert.Equal(DotLineWeight.Bold, entity.LineWeight);
        Assert.Equal(Color.AntiqueWhite, ((DotColor?) entity.LineColor)!.Color);
    }

    private static void ClearEntity<T>(T entity)
        where T : IDotHasLineStyleAttributes
    {
        entity.LineStyle = DotLineStyle.Default;
        entity.LineWeight = DotLineWeight.Normal;
        entity.LineWidth = null;
        entity.LineColor = null;

        Assert.Equal(DotLineStyle.Default, entity.LineStyle);
        Assert.Equal(DotLineWeight.Normal, entity.LineWeight);
        Assert.Null(entity.LineWidth);
        Assert.Null(entity.LineColor);
    }
}