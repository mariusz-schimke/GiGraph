using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.GraphCluster;
using GiGraph.Dot.Types.Alignment;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes.Setters;

public class DotGraphClusterLabelOptionsAttributesTest
{
    [Fact]
    public void setter_with_params_sets_all_properties()
    {
        var options = new DotGraphClusterLabelOptionsAttributes(new DotAttributeCollection());
        options.SetAlignment(DotHorizontalAlignment.Left, DotVerticalAlignment.Top);
        Assert.Equal(DotHorizontalAlignment.Left, options.HorizontalAlignment);
        Assert.Equal(DotVerticalAlignment.Top, options.VerticalAlignment);
    }

    [Fact]
    public void setter_with_alignment_sets_all_properties()
    {
        var options = new DotGraphClusterLabelOptionsAttributes(new DotAttributeCollection());
        options.SetAlignment(DotAlignment.BottomCenter);
        Assert.Equal(DotHorizontalAlignment.Center, options.HorizontalAlignment);
        Assert.Equal(DotVerticalAlignment.Bottom, options.VerticalAlignment);
    }

    [Fact]
    public void setter_with_alignment_options_sets_all_properties()
    {
        var options = new DotGraphClusterLabelOptionsAttributes(new DotAttributeCollection());
        options.SetAlignment(new DotAlignmentOptions(DotAlignment.MiddleLeft));
        Assert.Equal(DotHorizontalAlignment.Left, options.HorizontalAlignment);
        Assert.Equal(DotVerticalAlignment.Center, options.VerticalAlignment);
    }
}