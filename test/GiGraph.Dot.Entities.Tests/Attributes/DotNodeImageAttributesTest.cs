using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Nodes.Attributes;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Images;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes;

public class DotNodeImageAttributesTest
{
    [Fact]
    public void setter_with_params_sets_all_properties()
    {
        var image = new DotNodeImageAttributes(new DotAttributeCollection());
        image.Set("path1", DotAlignment.BottomLeft, DotImageScaling.FillHeight);
        Assert.Equal("path1", image.Path);
        Assert.Equal(DotAlignment.BottomLeft, image.Alignment);
        Assert.Equal(DotImageScaling.FillHeight, image.Scaling);
    }

    [Fact]
    public void setter_with_image_sets_all_properties()
    {
        var image = new DotNodeImageAttributes(new DotAttributeCollection());
        image.Set(new DotImage("path1", DotAlignment.BottomLeft, DotImageScaling.FillHeight));
        Assert.Equal("path1", image.Path);
        Assert.Equal(DotAlignment.BottomLeft, image.Alignment);
        Assert.Equal(DotImageScaling.FillHeight, image.Scaling);
    }
}