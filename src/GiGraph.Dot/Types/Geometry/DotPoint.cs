using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Types.Geometry;

/// <summary>
///     Represents a point in an n-dimensional plain.
/// </summary>
public class DotPoint : IDotEncodable
{
    /// <summary>
    ///     Creates and initializes a new point in an n-dimensional plain.
    /// </summary>
    /// <param name="isFixed">
    ///     Determines whether the node position (if applied to nodes) should not change (input-only).
    /// </param>
    /// <param name="coordinates">
    ///     The coordinates of the point.
    /// </param>
    public DotPoint(bool? isFixed, params double[] coordinates)
    {
        IsFixed = isFixed;

        Coordinates = coordinates ?? throw new ArgumentNullException(nameof(coordinates), "Point coordinate collection must not be null.");

        if (coordinates.Length == 0)
        {
            throw new ArgumentException("At least one coordinate has to be specified for a point.", nameof(coordinates));
        }
    }

    /// <summary>
    ///     Creates and initializes a new point in an n-dimensional plain.
    /// </summary>
    /// <param name="coordinates">
    ///     The coordinates of the point.
    /// </param>
    /// <param name="isFixed">
    ///     Determines whether the node position (if applied to nodes) should not change (input-only).
    /// </param>
    public DotPoint(IEnumerable<double> coordinates, bool? isFixed = null)
        : this(isFixed, coordinates.ToArray())
    {
    }

    /// <summary>
    ///     Creates and initializes a new point in an n-dimensional plain.
    /// </summary>
    /// <param name="coordinates">
    ///     The coordinates of the point.
    /// </param>
    public DotPoint(params double[] coordinates)
        : this(isFixed: null, coordinates)
    {
    }

    /// <summary>
    ///     Creates and initializes a new single-value point that, depending on the context, may be interpreted as an equal value for
    ///     every component of the attribute the point is assigned to (e.g. padding or margin).
    /// </summary>
    /// <param name="value">
    ///     The value to use.
    /// </param>
    /// <param name="isFixed">
    ///     Determines whether the node position (if applied to nodes) should not change (input-only).
    /// </param>
    public DotPoint(double value, bool? isFixed = null)
        : this(isFixed, value)
    {
    }

    /// <summary>
    ///     Creates and initializes a new point in a two-dimensional plain.
    /// </summary>
    /// <param name="x">
    ///     The x-coordinate of the point.
    /// </param>
    /// <param name="y">
    ///     The y-coordinate of the point.
    /// </param>
    /// <param name="isFixed">
    ///     Determines whether the node position (if applied to nodes) should not change (input-only).
    /// </param>
    public DotPoint(double x, double y, bool? isFixed = null)
        : this(isFixed, x, y)
    {
    }

    /// <summary>
    ///     Creates and initializes a new point in a two-dimensional plain.
    /// </summary>
    /// <param name="point">
    ///     The <see cref="System.Drawing.Point" /> to initialize the instance with.
    /// </param>
    /// <param name="isFixed">
    ///     Determines whether the node position (if applied to nodes) should not change (input-only).
    /// </param>
    public DotPoint(Point point, bool? isFixed = null)
        : this(isFixed, point.X, point.Y)
    {
    }

    /// <summary>
    ///     Creates and initializes a new point in a two-dimensional plain.
    /// </summary>
    /// <param name="point">
    ///     The <see cref="System.Drawing.PointF" /> to initialize the instance with.
    /// </param>
    /// <param name="isFixed">
    ///     Determines whether the node position (if applied to nodes) should not change (input-only).
    /// </param>
    public DotPoint(PointF point, bool? isFixed = null)
        : this(isFixed, point.X, point.Y)
    {
    }

    /// <summary>
    ///     The coordinates of the point.
    /// </summary>
    public double[] Coordinates { get; }

    /// <summary>
    ///     Determines whether the node position (if applied to nodes) should not change (input-only).
    /// </summary>
    public bool? IsFixed { get; init; }

    string IDotEncodable.GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => GetDotEncodedValue(options, syntaxRules);

    protected virtual string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
    {
        var fix = IsFixed is true ? "!" : string.Empty;
        return $"{string.Join(",", Coordinates.Select(c => c.ToString(syntaxRules.Culture)))}{fix}";
    }

    [return: NotNullIfNotNull(nameof(value))]
    public static implicit operator DotPoint?(double? value) => value.HasValue ? new DotPoint(value.Value) : null;

    [return: NotNullIfNotNull(nameof(point))]
    public static implicit operator DotPoint?(Point? point) => point.HasValue ? new DotPoint(point.Value) : null;

    [return: NotNullIfNotNull(nameof(point))]
    public static implicit operator DotPoint?(PointF? point) => point.HasValue ? new DotPoint(point.Value) : null;
}