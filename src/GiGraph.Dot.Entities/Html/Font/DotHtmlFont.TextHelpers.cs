using GiGraph.Dot.Entities.Html.Text;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Fonts;

namespace GiGraph.Dot.Entities.Html.Font
{
    public partial class DotHtmlFont
    {
        /// <summary>
        ///     Embeds the entity in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="text">
        ///     The text to embed in font and style elements.
        /// </param>
        /// <param name="fontName">
        ///     The name of the font to use.
        /// </param>
        /// <param name="fontSize">
        ///     The size to apply to the font.
        /// </param>
        /// <param name="fontColor">
        ///     The color to apply to the text.
        /// </param>
        /// <param name="fontStyle">
        ///     The style to apply to the text.
        /// </param>
        /// <param name="lineAlignment">
        ///     Specifies horizontal placement of lines if multiline text is specified.
        /// </param>
        public static DotHtmlEntity WithText(string text, string fontName = null, double? fontSize = null, DotColor fontColor = null, DotFontStyles? fontStyle = null, DotHorizontalAlignment? lineAlignment = null)
        {
            return WithEntity(new DotHtmlText(text, lineAlignment), fontName, fontSize, fontColor, fontStyle);
        }

        /// <summary>
        ///     Embeds the text in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="text">
        ///     The text to embed in font and style elements.
        /// </param>
        /// <param name="font">
        ///     The font and/or style to apply.
        /// </param>
        /// <param name="lineAlignment">
        ///     Specifies horizontal placement of lines if multiline text is specified.
        /// </param>
        public static DotHtmlFont WithText(string text, DotFont font, DotHorizontalAlignment? lineAlignment = null)
        {
            return WithEntity(new DotHtmlText(text, lineAlignment), font);
        }

        /// <summary>
        ///     Embeds the text in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="text">
        ///     The text to embed in font and style elements.
        /// </param>
        /// <param name="font">
        ///     The font and/or style to apply.
        /// </param>
        /// <param name="lineAlignment">
        ///     Specifies horizontal placement of lines if multiline text is specified.
        /// </param>
        public static DotHtmlFont WithText(string text, DotStyledFont font, DotHorizontalAlignment? lineAlignment = null)
        {
            return WithEntity(new DotHtmlText(text, lineAlignment), font);
        }
    }
}