namespace GiGraph.Dot.Entities.Qualities;

/// <summary>
///     Indicates that the implementation has style options.
/// </summary>
/// <typeparam name="TStyles">
///     The type of the style options flag enum.
/// </typeparam>
public interface IDotHasStyleOptions<TStyles>
    where TStyles : struct, Enum
{
    /// <summary>
    ///     Gets the style flags of the element.
    /// </summary>
    TStyles? Style { get; set; }
}