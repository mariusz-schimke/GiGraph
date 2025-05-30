using System.Diagnostics.Contracts;
using GiGraph.Dot.Entities.Qualities;

namespace GiGraph.Dot.Extensions;

public static class DotHasStyleOptionsExtension
{
    /// <summary>
    ///     Indicates whether the element has a style attribute assigned. Returns true if the style attribute has any value, including
    ///     its default value that renders an empty 'style' attribute. The attribute is a composite of multiple options, each of which is
    ///     exposed and configurable via a dedicated property.
    /// </summary>
    /// <param name="entity">
    ///     The current object.
    /// </param>
    /// <typeparam name="TStyles">
    ///     The type of the style options the object implements.
    /// </typeparam>
    [Pure]
    public static bool HasStyleOptions<TStyles>(this IDotHasStyleOptions<TStyles> entity)
        where TStyles : struct, Enum =>
        entity.Style.HasValue;

    /// <summary>
    ///     Removes the style options of the element if set. The 'style' attribute will not be rendered.
    /// </summary>
    /// <param name="entity">
    ///     The current object.
    /// </param>
    /// <typeparam name="T">
    ///     The type of the style options implementation.
    /// </typeparam>
    public static T RemoveStyleOptions<T>(this T entity)
        where T : IDotHasStyleOptions
    {
        entity.NullifyStyle();
        return entity;
    }
}