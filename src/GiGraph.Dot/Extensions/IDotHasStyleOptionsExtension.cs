using System.Diagnostics.Contracts;
using GiGraph.Dot.Entities.Qualities;

namespace GiGraph.Dot.Extensions;

public static partial class IDotHasStyleOptionsExtension
{
    /// <summary>
    ///     Determines if any style is assigned to the element, that is, if the Graphviz 'style' attribute has any value specified (is
    ///     not null).
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
    ///     Clears the style option flags of the element so that no style is set. This implies that the Graphviz 'style' attribute won't
    ///     be rendered for the current element at all.
    /// </summary>
    /// <param name="this">
    ///     The current object.
    /// </param>
    /// <typeparam name="TStyles">
    ///     The type of the style options the object implements.
    /// </typeparam>
    public static void ClearStyleOptions<TStyles>(this IDotHasStyleOptions<TStyles> @this)
        where TStyles : struct, Enum
    {
        @this.Style = null;
    }
}