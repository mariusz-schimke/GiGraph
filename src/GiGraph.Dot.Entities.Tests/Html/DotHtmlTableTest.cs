using System.Drawing;
using GiGraph.Dot.Entities.Html.Table;
using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Html.Table;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Html
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
                Style = DotHtmlTableStyles.Radial | DotHtmlTableStyles.Rounded,
                Borders = DotHtmlTableBorders.All,
                BackgroundColor = new DotGradientColor(Color.Red, Color.Blue)
            };

            Snapshot.Match(
                ((IDotHtmlEncodable) table).ToHtml(_syntaxOptions, _syntaxRules),
                "html_table_single_line"
            );
        }
    }
}