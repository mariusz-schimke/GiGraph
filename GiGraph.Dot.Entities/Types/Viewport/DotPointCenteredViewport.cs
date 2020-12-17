using System.Globalization;
using System.Linq;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Viewport
{
    /// <summary>
    ///     Specifies a viewport for the graph image, with a central point.
    /// </summary>
    public class DotPointCenteredViewport : DotViewport
    {
        /// <summary>
        ///     Creates and initializes a viewport instance.
        /// </summary>
        /// <param name="width">
        ///     The width of the final image, in points.
        /// </param>
        /// <param name="height">
        ///     The height of the final image, in points.
        /// </param>
        /// <param name="x">
        ///     The x coordinate of the center of the viewport.
        /// </param>
        /// <param name="y">
        ///     The y coordinate of the center of the viewport.
        /// </param>
        /// <param name="zoom">
        ///     The zoom factor. The image in the original layout will be <see cref="DotViewport.Width" /> / <see cref="DotViewport.Zoom" />
        ///     by <see cref="DotViewport.Height" /> / <see cref="DotViewport.Zoom" /> points in size. By default, the zoom factor is 1.
        /// </param>
        public DotPointCenteredViewport(double width, double height, double x, double y, double zoom = DefaultZoom)
            : base(width, height, zoom)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        ///     Gets the x coordinate of the center of the viewport.
        /// </summary>
        public virtual double X { get; }

        /// <summary>
        ///     Gets the y coordinate of the center of the viewport.
        /// </summary>
        public virtual double Y { get; }

        protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            var whz = base.GetDotEncodedValue(options, syntaxRules);
            var xy = string.Join(",", new[] { X, Y }.Select(v => v.ToString(CultureInfo.InvariantCulture)));
            return $"{whz},{xy}";
        }
    }
}