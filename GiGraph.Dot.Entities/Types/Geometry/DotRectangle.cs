using System.Drawing;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Geometry
{
    /// <summary>
    ///     A rectangle.
    /// </summary>
    public class DotRectangle : IDotEncodable
    {
        /// <summary>
        ///     Initializes a new rectangle instance.
        /// </summary>
        /// <param name="x">
        ///     The x-coordinate of the upper-left corner in points.
        /// </param>
        /// <param name="y">
        ///     The y-coordinate of the upper-left corner in points.
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
        ///     Gets or sets the x-coordinate of the upper-left corner in points.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        ///     Gets or sets the y-coordinate of the upper-left corner in points.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        ///     Gets or sets the width in points.
        /// </summary>
        public virtual double Width { get; set; }

        /// <summary>
        ///     Gets or sets the height in points.
        /// </summary>
        public virtual double Height { get; set; }

        string IDotEncodable.GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return GetDotEncodedValue(options, syntaxRules);
        }

        protected internal virtual string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            // The rectangle llx,lly,urx,ury gives the coordinates, in points, of the lower-left corner (llx,lly) and the upper-right corner (urx,ury).
            // I decided to use the standard approach, however, where a rect is defined by the upper-left and the lower right corner.
            return $"{X.ToString(syntaxRules.Culture)},{(Y + Height).ToString(syntaxRules.Culture)},{(X + Width).ToString(syntaxRules.Culture)},{Y.ToString(syntaxRules.Culture)}";
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