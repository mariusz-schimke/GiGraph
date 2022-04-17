using GiGraph.Dot.Entities.Html.Text;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Fonts;

namespace GiGraph.Dot.Entities.Html.Font.Styles;

public partial class DotHtmlFontStyle
{
    /// <summary>
    ///     Embeds the entity in appropriate HTML tags based on the specified font style.
    /// </summary>
    /// <param name="entity">
    ///     The entity to embed in font style elements. Only text and table elements are supported (including collections of those). See
    ///     <see href="https://graphviz.org/doc/info/shapes.html#html">
    ///         grammar
    ///     </see>
    ///     for more details.
    /// </param>
    /// <param name="style">
    ///     The style to apply to the entities.
    /// </param>
    public static DotHtmlEntity WithEntity(IDotHtmlEntity entity, DotFontStyles style)
    {
        var result = FromStyle(style, out var contentElement);
        contentElement?.SetContent(entity);

        return (DotHtmlEntity) result ??
            (entity is DotHtmlEntity htmlEntity ? htmlEntity : new DotHtmlEntity<IDotHtmlEntity>(entity));
    }

    /// <summary>
    ///     Embeds the text in appropriate HTML tags based on the specified font style.
    /// </summary>
    /// <param name="text">
    ///     The text to style.
    /// </param>
    /// <param name="style">
    ///     The style to apply to the text.
    /// </param>
    /// <param name="lineAlignment">
    ///     Specifies horizontal placement of lines if multiline text is specified.
    /// </param>
    public static DotHtmlEntity WithText(string text, DotFontStyles style, DotHorizontalAlignment? lineAlignment = null)
    {
        return WithEntity(new DotHtmlText(text, lineAlignment), style);
    }
}