using GiGraph.Dot.Entities.Html;
using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Options;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Html
{
    public class DotHtmlEntitiesTest
    {
        private readonly DotSyntaxOptions _syntaxOptions = new();
        private readonly DotSyntaxRules _syntaxRules = new();

        [Fact]
        public void encoded_html_table_is_valid_html()
        {
            var tag = new DotHtmlTag("custom-tag-name");
            tag.Attributes.Set("attr1", "value1");

            Snapshot.Match(
                ((IDotHtmlEncodable) tag).ToHtml(_syntaxOptions, _syntaxRules),
                "html_tag"
            );
        }
    }
}