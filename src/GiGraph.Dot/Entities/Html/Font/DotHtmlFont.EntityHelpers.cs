using GiGraph.Dot.Types.Fonts;

namespace GiGraph.Dot.Entities.Html.Font;

public partial class DotHtmlFont
{
    /// <summary>
    ///     Embeds the entity in appropriate HTML tags based on the specified font style.
    /// </summary>
    /// <param name="entity">
    ///     The entity to embed in font and style elements. Only text and table elements are supported (including collections of those).
    ///     See
    ///     <see href="https://www.graphviz.org/doc/info/shapes.html#html">
    ///         grammar
    ///     </see>
    ///     for more details.
    /// </param>
    /// <param name="font">
    ///     The font and/or style to apply.
    /// </param>
    public static DotHtmlFont WithEntity(IDotHtmlEntity entity, DotFont font)
    {
        var result = new DotHtmlFont(font);
        result.SetContent(entity);
        return result;
    }

    /// <summary>
    ///     Embeds the entity in appropriate HTML tags based on the specified font style.
    /// </summary>
    /// <param name="entity">
    ///     The entity to embed in font and style elements. Only text and table elements are supported (including collections of those).
    ///     See
    ///     <see href="https://www.graphviz.org/doc/info/shapes.html#html">
    ///         grammar
    ///     </see>
    ///     for more details.
    /// </param>
    /// <param name="font">
    ///     The font and/or style to apply.
    /// </param>
    public static DotHtmlFont WithEntity(IDotHtmlEntity entity, DotStyledFont font)
    {
        var result = FromStyledFont(font, out var contentElement);
        contentElement.SetContent(entity);
        return result;
    }
}