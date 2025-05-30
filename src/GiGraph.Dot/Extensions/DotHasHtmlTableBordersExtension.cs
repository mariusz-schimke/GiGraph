using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.Html.Table;

namespace GiGraph.Dot.Extensions;

public static class DotHasHtmlTableBordersExtension
{
    /// <summary>
    ///     Sets borders to draw.
    /// </summary>
    /// <param name="entity">
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
    /// <remarks>
    ///     If you want to hide all borders, set the border width to 0 (it can't be achieved by setting the visibility of all borders to
    ///     false).
    /// </remarks>
    public static T SetBorders<T>(this T entity, bool top = false, bool right = false, bool bottom = false, bool left = false)
        where T : IDotHasHtmlTableBorders
    {
        var borders = DotHtmlTableBorders.Top.When(top)
            | DotHtmlTableBorders.Right.When(right)
            | DotHtmlTableBorders.Bottom.When(bottom)
            | DotHtmlTableBorders.Left.When(left);

        entity.Borders = borders == default(DotHtmlTableBorders) ? null : borders;
        return entity;
    }

    private static DotHtmlTableBorders When(this DotHtmlTableBorders flag, bool value) => value ? flag : default(DotHtmlTableBorders);
}