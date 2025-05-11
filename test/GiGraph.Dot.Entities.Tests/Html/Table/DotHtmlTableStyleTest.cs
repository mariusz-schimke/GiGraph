using GiGraph.Dot.Entities.Html.Table;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Html.Table;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Html.Table;

public class DotHtmlTableStyleAttributeOptionsTest
{
    [Fact]
    public void setting_one_style_option_switches_others_from_null_to_false()
    {
        var table = new DotHtmlTable();
        Assert.False(table.Style.HasStyleOptions());

        Assert.Null(table.Style.RoundedCorners);
        Assert.Null(table.Style.RadialFill);

        table.Style.RoundedCorners = true;
        Assert.True(table.Style.RoundedCorners);
        Assert.False(table.Style.RadialFill);

        table.Style.RoundedCorners = false;
        Assert.False(table.Style.RoundedCorners);
        Assert.False(table.Style.RadialFill);

        Assert.True(table.Style.HasStyleOptions());
    }

    [Fact]
    public void nullifying_last_style_option_nullifies_style()
    {
        var table = new DotHtmlTable();
        Assert.False(table.Style.HasStyleOptions());

        table.Style.RoundedCorners = false;
        table.Style.RadialFill = true;

        Assert.False(table.Style.RoundedCorners);
        Assert.True(table.Style.RadialFill);

        Assert.True(table.Style.HasStyleOptions());

        table.Style.RadialFill = null;
        Assert.Null(table.Style.RadialFill);
        Assert.Null(table.Style.RoundedCorners);

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
        Assert.Null(table.Style.RadialFill);
        Assert.Null(table.Style.RoundedCorners);
        Assert.False(table.Style.HasStyleOptions());

        table.Style.SetStyleOptions(roundedCorners: false, radialFill: true);
        Assert.True(table.Style.RadialFill);
        Assert.False(table.Style.RoundedCorners);
        Assert.True(table.Style.HasStyleOptions());
    }
}