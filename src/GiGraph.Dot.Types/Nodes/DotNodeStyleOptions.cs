using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Types.Nodes
{
    /// <summary>
    ///     Node style options.
    /// </summary>
    public class DotNodeStyleOptions : DotClusterNodeCommonStyleOptions<DotNodeFillStyle>
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
        /// <param name="invisible">
        ///     Determines whether the element is invisible.
        /// </param>
        public DotNodeStyleOptions(
            DotNodeFillStyle fillStyle = default,
            DotBorderStyle borderStyle = default,
            DotBorderWeight borderWeight = default,
            DotCornerStyle cornerStyle = default,
            bool invisible = false
        )
            : base(fillStyle, borderStyle, borderWeight, cornerStyle, invisible)
        {
        }
    }
}