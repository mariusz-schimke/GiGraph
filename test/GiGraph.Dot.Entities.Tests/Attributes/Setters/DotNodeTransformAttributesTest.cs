using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Nodes.Attributes;
using GiGraph.Dot.Types.Geometry;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes.Setters;

public class DotNodeTransformAttributesTest
{
    [Fact]
    public void setter_with_params_sets_all_properties()
    {
        var geometry = new DotNodeTransformAttributes(new DotAttributeCollection());
        geometry.Set(45.0, 1.5, 2.0);
        Assert.Equal(45.0, geometry.Rotation);
        Assert.Equal(1.5, geometry.Skew);
        Assert.Equal(2.0, geometry.Distortion);
    }

    [Fact]
    public void setter_with_transform_sets_all_properties()
    {
        var geometry = new DotNodeTransformAttributes(new DotAttributeCollection());
        geometry.Set(new DotTransform(45.0, 1.5, 2.0));
        Assert.Equal(45.0, geometry.Rotation);
        Assert.Equal(1.5, geometry.Skew);
        Assert.Equal(2.0, geometry.Distortion);
    }
}