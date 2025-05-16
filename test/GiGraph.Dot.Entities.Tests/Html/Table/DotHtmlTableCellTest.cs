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

            CellPadding = 20,
            CellSpacing = 21,

            Borders = DotHtmlTableBorders.Vertical,

            ColumnSpan = 2,
            RowSpan = 3,

            PortName = "port name",

            Style =
            {
                BorderWidth = 23,
                BorderColor = Color.Blue,

                BackgroundColor = Color.Red,
                GradientFillAngle = 15,
                RadialFill = true
            },

            Size =
            {
                Height = 10,
                Width = 11,
                FixedSize = true
            },

            Hyperlink =
            {
                Title = "Title",
                Tooltip = "Tooltip",
                Href = "https://www.google.pl",
                Target = "_blank"
            },

            Alignment =
            {
                Horizontal = DotHtmlTableCellHorizontalAlignment.Justify,
                Vertical = DotVerticalAlignment.Bottom,
                Line = DotHorizontalAlignment.Center
            }
        };

        Snapshot.Match(
            ((IDotHtmlEncodable) cell).ToHtml(_syntaxOptions, _syntaxRules),
            "html_table_cell"
        );
    }
}