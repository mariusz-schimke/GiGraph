using System.Drawing;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Edges;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public interface IDotEdgeAttributes : IDotAttributeCollection, IDotFillable
    {
        /// <summary>
        /// <para>
        ///     Gets or sets the label to display on the edge. It can be a string or an HTML (<see cref="DotLabelHtml"/>).
        /// </para>
        /// <para>
        ///     When assigning a value to this property, an implicit conversion is performed.
        ///     <list type="bullet">
        ///         <item><see cref="Label"/> = "My label";</item>
        ///         <item><see cref="Label"/> = (<see cref="DotLabelHtml"/>) "&lt;TABLE&gt;...&lt;/TABLE&gt;";</item>
        ///     </list>
        /// </para>
        /// </summary>
        DotLabel Label { get; set; }

        /// <summary>
        /// External label for the edge. The label will be placed near the center of the edge. This can be useful in DOT
        /// to avoid the occasional problem when the use of edge labels distorts the layout. For other layouts,
        /// this attribute can be viewed as a synonym for the <see cref="Label"/> attribute.
        /// These labels are added after all nodes and edges have been placed. The labels will be placed so that they
        /// do not overlap any node or label. This means it may not be possible to place all of them.
        /// To force placing all of them, use the <see cref="IDotGraphAttributes.ForceExternalLabels"/> attribute on the graph.
        /// </summary>
        DotLabel ExternalLabel { get; set; }

        /// <summary>
        /// Tooltip annotation attached to the edge. If unset, Graphviz will use the <see cref="Label"/> attribute if defined.
        /// </summary>
        DotEscapableString Tooltip { get; set; }

        /// <summary>
        /// Gets or sets the color of the edge (default: <see cref="System.Drawing.Color.Black"/>).
        /// If <see cref="DotColorList"/> is used, with no weighted colors in its color collection (<see cref="DotColor"/> items only),
        /// the edge is drawn using parallel splines or lines, one for each color in the list, in the order given.
        /// The head arrow, if any, is drawn using the first color in the list, and the tail arrow, if any, the second color.
        /// This supports the common case of drawing opposing edges, but using parallel splines instead of separately routed multiedges.
        /// If any fraction is used, the colors are drawn in series, with each color being given roughly its specified fraction of the edge.
        /// </summary>
        DotColorDefinition Color { get; set; }

        /// <summary>
        /// Gets or sets the color used to fill the arrow head, assuming it has a filled style.
        /// If <see cref="FillColor"/> is not defined, <see cref="Color"/> is used.
        /// If it is not defined too, the default is used, except when the output format is MIF, which use black by default.
        /// </summary>
        DotColorDefinition FillColor { get; set; }

        /// <summary>
        /// <para>
        ///     Sets the style of the edge (default: null). See the descriptions of individual <see cref="DotStyle"/> values
        ///     to learn which styles are applicable to this element type.
        /// </para>
        /// <para>
        ///     Multiple styles can be used at once, for example:
        ///     <code>
        ///         <see cref="Style"/> = <see cref="DotStyle.Solid"/> | <see cref="DotStyle.Bold"/>;
        ///     </code>
        /// </para>
        /// </summary>
        DotStyle? Style { get; set; }

        /// <summary>
        /// Gets or sets the color used for text (default: <see cref="System.Drawing.Color.Black"/>).
        /// </summary>
        Color? FontColor { get; set; }

        /// <summary>
        /// <para>
        ///     Gets or sets the font used for text (default: "Times-Roman"). This very much depends on the output format and,
        ///     for non-bitmap output such as PostScript or SVG, the availability of the font when the graph is displayed or printed.
        ///     As such, it is best to rely on font faces that are generally available, such as Times-Roman, Helvetica or Courier.
        /// </para>
        /// <para>
        ///     How font names are resolved also depends on the underlying library that handles font name resolution.
        ///     If Graphviz was built using the fontconfig library, the latter library will be used to search for the font.
        ///     See the commands fc-list, fc-match and the other fontconfig commands for how names are resolved and which fonts are available.
        ///     Other systems may provide their own font package, such as Quartz for OS X.
        /// </para>
        /// <para>
        ///     Note that various font attributes, such as weight and slant, can be built into the font name.
        ///     Unfortunately, the syntax varies depending on which font system is dominant.
        ///     Thus, using <see cref="FontName"/> = "times bold italic" will produce a bold, slanted Times font using Pango,
        ///     the usual main font library. Alternatively, <see cref="FontName"/> = "times:italic" will produce a slanted Times font
        ///     from fontconfig, while <see cref="FontName"/> = "times-bold" will resolve to a bold Times using Quartz.
        ///     You will need to ascertain which package is used by your Graphviz system and refer to the relevant documentation.
        /// </para>
        /// <para>
        ///     If Graphviz is not built with a high-level font library, <see cref="FontName"/> will be considered the name
        ///     of a Type 1 or True Type font file. If you specify <see cref="FontName"/> = "schlbk", the tool will look
        ///     for a file named schlbk.ttf or schlbk.pfa or schlbk.pfb in one of the directories specified
        ///     by the <see cref="IDotGraphAttributes.FontPath"/> attribute. The lookup does support various aliases for the common fonts.
        /// </para>
        /// </summary>
        string FontName { get; set; }

        /// <summary>
        /// Gets or sets the font size used for text (in points; 72 points per inch). Default: 14.0, minimum: 1.0.
        /// </summary>
        double? FontSize { get; set; }

        /// <summary>
        /// Specifies the width of the pen, in points, used to draw lines and curves, including the boundaries of edges.
        /// The value has no effect on text. Default: 1.0, minimum: 0.0.
        /// </summary>
        double? PenWidth { get; set; }

        /// <summary>
        /// Gets or sets the multiplicative scale factor for arrowheads (default: 1.0, minimum: 0.0).
        /// </summary>
        double? ArrowSize { get; set; }

        /// <summary>
        /// Gets or sets the style of arrow head on the head node of an edge (default: <see cref="DotArrowType.Normal"/>).
        /// Appears only if the <see cref="ArrowDirection"/> attribute is <see cref="DotArrowDirection.Forward"/> or 
        /// <see cref="DotArrowDirection.Both"/>.
        /// </summary>
        DotArrowType? ArrowHead { get; set; }

        /// <summary>
        /// Gets or sets the style of arrow head on the tail node of an edge (default: <see cref="DotArrowType.Normal"/>).
        /// Appears only if the <see cref="ArrowDirection"/> attribute is <see cref="DotArrowDirection.Backward"/> or 
        /// <see cref="DotArrowDirection.Both"/>.
        /// </summary>
        DotArrowType? ArrowTail { get; set; }

        /// <summary>
        /// <para>
        ///     Gets or sets edge type for drawing arrow heads. Default: <see cref="DotArrowDirection.Forward"/> (for directed graphs),
        ///     <see cref="DotArrowDirection.None"/> (for undirected graphs).
        /// </para>
        /// <para>
        ///     Indicates which ends of the edge should be decorated with an arrow head.
        ///     The actual style of the arrow head can be specified using the <see cref="ArrowHead"/> and <see cref="ArrowTail"/> attributes.
        /// </para>
        /// <para>
        ///     A glyph is drawn at the head end of an edge if and only if the arrow direction is 
        ///     <see cref="DotArrowDirection.Forward"/> or <see cref="DotArrowDirection.Both"/>.
        /// </para>    
        /// <para>
        ///     A glyph is drawn at the tail end of an edge if and only if the direction is 
        ///     <see cref="DotArrowDirection.Backward"/> or <see cref="DotArrowDirection.Both"/>.
        /// </para>    
        /// <para>
        ///     For undirected edges T -- H, one of the nodes, usually the right hand one, is treated as the head
        ///     for the purpose of interpreting <see cref="DotArrowDirection.Forward"/> and <see cref="DotArrowDirection.Backward"/>.
        /// </para>
        /// </summary>
        DotArrowDirection? ArrowDirection { get; set; }

        /// <summary>
        /// Indicates where on the head node to attach the head of the edge. In the default case,
        /// the edge is aimed towards the center of the node, and then clipped at the node boundary.
        /// See also <see cref="DotEndpoint.Port"/> of the edge <see cref="DotEdge{TTail,THead}.Head"/> property.
        /// </summary>
        DotEndpointPort HeadPort { get; set; }

        /// <summary>
        /// Indicates where on the tail node to attach the tail of the edge. See also <see cref="DotEndpoint.Port"/>
        /// of the edge <see cref="DotEdge{TTail,THead}.Tail"/> property.
        /// </summary>
        DotEndpointPort TailPort { get; set; }

        /// <summary>
        /// Logical head of an edge. When the <see cref="IDotGraphAttributes.Compound"/> property of the graph is true,
        /// if the current property is defined and is the identifier of a cluster containing the real head node,
        /// the edge is clipped to the boundary of the cluster.
        /// </summary>
        string LogicalHeadId { get; set; }

        /// <summary>
        /// Logical tail of an edge. When the <see cref="IDotGraphAttributes.Compound"/> property of the graph is true,
        /// if the current property is defined and is the identifier of a cluster containing the real tail node,
        /// the edge is clipped to the boundary of the cluster.
        /// </summary>
        string LogicalTailId { get; set; }

        /// <summary>
        /// If true, attaches edge label to edge by a 2-segment polyline, underlining the label,
        /// then going to the closest point of spline. Default: false.
        /// </summary>
        bool? Decorate { get; set; }

        /// <summary>
        /// If false, the edge is not used in ranking the nodes. Default: true.
        /// See <see href="http://www.graphviz.org/doc/info/attrs.html#a:constraint">documentation</see>.
        /// </summary>
        bool? Constraint { get; set; }

        /// <summary>
        /// Comments are inserted into output. Device-dependent.
        /// </summary>
        string Comment { get; set; }

        /// <summary>
        /// <para>
        /// Hyperlinks incorporated into device-dependent output. At present, used in PS2, CMAP, I*MAP and SVG formats.
        /// For all these formats, URLs can be attached to nodes, edges and clusters.
        /// URL attributes can also be attached to the root graph in PS2, CMAP and I*MAP formats.
        /// This serves as the base URL for relative URLs in the former, and as the default image map file in the latter.
        /// </para>
        /// <para>
        /// For edges, the active areas are small circles where the edge contacts its head and tail nodes. In addition,
        /// for SVG, CMAPX and IMAP, the active area includes a thin polygon approximating the edge. The circles may overlap
        /// the related node, and the edge URL dominates. If the edge has a label, this will also be active. Finally,
        /// if the edge has a head or tail label, this will also be active.
        /// </para>
        /// <para>
        /// Note that, for edges, the attributes <see cref="HeadUrl"/>, <see cref="TailUrl"/>, <see cref="LabelUrl"/>,
        /// and <see cref="EdgeUrl"/> allow control of various parts of an edge. Also note that, if active areas of two edges overlap,
        /// it is unspecified which area dominates.
        /// </para>
        /// </summary>
        DotEscapableString Url { get; set; }

        /// <summary>
        /// Synonym for <see cref="Url"/>.
        /// </summary>
        DotEscapableString Href { get; set; }

        /// <summary>
        /// If the object has a <see cref="Url"/> specified, this attribute determines which window of the browser is used for the URL.
        /// See <see href="http://www.w3.org/TR/html401/present/frames.html#adef-target">W3C documentation</see>.
        /// </summary>
        DotEscapableString UrlTarget { get; set; }

        /// <summary>
        /// If defined, it is output as part of the head label of the edge. Also, this value is used near the head node,
        /// overriding any <see cref="Url"/> value.
        /// </summary>
        DotEscapableString HeadUrl { get; set; }

        /// <summary>
        /// Synonym for <see cref="HeadUrl"/>.
        /// </summary>
        DotEscapableString HeadHref { get; set; }

        /// <summary>
        /// If the edge has a <see cref="HeadUrl"/>, this attribute determines which window of the browser is used for the URL.
        /// Setting it to "_graphviz" will open a new window if it doesn't already exist, or reuse it if it does.
        /// If undefined, the value of the <see cref="UrlTarget"/> is used.
        /// </summary>
        DotEscapableString HeadUrlTarget { get; set; }

        /// <summary>
        /// Tooltip annotation attached to the head of an edge. This is used only if the edge has a <see cref="HeadUrl"/> attribute specified.
        /// </summary>
        DotEscapableString HeadUrlTooltip { get; set; }

        /// <summary>
        /// If defined, it is output as part of the tail label of the edge. Also, this value is used near the tail node,
        /// overriding any <see cref="Url"/> value.
        /// </summary>
        DotEscapableString TailUrl { get; set; }

        /// <summary>
        /// Synonym for <see cref="TailUrl"/>.
        /// </summary>
        DotEscapableString TailHref { get; set; }

        /// <summary>
        /// If the edge has a <see cref="TailUrl"/>, this attribute determines which window of the browser is used for the URL.
        /// Setting it to "_graphviz" will open a new window if it doesn't already exist, or reuse it if it does.
        /// If undefined, the value of the <see cref="UrlTarget"/> is used.
        /// </summary>
        DotEscapableString TailUrlTarget { get; set; }

        /// <summary>
        /// Tooltip annotation attached to the tail of an edge. This is used only if the edge has a <see cref="TailUrl"/> attribute specified.
        /// </summary>
        DotEscapableString TailUrlTooltip { get; set; }

        /// <summary>
        /// If defined, this is the link used for the label of an edge. This value overrides any <see cref="Url"/> defined for the edge.
        /// </summary>
        DotEscapableString LabelUrl { get; set; }

        /// <summary>
        /// Synonym for <see cref="LabelUrl"/>.
        /// </summary>
        DotEscapableString LabelHref { get; set; }

        /// <summary>
        /// If the edge has a <see cref="Url"/> or <see cref="LabelUrl"/> attribute, this attribute determines which window
        /// of the browser is used for the URL attached to the label. Setting it to "_graphviz" will open a new window
        /// if it doesn't already exist, or reuse it if it does. If undefined, the value of the <see cref="UrlTarget"/> is used.
        /// </summary>
        DotEscapableString LabelUrlTarget { get; set; }

        /// <summary>
        /// Tooltip annotation attached to label of an edge. This is used only if the edge has a <see cref="Url"/> or <see cref="LabelUrl"/> attribute specified.
        /// </summary>
        DotEscapableString LabelUrlTooltip { get; set; }

        /// <summary>
        /// If defined, this is the link used for the non-label parts of an edge. This value overrides any <see cref="Url"/> defined for the edge.
        /// Also, this value is used near the head or tail node unless overridden by a <see cref="HeadUrl"/> or <see cref="TailUrl"/> value, respectively.
        /// </summary>
        DotEscapableString EdgeUrl { get; set; }

        /// <summary>
        /// Synonym for <see cref="EdgeUrl"/>.
        /// </summary>
        DotEscapableString EdgeHref { get; set; }

        /// <summary>
        /// If the edge has a <see cref="Url"/> or <see cref="EdgeUrl"/> attribute, this attribute determines which window
        /// of the browser is used for the URL attached to the non-label part of the edge. Setting it to "_graphviz"
        /// will open a new window if it doesn't already exist, or reuse it if it does.
        /// If undefined, the value of the <see cref="UrlTarget"/> is used.
        /// </summary>
        DotEscapableString EdgeUrlTarget { get; set; }

        /// <summary>
        /// Tooltip annotation attached to the non-label part of an edge. This is used only if the edge has a <see cref="Url"/>
        /// or <see cref="EdgeUrl"/> attribute specified.
        /// </summary>
        DotEscapableString EdgeUrlTooltip { get; set; }
    }
}