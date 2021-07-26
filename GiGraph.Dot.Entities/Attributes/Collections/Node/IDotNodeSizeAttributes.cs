using GiGraph.Dot.Entities.Types.Nodes;

namespace GiGraph.Dot.Entities.Attributes.Collections.Node
{
    public interface IDotNodeSizeAttributes
    {
        /// <summary>
        ///     <para>
        ///         Width of node, in inches (default: 0.75, minimum: 0.01). This is taken as the initial, minimum width of the node. If
        ///         <see cref="Mode" /> is <see cref="DotNodeSizing.Fixed" />, this will be the final width of the node. Otherwise, if the
        ///         node label requires more width to fit, the node's width will be increased to contain the label. Note also that, if the
        ///         output format is dot, the value given to width will be the final value.
        ///     </para>
        ///     <para>
        ///         If the node shape is regular, the width and height are made identical. In this case, if either the width or the height is
        ///         set explicitly, that value is used. In this case, if both the width or the height are set explicitly, the maximum of the
        ///         two values is used. If neither is set explicitly, the minimum of the two default values is used.
        ///     </para>
        /// </summary>
        double? Width { get; set; }

        /// <summary>
        ///     <para>
        ///         Height of node, in inches (default: 0.5, minimum: 0.02). This is taken as the initial, minimum height of the node. If
        ///         <see cref="Mode" /> is <see cref="DotNodeSizing.Fixed" />, this will be the final height of the node. Otherwise, if the
        ///         node label requires more height to fit, the node's height will be increased to contain the label. Note also that, if the
        ///         output format is dot, the value given to height will be the final value.
        ///     </para>
        ///     <para>
        ///         If the node shape is regular, the width and height are made identical. In this case, if either the width or the height is
        ///         set explicitly, that value is used. In this case, if both the width or the height are set explicitly, the maximum of the
        ///         two values is used. If neither is set explicitly, the minimum of the two default values is used.
        ///     </para>
        /// </summary>
        double? Height { get; set; }

        /// <summary>
        ///     Gets or sets the value indicating how the size of the node is determined (default: <see cref="DotNodeSizing.Auto" />).
        /// </summary>
        DotNodeSizing? Mode { get; set; }
    }
}