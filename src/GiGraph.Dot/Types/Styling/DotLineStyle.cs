namespace GiGraph.Dot.Types.Styling;

/// <summary>
///     Line style.
/// </summary>
public enum DotLineStyle
{
    /// <summary>
    ///     A default (solid) style. Since this is not an explicit line style setting but rather expresses a lack of style specification,
    ///     the actual style displayed will be solid (default) or based on the global style options set for this element type.
    /// </summary>
    Default = DotStyles.Default,

    /// <summary>
    ///     A solid line style.
    /// </summary>
    Solid = DotStyles.Solid,

    /// <summary>
    ///     A dashed line style.
    /// </summary>
    Dashed = DotStyles.Dashed,

    /// <summary>
    ///     A dotted line style.
    /// </summary>
    Dotted = DotStyles.Dotted,

    /// <summary>
    ///     Causes the line to tapper from a specified width towards a width of 1 (in points).
    /// </summary>
    Tapered = DotStyles.Tapered
}