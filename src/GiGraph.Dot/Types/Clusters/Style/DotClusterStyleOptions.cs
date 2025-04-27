using GiGraph.Dot.Types.Graphs.Style;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Types.Clusters.Style;

/// <summary>
///     Cluster style options.
/// </summary>
public record DotClusterStyleOptions
{
    /// <summary>
    ///     Creates a new instance.
    /// </summary>
    public DotClusterStyleOptions()
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
    /// <param name="invisible">
    ///     Determines whether the element is invisible.
    /// </param>
    public DotClusterStyleOptions(
        DotGraphFillStyle? fillStyle = null,
        DotBorderStyle? borderStyle = null,
        DotBorderWeight? borderWeight = null,
        DotCornerStyle? cornerStyle = null,
        bool? invisible = null
    )
    {
        FillStyle = fillStyle;
        BorderStyle = borderStyle;
        BorderWeight = borderWeight;
        CornerStyle = cornerStyle;
        Invisible = invisible;
    }

    /// <summary>
    ///     The fill style.
    /// </summary>
    public DotGraphFillStyle? FillStyle { get; init; }

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
    ///     Determines whether the element is invisible.
    /// </summary>
    public bool? Invisible { get; init; }
}