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
        /// <param name="font">
        ///     The name of the font to use.
        /// </param>
        /// <param name="size">
        ///     The size to apply to the font.
        /// </param>
        /// <param name="color">
        ///     The color to apply to the text.
        /// </param>
        /// <param name="style">
        ///     The style to apply to the text.
        /// </param>
        /// <param name="lineAlignment">
        ///     Specifies horizontal placement of lines if multiline text is specified.
        /// </param>
        public static DotHtmlEntity WithText(string text, string font = null, double? size = null, DotColor color = null, DotFontStyles? style = null, DotHorizontalAlignment? lineAlignment = null)
        {
            return WithEntity(new DotHtmlText(text, lineAlignment), font, size, color, style);
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