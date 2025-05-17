using GiGraph.Dot.Entities.Html.Table;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Html.Table;

public class DotHtmlTableCellSpanTest
{
    [Fact]
    public void span_setter_sets_both_properties()
    {
        var table = new DotHtmlTableCell();
        Assert.Null(table.ColumnSpan);
        Assert.Null(table.RowSpan);

        var columnSpan = 1;
        var rowSpan = 2;
        table.SetSpan(columnSpan, rowSpan);

        Assert.Equal(columnSpan, table.ColumnSpan);
        Assert.Equal(rowSpan, table.RowSpan);

        table.SetSpan();
        Assert.Null(table.ColumnSpan);
        Assert.Null(table.RowSpan);
    }
}