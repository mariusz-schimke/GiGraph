using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Entities.Types.Styles
{
    /// <summary>
    ///     Fill style applicable to clusters.
    /// </summary>
    public enum DotNodeFillStyle
    {
        /// <summary>
        ///     No fill.
        /// </summary>
        None = 0,

        /// <summary>
        ///     Causes a plain color fill when <see cref="DotColor" /> is used, or a gradient fill when <see cref="DotGradientColor" /> is
        ///     used.
        /// </summary>
        Normal = DotStyles.Filled,

        /// <summary>
        ///     Applicable to rectangularly-shaped nodes. Causes the fill to be done as a set of vertical stripes. The colors are specified
        ///     via a color list (see <see cref="DotMultiColor" />), and drawn from left to right in list order. Optional color weights can
        ///     be specified to indicate the proportional widths of the bars. If the sum of the weights is less than 1, the remainder is
        ///     divided evenly among the colors with no weight.
        /// </summary>
        Striped = DotStyles.Striped,

        /// <summary>
        ///     Applicable to elliptically-shaped nodes. Causes the fill to be done as a set of wedges. The colors are specified via a color
        ///     list (see <see cref="DotMultiColor" />), with the colors drawn counter-clockwise starting at angle 0. Optional color weights
        ///     can be specified to indicate the proportional widths of the bars. If the sum of the weights is less than 1, the remainder is
        ///     divided evenly among the colors with no weight.
        /// </summary>
        Wedged = DotStyles.Wedged,

        /// <summary>
        ///     Causes a radial gradient fill when a <see cref="DotGradientColor" /> is used.
        /// </summary>
        Radial = DotStyles.Radial
    }
}