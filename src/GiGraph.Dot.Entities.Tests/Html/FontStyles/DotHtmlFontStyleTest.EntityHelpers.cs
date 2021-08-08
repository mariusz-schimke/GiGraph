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
        public void entity_is_correctly_styled()
        {
            var entityCollection = new DotHtmlEntityCollection(new DotHtmlText("text"));
            var entity = DotHtmlFontStyle.SetStyle(entityCollection, DotFontStyles.Bold);

            Snapshot.Match(
                ((IDotHtmlEncodable) entity).ToHtml(_syntaxOptions, _syntaxRules),
                "html_entity_styling"
            );
        }

        [Fact]
        public void entity_items_are_correctly_styled()
        {
            var entity = DotHtmlFontStyle.SetStyles(
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