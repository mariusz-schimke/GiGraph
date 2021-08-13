using GiGraph.Dot.Entities.Html;
using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Options;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Html
{
    public class DotHtmlVoidElementTest
    {
        private readonly DotSyntaxOptions _syntaxOptions = new();
        private readonly DotSyntaxRules _syntaxRules = new();

        [Fact]
        public void encoded_html_tag_is_valid_html()
        {
            var tag = new DotHtmlVoidElement("custom-tag-name");
            tag.Attributes.Set("attr1", "value1");

            Snapshot.Match(
                ((IDotHtmlEncodable) tag).ToHtml(_syntaxOptions, _syntaxRules),
                "html_void_tag"
            );
        }

        [Fact]
        public void encoded_html_tag_name_is_upper_case()
        {
            var tag = new DotHtmlVoidElement("custom-tag-name");
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
                "html_void_tag_upper_case_name"
            );
        }

        [Fact]
        public void encoded_html_tag_attributes_are_upper_case()
        {
            var tag = new DotHtmlVoidElement("custom-tag-name");
            tag.Attributes.Set("attr1", "value1");

            var syntaxOptions = new DotSyntaxOptions
            {
                Attributes =
                {
                    Html =
                    {
                        AttributeKeyCasing = DotTextCase.Upper
                    }
                }
            };

            Snapshot.Match(
                ((IDotHtmlEncodable) tag).ToHtml(syntaxOptions, _syntaxRules),
                "html_void_tag_upper_case_attributes"
            );
        }
    }
}