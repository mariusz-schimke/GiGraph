using System.Drawing;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Font;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Fonts;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes.Setters;

public class DotFontAttributesTest
{
    [Fact]
    public void setter_with_params_sets_all_properties()
    {
        var font = new DotFontAttributes(new DotAttributeCollection());
        Assert.Null(font.Name);
        Assert.Null(font.Size);
        Assert.Null(font.Color);

        font.Name = "arial";
        font.Set(12, Color.Red);
        Assert.Equal("arial", font.Name);
        Assert.Equal(12, font.Size);
        Assert.Equal(Color.Red, font.Color!.Color);

        font.Set("helvetica", 13, Color.Blue);
        Assert.Equal("helvetica", font.Name);
        Assert.Equal(13, font.Size);
        Assert.Equal(Color.Blue, font.Color!.Color);
    }

    [Fact]
    public void setter_with_font_sets_all_properties()
    {
        var font = new DotFontAttributes(new DotAttributeCollection());
        font.Set(new DotFont("arial", 12, Color.Red));
        Assert.Equal("arial", font.Name);
        Assert.Equal(12, font.Size);
        Assert.Equal(Color.Red, font.Color!.Color);
    }
}