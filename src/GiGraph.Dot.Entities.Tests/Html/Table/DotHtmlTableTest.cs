using System.Drawing;
using GiGraph.Dot.Entities.Html.Table;
using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Html.Table;
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
    }
}