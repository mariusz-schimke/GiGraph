using GiGraph.Dot.Entities.Graphs.Attributes;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Edges.Attributes
{
    public interface IDotEdgeAttributes
    {
        /// <summary>
        ///     <para>
        ///         Gets or sets the style of the edge (default: unset). See the descriptions of individual <see cref="DotStyles" /> values
        ///         to learn which styles are applicable to this type of element.
        ///     </para>
        ///     <para>
        ///         Multiple styles can be used at once, for example: <see cref="Style" /> = <see cref="DotStyles.Rounded" /> |
        ///         <see cref="DotStyles.Bold" />;
        ///     </para>
        /// </summary>
        DotStyles? Style { get; set; }

        /// <summary>
        ///     <para>
        ///         Gets or sets the label to display on the edge. It may be plain text (<see cref="string" />) or HTML (
        ///         <see cref="DotHtmlLabel" />). See also <see cref="DotFormattedTextBuilder" /> for plain text label formatting if needed.
        ///     </para>
        ///     <para>
        ///         Examples:
        ///         <list type="bullet">
        ///             <item>
        ///                 <description>
        ///                     <see cref="Label" /> = "My label";
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <description>
        ///                     <see cref="Label" /> = new <see cref="DotHtmlLabel" />("&lt;TABLE&gt;...&lt;/TABLE&gt;");
        ///                 </description>
        ///             </item>
        ///         </list>
        ///     </para>
        /// </summary>
        DotLabel Label { get; set; }

        /// <summary>
        ///     <para>
        ///         External label for the edge. The label will be placed near the center of the edge. This can be useful in dot to avoid the
        ///         occasional problem when the use of edge labels distorts the layout. For other layouts, this attribute can be viewed as a
        ///         synonym for the <see cref="Label" /> attribute.
        ///     </para>
        ///     <para>
        ///         These labels are added after all nodes and edges have been placed. The labels will be placed so that they do not overlap
        ///         any node or label. This means it may not be possible to place all of them. To force placing all of them, use the
        ///         <see cref="DotGraphLayoutAttributes.ForceExternalLabels" /> attribute on the graph.
        ///     </para>
        /// </summary>
        DotLabel ExternalLabel { set; get; }

        /// <summary>
        ///     If true, allows edge labels to be less constrained in position. In particular, it may appear on top of other edges. Default:
        ///     false.
        /// </summary>
        bool? AllowLabelFloat { get; set; }

        /// <summary>
        ///     Minimum edge length (rank difference between head and tail). Dot only, default: 1, minimum: 0.
        /// </summary>
        int? MinLength { get; set; }

        /// <summary>
        ///     Preferred edge length, in inches (fdp, neato only). Default: 1.0 (neato), 0.3 (fdp).
        /// </summary>
        double? Length { get; set; }

        /// <summary>
        ///     Weight of the edge. In dot, the heavier the weight, the shorter, straighter and more vertical the edge is. Note that weights
        ///     in dot must be integers. For twopi, a weight of 0 indicates the edge should not be used in constructing a spanning tree from
        ///     the root. For other layouts, a larger weight encourages the layout to make the edge length closer to that specified by the
        ///     <see cref="Length" /> attribute. Default: 1. Minimum: 0 [int] (dot, twopi), 1 [double] (neato, fdp).
        /// </summary>
        double? Weight { get; set; }

        /// <summary>
        ///     Tooltip annotation attached to the edge (svg, cmap only). If unset, Graphviz will use the <see cref="Label" /> attribute if
        ///     defined.
        /// </summary>
        DotEscapeString Tooltip { get; set; }

        /// <summary>
        ///     <para>
        ///         Gets or sets the color to use for the edge (default: <see cref="System.Drawing.Color.Black" />).
        ///     </para>
        ///     <para>
        ///         If <see cref="DotMultiColor" /> is used, with no weighted colors in its color collection (<see cref="DotColor" /> items
        ///         only), the edge is drawn using parallel splines or lines, one for each color in the list, in the order given. The head
        ///         arrow, if any, is drawn using the first color in the list, and the tail arrow, if any, the second color. This supports
        ///         the common case of drawing opposing edges, but using parallel splines instead of separately routed multiedges.
        ///     </para>
        ///     <para>
        ///         If <see cref="DotMultiColor" /> is used with at least one weighted color (<see cref="DotWeightedColor" />), the colors
        ///         are drawn in series, with each color being given roughly its specified fraction of the edge, expressed by the
        ///         <see cref="DotWeightedColor.Weight" /> property.
        ///     </para>
        /// </summary>
        DotColorDefinition Color { get; set; }

        /// <summary>
        ///     Gets or sets the color used to fill the arrowhead, assuming it has a filled style. If <see cref="FillColor" /> is not
        ///     defined, <see cref="Color" /> is used. If it is not defined too, the default is used, except when the output format is MIF,
        ///     which use black by default.
        /// </summary>
        DotColorDefinition FillColor { get; set; }

        /// <summary>
        ///     Specifies a color scheme namespace to use. If defined, specifies the context for interpreting color names. If no color scheme
        ///     is set, the standard <see cref="DotColorSchemes.X11" /> naming is used. For example, if
        ///     <see cref="DotColorSchemes.DotBrewerColorSchemes.BuGn9" /> Brewer color scheme is used, then a color named "7", e.g.
        ///     Color.FromName("7"), will be evaluated in the context of that specific color scheme. See <see cref="DotColorSchemes" /> for
        ///     supported scheme names.
        /// </summary>
        string ColorScheme { get; set; }

        /// <summary>
        ///     Specifies the width of the pen, in points, used to draw lines and curves, including the boundaries of edges. The value has no
        ///     effect on text. Default: 1.0, minimum: 0.0.
        /// </summary>
        double? Width { get; set; }

        /// <summary>
        ///     Gets or sets the multiplicative scale factor for arrowheads (default: 1.0, minimum: 0.0).
        /// </summary>
        double? ArrowheadScale { get; set; }

        /// <summary>
        ///     <para>
        ///         Gets or sets edge type for drawing arrowheads. Default: <see cref="DotEdgeDirections.Forward" /> (for directed graphs),
        ///         <see cref="DotEdgeDirections.None" /> (for undirected graphs).
        ///     </para>
        ///     <para>
        ///         Indicates which ends of the edge should be decorated with an arrowhead. The actual style of the arrowhead may be
        ///         specified using the <see cref="DotEdgeEndpointAttributes.Arrowhead" /> attribute on the
        ///         <see cref="DotEdgeAttributes.Head" /> or <see cref="DotEdgeAttributes.Tail" /> of the edge.
        ///     </para>
        ///     <para>
        ///         A glyph is drawn at the head end of the edge if and only if the direction is <see cref="DotEdgeDirections.Forward" /> or
        ///         <see cref="DotEdgeDirections.Both" />.
        ///     </para>
        ///     <para>
        ///         A glyph is drawn at the tail end of the edge if and only if the direction is <see cref="DotEdgeDirections.Backward" /> or
        ///         <see cref="DotEdgeDirections.Both" />.
        ///     </para>
        ///     <para>
        ///         For undirected edges T -- H, one of the nodes, usually the right hand one, is treated as the head for the purpose of
        ///         interpreting <see cref="DotEdgeDirections.Forward" /> and <see cref="DotEdgeDirections.Backward" />.
        ///     </para>
        /// </summary>
        DotEdgeDirections? Directions { get; set; }

        /// <summary>
        ///     If true, attaches label to the edge by a 2-segment polyline, underlining the label, then going to the closest point of
        ///     spline. Default: false.
        /// </summary>
        bool? AttachLabel { get; set; }

        /// <summary>
        ///     If false, the edge is not used in ranking the nodes (dot only, default: true). See
        ///     <see href="http://www.graphviz.org/doc/info/attrs.html#a:constraint">
        ///         documentation
        ///     </see>
        ///     for more details.
        /// </summary>
        bool? Constrain { get; set; }

        /// <summary>
        ///     Comments are inserted into output. Device-dependent.
        /// </summary>
        string Comment { get; set; }

        /// <summary>
        ///     <para>
        ///         Allows the graph author to provide an identifier for graph objects which is to be included in the output (svg,
        ///         postscript, map only).
        ///     </para>
        ///     <para>
        ///         Normal <see cref="DotEscapeString.NodeId" />, <see cref="DotEscapeString.EdgeDefinition" />,
        ///         <see cref="DotEscapeString.GraphId" /> substitutions can be applied (see <see cref="DotFormattedTextBuilder" />). Note, however,
        ///         that <see cref="DotEscapeString.EdgeDefinition" /> does not provide a unique ID for multi-edges.
        ///     </para>
        ///     <para>
        ///         If provided, it is the responsibility of the provider to keep ID values unique for its intended downstream use. If no ID
        ///         attribute is provided, then a unique internal ID is used. However, this value is unpredictable by the graph writer.
        ///     </para>
        ///     <para>
        ///         If the graph provides an ID attribute, this will be used as a prefix for internally generated attributes. By making
        ///         internally-used attributes distinct, the user can include multiple image maps in the same document.
        ///     </para>
        /// </summary>
        DotEscapeString ObjectId { get; set; }
    }
}