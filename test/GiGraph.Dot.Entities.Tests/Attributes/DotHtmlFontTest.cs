using System.Drawing;
using GiGraph.Dot.Entities.Html.Font;
using GiGraph.Dot.Types.Fonts;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes;

public class DotHtmlFontTest
{
    [Fact]
    public void setter_with_params_sets_all_properties()
    {
        var font = new DotHtmlFont();
        font.Set("arial", 12, Color.Red);
        Assert.Equal("arial", font.Name);
        Assert.Equal(12, font.Size);
        Assert.Equal(Color.Red, font.Color!.Color);
    }

    [Fact]
    public void setter_with_font_sets_all_properties()
    {
        var font = new DotHtmlFont();
        font.Set(new DotFont("arial", 12, Color.Red));
        Assert.Equal("arial", font.Name);
        Assert.Equal(12, font.Size);
        Assert.Equal(Color.Red, font.Color!.Color);
    }
}