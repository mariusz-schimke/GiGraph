using GiGraph.Dot.Entities.Attributes.Collections.Graph;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Entities.Types.Arrows;
using GiGraph.Dot.Entities.Types.Edges;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
    public interface IDotEdgeTailAttributes
    {
        /// <summary>
        ///     The text label to be placed near the tail of the edge.
        /// </summary>
        DotLabel Label { get; set; }

        /// <summary>
        ///     Indicates where on the tail node to attach the tail of the edge. See also <see cref="DotEndpoint.Port" /> of the edge's
        ///     <see cref="DotEdge{TTail,THead}.Tail" /> property.
        /// </summary>
        DotEndpointPort Port { get; set; }

        /// <summary>
        ///     Logical tail of the edge. When the <see cref="IDotGraphClusterAttributes.AllowEdgeClipping" /> attribute for clusters (on the
        ///     graph level) is true, if the current property is defined, and is the identifier of a cluster containing the real tail node,
        ///     the edge is clipped to the boundary of the cluster.
        /// </summary>
        string ClusterId { get; set; }

        /// <summary>
        ///     If true (default), the tail of the edge is clipped to the boundary of the tail node; otherwise, the end of the edge goes to
        ///     the center of the node, or the center of a port, if applicable.
        /// </summary>
        bool? ClipToNodeBoundary { get; set; }

        /// <summary>
        ///     If defined, it is output as part of the tail label of the edge. Also, this value is used near the tail node, overriding any
        ///     primary <see cref="IDotEdgeBaseAttributes.Url" /> set on the edge.
        /// </summary>
        DotEscapeString Url { get; set; }

        /// <summary>
        ///     Synonym for <see cref="Url" />.
        /// </summary>
        DotEscapeString Href { get; set; }

        /// <summary>
        ///     If the edge has a <see cref="Url" /> specified for its tail, this attribute determines which window of the browser is used
        ///     for the URL. Setting it to "_graphviz" will open a new window if it doesn't already exist, or reuse it if it does. If
        ///     undefined, the value of the primary <see cref="IDotEdgeBaseAttributes.UrlTarget" /> attribute of the edge is used.
        /// </summary>
        DotEscapeString UrlTarget { get; set; }

        /// <summary>
        ///     Tooltip annotation attached to the tail of the edge. This is used only if the edge has a <see cref="Url" /> attribute
        ///     specified for its tail.
        /// </summary>
        DotEscapeString UrlTooltip { get; set; }

        /// <summary>
        ///     Edges with the same tail and the same <see cref="GroupName" /> value are aimed at the same point on the tail (dot only). This
        ///     has no effect on loops. Each node may have at most 5 unique <see cref="GroupName" /> values.
        /// </summary>
        string GroupName { get; set; }

        /// <summary>
        ///     <para>
        ///         Gets or sets the style of arrowhead on the tail node of the edge (default: <see cref="DotArrowheadShape.Normal" />).
        ///         Appears only if the <see cref="IDotEdgeBaseAttributes.ArrowDirections" /> attribute on the edge is
        ///         <see cref="DotArrowDirections.Backward" /> or <see cref="DotArrowDirections.Both" />.
        ///     </para>
        ///     <para>
        ///         For basic shapes assign a value of the <see cref="DotArrowheadShape" /> enumeration to this property (it will be
        ///         converted implicitly). For variants of the basic shapes (filled/empty, normal/clipped) use <see cref="DotArrowhead" />.
        ///         To generate an arrow composed of multiple arrowheads use <see cref="DotCompositeArrowhead" />.
        ///     </para>
        /// </summary>
        DotArrowheadDefinition Arrowhead { get; set; }
    }
}