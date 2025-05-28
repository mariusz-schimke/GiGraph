using System.Drawing;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Font;
using GiGraph.Dot.Entities.Graphs.Attributes;
using GiGraph.Dot.Entities.Html.Font;
using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Extensions;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Qualities;

public class DotHasFontAttributesExtensionTest
{
    [Fact]
    public void graph_font_setters_set_all_properties()
    {
        var fontAttributes = new DotGraphFontAttributes(new DotAttributeCollection());
        TestExtensionMethods(fontAttributes);
    }

    [Fact]
    public void font_attributes_setters_set_all_properties()
    {
        var fontAttributes = new DotFontAttributes(new DotAttributeCollection());
        TestExtensionMethods(fontAttributes);
    }

    [Fact]
    public void html_font_setters_set_all_properties()
    {
        var font = new DotHtmlFont();
        TestExtensionMethods(font);
    }

    private void TestExtensionMethods<T>(T entity)
        where T : IDotHasFontAttributes
    {
        Assert.Null(entity.Name);
        Assert.Null(entity.Size);
        Assert.Null(entity.Color);

        entity.Name = "arial";
        entity.Set(12, Color.Red);
        Assert.Equal("arial", entity.Name);
        Assert.Equal(12, entity.Size);
        Assert.Equal(Color.Red, entity.Color!.Color);

        entity.Set("helvetica", 13);
        Assert.Equal("helvetica", entity.Name);
        Assert.Equal(13, entity.Size);
        Assert.Equal(Color.Red, entity.Color!.Color);

        entity.Set("times-roman", 14, Color.Blue);
        Assert.Equal("times-roman", entity.Name);
        Assert.Equal(14, entity.Size);
        Assert.Equal(Color.Blue, entity.Color!.Color);
    }
}