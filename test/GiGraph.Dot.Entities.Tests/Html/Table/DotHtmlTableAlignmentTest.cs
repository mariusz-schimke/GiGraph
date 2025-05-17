using GiGraph.Dot.Entities.Html.Table;
using GiGraph.Dot.Types.Alignment;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Html.Table;

public class DotHtmlTableAlignmentTest
{
    [Fact]
    public void alignment_setter_with_params_sets_both_properties()
    {
        var table = new DotHtmlTable();

        var horizontal = DotHorizontalAlignment.Left;
        var vertical = DotVerticalAlignment.Center;
        table.Alignment.Set(horizontal, vertical);

        Assert.Equal(horizontal, table.Alignment.Horizontal);
        Assert.Equal(vertical, table.Alignment.Vertical);
    }

    [Fact]
    public void alignment_setter_with_aggregated_alignment_sets_both_properties()
    {
        var table = new DotHtmlTable();

        var alignment = DotAlignment.BottomRight;
        table.Alignment.Set(alignment);

        Assert.Equal(DotHorizontalAlignment.Right, table.Alignment.Horizontal);
        Assert.Equal(DotVerticalAlignment.Bottom, table.Alignment.Vertical);
    }

    [Fact]
    public void alignment_options_setter_sets_both_properties()
    {
        var table = new DotHtmlTable();

        var alignment = new DotAlignmentOptions(DotHorizontalAlignment.Center, DotVerticalAlignment.Top);
        table.Alignment.Set(alignment);

        Assert.Equal(alignment.Horizontal, table.Alignment.Horizontal);
        Assert.Equal(alignment.Vertical, table.Alignment.Vertical);
    }
}