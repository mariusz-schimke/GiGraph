using GiGraph.Dot.Types.Geometry;

namespace GiGraph.Dot.Types.Nodes
{
    /// <summary>
    ///     Node size properties.
    /// </summary>
    public class DotNodeSize : DotSize
    {
        /// <summary>
        ///     Creates a new size instance.
        /// </summary>
        /// <param name="width">
        ///     The width to set.
        /// </param>
        /// <param name="height">
        ///     The height to set.
        /// </param>
        /// <param name="mode">
        ///     The sizing mode to set.
        /// </param>
        public DotNodeSize(double? width = null, double? height = null, DotNodeSizing? mode = null)
            : base(width, height)
        {
            Mode = mode;
        }

        /// <summary>
        ///     Gets or sets node sizing mode.
        /// </summary>
        public virtual DotNodeSizing? Mode { get; set; }
    }
}