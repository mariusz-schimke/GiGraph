using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.Html.Table;

namespace GiGraph.Dot.Extensions;

public static class IDotHasHtmlTableBordersExtension
{
    /// <summary>
    ///     Sets borders to draw.
    /// </summary>
    /// <param name="this">
    ///     The current object.
    /// </param>
    /// <param name="top">
    ///     Determines if the top border should be drawn.
    /// </param>
    /// <param name="right">
    ///     Determines if the right border should be drawn.
    /// </param>
    /// <param name="bottom">
    ///     Determines if the bottom border should be drawn.
    /// </param>
    /// <param name="left">
    ///     Determines if the left border should be drawn.
    /// </param>
    public static void SetBorders(this IDotHasHtmlTableBorders @this, bool top = false, bool right = false, bool bottom = false, bool left = false)
    {
        var borders = default(DotHtmlTableBorders);

        borders |= top ? DotHtmlTableBorders.Top : borders;
        borders |= right ? DotHtmlTableBorders.Right : borders;
        borders |= bottom ? DotHtmlTableBorders.Bottom : borders;
        borders |= left ? DotHtmlTableBorders.Left : borders;

        @this.Borders = borders;
    }
}