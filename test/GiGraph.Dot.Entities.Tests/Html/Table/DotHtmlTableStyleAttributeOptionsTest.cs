using GiGraph.Dot.Entities.Html.Table;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Html.Table;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Html.Table;

public class DotHtmlTableStyleAttributeOptionsTest
{
    [Fact]
    public void setting_last_style_option_default_preserves_default_style()
    {
        var table = new DotHtmlTable();
        Assert.False(table.Style.HasStyleOptions());

        Assert.False(table.Style.RoundedCorners);
        Assert.False(table.Style.RadialFill);

        table.Style.RoundedCorners = true;
        Assert.True(table.Style.RoundedCorners);
        Assert.False(table.Style.RadialFill);
        Assert.True(table.Style.HasStyleOptions());

        table.Style.RadialFill = true;
        Assert.True(table.Style.RoundedCorners);
        Assert.True(table.Style.RadialFill);
        Assert.True(table.Style.HasStyleOptions());

        table.Style.RoundedCorners = false;
        Assert.False(table.Style.RoundedCorners);
        Assert.True(table.Style.RadialFill);
        Assert.True(table.Style.HasStyleOptions());

        table.Style.RadialFill = false;
        Assert.False(table.Style.RoundedCorners);
        Assert.False(table.Style.RadialFill);
        Assert.True(table.Style.HasStyleOptions());
    }

    [Fact]
    public void clear_style_options_removes_the_style()
    {
        var table = new DotHtmlTable();
        Assert.False(table.Style.HasStyleOptions());

        table.Style.SetStyleOptions(roundedCorners: true);
        Assert.True(table.Style.HasStyleOptions());

        table.Style.RemoveStyleOptions();
        Assert.False(table.Style.HasStyleOptions());
    }

    [Fact]
    public void helper_methods_set_all_style_options()
    {
        var table = new DotHtmlTable();
        Assert.False(table.Style.HasStyleOptions());

        table.Style.SetStyleOptions(
            new DotHtmlTableStyleOptions(
                RoundedCorners: true,
                RadialFill: false
            )
        );

        Assert.True(table.Style.RoundedCorners);
        Assert.False(table.Style.RadialFill);
        Assert.True(table.Style.HasStyleOptions());

        table.Style.SetStyleOptions();
        Assert.False(table.Style.RoundedCorners);
        Assert.False(table.Style.RadialFill);
        Assert.True(table.Style.HasStyleOptions());

        table.Style.SetStyleOptions(roundedCorners: true);
        Assert.True(table.Style.RoundedCorners);
        Assert.False(table.Style.RadialFill);
        Assert.True(table.Style.HasStyleOptions());

        table.Style.SetStyleOptions(radialFill: true);
        Assert.True(table.Style.RadialFill);
        Assert.False(table.Style.RoundedCorners);
        Assert.True(table.Style.HasStyleOptions());
    }
}