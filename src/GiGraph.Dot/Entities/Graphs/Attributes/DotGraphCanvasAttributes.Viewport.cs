using GiGraph.Dot.Types.Graphs.Canvas.Viewport;

namespace GiGraph.Dot.Entities.Graphs.Attributes;

public partial class DotGraphCanvasAttributes
{
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
    ///     The zoom factor. The image in the original layout will be <paramref name="width"/> / <paramref name="zoom"/> by
    ///     <paramref name="height"/> / <paramref name="zoom"/> points in size. By default, the zoom factor is 1.
    /// </param>
    /// <remarks>
    ///     Viewport may be set by calling this method, <see cref="SetPointCenteredViewport"/>, or <see cref="SetNodeCenteredViewport"/>.
    ///     Only one of them should be used, as both of them write the same graph attribute.
    /// </remarks>
    public DotGraphCanvasAttributes SetViewport(double width, double height, double zoom = DotViewport.DefaultZoom)
    {
        Viewport = new DotViewport(width, height, zoom);
        return this;
    }

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
    ///     The x-coordinate of the viewport center.
    /// </param>
    /// <param name="y">
    ///     The y-coordinate of the viewport center.
    /// </param>
    /// <param name="zoom">
    ///     The zoom factor. The image in the original layout will be <paramref name="width"/> / <paramref name="zoom"/> by
    ///     <paramref name="height"/> / <paramref name="zoom"/> points in size. By default, the zoom factor is 1.
    /// </param>
    /// <remarks>
    ///     Viewport may be set by calling this method, <see cref="SetViewport"/>, or <see cref="SetNodeCenteredViewport"/>. Only one of
    ///     them should be used, as both of them write the same graph attribute.
    /// </remarks>
    public DotGraphCanvasAttributes SetPointCenteredViewport(double width, double height, double x, double y, double zoom = DotViewport.DefaultZoom)
    {
        Viewport = new DotPointCenteredViewport(width, height, x, y, zoom);
        return this;
    }

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
    ///     The zoom factor. The image in the original layout will be <paramref name="width"/> / <paramref name="zoom"/> by
    ///     <paramref name="height"/> / <paramref name="zoom"/> points in size. By default, the zoom factor is 1.
    /// </param>
    /// <remarks>
    ///     Viewport may be set by calling this method, <see cref="SetViewport"/>, or <see cref="SetPointCenteredViewport"/>. Only one of
    ///     them should be used, as both of them write the same graph attribute.
    /// </remarks>
    public DotGraphCanvasAttributes SetNodeCenteredViewport(double width, double height, string nodeId, double zoom = DotViewport.DefaultZoom)
    {
        Viewport = new DotNodeCenteredViewport(width, height, nodeId, zoom);
        return this;
    }
}