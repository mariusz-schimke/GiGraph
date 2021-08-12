using GiGraph.Dot.Entities.Html.LineBreak;
using GiGraph.Dot.Entities.Html.Text;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Fonts;

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

        /// <summary>
        ///     Initializes and appends nested font style elements.
        /// </summary>
        /// <param name="text">
        ///     The text to append.
        /// </param>
        /// <param name="fontStyle">
        ///     The font style to use.
        /// </param>
        /// <param name="lineAlignment">
        ///     Specifies horizontal placement of lines if multiline text is specified.
        /// </param>
        public virtual DotHtmlBuilder AppendStyledText(string text, DotFontStyles fontStyle, DotHorizontalAlignment? lineAlignment = null)
        {
            return AppendStyled(fontStyle, s => s.AppendText(text, lineAlignment));
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
        public virtual DotHtmlBuilder AppendStyledText(string text, DotFont font, DotHorizontalAlignment? lineAlignment = null)
        {
            return AppendFont(font, e => e.AppendText(text, lineAlignment));
        }

        /// <summary>
        ///     Initializes and appends a font element with nested font style elements.
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
        public virtual DotHtmlBuilder AppendStyledText(string text, DotStyledFont font, DotHorizontalAlignment? lineAlignment = null)
        {
            return AppendStyledFont(font, e => e.AppendText(text, lineAlignment));
        }
    }
}