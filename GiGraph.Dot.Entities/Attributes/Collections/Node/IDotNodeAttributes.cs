using GiGraph.Dot.Entities.Attributes.Collections.Graph;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Points;
using GiGraph.Dot.Entities.Types.Records;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections.Node
{
    public interface IDotNodeAttributes
    {
        /// <summary>
        ///     <para>
        ///         Gets or sets the label to display on the node. It may be plain text (<see cref="string" />), HTML (
        ///         <see cref="DotHtmlLabel" />), or a record (<see cref="DotRecordLabel" />) for a record-based node (when
        ///         <see cref="Shape" /> = <see cref="DotNodeShape.Record" /> or <see cref="Shape" /> =
        ///         <see cref="DotNodeShape.RoundedRecord" />).
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
        ///     force placing all of them, use the <see cref="DotGraphAttributes.ForceExternalLabels" /> attribute on the graph.
        /// </summary>
        DotLabel ExternalLabel { get; set; }

        /// <summary>
        ///     Vertical placement of the label (default: <see cref="DotVerticalAlignment.Center" />). This attribute is used only when the
        ///     height of the node is larger than the height of its label.
        /// </summary>
        DotVerticalAlignment? VerticalLabelAlignment { get; set; }

        /// <summary>
        ///     Tooltip annotation attached to the node. If unset, Graphviz will use the <see cref="Label" /> attribute if defined. Note that
        ///     if the label is a record specification or an HTML-like label, the resulting tooltip may be unhelpful. In this case, if
        ///     tooltips will be generated, the user should set a tooltip attribute explicitly.
        /// </summary>
        DotEscapeString Tooltip { get; set; }

        /// <summary>
        ///     <para>
        ///         Gets or sets the color to use for the node (default: <see cref="System.Drawing.Color.Black" />).
        ///     </para>
        ///     <para>
        ///         If <see cref="DotGradientColor" /> is used, with no weighted colors in its parameters (<see cref="DotColor" /> items
        ///         only), and the <see cref="Style" /> contains <see cref="DotStyles.Filled" />, a linear gradient fill is done.
        ///     </para>
        ///     <para>
        ///         If <see cref="DotGradientColor" /> is used with weighted colors (see <see cref="DotWeightedColor" />), a degenerate
        ///         linear gradient fill is done. This essentially does a fill using two colors, with the
        ///         <see cref="DotWeightedColor.Weight" /> specifying how much of region is filled with each color.
        ///     </para>
        ///     <para>
        ///         If the <see cref="Style" /> attribute contains the value <see cref="DotStyles.Radial" />, then a radial gradient fill is
        ///         done. See also the <see cref="GradientAngle" /> attribute for setting a gradient angle.
        ///     </para>
        ///     <para>
        ///         These fills work with any shape. For certain shapes, the <see cref="Style" /> attribute can be set to do fills using more
        ///         than 2 colors (set the <see cref="DotStyles.Striped" /> or <see cref="DotStyles.Wedged" /> shape, and use
        ///         <see cref="DotMultiColor" /> as a color list definition).
        ///     </para>
        /// </summary>
        DotColorDefinition Color { get; set; }

        /// <summary>
        ///     <para>
        ///         Gets or sets the color used to fill the background of the node, assuming that <see cref="Style" /> is
        ///         <see cref="DotStyles.Filled" />. If <see cref="FillColor" /> is not defined, <see cref="Color" /> is used. If it is not
        ///         defined too, the default is used, except for <see cref="Shape" /> of <see cref="DotNodeShape.Point" />, or when the
        ///         output format is MIF, which use black by default.
        ///     </para>
        ///     <para>
        ///         When <see cref="DotGradientColor" /> is used, a gradient fill is generated. By default, this is a linear fill; setting
        ///         <see cref="Style" /> to <see cref="DotStyles.Radial" /> will cause a radial fill. If the second color is
        ///         <see cref="System.Drawing.Color.Empty" />, the default color is used for it. See also the <see cref="GradientAngle" />
        ///         attribute for setting a gradient angle.
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
        int? GradientAngle { get; set; }

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
        ///     <para>
        ///         Width of node, in inches (default: 0.75, minimum: 0.01). This is taken as the initial, minimum width of the node. If
        ///         <see cref="Sizing" /> is <see cref="DotNodeSizing.Fixed" />, this will be the final width of the node. Otherwise, if the
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
        ///         <see cref="Sizing" /> is <see cref="DotNodeSizing.Fixed" />, this will be the final height of the node. Otherwise, if the
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
        DotNodeSizing? Sizing { get; set; }

        /// <summary>
        ///     Specifies space left around the node's label. By default, the value is (0.11, 0.055).
        /// </summary>
        DotPoint Margin { get; set; }

        /// <summary>
        ///     Comments are inserted into output. Device-dependent.
        /// </summary>
        string Comment { get; set; }

        /// <summary>
        ///     Determines how inedges and outedges, that is, edges with the node as their head or tail node respectively, are ordered (dot
        ///     only). If defined on a graph or subgraph level, the value is applied to all nodes in the graph or subgraph. Note that the
        ///     graph attribute takes precedence over the node attribute.
        /// </summary>
        DotEdgeOrderingMode? EdgeOrderingMode { get; set; }

        /// <summary>
        ///     The name of the group the node belongs to. If the endpoints of an edge belong to the same group (have the same group name
        ///     assigned), parameters are set to avoid crossings and keep the edges straight (dot only).
        /// </summary>
        string GroupName { get; set; }

        /// <summary>
        ///     Gets or sets the sorting index of the node (default: 0). If <see cref="DotGraphAttributes.PackingMode" /> indicates an array
        ///     packing, this attribute specifies an insertion order among the components, with smaller values inserted first.
        /// </summary>
        int? SortIndex { get; set; }
    }
}