namespace GiGraph.Dot.Types.Geometry
{
    /// <summary>
    ///     Geometry attributes of a polygonal shape.
    /// </summary>
    /// <param name="Sides">
    ///     Number of sides.
    /// </param>
    /// <param name="Regular">
    ///     Determines whether the shape is regular.
    /// </param>
    /// <param name="Peripheries">
    ///     Number of peripheries.
    /// </param>
    /// <param name="Rotation">
    ///     Rotation angle.
    /// </param>
    /// <param name="Skew">
    ///     Skew factor.
    /// </param>
    /// <param name="Distortion">
    ///     Distortion factor.
    /// </param>
    public record DotPolygon(int? Sides = null, bool? Regular = null, int? Peripheries = null, double? Rotation = null, double? Skew = null, double? Distortion = null);
}