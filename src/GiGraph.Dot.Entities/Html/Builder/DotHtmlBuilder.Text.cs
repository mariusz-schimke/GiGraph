using GiGraph.Dot.Entities.Html.LineBreak;
using GiGraph.Dot.Entities.Html.Text;
using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html.Builder
{
    public partial class DotHtmlBuilder
    {
        /// <summary>
        ///     Appends the specified text to the builder and optionally sets alignment for its individual lines if the text is composed of
        ///     multiple lines.
        /// </summary>
        /// <param name="text">
        ///     The text to append.
        /// </param>
        /// <param name="horizontalAlignment">
        ///     Specifies horizontal placement of lines if multiline text is specified.
        /// </param>
        public virtual DotHtmlBuilder AppendText(string text, DotHorizontalAlignment? horizontalAlignment = null)
        {
            return Append(DotHtmlText.FromMultilineText(text, horizontalAlignment));
        }

        /// <summary>
        ///     Initializes and appends a font element.
        /// </summary>
        /// <param name="text">
        ///     The text to append.
        /// </param>
        /// <param name="horizontalAlignment">
        ///     Specifies horizontal placement of the line.
        /// </param>
        public virtual DotHtmlBuilder AppendLine(string text, DotHorizontalAlignment? horizontalAlignment = null)
        {
            AppendText(text, horizontalAlignment);
            return AppendLine(horizontalAlignment);
        }

        /// <summary>
        ///     Initializes and appends a font element.
        /// </summary>
        /// <param name="horizontalAlignment">
        ///     Specifies horizontal placement of the last line of text.
        /// </param>
        public virtual DotHtmlBuilder AppendLine(DotHorizontalAlignment? horizontalAlignment = null)
        {
            return Append(new DotHtmlLineBreak(horizontalAlignment));
        }
    }
}