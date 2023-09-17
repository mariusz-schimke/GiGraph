using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Types.Clusters;

/// <summary>
///     Fill style applicable to clusters.
/// </summary>
public enum DotClusterFillStyle
{
    /// <summary>
    ///     No fill.
    /// </summary>
    None = DotFillStyle.None,

    /// <summary>
    ///     Causes a plain color fill when <see cref="DotColor" /> is used, or a gradient fill when <see cref="DotGradientColor" /> is
    ///     used.
    /// </summary>
    Normal = DotFillStyle.Normal,

    /// <summary>
    ///     Causes the fill to be done as a set of vertical stripes. The colors are specified via a color list (see
    ///     <see cref="DotMulticolor" />), and drawn from left to right in list order. Optional color weights can be specified to
    ///     indicate the proportional widths of the bars. If the sum of the weights is less than 1, the remainder is divided evenly among
    ///     the colors with no weight.
    /// </summary>
    Striped = DotFillStyle.Striped,

    /// <summary>
    ///     Causes a radial gradient fill when a <see cref="DotGradientColor" /> is used.
    /// </summary>
    Radial = DotFillStyle.Radial
}