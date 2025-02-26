using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Types.Viewport;

/// <summary>
///     Specifies a viewport for the graph image, with a central point.
/// </summary>
/// <param name="width">
///     The width of the final image, in points.
/// </param>
/// <param name="height">
///     The height of the final image, in points.
/// </param>
/// <param name="x">
///     The x-coordinate of the center of the viewport.
/// </param>
/// <param name="y">
///     The y-coordinate of the center of the viewport.
/// </param>
/// <param name="zoom">
///     The zoom factor. The image in the original layout will be <see cref="DotViewport.Width" /> / <see cref="DotViewport.Zoom" />
///     by <see cref="DotViewport.Height" /> / <see cref="DotViewport.Zoom" /> points in size. By default, the zoom factor is 1.
/// </param>
public class DotPointCenteredViewport(double width, double height, double x, double y, double zoom = DotViewport.DefaultZoom)
    : DotViewport(width, height, zoom)
{
    /// <summary>
    ///     The x-coordinate of the center of the viewport.
    /// </summary>
    public double X { get; } = x;

    /// <summary>
    ///     The y-coordinate of the center of the viewport.
    /// </summary>
    public double Y { get; } = y;

    protected override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
    {
        var whz = base.GetDotEncodedValue(options, syntaxRules);
        var xy = string.Join(",", new[] { X, Y }.Select(v => v.ToString(syntaxRules.Culture)));
        return $"{whz},{xy}";
    }
}