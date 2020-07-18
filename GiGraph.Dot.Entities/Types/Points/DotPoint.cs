using System.Collections.Generic;
using System.Drawing;

namespace GiGraph.Dot.Entities.Types.Points
{
    /// <summary>
    ///     Represents a point in a two-dimensional plain.
    /// </summary>
    public class DotPoint : DotPointDefinition
    {
        public DotPoint(double x, double y, bool? isFixed = null)
            : base(isFixed)
        {
            X = x;
            Y = y;
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

        public override IEnumerable<double> Coordinates => new[] { X, Y };

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