namespace GiGraph.Dot.Types.Styling;

/// <summary>
///     Line weight.
/// </summary>
public enum DotLineWeight
{
    /// <summary>
    ///     A normal line weight. Since this is not an explicit weight setting but rather expresses a lack of weight specification, the
    ///     actual weight displayed will be normal (default) or based on the global style options set for this element type.
    /// </summary>
    Normal = DotStyles.Default,

    /// <summary>
    ///     A bold line style.
    /// </summary>
    Bold = DotStyles.Bold
}