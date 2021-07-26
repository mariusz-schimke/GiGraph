using GiGraph.Dot.Entities.Types.Clusters;

namespace GiGraph.Dot.Entities.Types.Graphs
{
    /// <summary>
    ///     Graph style options.
    /// </summary>
    public class DotGraphStyleOptions
    {
        /// <summary>
        ///     Creates and initializes a new instance.
        /// </summary>
        /// <param name="fillStyle">
        ///     The fill style for graph and clusters. The only option applicable to the root graph is
        ///     <see cref="DotClusterFillStyle.Radial" />.
        /// </param>
        public DotGraphStyleOptions(DotClusterFillStyle fillStyle = DotClusterFillStyle.None)
        {
            FillStyle = fillStyle;
        }

        /// <summary>
        ///     Gets or sets a fill style for graph and clusters. The only option applicable to the root graph is
        ///     <see cref="DotClusterFillStyle.Radial" />.
        /// </summary>
        public virtual DotClusterFillStyle FillStyle { get; set; }
    }
}