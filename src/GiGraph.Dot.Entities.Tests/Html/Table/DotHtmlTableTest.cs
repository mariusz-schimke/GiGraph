using System.Drawing;
using GiGraph.Dot.Entities.Html.Table;
using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Fonts;
using GiGraph.Dot.Types.Html.Table;
using GiGraph.Dot.Types.Images;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Html.Table
{
    public class DotHtmlTableTest
    {
        private readonly DotSyntaxOptions _syntaxOptions = new();
        private readonly DotSyntaxRules _syntaxRules = new();

        [Fact]
        public void encoded_html_table_is_valid_html()
        {
            var table = new DotHtmlTable
            {
                Id = "id",

                Height = 10,
                Width = 11,

                CellPadding = 20,
                CellSpacing = 21,
                CellBorderWidth = 22,
                FixedSize = false,

                Borders = DotHtmlTableBorders.Vertical,
                BorderWidth = 23,
                BorderColor = Color.Blue,

                HorizontalAlignment = DotHorizontalAlignment.Right,
                VerticalAlignment = DotVerticalAlignment.Top,

                Style = DotHtmlTableStyles.Radial | DotHtmlTableStyles.Rounded,

                BackgroundColor = new DotGradientColor(Color.Red, Color.Blue),
                GradientFillAngle = 15,

                Title = "Title",
                Tooltip = "Tooltip",
                Href = "https://www.google.pl",
                Target = "_blank",

                ColumnFormat = "column format",
                RowFormat = "row format",

                PortName = "port name"
            };

            Snapshot.Match(
                ((IDotHtmlEncodable) table).ToHtml(_syntaxOptions, _syntaxRules),
                "html_table"
            );
        }

        [Fact]
        public void encoded_html_table_with_rows_and_cells_is_valid_html()
        {
            var font = new DotStyledFont("Arial", 10, Color.Red, DotFontStyles.Bold);

            var table = new DotHtmlTable
            {
                Id = "tableId"
            };

            table.Children.AddRow(row =>
            {
                row.Children.AddCell(cell => cell.Id = "cellId1");
                row.Children.AddCell("cell2", cell => cell.Id = "cellId2");
                row.Children.AddCell("cell3", font.Style!.Value, font.Name, font.Size, font.Color, cell => cell.Id = "cell3");
                row.Children.AddCell("cell4", font, cell => cell.Id = "cell4");

                row.Children.AddCells("cell5", "cell6");
                row.Children.AddCells(new[] { "cell7", "cell8" }, (cell, i) => cell.Id = $"cell{i}");
                row.Children.AddCells(new[] { "cell9", "cell10" }, font, (cell, i) => cell.Id = $"cell{i}");
                row.Children.AddCells(new[] { "cell11", "cell12" }, font.Style!.Value, font.Name, font.Size, font.Color, (cell, i) => cell.Id = $"cell{i}");

                row.Children.AddImageCell("image.png", DotImageScaling.None, cell => cell.Id = "img-cell");
            });

            table.Children.AddHorizontalRule();

            Snapshot.Match(
                ((IDotHtmlEncodable) table).ToHtml(_syntaxOptions, _syntaxRules),
                "html_table_with_rows"
            );
        }
    }
}