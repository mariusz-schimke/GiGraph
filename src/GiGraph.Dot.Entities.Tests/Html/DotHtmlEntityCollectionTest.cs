using GiGraph.Dot.Entities.Html;
using GiGraph.Dot.Entities.Html.Font;
using GiGraph.Dot.Entities.Html.Image;
using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Html
{
    public class DotHtmlEntityCollectionTest
    {
        private readonly DotSyntaxOptions _syntaxOptions = new();
        private readonly DotSyntaxRules _syntaxRules = new();

        [Fact]
        public void encoded_html_entity_collection_is_valid_html()
        {
            var tag = new DotHtmlEntityCollection
            {
                new DotHtmlBold("this is an image: "),
                new DotHtmlImage("image.png"),
                new DotHtml("<br align=\"RIGHT\"/>")
            };

            Snapshot.Match(
                ((IDotHtmlEncodable) tag).ToHtml(_syntaxOptions, _syntaxRules),
                "html_entity_collection"
            );
        }
    }
}