using System.Globalization;
using System.Linq;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Viewport
{
    /// <summary>
    ///     Specifies a viewport for the graph image.
    /// </summary>
    public class DotViewport : IDotEncodable
    {
        protected const double DefaultZoom = 1;

        /// <summary>
        ///     Creates and initializes a viewport instance.
        /// </summary>
        /// <param name="width">
        ///     The width of the final image, in points.
        /// </param>
        /// <param name="height">
        ///     The height of the final image, in points.
        /// </param>
        /// <param name="zoom">
        ///     The zoom factor. The image in the original layout will be <see cref="Width" /> / <see cref="Zoom" /> by <see cref="Height" />
        ///     / <see cref="Zoom" /> points in size. By default, the zoom factor is 1.
        /// </param>
        public DotViewport(double width, double height, double zoom = DefaultZoom)
        {
            Width = width;
            Height = height;
            Zoom = zoom;
        }

        /// <summary>
        ///     Gets the width of the final image, in points.
        /// </summary>
        public virtual double Width { get; }

        /// <summary>
        ///     Gets the height of the final image, in points.
        /// </summary>
        public virtual double Height { get; }

        /// <summary>
        ///     Gets the zoom factor. The image in the original layout will be <see cref="Width" /> / <see cref="Zoom" /> by
        ///     <see cref="Height" /> / <see cref="Zoom" /> points in size. By default, the zoom factor is 1.
        /// </summary>
        public virtual double Zoom { get; }

        string IDotEncodable.GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return GetDotEncodedValue(options, syntaxRules);
        }

        protected internal virtual string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return string.Join(
                ",",
                new[] { Width, Height, Zoom }.Select(v => v.ToString(CultureInfo.InvariantCulture))
            );
        }
    }
}