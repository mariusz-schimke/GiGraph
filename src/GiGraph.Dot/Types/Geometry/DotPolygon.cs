namespace GiGraph.Dot.Types.Geometry;

/// <summary>
///     Geometry attributes of a polygonal shape.
/// </summary>
/// <param name="Sides">
///     Number of sides.
/// </param>
/// <param name="Regular">
///     Determines whether the shape is regular.
/// </param>
public record DotPolygon(int? Sides = null, bool? Regular = null);