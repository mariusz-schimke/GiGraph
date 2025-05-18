namespace GiGraph.Dot.Types.Styling;

/// <summary>
///     The fill styles of an element.
/// </summary>
public enum DotFillStyle
{
    /// <summary>
    ///     No fill. Since this is not an explicit fill style setting but rather expresses a lack of style specification, the actual
    ///     style applied will be no fill (by default) or based on the global style options set for this element type.
    /// </summary>
    None = DotStyles.Default,

    /// <inheritdoc cref="DotStyles.Filled"/>
    Regular = DotStyles.Filled,

    /// <inheritdoc cref="DotStyles.Striped"/>
    Striped = DotStyles.Striped,

    /// <inheritdoc cref="DotStyles.Wedged"/>
    Wedged = DotStyles.Wedged,

    /// <inheritdoc cref="DotStyles.Radial"/>
    Radial = DotStyles.Radial
}