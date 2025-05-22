namespace GiGraph.Dot.Types.Geometry;

/// <summary>
///     The transform attributes of a polygonal shape.
/// </summary>
/// <param name="Rotation">
///     Rotation angle.
/// </param>
/// <param name="Skew">
///     Skew factor.
/// </param>
/// <param name="Distortion">
///     Distortion factor.
/// </param>
public record DotTransform(double? Rotation = null, double? Skew = null, double? Distortion = null);