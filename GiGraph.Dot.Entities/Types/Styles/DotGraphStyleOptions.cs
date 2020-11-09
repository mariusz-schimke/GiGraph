namespace GiGraph.Dot.Entities.Types.Styles
{
    /// <summary>
    ///     Graph style options.
    /// </summary>
    public class DotGraphStyleOptions
    {
        /// <summary>
        ///     Creates and initializes a new instance.
        /// </summary>
        /// <param name="fill">
        ///     The fill style for graph and clusters. The only option applicable to the root graph is
        ///     <see cref="DotClusterFillStyle.Radial" />.
        /// </param>
        public DotGraphStyleOptions(DotClusterFillStyle fill = DotClusterFillStyle.None)
        {
            Fill = fill;
        }

        /// <summary>
        ///     Gets or sets a fill style for graph and clusters. The only option applicable to the root graph is
        ///     <see cref="DotClusterFillStyle.Radial" />.
        /// </summary>
        public virtual DotClusterFillStyle Fill { get; set; }
    }
}