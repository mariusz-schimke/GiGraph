using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Types.Images
{
    /// <summary>
    ///     Image properties.
    /// </summary>
    /// <param name="Path">
    ///     Image path.
    /// </param>
    /// <param name="Alignment">
    ///     Image alignment.
    /// </param>
    /// <param name="Scaling">
    ///     Image scaling.
    /// </param>
    public record DotImage(string Path = null, DotAlignment? Alignment = null, DotImageScaling? Scaling = null);
}