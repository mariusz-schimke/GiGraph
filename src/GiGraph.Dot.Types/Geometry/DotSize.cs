namespace GiGraph.Dot.Types.Geometry
{
    /// <summary>
    ///     Size properties.
    /// </summary>
    /// <param name="Width">
    ///     The width.
    /// </param>
    /// <param name="Height">
    ///     The height.
    /// </param>
    public record DotSize(double? Width = null, double? Height = null);
}