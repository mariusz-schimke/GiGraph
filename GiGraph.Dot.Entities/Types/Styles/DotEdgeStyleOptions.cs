namespace GiGraph.Dot.Entities.Types.Styles
{
    /// <summary>
    ///     Edge style options.
    /// </summary>
    public class DotEdgeStyleOptions
    {
        /// <summary>
        ///     Creates and initializes a new instance.
        /// </summary>
        /// <param name="lineStyle">
        ///     A line style for the edge.
        /// </param>
        /// <param name="lineWeight">
        ///     A line weight for the edge.
        /// </param>
        /// <param name="invisible">
        ///     Determines whether the element is invisible.
        /// </param>
        public DotEdgeStyleOptions(DotLineStyle lineStyle = default, DotLineWeight lineWeight = default, bool invisible = false)
        {
            LineStyle = lineStyle;
            LineWeight = lineWeight;
            Invisible = invisible;
        }

        /// <summary>
        ///     Gets or sets a line style for the edge.
        /// </summary>
        public virtual DotLineStyle LineStyle { get; set; }

        /// <summary>
        ///     Gets or sets a line weight for the edge.
        /// </summary>
        public virtual DotLineWeight LineWeight { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the element is invisible.
        /// </summary>
        public virtual bool Invisible { get; set; }
    }
}