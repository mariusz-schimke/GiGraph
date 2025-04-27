using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Types.Nodes.Style;

/// <summary>
///     Node style options.
/// </summary>
public record DotNodeStyleOptions
{
    /// <summary>
    ///     Creates a new instance.
    /// </summary>
    public DotNodeStyleOptions()
    {
    }

    /// <summary>
    ///     Creates and initializes a new instance.
    /// </summary>
    /// <param name="fillStyle">
    ///     Fill style.
    /// </param>
    /// <param name="borderStyle">
    ///     Border style.
    /// </param>
    /// <param name="borderWeight">
    ///     Border weight.
    /// </param>
    /// <param name="cornerStyle">
    ///     Corner style.
    /// </param>
    /// <param name="diagonals">
    ///     Causes small chords to be drawn near the vertices of the node’s polygon or, in case of circles and ellipses, two chords near
    ///     the top and the bottom of the shape.
    /// </param>
    /// <param name="invisible">
    ///     Determines whether the element is invisible.
    /// </param>
    public DotNodeStyleOptions(
        DotNodeFillStyle? fillStyle = null,
        DotBorderStyle? borderStyle = null,
        DotBorderWeight? borderWeight = null,
        DotCornerStyle? cornerStyle = null,
        bool? diagonals = null,
        bool? invisible = null
    )
    {
        FillStyle = fillStyle;
        BorderStyle = borderStyle;
        BorderWeight = borderWeight;
        CornerStyle = cornerStyle;
        Diagonals = diagonals;
        Invisible = invisible;
    }

    /// <summary>
    ///     The fill style.
    /// </summary>
    public DotNodeFillStyle? FillStyle { get; init; }

    /// <summary>
    ///     The border style.
    /// </summary>
    public DotBorderStyle? BorderStyle { get; init; }

    /// <summary>
    ///     The border weight.
    /// </summary>
    public DotBorderWeight? BorderWeight { get; init; }

    /// <summary>
    ///     The corner style.
    /// </summary>
    public DotCornerStyle? CornerStyle { get; init; }

    /// <summary>
    ///     Causes small chords to be drawn near the vertices of the node’s polygon or, in case of circles and ellipses, two chords near
    ///     the top and the bottom of the shape.
    /// </summary>
    public bool? Diagonals { get; }

    /// <summary>
    ///     Determines whether the element is invisible.
    /// </summary>
    public bool? Invisible { get; init; }
}