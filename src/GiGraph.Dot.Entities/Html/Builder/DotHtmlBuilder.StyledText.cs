using GiGraph.Dot.Entities.Html.Font.Styles;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Fonts;

namespace GiGraph.Dot.Entities.Html.Builder
{
    public partial class DotHtmlBuilder
    {
        /// <summary>
        ///     Appends bold text to this instance.
        /// </summary>
        /// <param name="text">
        ///     The text to append.
        /// </param>
        /// <param name="lineAlignment">
        ///     Specifies horizontal placement of lines if multiline text is specified.
        /// </param>
        public virtual DotHtmlBuilder AppendBoldText(string text, DotHorizontalAlignment? lineAlignment = null)
        {
            return AppendEntity(new DotHtmlBold(text, lineAlignment));
        }

        /// <summary>
        ///     Appends italic text to this instance.
        /// </summary>
        /// <param name="text">
        ///     The text to append.
        /// </param>
        /// <param name="lineAlignment">
        ///     Specifies horizontal placement of lines if multiline text is specified.
        /// </param>
        public virtual DotHtmlBuilder AppendItalicText(string text, DotHorizontalAlignment? lineAlignment = null)
        {
            return AppendEntity(new DotHtmlItalic(text, lineAlignment));
        }

        /// <summary>
        ///     Appends underline text to this instance.
        /// </summary>
        /// <param name="text">
        ///     The text to append.
        /// </param>
        /// <param name="lineAlignment">
        ///     Specifies horizontal placement of lines if multiline text is specified.
        /// </param>
        public virtual DotHtmlBuilder AppendUnderlineText(string text, DotHorizontalAlignment? lineAlignment = null)
        {
            return AppendEntity(new DotHtmlUnderline(text, lineAlignment));
        }

        /// <summary>
        ///     Appends overline text to this instance.
        /// </summary>
        /// <param name="text">
        ///     The text to append.
        /// </param>
        /// <param name="lineAlignment">
        ///     Specifies horizontal placement of lines if multiline text is specified.
        /// </param>
        public virtual DotHtmlBuilder AppendOverlineText(string text, DotHorizontalAlignment? lineAlignment = null)
        {
            return AppendEntity(new DotHtmlOverline(text, lineAlignment));
        }

        /// <summary>
        ///     Appends subscript text to this instance.
        /// </summary>
        /// <param name="text">
        ///     The text to append.
        /// </param>
        /// <param name="lineAlignment">
        ///     Specifies horizontal placement of lines if multiline text is specified.
        /// </param>
        public virtual DotHtmlBuilder AppendSubscriptText(string text, DotHorizontalAlignment? lineAlignment = null)
        {
            return AppendEntity(new DotHtmlSubscript(text, lineAlignment));
        }

        /// <summary>
        ///     Appends superscript text to this instance.
        /// </summary>
        /// <param name="text">
        ///     The text to append.
        /// </param>
        /// <param name="lineAlignment">
        ///     Specifies horizontal placement of lines if multiline text is specified.
        /// </param>
        public virtual DotHtmlBuilder AppendSuperscriptText(string text, DotHorizontalAlignment? lineAlignment = null)
        {
            return AppendEntity(new DotHtmlSuperscript(text, lineAlignment));
        }

        /// <summary>
        ///     Appends strikethrough text to this instance.
        /// </summary>
        /// <param name="text">
        ///     The text to append.
        /// </param>
        /// <param name="lineAlignment">
        ///     Specifies horizontal placement of lines if multiline text is specified.
        /// </param>
        public virtual DotHtmlBuilder AppendStrikethroughText(string text, DotHorizontalAlignment? lineAlignment = null)
        {
            return AppendEntity(new DotHtmlStrikethrough(text, lineAlignment));
        }

        /// <summary>
        ///     Appends styled text to this instance.
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
        ///     Appends styled text to this instance.
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