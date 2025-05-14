using System.Diagnostics.Contracts;
using GiGraph.Dot.Entities.Qualities;

namespace GiGraph.Dot.Extensions;

public static class IDotHasStyleOptionsExtension
{
    /// <summary>
    ///     Indicates whether the element has a style attribute assigned. Returns true if the style attribute has any value, including
    ///     default values that render an empty 'style' attribute. The style attribute is settable through the element's style options
    ///     exposed through individual properties.
    /// </summary>
    /// <param name="this">
    ///     The current object.
    /// </param>
    /// <typeparam name="TStyles">
    ///     The type of the style options the object implements.
    /// </typeparam>
    [Pure]
    public static bool HasStyleOptions<TStyles>(this IDotHasStyleOptions<TStyles> @this)
        where TStyles : struct, Enum =>
        @this.Style.HasValue;

    /// <summary>
    ///     Removes the style options of the element if set. The 'style' attribute will not be rendered.
    /// </summary>
    /// <param name="this">
    ///     The current object.
    /// </param>
    /// <typeparam name="TStyles">
    ///     The type of the style options the object implements.
    /// </typeparam>
    public static void RemoveStyleOptions<TStyles>(this IDotHasStyleOptions<TStyles> @this)
        where TStyles : struct, Enum
    {
        @this.Style = null;
    }
}