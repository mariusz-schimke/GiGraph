namespace GiGraph.Dot.Entities.Qualities;

/// <summary>
///     Indicates that the implementation has style options.
/// </summary>
public interface IDotHasStyleOptions
{
    void NullifyStyle();
}

/// <summary>
///     Indicates that the implementation has style options.
/// </summary>
/// <typeparam name="TStyles">
///     The type of the style options flag enum.
/// </typeparam>
public interface IDotHasStyleOptions<TStyles> : IDotHasStyleOptions
    where TStyles : struct, Enum
{
    /// <summary>
    ///     Gets the style flags of the element.
    /// </summary>
    TStyles? Style { get; set; }
}