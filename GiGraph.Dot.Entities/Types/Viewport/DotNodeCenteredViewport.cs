using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Viewport
{
    /// <summary>
    ///     Specifies a viewport for the graph image, with a node as the central point.
    /// </summary>
    public class DotNodeCenteredViewport : DotViewport
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
        /// <param name="nodeId">
        ///     The identifier of a node whose center should be used as the focus.
        /// </param>
        /// <param name="zoom">
        ///     The zoom factor. The image in the original layout will be <see cref="DotViewport.Width" /> / <see cref="DotViewport.Zoom" />
        ///     by <see cref="DotViewport.Height" /> / <see cref="DotViewport.Zoom" /> points in size. By default, the zoom factor is 1.
        /// </param>
        public DotNodeCenteredViewport(double width, double height, string nodeId, double zoom = DefaultZoom)
            : base(width, height, zoom)
        {
            NodeId = nodeId;
        }

        /// <summary>
        ///     Gets the identifier of a node whose center should be used as the focus.
        /// </summary>
        public virtual string NodeId { get; }

        protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
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
}