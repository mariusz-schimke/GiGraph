using System.Drawing;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Graphs.Attributes;
using GiGraph.Dot.Types.Fonts;
using GiGraph.Dot.Types.Graphs.Font;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes.Setters;

public class DotGraphFontAttributesTest
{
    [Fact]
    public void setter_with_font_sets_all_properties()
    {
        var font = new DotGraphFontAttributes(new DotAttributeCollection());
        font.Set(new DotGraphFont("arial", 12, Color.Red, "dir", DotFontConvention.Fontconfig));
        Assert.Equal("arial", font.Name);
        Assert.Equal(12, font.Size);
        Assert.Equal(Color.Red, font.Color!.Color);
        Assert.Equal("dir", font.Directories);
        Assert.Equal(DotFontConvention.Fontconfig, font.Convention);
    }
}