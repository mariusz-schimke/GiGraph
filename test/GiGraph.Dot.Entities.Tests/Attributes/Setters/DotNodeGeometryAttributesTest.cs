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
        geometry.SetGeometry(5, true);
        Assert.Equal(5, geometry.Sides);
        Assert.Equal(true, geometry.Regular);

        geometry.SetTransform(45.0, 1.5, 2.0);
        Assert.Equal(45.0, geometry.Rotation);
        Assert.Equal(1.5, geometry.Skew);
        Assert.Equal(2.0, geometry.Distortion);
    }

    [Fact]
    public void setter_with_polygon_sets_all_properties()
    {
        var geometry = new DotNodeGeometryAttributes(new DotAttributeCollection());
        geometry.Set(new DotPolygon(5, true, 45.0, 1.5, 2.0));
        Assert.Equal(5, geometry.Sides);
        Assert.Equal(true, geometry.Regular);
        Assert.Equal(45.0, geometry.Rotation);
        Assert.Equal(1.5, geometry.Skew);
        Assert.Equal(2.0, geometry.Distortion);
    }
}