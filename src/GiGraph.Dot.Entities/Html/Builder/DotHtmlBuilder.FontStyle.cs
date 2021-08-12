using System;
using GiGraph.Dot.Entities.Html.Font;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Fonts;

namespace GiGraph.Dot.Entities.Html.Builder
{
    public partial class DotHtmlBuilder
    {
        /// <summary>
        ///     Initializes and appends a bold element.
        /// </summary>
        /// <param name="init">
        ///     A content initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendBold(Action<DotHtmlBuilder> init)
        {
            return Append(new DotHtmlBold(), init);
        }

        /// <summary>
        ///     Initializes and appends bold text.
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
        ///     Initializes and appends an italic element.
        /// </summary>
        /// <param name="init">
        ///     A content initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendItalic(Action<DotHtmlBuilder> init)
        {
            return Append(new DotHtmlItalic(), init);
        }

        /// <summary>
        ///     Initializes and appends italic text.
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
        ///     Initializes and appends an underline element.
        /// </summary>
        /// <param name="init">
        ///     A content initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendUnderline(Action<DotHtmlBuilder> init)
        {
            return Append(new DotHtmlUnderline(), init);
        }

        /// <summary>
        ///     Initializes and appends underline text.
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
        ///     Initializes and appends an overline element.
        /// </summary>
        /// <param name="init">
        ///     A content initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendOverline(Action<DotHtmlBuilder> init)
        {
            return Append(new DotHtmlOverline(), init);
        }

        /// <summary>
        ///     Initializes and appends overline text.
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
        ///     Initializes and appends a subscript element.
        /// </summary>
        /// <param name="init">
        ///     A content initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendSubscript(Action<DotHtmlBuilder> init)
        {
            return Append(new DotHtmlSubscript(), init);
        }

        /// <summary>
        ///     Initializes and appends subscript text.
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
        ///     Initializes and appends a superscript element.
        /// </summary>
        /// <param name="init">
        ///     A content initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendSuperscript(Action<DotHtmlBuilder> init)
        {
            return Append(new DotHtmlSuperscript(), init);
        }

        /// <summary>
        ///     Initializes and appends superscript text.
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
        ///     Initializes and appends a strikethrough element.
        /// </summary>
        /// <param name="init">
        ///     A content initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendStrikethrough(Action<DotHtmlBuilder> init)
        {
            return Append(new DotHtmlStrikethrough(), init);
        }

        /// <summary>
        ///     Initializes and appends strikethrough text.
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
        ///     Initializes and appends nested font style elements.
        /// </summary>
        /// <param name="fontStyle">
        ///     The font style to use.
        /// </param>
        /// <param name="init">
        ///     A content initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendStyled(DotFontStyles fontStyle, Action<DotHtmlBuilder> init)
        {
            var rootElement = (IDotHtmlContentEntity) DotHtmlFontStyle.FromStyle(fontStyle, out var contentElement)
             ?? new DotHtmlEntityCollection();

            (contentElement ?? rootElement).SetContent(init);
            return AppendEntity(rootElement);
        }
    }
}