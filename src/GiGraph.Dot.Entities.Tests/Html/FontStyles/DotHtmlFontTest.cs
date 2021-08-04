using System.Drawing;
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
    public class DotHtmlFontTest
    {
        private readonly DotSyntaxOptions _syntaxOptions = new();
        private readonly DotSyntaxRules _syntaxRules = new();

        [Fact]
        public void encoded_html_font_tag_is_valid_html()
        {
            var tag = new DotHtmlFont("arial", 10, Color.Red);

            Snapshot.Match(
                ((IDotHtmlEncodable) tag).ToHtml(_syntaxOptions, _syntaxRules),
                "html_font"
            );
        }

        [Fact]
        public void text_is_not_embedded_in_any_tag_for_no_font_params()
        {
            var entity = DotHtmlFont.StyleText("text");

            Snapshot.Match(
                ((IDotHtmlEncodable) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_text_font_no_params"
            );
        }

        [Fact]
        public void text_is_embedded_in_font_tag_only_with_all_set_attributes()
        {
            var entity = DotHtmlFont.StyleText("text", "Arial", 20, Color.Blue);

            Snapshot.Match(
                ((IDotHtmlEncodable) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_text_font_arial_20_blue"
            );
        }

        [Fact]
        public void text_is_embedded_in_font_tag_only_with_all_set_attributes_and_style()
        {
            var font = new DotStyledFont("Arial", 20, Color.Blue, DotFontStyles.Overline | DotFontStyles.Subscript);

            var entity1 = DotHtmlFont.StyleText("text", font);
            var entity2 = DotHtmlFont.StyleText("text", font.Name, font.Size, font.Color, font.Style);

            Assert.Equal((string) entity1.ToHtml(), entity2.ToHtml());

            Snapshot.Match(
                ((IDotHtmlEncodable) entity1).ToHtml(_syntaxOptions, _syntaxRules),
                "html_text_font_arial_20_blue_overline_subscript"
            );
        }

        [Fact]
        public void entity_collection_is_correctly_processed_for_font()
        {
            var font = new DotStyledFont("Arial", 20, Color.Blue, DotFontStyles.Bold);

            IDotHtmlEntity entityCollection = new DotHtmlEntityCollection(new DotHtmlText("text"));

            var entity1 = DotHtmlFont.StyleEntity(entityCollection, font);
            var entity2 = DotHtmlFont.StyleEntity(entityCollection, font.Name, font.Size, font.Color, font.Style);

            Assert.Equal((string) entity1.ToHtml(), entity2.ToHtml());

            Snapshot.Match(
                entity1.ToHtml(_syntaxOptions, _syntaxRules),
                "html_text_font_entity_collection"
            );
        }

        [Fact]
        public void entity_interface_is_correctly_processed_for_font()
        {
            var font = new DotStyledFont("Arial", 20, Color.Blue, DotFontStyles.Bold);

            var table = new DotHtmlTable();
            table.Children.AddRow(r => r.Children.AddCell("text"));
            DotHtmlEntity htmlEntity = table;

            var entity1 = DotHtmlFont.StyleEntity(htmlEntity, font);
            var entity2 = DotHtmlFont.StyleEntity(htmlEntity, font.Name, font.Size, font.Color, font.Style);

            Assert.Equal((string) entity1.ToHtml(), entity2.ToHtml());

            Snapshot.Match(
                ((IDotHtmlEntity) entity1).ToHtml(_syntaxOptions, _syntaxRules),
                "html_text_font_interface"
            );
        }
    }
}