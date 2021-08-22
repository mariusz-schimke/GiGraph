using GiGraph.Dot.Types.Clusters;

namespace GiGraph.Dot.Types.Graphs
{
    /// <summary>
    ///     Graph style options.
    /// </summary>
    /// <param name="FillStyle">
    ///     The fill style for graph and clusters. The only option applicable to the root graph is
    ///     <see cref="GiGraph.Dot.Types.Clusters.DotClusterFillStyle.Radial" />.
    /// </param>
    public record DotGraphStyleProperties(DotClusterFillStyle FillStyle = DotClusterFillStyle.None);
}