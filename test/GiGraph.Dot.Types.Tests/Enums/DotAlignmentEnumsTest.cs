using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Html.Table;
using Xunit;

namespace GiGraph.Dot.Types.Tests.Enums;

public class DotAlignmentEnumsTest
{
    [Fact]
    public void horizontal_alignment_continues_vertical_alignment()
    {
        var horizontalAlignmentValues = Enum.GetValues<DotHorizontalAlignment>().Cast<int>();
        var verticalAlignmentValues = Enum.GetValues<DotVerticalAlignment>().Cast<int>();

        Assert.True(horizontalAlignmentValues.Min() > verticalAlignmentValues.Min());
    }

    [Fact]
    public void html_table_cell_horizontal_alignment_continues_horizontal_alignment()
    {
        var horizontalAlignmentValues = Enum.GetValues<DotHorizontalAlignment>().Cast<int>().ToArray();
        var htmlHorizontalAlignmentValues = Enum.GetValues<DotHtmlTableCellHorizontalAlignment>().Cast<int>().ToArray();

        Assert.True(htmlHorizontalAlignmentValues.Distinct().Count() == htmlHorizontalAlignmentValues.Length);
        Assert.True(htmlHorizontalAlignmentValues.Max() > horizontalAlignmentValues.Max());
    }
}