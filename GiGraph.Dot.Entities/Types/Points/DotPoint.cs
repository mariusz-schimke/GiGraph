using System.Drawing;
using System.Globalization;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Points
{
    /// <summary>
    ///     Represents a point in a two-dimensional plain.
    /// </summary>
    public class DotPoint : IDotEncodable
    {
        public DotPoint(double x, double y, bool? isFixed = null)
        {
            X = x;
            Y = y;
            IsFixed = isFixed;
        }

        public DotPoint(double xy, bool? isFixed = null)
            : this(xy, xy, isFixed)
        {
        }

        /// <summary>
        ///     Gets or sets the x-coordinate of the point.
        /// </summary>
        public virtual double X { get; set; }

        /// <summary>
        ///     Gets or sets the y-coordinate of the point.
        /// </summary>
        public virtual double Y { get; set; }

        /// <summary>
        ///     Gets or sets the value indicating whether the node position (if applied to nodes) should not change (input-only).
        /// </summary>
        public virtual bool? IsFixed { get; set; }

        string IDotEncodable.GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            var culture = CultureInfo.InvariantCulture;
            return $"{X.ToString(culture)},{Y.ToString(culture)}{(true == IsFixed ? "!" : string.Empty)}";
        }

        public static implicit operator DotPoint(double? xy)
        {
            return xy.HasValue ? new DotPoint(xy.Value) : null;
        }

        public static implicit operator DotPoint(Point? point)
        {
            return point.HasValue ? new DotPoint(point.Value.X, point.Value.Y) : null;
        }

        public static implicit operator DotPoint(PointF? point)
        {
            return point.HasValue ? new DotPoint(point.Value.X, point.Value.Y) : null;
        }
    }
}