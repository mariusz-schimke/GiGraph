namespace GiGraph.Dot.Entities.Types.Styles
{
    /// <summary>
    ///     Edge style options.
    /// </summary>
    public class DotEdgeStyleOptions : DotCommonStyleOptions
    {
        /// <summary>
        ///     Gets or sets a line style for the edge.
        /// </summary>
        public virtual DotEdgeStyle Line { get; set; }

        /// <summary>
        ///     Gets or sets the line weight of the edge.
        /// </summary>
        public virtual DotEdgeWeight Weight { get; set; }
    }
}