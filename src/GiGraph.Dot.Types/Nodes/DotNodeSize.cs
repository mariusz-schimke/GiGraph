using GiGraph.Dot.Types.Geometry;

namespace GiGraph.Dot.Types.Nodes
{
    /// <summary>
    ///     Node size properties.
    /// </summary>
    /// <param name="Width">
    ///     The width to set.
    /// </param>
    /// <param name="Height">
    ///     The height to set.
    /// </param>
    /// <param name="Mode">
    ///     The sizing mode to set.
    /// </param>
    public record DotNodeSize(double? Width = null, double? Height = null, DotNodeSizing? Mode = null) : DotSize(Width, Height)
    {
        /// <summary>
        ///     The node sizing mode.
        /// </summary>
        public virtual DotNodeSizing? Mode { get; init; } = Mode;
    }
}