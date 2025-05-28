using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Nodes.Attributes;
using GiGraph.Dot.Types.Geometry;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes.Setters;

public class DotNodeGeometryAttributesTest
{
    [Fact]
    public void setter_with_params_sets_all_properties()
    {
        var geometry = new DotNodeGeometryAttributes(new DotAttributeCollection());
        geometry.Set(5, true);
        Assert.Equal(5, geometry.Sides);
        Assert.True(geometry.Regular);
    }

    [Fact]
    public void setter_with_polygon_sets_all_properties()
    {
        var geometry = new DotNodeGeometryAttributes(new DotAttributeCollection());
        geometry.Set(new DotPolygon(5, true));
        Assert.Equal(5, geometry.Sides);
        Assert.True(geometry.Regular);
    }
}