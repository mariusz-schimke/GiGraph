using System.Linq;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Types.Viewport
{
    /// <summary>
    ///     Specifies a viewport for the graph image, with a central point.
    /// </summary>
    /// <param name="Width">
    ///     The width of the final image, in points.
    /// </param>
    /// <param name="Height">
    ///     The height of the final image, in points.
    /// </param>
    /// <param name="X">
    ///     The x-coordinate of the center of the viewport.
    /// </param>
    /// <param name="Y">
    ///     The y-coordinate of the center of the viewport.
    /// </param>
    /// <param name="Zoom">
    ///     The zoom factor. The image in the original layout will be <see cref="DotViewport.Width" /> / <see cref="DotViewport.Zoom" />
    ///     by <see cref="DotViewport.Height" /> / <see cref="DotViewport.Zoom" /> points in size. By default, the zoom factor is 1.
    /// </param>
    public record DotPointCenteredViewport(double Width, double Height, double X, double Y, double Zoom = DotViewport.DefaultZoom)
        : DotViewport(Width, Height, Zoom)
    {
        protected override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            var whz = base.GetDotEncodedValue(options, syntaxRules);
            var xy = string.Join(",", new[] { X, Y }.Select(v => v.ToString(syntaxRules.Culture)));
            return $"{whz},{xy}";
        }
    }
}