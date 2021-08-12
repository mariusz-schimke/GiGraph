using GiGraph.Dot.Entities.Html.LineBreak;
using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html.Builder
{
    public partial class DotHtmlBuilder
    {
        /// <summary>
        ///     Initializes and appends a font element.
        /// </summary>
        /// <param name="text">
        ///     The text to append.
        /// </param>
        /// <param name="lineAlignment">
        ///     Specifies horizontal placement of the line.
        /// </param>
        public virtual DotHtmlBuilder AppendLine(string text, DotHorizontalAlignment? lineAlignment = null)
        {
            AppendText(text, lineAlignment);
            return AppendLine(lineAlignment);
        }

        /// <summary>
        ///     Initializes and appends a font element.
        /// </summary>
        /// <param name="lineAlignment">
        ///     Specifies horizontal placement of the last line of text.
        /// </param>
        public virtual DotHtmlBuilder AppendLine(DotHorizontalAlignment? lineAlignment = null)
        {
            return AppendEntity(DotHtmlLineBreak.Instance(lineAlignment));
        }
    }
}