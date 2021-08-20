using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Types.Nodes
{
    /// <summary>
    ///     Node style properties.
    /// </summary>
    public class DotNodeStyleProperties : DotClusterNodeCommonStyleProperties<DotNodeFillStyle>
    {
        /// <summary>
        ///     Creates and initializes a new instance.
        /// </summary>
        /// <param name="fillStyle">
        ///     Fill style for the element.
        /// </param>
        /// <param name="borderStyle">
        ///     Border style for the element.
        /// </param>
        /// <param name="borderWeight">
        ///     Border weight for the element.
        /// </param>
        /// <param name="cornerStyle">
        ///     Corner style for the element.
        /// </param>
        /// <param name="diagonals">
        ///     Causes small chords to be drawn near the vertices of the node’s polygon or, in case of circles and ellipses, two chords near
        ///     the top and the bottom of the shape.
        /// </param>
        /// <param name="invisible">
        ///     Determines whether the element is invisible.
        /// </param>
        public DotNodeStyleProperties(
            DotNodeFillStyle fillStyle = default,
            DotBorderStyle borderStyle = default,
            DotBorderWeight borderWeight = default,
            DotCornerStyle cornerStyle = default,
            bool diagonals = false,
            bool invisible = false
        )
            : base(fillStyle, borderStyle, borderWeight, cornerStyle, invisible)
        {
            Diagonals = diagonals;
        }

        /// <summary>
        ///     Causes small chords to be drawn near the vertices of the node’s polygon or, in case of circles and ellipses, two chords near
        ///     the top and the bottom of the shape.
        /// </summary>
        public virtual bool Diagonals { get; set; }
    }
}