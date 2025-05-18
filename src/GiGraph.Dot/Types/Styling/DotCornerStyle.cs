namespace GiGraph.Dot.Types.Styling;

/// <summary>
///     Corner style.
/// </summary>
public enum DotCornerStyle
{
    /// <summary>
    ///     A sharp corner style. Since this is not an explicit corner style setting but rather expresses a lack of style specification,
    ///     the actual style displayed will be sharp (default) or based on the global style options set for this element type.
    /// </summary>
    Sharp = DotStyles.Default,

    /// <summary>
    ///     A rounded corner style.
    /// </summary>
    Rounded = DotStyles.Rounded
}