using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Entities.Html.Text;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Fonts;

namespace GiGraph.Dot.Entities.Html.Font
{
    public partial class DotHtmlFont
    {
        /// <summary>
        ///     Embeds the text in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="text">
        ///     The text to embed in font and style elements.
        /// </param>
        /// <param name="color">
        ///     The color to apply to the text.
        /// </param>
        /// <param name="style">
        ///     The style to apply to the text.
        /// </param>
        /// <param name="name">
        ///     The name of the font to use.
        /// </param>
        /// <param name="size">
        ///     The size to apply to the font.
        /// </param>
        public static DotHtmlEntity SetFont(string text, string name = null, double? size = null, DotColor color = null, DotFontStyles? style = null)
        {
            return SetFont(new DotHtmlText(text), name, size, color, style);
        }

        /// <summary>
        ///     Embeds the text in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="text">
        ///     The text to embed in font and style elements.
        /// </param>
        /// <param name="font">
        ///     The font and style to apply.
        /// </param>
        public static DotHtmlEntity SetFont(string text, DotStyledFont font)
        {
            return SetFont(text, font.Name, font.Size, font.Color, font.Style);
        }

        /// <summary>
        ///     Embeds the pieces of text in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="color">
        ///     The color to apply to the text.
        /// </param>
        /// <param name="items">
        ///     The pieces of text to style.
        /// </param>
        /// <param name="name">
        ///     The name of the font to use.
        /// </param>
        /// <param name="size">
        ///     The size to apply to the font.
        /// </param>
        /// <param name="style">
        ///     The style to apply to the text.
        /// </param>
        public static DotHtmlEntity SetFont(IEnumerable<(string Text, DotFontStyles Style)> items, string name = null, double? size = null, DotColor color = null, DotFontStyles? style = null)
        {
            return SetFont(DotHtmlFontStyle.SetStyles(items), name, size, color, style);
        }

        /// <summary>
        ///     Embeds the pieces of text in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="items">
        ///     The pieces of text to style.
        /// </param>
        /// <param name="font">
        ///     The font and style to apply.
        /// </param>
        public static DotHtmlEntity SetFont(DotStyledFont font, params (string Text, DotFontStyles Style)[] items)
        {
            return SetFont(items, font);
        }

        /// <summary>
        ///     Embeds the pieces of text in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="items">
        ///     The pieces of text to style.
        /// </param>
        /// <param name="font">
        ///     The font and style to apply.
        /// </param>
        public static DotHtmlEntity SetFont(IEnumerable<(string Text, DotFontStyles Style)> items, DotStyledFont font)
        {
            return SetFont(DotHtmlFontStyle.SetStyles(items), font);
        }

        /// <summary>
        ///     Embeds the pieces of text in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="items">
        ///     The pieces of text to style.
        /// </param>
        public static DotHtmlEntityCollection SetFonts(params (string Text, DotStyledFont Font)[] items)
        {
            return SetFonts((IEnumerable<(string Text, DotStyledFont Font)>) items);
        }

        /// <summary>
        ///     Embeds the pieces of text in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="font">
        ///     The common font to apply to all specified entities.
        /// </param>
        /// <param name="items">
        ///     The pieces of text to style.
        /// </param>
        public static DotHtmlEntity SetFonts(DotStyledFont font, params (string Text, DotStyledFont Font)[] items)
        {
            return SetFonts(items, font);
        }

        /// <summary>
        ///     Embeds the pieces of text in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="items">
        ///     The pieces of text to style.
        /// </param>
        public static DotHtmlEntityCollection SetFonts(IEnumerable<(string Text, DotStyledFont Font)> items)
        {
            return new DotHtmlEntityCollection(
                items.Select(item => SetFont(item.Text, item.Font))
            );
        }

        /// <summary>
        ///     Embeds the pieces of text in appropriate HTML tags based on the specified font style.
        /// </summary>
        /// <param name="items">
        ///     The pieces of text to style.
        /// </param>
        /// <param name="font">
        ///     The common font to apply to all specified pieces of text.
        /// </param>
        public static DotHtmlEntity SetFonts(IEnumerable<(string Text, DotStyledFont Font)> items, DotStyledFont font)
        {
            return SetFont(SetFonts(items), font);
        }
    }
}