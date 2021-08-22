using System.Linq;
using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Types.Viewport
{
    /// <summary>
    ///     Specifies a viewport for the graph image.
    /// </summary>
    /// <param name="Width">
    ///     The width of the final image, in points.
    /// </param>
    /// <param name="Height">
    ///     The height of the final image, in points.
    /// </param>
    /// <param name="Zoom">
    ///     The zoom factor. The image in the original layout will be <see cref="Width" /> / <see cref="Zoom" /> by <see cref="Height" />
    ///     / <see cref="Zoom" /> points in size. By default, the zoom factor is 1.
    /// </param>
    public record DotViewport(double Width, double Height, double Zoom = DotViewport.DefaultZoom) : IDotEncodable
    {
        protected const double DefaultZoom = 1;

        string IDotEncodable.GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return GetDotEncodedValue(options, syntaxRules);
        }

        protected internal virtual string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return string.Join(
                ",",
                new[] { Width, Height, Zoom }.Select(v => v.ToString(syntaxRules.Culture))
            );
        }
    }
}