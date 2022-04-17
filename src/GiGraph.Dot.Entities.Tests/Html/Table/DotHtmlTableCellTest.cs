using System.Drawing;
using GiGraph.Dot.Entities.Html.Table;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Html.Table;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Html.Table;

public class DotHtmlTableCellTest
{
    private readonly DotSyntaxOptions _syntaxOptions = new();
    private readonly DotSyntaxRules _syntaxRules = new();

    [Fact]
    public void encoded_html_table_cell_is_valid_html()
    {
        var cell = new DotHtmlTableCell
        {
            Id = "id",

            Height = 10,
            Width = 11,

            CellPadding = 20,
            CellSpacing = 21,
            FixedSize = true,

            Borders = DotHtmlTableBorders.Vertical,
            BorderWidth = 23,
            BorderColor = Color.Blue,

            HorizontalAlignment = DotHtmlTableCellHorizontalAlignment.Justify,
            HorizontalLineAlignment = DotHorizontalAlignment.Center,
            VerticalAlignment = DotVerticalAlignment.Bottom,

            Style = DotHtmlTableStyles.Radial,

            BackgroundColor = Color.Red,
            GradientFillAngle = 15,

            Title = "Title",
            Tooltip = "Tooltip",
            Href = "https://www.google.pl",
            Target = "_blank",

            ColumnSpan = 2,
            RowSpan = 3,

            PortName = "port name"
        };

        Snapshot.Match(
            ((IDotHtmlEncodable) cell).ToHtml(_syntaxOptions, _syntaxRules),
            "html_table_cell"
        );
    }
}