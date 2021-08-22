using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Types.Clusters
{
    /// <summary>
    ///     Cluster style properties.
    /// </summary>
    /// <param name="FillStyle">
    ///     Fill style for the element.
    /// </param>
    /// <param name="BorderStyle">
    ///     Border style for the element.
    /// </param>
    /// <param name="BorderWeight">
    ///     Border weight for the element.
    /// </param>
    /// <param name="CornerStyle">
    ///     Corner style for the element.
    /// </param>
    /// <param name="Invisible">
    ///     Determines whether the element is invisible.
    /// </param>
    public record DotClusterStyleProperties
    (
        DotClusterFillStyle FillStyle = default,
        DotBorderStyle BorderStyle = default,
        DotBorderWeight BorderWeight = default,
        DotCornerStyle CornerStyle = default,
        bool Invisible = false
    ) : DotClusterNodeCommonStyleProperties<DotClusterFillStyle>(FillStyle, BorderStyle, BorderWeight, CornerStyle, Invisible);
}