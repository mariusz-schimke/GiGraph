using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Types.Edges;

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
public record DotEdgeStyleProperties(DotLineStyle LineStyle = default, DotLineWeight LineWeight = default, bool Invisible = false);