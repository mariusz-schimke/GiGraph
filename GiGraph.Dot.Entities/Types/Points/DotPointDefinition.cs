using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Points
{
    /// <summary>
    ///     Represents a point in a two-dimensional plain.
    /// </summary>
    public abstract class DotPointDefinition : IDotEncodable
    {
        protected DotPointDefinition(bool? isFixed)
        {
            IsFixed = isFixed;
        }

        /// <summary>
        ///     Gets the component coordinates of the point.
        /// </summary>
        public abstract IEnumerable<double> Coordinates { get; }

        /// <summary>
        ///     Gets or sets the value indicating whether the node position (if applied to nodes) should not change (input-only).
        /// </summary>
        public virtual bool? IsFixed { get; set; }

        string IDotEncodable.GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return GetDotEncodedValue(options, syntaxRules);
        }

        protected internal string GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            var fix = true == IsFixed ? "!" : string.Empty;
            return $"{string.Join(",", Coordinates.Select(c => c.ToString(CultureInfo.InvariantCulture)))}{fix}";
        }

        public static implicit operator DotPointDefinition(double? xy)
        {
            return xy.HasValue ? new DotPoint(xy.Value) : null;
        }

        public static implicit operator DotPointDefinition(Point? point)
        {
            return point.HasValue ? new DotPoint(point.Value.X, point.Value.Y) : null;
        }

        public static implicit operator DotPointDefinition(PointF? point)
        {
            return point.HasValue ? new DotPoint(point.Value.X, point.Value.Y) : null;
        }
    }
}