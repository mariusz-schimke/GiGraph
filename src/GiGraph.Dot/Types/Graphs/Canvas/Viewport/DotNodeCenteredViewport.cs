using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Types.Graphs.Canvas.Viewport;

/// <summary>
///     Specifies a viewport for the graph image, with a node as the central point.
/// </summary>
/// <param name="width">
///     The width of the final image, in points.
/// </param>
/// <param name="height">
///     The height of the final image, in points.
/// </param>
/// <param name="nodeId">
///     The identifier of a node whose center should be used as the focus.
/// </param>
/// <param name="zoom">
///     The zoom factor. The image in the original layout will be <see cref="DotViewport.Width"/> / <see cref="DotViewport.Zoom"/> by
///     <see cref="DotViewport.Height"/> / <see cref="DotViewport.Zoom"/> points in size. By default, the zoom factor is 1.
/// </param>
public class DotNodeCenteredViewport(double width, double height, string nodeId, double zoom = DotViewport.DefaultZoom)
    : DotViewport(width, height, zoom)
{
    /// <summary>
    ///     The identifier of a node whose center should be used as the focus.
    /// </summary>
    public string NodeId { get; } = nodeId ?? throw new ArgumentNullException(nameof(nodeId), "Node identifier must not be null.");

    protected override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
    {
        var whz = base.GetDotEncodedValue(options, syntaxRules);

        // Based on the Graphviz code, escaping the apostrophe is not supported, but they do handle a case when there is an apostrophe and no comma.
        // When there is both a comma and an apostrophe in the node identifier, the centering will not work.
        return NodeId.Contains('\'') && false == NodeId.Contains(',')
            ? $"{whz},{NodeId}"
            : $"{whz},'{NodeId}'";
    }
}