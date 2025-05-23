using System.Drawing;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Nodes.Attributes;
using GiGraph.Dot.Types.Colors;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes.Setters;

public class DotNodeStyleAttributesTest
{
    [Fact]
    public void border_style_setter_sets_all_properties()
    {
        var style = new DotNodeStyleAttributes(new DotAttributeCollection());
        Assert.Null(style.Color);
        Assert.Null(style.BorderWidth);

        style.SetBorderStyle(Color.Aquamarine, 2.1);
        Assert.Equal(Color.Aquamarine, ((DotColor?) style.Color)!.Color);
        Assert.Equal(2.1, style.BorderWidth);
    }
}