using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Types.Edges.Style;

/// <summary>
///     Edge style options.
/// </summary>
/// <param name="LineStyle">
///     A line style.
/// </param>
/// <param name="LineWeight">
///     A line weight.
/// </param>
/// <param name="Invisible">
///     Determines whether the element is invisible.
/// </param>
public record DotEdgeStyleOptions(DotLineStyle? LineStyle = null, DotLineWeight? LineWeight = null, bool? Invisible = null);