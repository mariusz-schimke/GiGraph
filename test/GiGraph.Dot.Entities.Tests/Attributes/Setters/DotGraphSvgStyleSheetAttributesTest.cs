using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Graphs.Attributes;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes.Setters;

public class DotGraphSvgStyleSheetAttributesTest
{
    [Fact]
    public void setter_with_params_sets_all_properties()
    {
        var svgStyle = new DotGraphSvgStyleSheetAttributes(new DotAttributeCollection());
        svgStyle.Set("url", "class");
        Assert.Equal("url", svgStyle.Url);
        Assert.Equal("class", svgStyle.Class);
    }
}