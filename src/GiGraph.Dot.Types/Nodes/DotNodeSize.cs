using GiGraph.Dot.Types.Geometry;

namespace GiGraph.Dot.Types.Nodes
{
    /// <summary>
    ///     Node size attributes.
    /// </summary>
    /// <param name="Width">
    ///     The width.
    /// </param>
    /// <param name="Height">
    ///     The height.
    /// </param>
    /// <param name="Mode">
    ///     The sizing mode.
    /// </param>
    public record DotNodeSize(double? Width = null, double? Height = null, DotNodeSizing? Mode = null) : DotSize(Width, Height);
}