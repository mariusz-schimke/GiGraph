using GiGraph.Dot.Entities.Html.Table;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Html.Table;

public class DotHtmlTableFormatTest
{
    [Fact]
    public void format_setter_sets_both_properties()
    {
        var table = new DotHtmlTable();
        Assert.Null(table.ColumnFormat);
        Assert.Null(table.RowFormat);

        var columnFormat = "cell";
        var rowFormat = "row";
        table.SetFormat(columnFormat, rowFormat);

        Assert.Equal(columnFormat, table.ColumnFormat);
        Assert.Equal(rowFormat, table.RowFormat);

        table.SetFormat(null, null);
        Assert.Null(table.ColumnFormat);
        Assert.Null(table.RowFormat);
    }
}