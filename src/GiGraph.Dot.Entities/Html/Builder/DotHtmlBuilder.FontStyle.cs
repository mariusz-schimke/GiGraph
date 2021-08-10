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
        ///     An element initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendBold(Action<DotHtmlBold> init)
        {
            return Append(new DotHtmlBold(), init);
        }

        /// <summary>
        ///     Initializes and appends a bold element.
        /// </summary>
        /// <param name="text">
        ///     The text to append.
        /// </param>
        /// <param name="horizontalAlignment">
        ///     Specifies horizontal placement of lines if multiline text is specified.
        /// </param>
        public virtual DotHtmlBuilder AppendBoldText(string text, DotHorizontalAlignment? horizontalAlignment = null)
        {
            return Append(new DotHtmlBold(text, horizontalAlignment));
        }

        /// <summary>
        ///     Initializes and appends an italic element.
        /// </summary>
        /// <param name="init">
        ///     An element initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendItalic(Action<DotHtmlItalic> init)
        {
            return Append(new DotHtmlItalic(), init);
        }

        /// <summary>
        ///     Initializes and appends an italic element.
        /// </summary>
        /// <param name="text">
        ///     The text to append.
        /// </param>
        /// <param name="horizontalAlignment">
        ///     Specifies horizontal placement of lines if multiline text is specified.
        /// </param>
        public virtual DotHtmlBuilder AppendItalicText(string text, DotHorizontalAlignment? horizontalAlignment = null)
        {
            return Append(new DotHtmlItalic(text, horizontalAlignment));
        }

        /// <summary>
        ///     Initializes and appends an underline element.
        /// </summary>
        /// <param name="init">
        ///     An element initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendUnderline(Action<DotHtmlUnderline> init)
        {
            return Append(new DotHtmlUnderline(), init);
        }

        /// <summary>
        ///     Initializes and appends an underline element.
        /// </summary>
        /// <param name="text">
        ///     The text to append.
        /// </param>
        /// <param name="horizontalAlignment">
        ///     Specifies horizontal placement of lines if multiline text is specified.
        /// </param>
        public virtual DotHtmlBuilder AppendUnderlineText(string text, DotHorizontalAlignment? horizontalAlignment = null)
        {
            return Append(new DotHtmlUnderline(text, horizontalAlignment));
        }

        /// <summary>
        ///     Initializes and appends an overline element.
        /// </summary>
        /// <param name="init">
        ///     An element initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendOverline(Action<DotHtmlOverline> init)
        {
            return Append(new DotHtmlOverline(), init);
        }

        /// <summary>
        ///     Initializes and appends an overline element.
        /// </summary>
        /// <param name="text">
        ///     The text to append.
        /// </param>
        /// <param name="horizontalAlignment">
        ///     Specifies horizontal placement of lines if multiline text is specified.
        /// </param>
        public virtual DotHtmlBuilder AppendOverlineText(string text, DotHorizontalAlignment? horizontalAlignment = null)
        {
            return Append(new DotHtmlOverline(text, horizontalAlignment));
        }

        /// <summary>
        ///     Initializes and appends an subscript element.
        /// </summary>
        /// <param name="init">
        ///     An element initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendSubscript(Action<DotHtmlSubscript> init)
        {
            return Append(new DotHtmlSubscript(), init);
        }

        /// <summary>
        ///     Initializes and appends an subscript element.
        /// </summary>
        /// <param name="text">
        ///     The text to append.
        /// </param>
        /// <param name="horizontalAlignment">
        ///     Specifies horizontal placement of lines if multiline text is specified.
        /// </param>
        public virtual DotHtmlBuilder AppendSubscriptText(string text, DotHorizontalAlignment? horizontalAlignment = null)
        {
            return Append(new DotHtmlSubscript(text, horizontalAlignment));
        }

        /// <summary>
        ///     Initializes and appends an superscript element.
        /// </summary>
        /// <param name="init">
        ///     An element initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendSuperscript(Action<DotHtmlSuperscript> init)
        {
            return Append(new DotHtmlSuperscript(), init);
        }

        /// <summary>
        ///     Initializes and appends an superscript element.
        /// </summary>
        /// <param name="text">
        ///     The text to append.
        /// </param>
        /// <param name="horizontalAlignment">
        ///     Specifies horizontal placement of lines if multiline text is specified.
        /// </param>
        public virtual DotHtmlBuilder AppendSuperscriptText(string text, DotHorizontalAlignment? horizontalAlignment = null)
        {
            return Append(new DotHtmlSuperscript(text, horizontalAlignment));
        }

        /// <summary>
        ///     Initializes and appends an strikethrough element.
        /// </summary>
        /// <param name="init">
        ///     An element initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendStrikethrough(Action<DotHtmlStrikethrough> init)
        {
            return Append(new DotHtmlStrikethrough(), init);
        }

        /// <summary>
        ///     Initializes and appends an strikethrough element.
        /// </summary>
        /// <param name="text">
        ///     The text to append.
        /// </param>
        /// <param name="horizontalAlignment">
        ///     Specifies horizontal placement of lines if multiline text is specified.
        /// </param>
        public virtual DotHtmlBuilder AppendStrikethroughText(string text, DotHorizontalAlignment? horizontalAlignment = null)
        {
            return Append(new DotHtmlStrikethrough(text, horizontalAlignment));
        }

        /// <summary>
        ///     Initializes and appends nested font style elements.
        /// </summary>
        /// <param name="fontStyle">
        ///     The font style to use.
        /// </param>
        /// <param name="init">
        ///     An element initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendStyled(DotFontStyles fontStyle, Action<IDotHtmlContentEntity> init)
        {
            var rootElement = (IDotHtmlContentEntity) DotHtmlFontStyle.FromStyle(fontStyle, out var contentElement)
             ?? new DotHtmlEntityCollection();

            init?.Invoke(contentElement ?? rootElement);
            return Append(rootElement);
        }
    }
}