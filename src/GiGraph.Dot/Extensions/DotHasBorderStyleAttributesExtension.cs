using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.Colors;

namespace GiGraph.Dot.Extensions;

public static class DotHasBorderStyleAttributesExtension
{
    /// <summary>
    ///     Sets border style.
    /// </summary>
    /// <param name="entity">
    ///     The current object.
    /// </param>
    /// <param name="color">
    ///     The color to set for the border. Note: this color also acts as the fill color if a fill style is specified, unless a fill
    ///     color is specified separately. To ensure the color is used only for the border, set both the color and a fill color, or don't
    ///     apply a filled style.
    /// </param>
    /// <param name="width">
    ///     The width to set.
    /// </param>
    public static T SetBorderStyle<T>(this T entity, DotColor? color, double? width)
        where T : IDotHasBorderStyleAttributes
    {
        entity.Color = color;
        entity.BorderWidth = width;
        return entity;
    }
}