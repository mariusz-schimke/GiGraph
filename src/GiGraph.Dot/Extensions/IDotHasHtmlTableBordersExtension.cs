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
        @this.Borders = DotHtmlTableBorders.Top.When(top)
            | DotHtmlTableBorders.Right.When(right)
            | DotHtmlTableBorders.Bottom.When(bottom)
            | DotHtmlTableBorders.Left.When(left);
    }

    private static DotHtmlTableBorders When(this DotHtmlTableBorders flag, bool value) => value ? flag : default(DotHtmlTableBorders);
}