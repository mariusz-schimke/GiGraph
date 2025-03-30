using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Types.Clusters;

/// <summary>
///     Cluster style modifiers.
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
/// <param name="Invisible">
///     Determines whether the element is invisible.
/// </param>
public record DotClusterStyleModifiers(
    DotClusterFillStyle FillStyle = default,
    DotBorderStyle BorderStyle = default,
    DotBorderWeight BorderWeight = default,
    DotCornerStyle CornerStyle = default,
    bool Invisible = false
)
{
    /// <summary>
    ///     The fill style.
    /// </summary>
    public DotClusterFillStyle FillStyle { get; init; } = FillStyle;

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