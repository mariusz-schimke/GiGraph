using System;
using GiGraph.Dot.Entities.Html.Font;
using GiGraph.Dot.Types.Fonts;

namespace GiGraph.Dot.Entities.Html.Builder
{
    // TODO: w metodach init przekazywać builder zamiast nowo dodanej encji?

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
    }
}