using System.Drawing;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Edges.Attributes;
using GiGraph.Dot.Types.Colors;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes.Setters;

public class DotEdgeStyleAttributesTest
{
    [Fact]
    public void arrowhead_style_setter_sets_both_properties()
    {
        var style = new DotEdgeStyleAttributes(new DotAttributeCollection());
        style.SetArrowheadStyle(3, Color.Blue);
        Assert.Equal(Color.Blue, ((DotColor?) style.ArrowheadFillColor)!.Color);
        Assert.Equal(3, style.ArrowheadScale);
    }
}