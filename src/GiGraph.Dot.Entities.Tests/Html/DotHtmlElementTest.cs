using System.Drawing;
using GiGraph.Dot.Entities.Html;
using GiGraph.Dot.Entities.Html.Font;
using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Colors;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Html
{
    public class DotHtmlEntitiesTest
    {
        private readonly DotSyntaxOptions _syntaxOptions = new();
        private readonly DotSyntaxRules _syntaxRules = new();

        [Fact]
        public void encoded_empty_html_element_is_valid_html()
        {
            var tag = new DotHtmlElement("custom-tag-name");
            tag.Attributes.SetEnum("align", DotHorizontalAlignment.Center);

            Snapshot.Match(
                ((IDotHtmlEncodable) tag).ToHtml(_syntaxOptions, _syntaxRules),
                "html_empty_element"
            );
        }

        [Fact]
        public void encoded_html_element_with_children_is_valid_html()
        {
            var tag = new DotHtmlElement("custom-tag-name")
            {
                Children =
                {
                    new DotHtmlBold("bold text")
                }
            };

            tag.Attributes.SetComplex("bgcolor", new DotGradientColor(Color.Red, Color.Blue));

            Snapshot.Match(
                ((IDotHtmlEncodable) tag).ToHtml(_syntaxOptions, _syntaxRules),
                "html_element"
            );
        }
    }
}