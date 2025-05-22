using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Nodes.Attributes;
using GiGraph.Dot.Types.Geometry;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes.Setters;

public class DotNodeSizeAttributesTest
{
    [Fact]
    public void setter_with_params_sets_all_properties()
    {
        var size = new DotNodeSizeAttributes(new DotAttributeCollection());
        Assert.Null(size.Width);
        Assert.Null(size.Height);
        Assert.Null(size.Mode);

        size.Mode = DotSizingMode.Fixed;
        size.Set(1.5, 2.0);
        Assert.Equal(1.5, size.Width);
        Assert.Equal(2.0, size.Height);
        Assert.Equal(DotSizingMode.Fixed, size.Mode);

        size.Set(1.5, 2.0, DotSizingMode.Auto);
        Assert.Equal(1.5, size.Width);
        Assert.Equal(2.0, size.Height);
        Assert.Equal(DotSizingMode.Auto, size.Mode);
    }

    [Fact]
    public void setter_with_size_sets_all_properties()
    {
        var size = new DotNodeSizeAttributes(new DotAttributeCollection());
        Assert.Null(size.Width);
        Assert.Null(size.Height);
        Assert.Null(size.Mode);

        size.Mode = DotSizingMode.Fixed;
        size.Set(new DotSize(1.5, 2.0));
        Assert.Equal(1.5, size.Width);
        Assert.Equal(2.0, size.Height);
        Assert.Null(size.Mode);

        size.Set(new DotSize(1.6, 2.1, DotSizingMode.Shape));
        Assert.Equal(1.6, size.Width);
        Assert.Equal(2.1, size.Height);
        Assert.Equal(DotSizingMode.Shape, size.Mode);
    }
}