using System.Drawing;
using GiGraph.Dot.Entities.Html;
using GiGraph.Dot.Entities.Html.Font;
using GiGraph.Dot.Entities.Html.Table;
using GiGraph.Dot.Entities.Html.Text;
using GiGraph.Dot.Types.Fonts;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Html.FontStyles
{
    public partial class DotHtmlFontTest
    {
        [Fact]
        public void entity_interface_is_correctly_processed()
        {
            var font = new DotStyledFont("Arial", 20, Color.Blue, DotFontStyles.Bold);

            var entityCollection = new DotHtmlEntityCollection(new DotHtmlText("text"));

            var entity1 = DotHtmlFont.SetFont(entityCollection, font);
            var entity2 = DotHtmlFont.SetFont(entityCollection, font.Name, font.Size, font.Color, font.Style);

            Assert.Equal((string) entity1.ToHtml(), entity2.ToHtml());

            Snapshot.Match(
                ((IDotHtmlEntity) entity1).ToHtml(_syntaxOptions, _syntaxRules),
                "html_font_with_entity_content"
            );
        }

        [Fact]
        public void entity_enumerable_is_correctly_styled_with_same_font()
        {
            var entity = DotHtmlFont.SetFont(
                new (IDotHtmlEntity, DotFontStyles)[]
                {
                    (new DotHtmlTable(), DotFontStyles.Normal),
                    (new DotHtmlTable(), DotFontStyles.Italic)
                },
                "Arial",
                10,
                Color.CadetBlue
            );

            Snapshot.Match(
                ((IDotHtmlEntity) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_font_with_entity_enumerable"
            );
        }

        [Fact]
        public void entity_items_are_correctly_styled_with_same_font()
        {
            var entity = DotHtmlFont.SetFont(
                new DotStyledFont("Arial", 10, Color.CadetBlue, DotFontStyles.Bold),
                (new DotHtmlTable(), DotFontStyles.Normal),
                (new DotHtmlTable(), DotFontStyles.Italic)
            );

            Snapshot.Match(
                ((IDotHtmlEntity) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_font_with_entity_array"
            );
        }

        [Fact]
        public void entity_items_are_correctly_styled_with_multiple_fonts()
        {
            var entity = DotHtmlFont.SetFonts(
                (new DotHtmlTable(), new DotStyledFont("Arial", 10, Color.CadetBlue, DotFontStyles.Bold)),
                (new DotHtmlTable(), new DotStyledFont("Arial", 12, Color.Red, DotFontStyles.Italic))
            );

            Snapshot.Match(
                ((IDotHtmlEntity) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_font_array_with_entity"
            );
        }
    }
}