using GiGraph.Dot.Entities.Html;
using GiGraph.Dot.Entities.Html.Font;
using GiGraph.Dot.Entities.Html.Table;
using GiGraph.Dot.Entities.Html.Text;
using GiGraph.Dot.Output;
using GiGraph.Dot.Types.Fonts;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Html.FontStyles
{
    public partial class DotHtmlFontStyleTest
    {
        [Fact]
        public void text_is_not_embedded_in_any_tag_for_normal_style()
        {
            var entity = DotHtmlFontStyle.SetStyle("text", DotFontStyles.Normal);

            Snapshot.Match(
                ((IDotHtmlEncodable) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_text_styling_normal_text"
            );
        }

        [Fact]
        public void text_is_embedded_in_bold_tag()
        {
            var entity = DotHtmlFontStyle.SetStyle("text", DotFontStyles.Bold);

            Snapshot.Match(
                ((IDotHtmlEncodable) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_text_styling_bold_text"
            );
        }

        [Fact]
        public void text_is_embedded_in_bold_italic_tags()
        {
            var entity = DotHtmlFontStyle.SetStyle("text", DotFontStyles.Bold | DotFontStyles.Italic);

            Snapshot.Match(
                ((IDotHtmlEncodable) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_text_styling_bold_italic_text"
            );
        }

        [Fact]
        public void text_is_embedded_in_all_tags()
        {
            var entity = DotHtmlFontStyle.SetStyle(
                "text",
                DotFontStyles.Bold | DotFontStyles.Italic | DotFontStyles.Underline | DotFontStyles.Overline | DotFontStyles.Subscript | DotFontStyles.Superscript
            );

            Snapshot.Match(
                ((IDotHtmlEncodable) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_text_styling_all_tags_text"
            );
        }

        [Fact]
        public void entity_interface_is_correctly_styled()
        {
            IDotHtmlEntity entityCollection = new DotHtmlEntityCollection(new DotHtmlText("text"));
            var entity = DotHtmlFontStyle.SetStyle(entityCollection, DotFontStyles.Bold);

            Snapshot.Match(
                ((IDotHtmlEncodable) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_entity_interface_styling"
            );
        }

        [Fact]
        public void entity_is_correctly_styled()
        {
            var table = new DotHtmlTable();
            table.AddRow(r => r.AddCell("text"));
            DotHtmlEntity htmlEntity = table;

            var entity = DotHtmlFontStyle.SetStyle(htmlEntity, DotFontStyles.Bold);

            Snapshot.Match(
                ((IDotHtmlEntity) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_entity_collection_styling"
            );
        }

        [Fact]
        public void text_items_are_correctly_styled()
        {
            var entity = DotHtmlFontStyle.SetStyle(
                ("Foo ", DotFontStyles.Normal),
                ("Bar ", DotFontStyles.Bold),
                ("Baz ", DotFontStyles.Italic | DotFontStyles.Underline)
            );

            Snapshot.Match(
                ((IDotHtmlEntity) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_text_multistyling"
            );
        }

        [Fact]
        public void entity_items_are_correctly_styled()
        {
            var entity = DotHtmlFontStyle.SetStyle(
                (new DotHtmlTable(), DotFontStyles.Normal),
                (new DotHtmlTable(), DotFontStyles.Bold)
            );

            Snapshot.Match(
                ((IDotHtmlEntity) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_entity_multistyling"
            );
        }
    }
}