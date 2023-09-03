using GiGraph.Dot.Entities.Html;
using GiGraph.Dot.Entities.Html.Font.Styles;
using GiGraph.Dot.Entities.Html.Text;
using GiGraph.Dot.Output.Qualities;
using GiGraph.Dot.Types.Fonts;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Html.FontStyles;

public partial class DotHtmlFontStyleTest
{
    [Fact]
    public void entity_factory_method_generates_correct_style()
    {
        var entityCollection = new DotHtmlEntityCollection(new DotHtmlText("text"));
        var entity = DotHtmlFontStyle.WithEntity(entityCollection, DotFontStyles.Bold);

        Snapshot.Match(
            ((IDotHtmlEncodable) entity).ToHtml(_syntaxOptions, _syntaxRules),
            "html_entity_styling_bold"
        );
    }

    [Fact]
    public void entity_factory_method_returns_source_entity_for_normal_font_style()
    {
        var entityCollection = new DotHtmlEntityCollection(new DotHtmlText("text"));
        var entity = DotHtmlFontStyle.WithEntity(entityCollection, DotFontStyles.Normal);

        Snapshot.Match(
            ((IDotHtmlEncodable) entity).ToHtml(_syntaxOptions, _syntaxRules),
            "html_entity_styling_normal"
        );
    }
}