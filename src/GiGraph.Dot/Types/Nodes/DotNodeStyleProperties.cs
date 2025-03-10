using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Types.Nodes;

/// <summary>
///     Node style attributes.
/// </summary>
/// <param name="FillStyle">
///     Fill style.
/// </param>
/// <param name="BorderStyle">
///     Border style.
/// </param>
/// <param name="BorderWeight">
///     Border weight.
/// </param>
/// <param name="CornerStyle">
///     Corner style.
/// </param>
/// <param name="Diagonals">
///     Causes small chords to be drawn near the vertices of the node’s polygon or, in case of circles and ellipses, two chords near
///     the top and the bottom of the shape.
/// </param>
/// <param name="Invisible">
///     Determines whether the element is invisible.
/// </param>
public record DotNodeStyleProperties(
    DotNodeFillStyle FillStyle = default,
    DotBorderStyle BorderStyle = default,
    DotBorderWeight BorderWeight = default,
    DotCornerStyle CornerStyle = default,
    bool Diagonals = false,
    bool Invisible = false
) : DotClusterNodeCommonStyleProperties<DotNodeFillStyle>(FillStyle, BorderStyle, BorderWeight, CornerStyle, Invisible);