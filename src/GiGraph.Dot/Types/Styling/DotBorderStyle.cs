namespace GiGraph.Dot.Types.Styling;

/// <summary>
///     Border style.
/// </summary>
public enum DotBorderStyle
{
    /// <summary>
    ///     A normal border style. Since this is not an explicit border style setting but rather expresses a lack of weight
    ///     specification, the actual style displayed will be solid (default) or based on the global style options set for this element
    ///     type.
    /// </summary>
    Default = DotStyles.Default,

    /// <summary>
    ///     A solid border style.
    /// </summary>
    Solid = DotStyles.Solid,

    /// <summary>
    ///     A dashed border style.
    /// </summary>
    Dashed = DotStyles.Dashed,

    /// <summary>
    ///     A dotted border style.
    /// </summary>
    Dotted = DotStyles.Dotted
}