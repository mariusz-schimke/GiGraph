using GiGraph.Dot.Entities.Html.Table;
using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Html.Table
{
    public class DotHtmlTableRowTest
    {
        private readonly DotSyntaxOptions _syntaxOptions = new();
        private readonly DotSyntaxRules _syntaxRules = new();

        [Fact]
        public void encoded_html_table_row_is_valid_html()
        {
            var row = new DotHtmlTableRow();

            Snapshot.Match(
                ((IDotHtmlEncodable) row).ToHtml(_syntaxOptions, _syntaxRules),
                "html_table_row"
            );
        }
    }
}