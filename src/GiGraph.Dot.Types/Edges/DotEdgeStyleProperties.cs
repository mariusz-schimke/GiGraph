using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Types.Edges
{
    /// <summary>
    ///     Edge style options.
    /// </summary>
    /// <param name="LineStyle">
    ///     A line style for the edge.
    /// </param>
    /// <param name="LineWeight">
    ///     A line weight for the edge.
    /// </param>
    /// <param name="Invisible">
    ///     Determines whether the element is invisible.
    /// </param>
    public record DotEdgeStyleProperties(DotLineStyle LineStyle = default, DotLineWeight LineWeight = default, bool Invisible = false)
    {
        /// <summary>
        ///     Gets or sets a line style for the edge.
        /// </summary>
        public virtual DotLineStyle LineStyle { get; init; } = LineStyle;

        /// <summary>
        ///     Gets or sets a line weight for the edge.
        /// </summary>
        public virtual DotLineWeight LineWeight { get; init; } = LineWeight;

        /// <summary>
        ///     Gets or sets a value indicating whether the element is invisible.
        /// </summary>
        public virtual bool Invisible { get; init; } = Invisible;
    }
}