using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Types.Viewport;

/// <summary>
///     Specifies a viewport for the graph image, with a node as the central point.
/// </summary>
/// <param name="Width">
///     The width of the final image, in points.
/// </param>
/// <param name="Height">
///     The height of the final image, in points.
/// </param>
/// <param name="NodeId">
///     The identifier of a node whose center should be used as the focus.
/// </param>
/// <param name="Zoom">
///     The zoom factor. The image in the original layout will be <see cref="DotViewport.Width" /> / <see cref="DotViewport.Zoom" />
///     by <see cref="DotViewport.Height" /> / <see cref="DotViewport.Zoom" /> points in size. By default, the zoom factor is 1.
/// </param>
public record DotNodeCenteredViewport(double Width, double Height, string NodeId, double Zoom = DotViewport.DefaultZoom)
    : DotViewport(Width, Height, Zoom)
{
    protected override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
    {
        var whz = base.GetDotEncodedValue(options, syntaxRules);

        // Based on the Graphviz code, escaping the apostrophe is not supported, but
        // they implemented a fallback for a case when there is an apostrophe and no comma.
        // When there is both a comma and an apostrophe in the node identifier, the centering will not work.
        return true == NodeId?.Contains("'") && false == NodeId?.Contains(",")
            ? $"{whz},{NodeId}"
            : $"{whz},'{NodeId}'";
    }
}