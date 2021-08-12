using GiGraph.Dot.Entities.Html.Text;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Fonts;

namespace GiGraph.Dot.Entities.Html.Builder
{
    // TODO: dla spójności wszystkie metody AppendLine też powinny móc customizować tekst...
    // Może da sie to jakoś obejść, żeby ciągle nie powtarzać szeregu metod?

    public partial class DotHtmlBuilder
    {
        /// <summary>
        ///     Appends the specified text to the builder and optionally sets alignment for its individual lines if the text is composed of
        ///     multiple lines.
        /// </summary>
        /// <param name="text">
        ///     The text to append.
        /// </param>
        /// <param name="lineAlignment">
        ///     Specifies horizontal placement of lines if multiline text is specified.
        /// </param>
        public virtual DotHtmlBuilder AppendText(string text, DotHorizontalAlignment? lineAlignment = null)
        {
            return AppendEntity(DotHtmlText.FromMultilineText(text, lineAlignment));
        }

        /// <summary>
        ///     Initializes and appends a font element.
        /// </summary>
        /// <param name="text">
        ///     The text to append.
        /// </param>
        /// <param name="font">
        ///     The font to use.
        /// </param>
        /// <param name="lineAlignment">
        ///     Specifies horizontal placement of lines if multiline text is specified.
        /// </param>
        public virtual DotHtmlBuilder AppendText(string text, DotFont font, DotHorizontalAlignment? lineAlignment = null)
        {
            return AppendFont(font, e => e.AppendText(text, lineAlignment));
        }
    }
}