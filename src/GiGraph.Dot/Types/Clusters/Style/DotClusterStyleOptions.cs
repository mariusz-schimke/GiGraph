using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Types.Clusters.Style;

/// <summary>
///     Cluster style options.
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
public record DotClusterStyleOptions(
    DotClusterFillStyle? FillStyle = null,
    DotBorderStyle? BorderStyle = null,
    DotBorderWeight? BorderWeight = null,
    DotCornerStyle? CornerStyle = null,
    bool? Invisible = null
);