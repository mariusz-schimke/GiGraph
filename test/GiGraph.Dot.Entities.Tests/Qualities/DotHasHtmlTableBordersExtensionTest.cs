using GiGraph.Dot.Entities.Html.Table;
using GiGraph.Dot.Extensions;
using GiGraph.Dot.Types.Html.Table;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Qualities;

public class DotHasHtmlTableBordersExtensionTest
{
    [Fact]
    public void table_borders_setter_sets_correct_borders()
    {
        var table = new DotHtmlTable();
        Assert.Null(table.Borders);

        table.SetBorders(true);
        Assert.Equal(DotHtmlTableBorders.Top, table.Borders);

        table.SetBorders(true, true);
        Assert.Equal(DotHtmlTableBorders.Top | DotHtmlTableBorders.Right, table.Borders);

        table.SetBorders(true, true, true);
        Assert.Equal(DotHtmlTableBorders.Top | DotHtmlTableBorders.Right | DotHtmlTableBorders.Bottom, table.Borders);

        table.SetBorders(true, true, true, true);
        Assert.Equal(DotHtmlTableBorders.Top | DotHtmlTableBorders.Right | DotHtmlTableBorders.Bottom | DotHtmlTableBorders.Left, table.Borders);

        table.SetBorders();
        Assert.Null(table.Borders);
    }

    [Fact]
    public void borders_setter_is_available_on_cell()
    {
        // This test just makes sure the table cell implements the interface for the extension method to be available.
        // The rest is tested by the other tests here on the table.
        var table = new DotHtmlTableCell();
        table.SetBorders();
        Assert.Null(table.Borders);
    }
}