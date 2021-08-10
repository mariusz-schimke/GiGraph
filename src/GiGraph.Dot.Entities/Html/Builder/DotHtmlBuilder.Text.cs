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

        /// <summary>
        ///     Initializes and appends nested font style elements.
        /// </summary>
        /// <param name="text">
        ///     The text to append.
        /// </param>
        /// <param name="fontStyle">
        ///     The font style to use.
        /// </param>
        public virtual DotHtmlBuilder AppendStyledText(string text, DotFontStyles fontStyle)
        {
            return AppendStyled(fontStyle, s => s.SetContent(text));
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
        public virtual DotHtmlBuilder AppendStyledText(string text, DotFont font)
        {
            return AppendFont(font, e => e.SetContent(text));
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
        public virtual DotHtmlBuilder AppendStyledText(string text, DotStyledFont font)
        {
            return AppendStyledFont(font, e => e.SetContent(text));
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
        public virtual DotHtmlBuilder AppendStyledText(string text, string name = null, double? size = null, DotColor color = null, DotFontStyles? style = null)
        {
            return AppendStyledText(text, new DotStyledFont(name, size, color, style));
        }
    }
}