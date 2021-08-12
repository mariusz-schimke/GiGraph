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
        ///     A content initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendFont(Action<DotHtmlBuilder> init)
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
        ///     A content initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendFont(DotFont font, Action<DotHtmlBuilder> init)
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
        ///     A content initialization delegate.
        /// </param>
        public virtual DotHtmlBuilder AppendStyledFont(DotStyledFont font, Action<DotHtmlBuilder> init)
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

            initElement.SetContent(init);
            return AppendEntity(fontElement);
        }
    }
}