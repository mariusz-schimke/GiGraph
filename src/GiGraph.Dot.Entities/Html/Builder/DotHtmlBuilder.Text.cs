using GiGraph.Dot.Entities.Html.LineBreak;
using GiGraph.Dot.Entities.Html.Text;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Colors;
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
            return Append(DotHtmlText.FromMultilineText(text, lineAlignment));
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
            return Append(new DotHtmlLineBreak(lineAlignment));
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
            return AppendStyled(fontStyle, s => s.SetContent(text, lineAlignment));
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
            return AppendFont(font, e => e.SetContent(text, lineAlignment));
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
            return AppendStyledFont(font, e => e.SetContent(text, lineAlignment));
        }

        /// <summary>
        ///     Initializes and appends a font element with nested font style elements.
        /// </summary>
        /// <param name="text">
        ///     The text to append.
        /// </param>
        /// <param name="name">
        ///     Font name.
        /// </param>
        /// <param name="size">
        ///     Font size.
        /// </param>
        /// <param name="color">
        ///     Font color.
        /// </param>
        /// <param name="style">
        ///     Font style.
        /// </param>
        /// <param name="lineAlignment">
        ///     Specifies horizontal placement of lines if multiline text is specified.
        /// </param>
        public virtual DotHtmlBuilder AppendStyledText(string text, string name = null, double? size = null, DotColor color = null, DotFontStyles? style = null, DotHorizontalAlignment? lineAlignment = null)
        {
            return AppendStyledText(text, new DotStyledFont(name, size, color, style), lineAlignment);
        }
    }
}