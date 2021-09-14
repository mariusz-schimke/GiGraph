using System.Drawing;
using GiGraph.Dot.Entities.Html;
using GiGraph.Dot.Entities.Html.Font;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;
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
                new DotHtmlBold("bold text")
            };

            tag.Attributes.SetComplex("bgcolor", new DotGradientColor(Color.Red, Color.Blue));

            Snapshot.Match(
                ((IDotHtmlEncodable) tag).ToHtml(_syntaxOptions, _syntaxRules),
                "html_element"
            );
        }

        [Fact]
        public void encoded_html_element_name_is_upper_case()
        {
            var tag = new DotHtmlElement("custom-tag-name");
            tag.Attributes.Set("attr1", "value1");

            var syntaxOptions = new DotSyntaxOptions
            {
                Attributes =
                {
                    Html =
                    {
                        ElementNameCasing = DotTextCase.Upper
                    }
                }
            };

            Snapshot.Match(
                ((IDotHtmlEncodable) tag).ToHtml(syntaxOptions, _syntaxRules),
                "html_element_upper_case_name"
            );
        }

        [Fact]
        public void to_string_returns_html()
        {
            var tag = new DotHtmlElement("custom-tag-name");
            tag.Attributes.SetEnum("align", DotHorizontalAlignment.Center);

            Assert.Equal(tag.ToHtml(), tag.ToString());
        }
    }
}