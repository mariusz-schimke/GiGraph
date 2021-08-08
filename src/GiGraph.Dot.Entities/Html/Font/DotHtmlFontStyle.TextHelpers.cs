using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Entities.Html.Text;
using GiGraph.Dot.Types.Fonts;

namespace GiGraph.Dot.Entities.Html.Font
{
    public partial class DotHtmlFontStyle
    {
        /// <summary>
        ///     Embeds the pieces of text in appropriate HTML tags each, based on the font styles specified for them.
        /// </summary>
        /// <param name="items">
        ///     The pieces of text to style.
        /// </param>
        public static DotHtmlEntity SetStyles(params (string Text, DotFontStyles Style)[] items)
        {
            return SetStyles((IEnumerable<(string Text, DotFontStyles Style)>) items);
        }

        /// <summary>
        ///     Embeds the pieces of text in appropriate HTML tags each, based on the font styles specified for them.
        /// </summary>
        /// <param name="style">
        ///     The common style to apply to the text.
        /// </param>
        /// <param name="items">
        ///     The HTML entities to style.
        /// </param>
        public static DotHtmlEntity SetStyles(DotFontStyles style, params (string Text, DotFontStyles Style)[] items)
        {
            return SetStyles(items, style);
        }

        /// <summary>
        ///     Embeds the pieces of text in appropriate HTML tags each, based on the font styles specified for them.
        /// </summary>
        /// <param name="items">
        ///     The pieces of text to style.
        /// </param>
        /// <param name="style">
        ///     The common style to apply to the text.
        /// </param>
        public static DotHtmlEntity SetStyles(IEnumerable<(string Text, DotFontStyles Style)> items, DotFontStyles? style = null)
        {
            return SetStyle(
                new DotHtmlEntityCollection(
                    items.Select(item => SetStyle(item.Text, item.Style))
                ),
                style.GetValueOrDefault(DotFontStyles.Normal)
            );
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
        public static DotHtmlEntity SetStyle(string text, DotFontStyles style)
        {
            return SetStyle(new DotHtmlText(text), style);
        }
    }
}