using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Nodes.Attributes;
using GiGraph.Dot.Types.Geometry;
using GiGraph.Dot.Types.Nodes.Size;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes.Setters;

public class DotNodeSizeAttributesTest
{
    [Fact]
    public void setter_with_params_sets_all_properties()
    {
        var size = new DotNodeSizeAttributes(new DotAttributeCollection());
        size.Set(1.5, 2.0, DotNodeSizing.Fixed);
        Assert.Equal(1.5, size.Width);
        Assert.Equal(2.0, size.Height);
        Assert.Equal(DotNodeSizing.Fixed, size.Mode);
    }

    [Fact]
    public void setter_with_size_sets_all_properties()
    {
        var size = new DotNodeSizeAttributes(new DotAttributeCollection());
        size.Set(new DotSize(1.5, 2.0), DotNodeSizing.Fixed);
        Assert.Equal(1.5, size.Width);
        Assert.Equal(2.0, size.Height);
        Assert.Equal(DotNodeSizing.Fixed, size.Mode);
    }

    [Fact]
    public void setter_with_node_size_sets_all_properties()
    {
        var size = new DotNodeSizeAttributes(new DotAttributeCollection());
        size.Set(new DotNodeSize(1.5, 2.0, DotNodeSizing.Fixed));
        Assert.Equal(1.5, size.Width);
        Assert.Equal(2.0, size.Height);
        Assert.Equal(DotNodeSizing.Fixed, size.Mode);
    }
}