using GiGraph.Dot.Entities.Graphs.Attributes;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.Geometry;
using GiGraph.Dot.Types.Nodes;
using GiGraph.Dot.Types.Records;
using GiGraph.Dot.Types.Styling;
using GiGraph.Dot.Types.Text;

namespace GiGraph.Dot.Entities.Nodes.Attributes
{
    public interface IDotNodeAttributes
    {
        /// <summary>
        ///     <para>
        ///         Gets or sets the style of the cluster (default: unset). See the descriptions of individual <see cref="DotStyles" />
        ///         values to learn which styles are applicable to this type of element.
        ///     </para>
        ///     <para>
        ///         Multiple styles can be used at once, for example: <see cref="Style" /> = <see cref="DotStyles.Rounded" /> |
        ///         <see cref="DotStyles.Bold" />;
        ///     </para>
        /// </summary>
        DotStyles? Style { get; set; }

        /// <summary>
        ///     <para>
        ///         Gets or sets the label to display on the node. It may be plain text (<see cref="string" />), HTML (
        ///         <see cref="DotHtmlLabel" />), or a record (<see cref="DotRecordLabel" />) for a record-based node (when
        ///         <see cref="Shape" /> = <see cref="DotNodeShape.Record" /> or <see cref="Shape" /> =
        ///         <see cref="DotNodeShape.RoundedRecord" />). When not specified, node identifier is used.
        ///     </para>
        ///     <para>
        ///         See also <see cref="DotTextFormatter" /> for plain text label formatting if needed, and <see cref="DotRecordBuilder" />
        ///         for building records.
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
        ///             <item>
        ///                 <description>
        ///                     <see cref="Label" /> = new <see cref="DotRecord" />("My field 1", "My field 2");
        ///                 </description>
        ///             </item>
        ///         </list>
        ///     </para>
        /// </summary>
        DotLabel Label { get; set; }

        /// <summary>
        ///     External label for the node. The label will be placed outside of the node but near it. This can be useful in DOT to avoid the
        ///     occasional problem when the use of edge labels distorts the layout. For other layouts, this attribute can be viewed as a
        ///     synonym for the <see cref="Label" /> attribute. These labels are added after all nodes and edges have been placed. The labels
        ///     will be placed so that they do not overlap any node or label. This means it may not be possible to place all of them. To
        ///     force placing all of them, use the <see cref="DotGraphLayoutAttributes.ForceExternalLabels" /> attribute of graph
        ///     <see cref="DotGraphAttributes.Layout" />.
        /// </summary>
        DotLabel ExternalLabel { get; set; }

        /// <summary>
        ///     Vertical placement of the label (default: <see cref="DotVerticalAlignment.Center" />). This attribute is used only when the
        ///     height of the node is larger than the height of its label.
        /// </summary>
        DotVerticalAlignment? LabelAlignment { get; set; }

        /// <summary>
        ///     Tooltip annotation attached to the node (svg, cmap only). If unset, Graphviz will use the <see cref="Label" /> attribute if
        ///     defined. Note that if the label is a record specification or an HTML-like label, the resulting tooltip may be unhelpful. In
        ///     this case, if tooltips will be generated, the user should set a tooltip attribute explicitly.
        /// </summary>
        DotEscapeString Tooltip { get; set; }

        /// <summary>
        ///     <para>
        ///         Gets or sets the color to use for the node (default: <see cref="System.Drawing.Color.Black" />).
        ///     </para>
        ///     <para>
        ///         If <see cref="DotGradientColor" /> is used, with no weighted colors in its parameters (<see cref="DotColor" /> items
        ///         only), and a <see cref="DotNodeFillStyle.Normal" /> fill style is specified for the node, a linear gradient fill is done.
        ///     </para>
        ///     <para>
        ///         If <see cref="DotGradientColor" /> is used with weighted colors (see <see cref="DotWeightedColor" />), a degenerate
        ///         linear gradient fill is done. This essentially does a fill using two colors, with the
        ///         <see cref="DotWeightedColor.Weight" /> specifying how much of region is filled with each color.
        ///     </para>
        ///     <para>
        ///         If a <see cref="DotNodeFillStyle.Radial" /> fill style is specified for the node, then a radial gradient fill is done.
        ///         See also the <see cref="GradientFillAngle" /> attribute for setting a gradient angle.
        ///     </para>
        ///     <para>
        ///         These fills work with any shape. For certain shapes, fill style can be set to do fills using more than 2 colors (set the
        ///         fill style to <see cref="DotNodeFillStyle.Striped" /> or <see cref="DotNodeFillStyle.Wedged" /> style, and use
        ///         <see cref="DotMultiColor" /> as a color list definition).
        ///     </para>
        /// </summary>
        DotColorDefinition Color { get; set; }

        /// <summary>
        ///     <para>
        ///         Gets or sets the color used to fill the background of the node, assuming that the fill style of the node is
        ///         <see cref="DotNodeFillStyle.Normal" /> (default: <see cref="System.Drawing.Color.LightGray" />). If
        ///         <see cref="FillColor" /> is not defined, <see cref="Color" /> is used. If it is not defined too, the default is used,
        ///         except for <see cref="Shape" /> of <see cref="DotNodeShape.Point" />, or when the output format is MIF, which use black
        ///         by default.
        ///     </para>
        ///     <para>
        ///         When <see cref="DotGradientColor" /> is used, a gradient fill is generated. By default, this is a linear fill; applying
        ///         the <see cref="DotNodeFillStyle.Radial" /> fill style to the node will cause a radial fill. If the second color is
        ///         <see cref="System.Drawing.Color.Empty" />, the default color is used for it. See also the
        ///         <see cref="GradientFillAngle" /> attribute for setting a gradient angle.
        ///     </para>
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
        ///     If a gradient fill is being used, this determines the angle of the fill. For linear fills, the colors transform along a line
        ///     specified by the angle and the center of the object. For radial fills, a value of zero causes the colors to transform
        ///     radially from the center; for non-zero values, the colors transform from a point near the object's periphery as specified by
        ///     the value. If unset, the default angle is 0.
        /// </summary>
        int? GradientFillAngle { get; set; }

        /// <summary>
        ///     Specifies the width of the pen, in points, used to draw lines and curves. The value has no effect on text. Default: 1.0,
        ///     minimum: 0.0.
        /// </summary>
        double? BorderWidth { get; set; }

        /// <summary>
        ///     Gets or sets the shape of the node (default: <see cref="DotNodeShape.Ellipse" />).
        /// </summary>
        DotNodeShape? Shape { get; set; }

        /// <summary>
        ///     Specifies space left around the node's label. By default, the value is (0.11, 0.055).
        /// </summary>
        DotPoint Padding { get; set; }

        /// <summary>
        ///     Comments are inserted into output. Device-dependent.
        /// </summary>
        string Comment { get; set; }

        /// <summary>
        ///     Determines how inedges and outedges, that is, edges with the node as their head or tail node respectively, are ordered (dot
        ///     only). If defined on a graph or subgraph, the value is applied to all nodes in the graph or subgraph. Note that the
        ///     corresponding graph attribute takes precedence over the node attribute.
        /// </summary>
        DotEdgeOrderingMode? EdgeOrderingMode { get; set; }

        /// <summary>
        ///     The name of the group the node belongs to (dot only). If the endpoints of an edge belong to the same group (have the same
        ///     group name assigned), parameters are set to avoid crossings and keep the edges straight (dot only).
        /// </summary>
        string GroupName { get; set; }

        /// <summary>
        ///     Gets or sets the sorting index of the node (default: 0). If <see cref="DotGraphLayoutAttributes.PackingMode" /> of graph
        ///     <see cref="DotGraphAttributes.Layout" /> indicates an array packing, this attribute specifies an insertion order among the
        ///     components, with smaller values inserted first.
        /// </summary>
        int? SortIndex { get; set; }

        /// <summary>
        ///     <para>
        ///         Specifies whether the node should be used as the center of the layout and the root of the generated spanning tree
        ///         (default: false; circo, twopi only).
        ///     </para>
        ///     <para>
        ///         In twopi, root will actually be the central node. In circo, the block containing the node will be central in the drawing
        ///         of its connected component. If not defined, twopi will pick a most central node, and circo will pick a random node.
        ///     </para>
        ///     <para>
        ///         If the <see cref="DotGraphAttributes.RootNodeId" /> attribute on the graph is defined as the empty string, twopi will
        ///         reset it to name of the node picked as the root node.
        ///     </para>
        ///     <para>
        ///         For twopi, it is possible to have multiple roots, presumably one for each component. If more than one node in a component
        ///         is marked as the root, twopi will pick one.
        ///     </para>
        /// </summary>
        bool? IsRoot { get; set; }

        /// <summary>
        ///     <para>
        ///         Allows the graph author to provide an identifier for graph objects which is to be included in the output (svg,
        ///         postscript, map only).
        ///     </para>
        ///     <para>
        ///         Normal <see cref="DotEscapeString.NodeId" />, <see cref="DotEscapeString.EdgeDefinition" />,
        ///         <see cref="DotEscapeString.GraphId" /> substitutions can be applied (see <see cref="DotTextFormatter" />). Note, however,
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