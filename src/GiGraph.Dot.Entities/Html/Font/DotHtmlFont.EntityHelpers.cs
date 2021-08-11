using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Fonts;

namespace GiGraph.Dot.Entities.Html.Font
{
    public partial class DotHtmlFont
    {
        /// <summary>
        ///     Embeds the entity in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="entity">
        ///     The entity to embed in font and style elements. Only text and table elements are supported (including collections of those).
        ///     See
        ///     <see href="https://graphviz.org/doc/info/shapes.html#html">
        ///         grammar
        ///     </see>
        ///     for more details.
        /// </param>
        /// <param name="fontName">
        ///     The name of the font to use.
        /// </param>
        /// <param name="fontStyle">
        ///     The style to apply to the text.
        /// </param>
        /// <param name="fontColor">
        ///     The color to apply to the text.
        /// </param>
        /// <param name="fontSize">
        ///     The size to apply to the font.
        /// </param>
        public static DotHtmlEntity WithEntity(IDotHtmlEntity entity, string fontName = null, double? fontSize = null, DotColor fontColor = null, DotFontStyles? fontStyle = null)
        {
            var result = FromStyledFont(out var contentElement, fontName, fontSize, fontColor, fontStyle);
            contentElement.SetContent(entity);
            return result;
        }

        /// <summary>
        ///     Embeds the entity in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="entity">
        ///     The entity to embed in font and style elements. Only text and table elements are supported (including collections of those).
        ///     See
        ///     <see href="https://graphviz.org/doc/info/shapes.html#html">
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

        /// <summary>
        ///     Embeds the entity in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="entity">
        ///     The entity to embed in font and style elements. Only text and table elements are supported (including collections of those).
        ///     See
        ///     <see href="https://graphviz.org/doc/info/shapes.html#html">
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
    }
}