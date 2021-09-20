using GiGraph.Dot.Entities.Html.Text;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Fonts;

namespace GiGraph.Dot.Entities.Html.Builder
{
    public partial class DotHtmlBuilder
    {
        /// <summary>
        ///     Appends text to this instance and optionally sets alignment for its individual lines if the text is composed of multiple
        ///     lines.
        /// </summary>
        /// <param name="text">
        ///     The text to append.
        /// </param>
        /// <param name="lineAlignment">
        ///     Specifies horizontal placement of lines if multiline text is specified.
        /// </param>
        public virtual DotHtmlBuilder AppendText(string text, DotHorizontalAlignment? lineAlignment = null)
        {
            return AppendEntity(new DotHtmlText(text, lineAlignment));
        }

        /// <summary>
        ///     Appends text with the specified font to this instance.
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