using System;
using GiGraph.Dot.Entities.Html.Font;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Fonts;

namespace GiGraph.Dot.Entities.Html.Builder
{
    public partial class DotHtmlBuilder
    {
        /// <summary>
        ///     Initializes and appends a font element.
        /// </summary>
        /// <param name="init">
        ///     An element initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendFont(Action<DotHtmlFont> init)
        {
            return Append(new DotHtmlFont(), init);
        }

        /// <summary>
        ///     Initializes and appends a font element.
        /// </summary>
        /// <param name="font">
        ///     The font to use.
        /// </param>
        /// <param name="init">
        ///     An element initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendFont(DotFont font, Action<DotHtmlFont> init)
        {
            return Append(new DotHtmlFont(font), init);
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
        public virtual DotHtmlBuilder AppendFont(string text, DotFont font)
        {
            return AppendFont(font, e => e.SetContent(text));
        }

        /// <summary>
        ///     Initializes and appends a font element.
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
        public virtual DotHtmlBuilder AppendFont(string text, string name = null, double? size = null, DotColor color = null)
        {
            return AppendFont(text, new DotFont(name, size, color));
        }

        /// <summary>
        ///     Initializes and appends a font element with nested font style elements.
        /// </summary>
        /// <param name="font">
        ///     The font to use.
        /// </param>
        /// <param name="init">
        ///     An element initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendStyledFont(DotStyledFont font, Action<DotHtmlElement> init)
        {
            var fontElement = new DotHtmlFont(font);
            DotHtmlElement initElement = fontElement;

            if (font.Style.HasValue)
            {
                var styleRootElement = DotHtmlFontStyle.FromStyle(font.Style.Value, out var contentElement);
                if (styleRootElement is not null)
                {
                    fontElement.SetContent(styleRootElement);
                    initElement = contentElement;
                }
            }

            init?.Invoke(initElement);
            return Append(fontElement);
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
        public virtual DotHtmlBuilder AppendStyledFont(string text, DotStyledFont font)
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
        public virtual DotHtmlBuilder AppendStyledFont(string text, string name = null, double? size = null, DotColor color = null, DotFontStyles? style = null)
        {
            return AppendStyledFont(text, new DotStyledFont(name, size, color, style));
        }
    }
}