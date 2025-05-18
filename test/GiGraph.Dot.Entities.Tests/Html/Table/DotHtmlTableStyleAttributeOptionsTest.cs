using System.Drawing;
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

    [Fact]
    public void set_plain_fill_helper_method_does_not_place_empty_style_attribute_for_regular_fill()
    {
        var table = new DotHtmlTable();
        Assert.Equal(DotHtmlTableFillStyle.Regular, table.Style.FillStyle);
        Assert.Equal(DotHtmlTableCornerStyle.Sharp, table.Style.CornerStyle);
        Assert.False(table.Style.HasStyleOptions());

        table.Style.SetPlainFill(Color.Red);
        Assert.False(table.Style.HasStyleOptions());

        table.Style.SetRadialGradientFill(Color.Red, Color.Blue);
        Assert.True(table.Style.HasStyleOptions());
    }

    [Fact]
    public void set_border_style_helper_method_sets_all_attributes()
    {
        var table = new DotHtmlTable();
        table.Style.SetBorderStyle(Color.Azure, 4);

        Assert.Equal(Color.Azure, table.Style.BorderColor!.Color);
        Assert.Equal(4, table.Style.BorderWidth);

        table.Style.SetBorderStyle(Color.Bisque, 5, 4);

        Assert.Equal(Color.Bisque, table.Style.BorderColor!.Color);
        Assert.Equal(5, table.Style.BorderWidth);
        Assert.Equal(4, table.Style.CellBorderWidth);
    }
}