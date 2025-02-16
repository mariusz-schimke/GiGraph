using System;
using GiGraph.Dot.Entities.Html.Font;
using GiGraph.Dot.Entities.Html.Font.Styles;
using GiGraph.Dot.Types.Fonts;

namespace GiGraph.Dot.Entities.Html.Builder;

public partial class DotHtmlBuilder
{
    /// <summary>
    ///     Appends a font element to this instance and builds its content.
    /// </summary>
    /// <param name="init">
    ///     A content initialization delegate.
    /// </param>
    public virtual DotHtmlBuilder AppendFont(Action<DotHtmlBuilder> init) => Append(new DotHtmlFont(), init);

    /// <summary>
    ///     Appends a font element to this instance and builds its content.
    /// </summary>
    /// <param name="font">
    ///     The font to use.
    /// </param>
    /// <param name="init">
    ///     A content initialization delegate.
    /// </param>
    public virtual DotHtmlBuilder AppendFont(DotFont font, Action<DotHtmlBuilder> init) => Append(new DotHtmlFont(font), init);

    /// <summary>
    ///     Appends a font element with nested font style elements to this instance and builds the content of the bottom one.
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
                initElement = contentElement!;
            }
        }

        initElement.SetContent(init);
        return AppendEntity(fontElement);
    }
}