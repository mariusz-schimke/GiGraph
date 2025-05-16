using GiGraph.Dot.Entities.Html.Table;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Html.Table;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Html.Table;

public class DotHtmlTableCellAlignmentTest
{
    [Fact]
    public void alignment_options_setter_sets_both_properties()
    {
        var table = new DotHtmlTableCell();

        var alignment = new DotHtmlTableCellAlignmentOptions(DotHtmlTableCellHorizontalAlignment.Justify, DotVerticalAlignment.Top);
        table.Alignment.Set(alignment);

        Assert.Equal(alignment.Horizontal, table.Alignment.Horizontal);
        Assert.Equal(alignment.Vertical, table.Alignment.Vertical);
    }
}