using GiGraph.Dot.Entities.Html.Table;
using GiGraph.Dot.Entities.Qualities;
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
        TestSettingBorders(table);
    }

    [Fact]
    public void table_cell_borders_setter_sets_correct_borders()
    {
        var cell = new DotHtmlTableCell();
        TestSettingBorders(cell);
    }

    private void TestSettingBorders<T>(T entity)
        where T : IDotHasHtmlTableBorders
    {
        Assert.Null(entity.Borders);

        entity.SetBorders(true);
        Assert.Equal(DotHtmlTableBorders.Top, entity.Borders);

        entity.SetBorders(true, true);
        Assert.Equal(DotHtmlTableBorders.Top | DotHtmlTableBorders.Right, entity.Borders);

        entity.SetBorders(true, true, true);
        Assert.Equal(DotHtmlTableBorders.Top | DotHtmlTableBorders.Right | DotHtmlTableBorders.Bottom, entity.Borders);

        entity.SetBorders(true, true, true, true);
        Assert.Equal(DotHtmlTableBorders.Top | DotHtmlTableBorders.Right | DotHtmlTableBorders.Bottom | DotHtmlTableBorders.Left, entity.Borders);

        entity.SetBorders();
        Assert.Null(entity.Borders);
    }
}