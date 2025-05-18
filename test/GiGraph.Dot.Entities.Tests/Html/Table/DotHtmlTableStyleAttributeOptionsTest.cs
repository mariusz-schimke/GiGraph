using GiGraph.Dot.Entities.Html.Table;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Html.Table;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Html.Table;

public class DotHtmlTableStyleAttributeOptionsTest
{
    [Fact]
    public void setting_last_style_option_default_removes_style()
    {
        var table = new DotHtmlTable();
        Assert.Equal(DotHtmlTableFillStyle.Regular, table.Style.FillStyle);
        Assert.Equal(DotHtmlTableCornerStyle.Sharp, table.Style.CornerStyle);
        Assert.False(table.Style.HasStyleOptions());

        table.Style.CornerStyle = DotHtmlTableCornerStyle.Rounded;
        Assert.Equal(DotHtmlTableFillStyle.Regular, table.Style.FillStyle);
        Assert.Equal(DotHtmlTableCornerStyle.Rounded, table.Style.CornerStyle);
        Assert.True(table.Style.HasStyleOptions());

        table.Style.FillStyle = DotHtmlTableFillStyle.Radial;
        Assert.Equal(DotHtmlTableFillStyle.Radial, table.Style.FillStyle);
        Assert.Equal(DotHtmlTableCornerStyle.Rounded, table.Style.CornerStyle);
        Assert.True(table.Style.HasStyleOptions());

        table.Style.CornerStyle = DotHtmlTableCornerStyle.Sharp;
        Assert.Equal(DotHtmlTableFillStyle.Radial, table.Style.FillStyle);
        Assert.Equal(DotHtmlTableCornerStyle.Sharp, table.Style.CornerStyle);
        Assert.True(table.Style.HasStyleOptions());

        table.Style.FillStyle = DotHtmlTableFillStyle.Regular;
        Assert.Equal(DotHtmlTableFillStyle.Regular, table.Style.FillStyle);
        Assert.Equal(DotHtmlTableCornerStyle.Sharp, table.Style.CornerStyle);
        Assert.False(table.Style.HasStyleOptions());
    }

    [Fact]
    public void remove_style_options_removes_the_style()
    {
        var table = new DotHtmlTable();
        Assert.False(table.Style.HasStyleOptions());

        table.Style.SetStyleOptions(cornerStyle: DotHtmlTableCornerStyle.Rounded);
        Assert.True(table.Style.HasStyleOptions());

        table.Style.RemoveStyleOptions();
        Assert.False(table.Style.HasStyleOptions());
    }

    [Fact]
    public void helper_methods_set_all_style_options()
    {
        var table = new DotHtmlTable();
        Assert.Equal(DotHtmlTableFillStyle.Regular, table.Style.FillStyle);
        Assert.Equal(DotHtmlTableCornerStyle.Sharp, table.Style.CornerStyle);
        Assert.False(table.Style.HasStyleOptions());

        table.Style.SetStyleOptions(
            new DotHtmlTableStyleOptions(
                DotHtmlTableFillStyle.Regular,
                DotHtmlTableCornerStyle.Rounded
            )
        );

        Assert.Equal(DotHtmlTableFillStyle.Regular, table.Style.FillStyle);
        Assert.Equal(DotHtmlTableCornerStyle.Rounded, table.Style.CornerStyle);
        Assert.True(table.Style.HasStyleOptions());

        table.Style.SetStyleOptions();
        Assert.Equal(DotHtmlTableFillStyle.Regular, table.Style.FillStyle);
        Assert.Equal(DotHtmlTableCornerStyle.Sharp, table.Style.CornerStyle);
        Assert.False(table.Style.HasStyleOptions());

        table.Style.SetStyleOptions(cornerStyle: DotHtmlTableCornerStyle.Rounded);
        Assert.Equal(DotHtmlTableFillStyle.Regular, table.Style.FillStyle);
        Assert.Equal(DotHtmlTableCornerStyle.Rounded, table.Style.CornerStyle);
        Assert.True(table.Style.HasStyleOptions());

        table.Style.SetStyleOptions(fillStyle: DotHtmlTableFillStyle.Radial);
        Assert.Equal(DotHtmlTableFillStyle.Radial, table.Style.FillStyle);
        Assert.Equal(DotHtmlTableCornerStyle.Sharp, table.Style.CornerStyle);
        Assert.True(table.Style.HasStyleOptions());
    }
}