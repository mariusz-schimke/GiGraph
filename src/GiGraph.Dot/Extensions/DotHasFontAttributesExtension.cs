using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.Colors;

namespace GiGraph.Dot.Extensions;

public static class DotHasFontAttributesExtension
{
    /// <summary>
    ///     Sets font attributes.
    /// </summary>
    /// <param name="entity">
    ///     The current object.
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
    public static T Set<T>(this T entity, string? name, double? size, DotColor? color)
        where T : IDotHasFontAttributes
    {
        entity.Name = name;
        entity.Size = size;
        entity.Color = color;
        return entity;
    }
}