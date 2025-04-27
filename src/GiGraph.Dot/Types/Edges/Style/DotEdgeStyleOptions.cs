using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Types.Edges.Style;

/// <summary>
///     Edge style options.
/// </summary>
public record DotEdgeStyleOptions
{
    /// <summary>
    ///     Creates a new instance.
    /// </summary>
    public DotEdgeStyleOptions()
    {
    }

    /// <summary>
    ///     Creates and initializes a new instance.
    /// </summary>
    /// <param name="lineStyle">
    ///     A line style.
    /// </param>
    /// <param name="lineWeight">
    ///     A line weight.
    /// </param>
    /// <param name="invisible">
    ///     Determines whether the element is invisible.
    /// </param>
    public DotEdgeStyleOptions(DotLineStyle? lineStyle = null, DotLineWeight? lineWeight = null, bool? invisible = null)
    {
        LineStyle = lineStyle;
        LineWeight = lineWeight;
        Invisible = invisible;
    }

    /// <summary>
    ///     A line style.
    /// </summary>
    public DotLineStyle? LineStyle { get; init; }

    /// <summary>
    ///     A line weight.
    /// </summary>
    public DotLineWeight? LineWeight { get; init; }

    /// <summary>
    ///     Determines whether the element is invisible.
    /// </summary>
    public bool? Invisible { get; init; }
}