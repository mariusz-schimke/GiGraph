using GiGraph.Dot.Entities.Html;
using GiGraph.Dot.Entities.Html.Font;
using GiGraph.Dot.Entities.Html.Table;
using GiGraph.Dot.Entities.Html.Text;
using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.Fonts;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Html.FontStyles
{
    public class DotHtmlFontStylingTest
    {
        private readonly DotSyntaxOptions _syntaxOptions = new();
        private readonly DotSyntaxRules _syntaxRules = new();

        [Fact]
        public void text_is_not_embedded_in_any_tag()
        {
            var entity = DotHtmlFontStyle.StyleText("text", DotFontStyles.Normal);

            Snapshot.Match(
                ((IDotHtmlEncodable) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_text_styling_normal_text"
            );
        }

        [Fact]
        public void text_is_embedded_in_bold_tag()
        {
            var entity = DotHtmlFontStyle.StyleText("text", DotFontStyles.Bold);

            Snapshot.Match(
                ((IDotHtmlEncodable) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_text_styling_bold_text"
            );
        }

        [Fact]
        public void text_is_embedded_in_bold_italic_tags()
        {
            var entity = DotHtmlFontStyle.StyleText("text", DotFontStyles.Bold | DotFontStyles.Italic);

            Snapshot.Match(
                ((IDotHtmlEncodable) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_text_styling_bold_italic_text"
            );
        }

        [Fact]
        public void text_is_embedded_in_all_tags()
        {
            var entity = DotHtmlFontStyle.StyleText(
                "text",
                DotFontStyles.Bold | DotFontStyles.Italic | DotFontStyles.Underline | DotFontStyles.Overline | DotFontStyles.Subscript | DotFontStyles.Superscript
            );

            Snapshot.Match(
                ((IDotHtmlEncodable) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_text_styling_all_tags_text"
            );
        }

        [Fact]
        public void entity_collection_is_correctly_processed()
        {
            IDotHtmlEntity entityCollection = new DotHtmlEntityCollection(new DotHtmlText("text"));
            var entity = DotHtmlFontStyle.StyleEntity(entityCollection, DotFontStyles.Bold);

            Snapshot.Match(
                entity.ToHtml(_syntaxOptions, _syntaxRules),
                "html_entity_collection_styling"
            );
        }

        [Fact]
        public void entity_interface_is_correctly_processed()
        {
            var table = new DotHtmlTable();
            table.Children.AddRow(r => r.Children.AddCell("text"));
            DotHtmlEntity htmlEntity = table;

            var entity = DotHtmlFontStyle.StyleEntity(htmlEntity, DotFontStyles.Bold);

            Snapshot.Match(
                ((IDotHtmlEntity) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_entity_interface_styling"
            );
        }
    }
}