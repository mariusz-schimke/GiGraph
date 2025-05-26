using System.Drawing;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Font;
using GiGraph.Dot.Types.Fonts;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes.Setters;

public class DotFontAttributesTest
{
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