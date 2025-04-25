using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Types.Graphs.Canvas.Viewport;

/// <summary>
///     Specifies a viewport for the graph image.
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
public class DotViewport(double width, double height, double zoom = DotViewport.DefaultZoom) : IDotEncodable
{
    protected const double DefaultZoom = 1;

    /// <summary>
    ///     The width of the final image, in points.
    /// </summary>
    public double Width { get; } = width;

    /// <summary>
    ///     The height of the final image, in points.
    /// </summary>
    public double Height { get; } = height;

    /// <summary>
    ///     The zoom factor. The image in the original layout will be <see cref="Width" /> / <see cref="Zoom" /> by <see cref="Height" />
    ///     / <see cref="Zoom" /> points in size. By default, the zoom factor is 1.
    /// </summary>
    public double Zoom { get; } = zoom;

    string IDotEncodable.GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => GetDotEncodedValue(options, syntaxRules);

    protected virtual string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
    {
        return string.Join(
            ",",
            new[] { Width, Height, Zoom }.Select(v => v.ToString(syntaxRules.Culture))
        );
    }
}