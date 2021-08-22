using System.Drawing;
using System.Linq;
using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Types.Geometry
{
    /// <summary>
    ///     A rectangle.
    /// </summary>
    [DotJoinableType(separator: " ")]
    public record DotRectangle : IDotEncodable
    {
        /// <summary>
        ///     Initializes a new rectangle instance.
        /// </summary>
        /// <param name="x">
        ///     The x-coordinate of the lower-left corner in points.
        /// </param>
        /// <param name="y">
        ///     The y-coordinate of the lower-left corner in points.
        /// </param>
        /// <param name="width">
        ///     The width in points.
        /// </param>
        /// <param name="height">
        ///     The height in points.
        /// </param>
        public DotRectangle(double x, double y, double width, double height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        /// <summary>
        ///     Initializes a new rectangle instance.
        /// </summary>
        /// <param name="rectangle">
        ///     The source rectangle.
        /// </param>
        public DotRectangle(Rectangle rectangle)
            : this(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height)
        {
        }

        /// <summary>
        ///     Initializes a new rectangle instance.
        /// </summary>
        /// <param name="rectangle">
        ///     The source rectangle.
        /// </param>
        public DotRectangle(RectangleF rectangle)
            : this(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height)
        {
        }

        /// <summary>
        ///     The x-coordinate of the lower-left corner in points.
        /// </summary>
        public double X { get; init; }

        /// <summary>
        ///     The y-coordinate of the lower-left corner in points.
        /// </summary>
        public double Y { get; init; }

        /// <summary>
        ///     The width in points.
        /// </summary>
        public double Width { get; init; }

        /// <summary>
        ///     The height in points.
        /// </summary>
        public double Height { get; init; }

        string IDotEncodable.GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return GetDotEncodedValue(options, syntaxRules);
        }

        protected internal virtual string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            // The rectangle llx,lly,urx,ury gives the coordinates, in points, of the lower-left corner (llx,lly) and the upper-right corner (urx,ury).
            return string.Join(
                ",",
                new[] { X, Y, X + Width, Y + Height }.Select(value => value.ToString(syntaxRules.Culture))
            );
        }

        public static implicit operator DotRectangle(Rectangle? rectangle)
        {
            return rectangle.HasValue ? new DotRectangle(rectangle.Value.X, rectangle.Value.Y, rectangle.Value.Width, rectangle.Value.Height) : null;
        }

        public static implicit operator DotRectangle(RectangleF? rectangle)
        {
            return rectangle.HasValue ? new DotRectangle(rectangle.Value.X, rectangle.Value.Y, rectangle.Value.Width, rectangle.Value.Height) : null;
        }
    }
}