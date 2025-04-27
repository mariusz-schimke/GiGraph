namespace GiGraph.Dot.Types.Styling;

/// <summary>
///     Line style.
/// </summary>
public enum DotLineStyle
{
    /// <summary>
    ///     The default style.
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