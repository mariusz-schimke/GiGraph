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
public record DotNodeStyleOptions(
    DotNodeFillStyle FillStyle = default,
    DotBorderStyle BorderStyle = default,
    DotBorderWeight BorderWeight = default,
    DotCornerStyle CornerStyle = default,
    bool Diagonals = false,
    bool Invisible = false
)
{
    /// <summary>
    ///     The fill style.
    /// </summary>
    public DotNodeFillStyle FillStyle { get; init; } = FillStyle;

    /// <summary>
    ///     The border style.
    /// </summary>
    public DotBorderStyle BorderStyle { get; init; } = BorderStyle;

    /// <summary>
    ///     The border weight.
    /// </summary>
    public DotBorderWeight BorderWeight { get; init; } = BorderWeight;

    /// <summary>
    ///     The corner style.
    /// </summary>
    public DotCornerStyle CornerStyle { get; init; } = CornerStyle;

    /// <summary>
    ///     Determines whether the element is invisible.
    /// </summary>
    public bool Invisible { get; init; } = Invisible;
}