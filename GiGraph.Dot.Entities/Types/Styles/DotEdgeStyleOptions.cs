namespace GiGraph.Dot.Entities.Types.Styles
{
    /// <summary>
    ///     Edge style options.
    /// </summary>
    public class DotEdgeStyleOptions
    {
        /// <summary>
        ///     Gets or sets a line style for the edge.
        /// </summary>
        public virtual DotLineStyle LineStyle { get; set; }

        /// <summary>
        ///     Gets or sets the line weight of the edge.
        /// </summary>
        public virtual DotLineWeight LineWeight { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the element is invisible.
        /// </summary>
        public virtual bool Invisible { get; set; }
    }
}