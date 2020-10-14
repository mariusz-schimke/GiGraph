using GiGraph.Dot.Entities.Attributes.Collections.Graph;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Hyperlinks;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
    public interface IDotEdgeAttributes
    {
        /// <summary>
        ///     <para>
        ///         Gets or sets the label to display on the edge. It may be plain text (<see cref="string" />) or HTML (
        ///         <see cref="DotHtmlLabel" />). See also <see cref="DotTextFormatter" /> for plain text label formatting if needed.
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
        ///     External label for the edge. The label will be placed near the center of the edge. This can be useful in dot to avoid the
        ///     occasional problem when the use of edge labels distorts the layout. For other layouts, this attribute can be viewed as a
        ///     synonym for the <see cref="Label" /> attribute. These labels are added after all nodes and edges have been placed. The labels
        ///     will be placed so that they do not overlap any node or label. This means it may not be possible to place all of them. To
        ///     force placing all of them, use the <see cref="IDotGraphAttributes.ForceExternalLabels" /> attribute on the graph.
        /// </summary>
        DotLabel ExternalLabel { set; get; }

        /// <summary>
        ///     If true, allows edge labels to be less constrained in position. In particular, it may appear on top of other edges. Default:
        ///     false.
        /// </summary>
        bool? AllowLabelFloat { get; set; }

        /// <summary>
        ///     Minimum edge length (rank difference between head and tail). Default: 1, minimum: 0.
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
        ///     <see cref="Length" /> attribute. Default: 1, minimum: 0 (dot, twopi), 1 (neato, fdp).
        /// </summary>
        double? Weight { get; set; }

        /// <summary>
        ///     Tooltip annotation attached to the edge. If unset, Graphviz will use the <see cref="Label" /> attribute if defined.
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
        ///     <para>
        ///         Sets the style of the edge (default: unset). See the descriptions of individual <see cref="DotStyles" /> values to learn
        ///         which styles are applicable to this element type.
        ///     </para>
        ///     <para>
        ///         Multiple styles can be used at once, for example: <see cref="Style" /> = <see cref="DotStyles.Solid" /> |
        ///         <see cref="DotStyles.Bold" />;
        ///     </para>
        /// </summary>
        DotStyles? Style { get; set; }

        /// <summary>
        ///     Specifies the width of the pen, in points, used to draw lines and curves, including the boundaries of edges. The value has no
        ///     effect on text. Default: 1.0, minimum: 0.0.
        /// </summary>
        double? PenWidth { get; set; }

        /// <summary>
        ///     Gets or sets the multiplicative scale factor for arrowheads (default: 1.0, minimum: 0.0).
        /// </summary>
        double? ArrowheadScale { get; set; }

        /// <summary>
        ///     <para>
        ///         Gets or sets edge type for drawing arrowheads. Default: <see cref="DotArrowDirections.Forward" /> (for directed graphs),
        ///         <see cref="DotArrowDirections.None" /> (for undirected graphs).
        ///     </para>
        ///     <para>
        ///         Indicates which ends of the edge should be decorated with an arrow head. The actual style of the arrowhead can be
        ///         specified using the <see cref="IDotEdgeHeadAttributes.Arrowhead" /> attribute on the head of the edge, and the
        ///         corresponding <see cref="IDotEdgeTailAttributes.Arrowhead" /> attribute on the tail of the edge.
        ///     </para>
        ///     <para>
        ///         A glyph is drawn at the head end of the edge if and only if the arrow direction is
        ///         <see cref="DotArrowDirections.Forward" /> or <see cref="DotArrowDirections.Both" />.
        ///     </para>
        ///     <para>
        ///         A glyph is drawn at the tail end of the edge if and only if the direction is <see cref="DotArrowDirections.Backward" />
        ///         or <see cref="DotArrowDirections.Both" />.
        ///     </para>
        ///     <para>
        ///         For undirected edges T -- H, one of the nodes, usually the right hand one, is treated as the head for the purpose of
        ///         interpreting <see cref="DotArrowDirections.Forward" /> and <see cref="DotArrowDirections.Backward" />.
        ///     </para>
        /// </summary>
        DotArrowDirections? ArrowDirections { get; set; }

        /// <summary>
        ///     If true, attaches label to the edge by a 2-segment polyline, underlining the label, then going to the closest point of
        ///     spline. Default: false.
        /// </summary>
        bool? AttachLabel { get; set; }

        /// <summary>
        ///     If false, the edge is not used in ranking the nodes (default: true). See
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
        ///     If defined, this is the link used for the label of the edge. This value overrides any <see cref="Url" /> defined for the
        ///     edge.
        /// </summary>
        DotEscapeString LabelUrl { get; set; }

        /// <summary>
        ///     Synonym for <see cref="LabelUrl" />.
        /// </summary>
        DotEscapeString LabelHref { get; set; }

        /// <summary>
        ///     If the edge has a <see cref="Url" /> or <see cref="LabelUrl" /> attribute, this attribute determines which window of the
        ///     browser is used for the URL attached to the label. Setting it to <see cref="DotHyperlinkTargets.NewWindow" /> will open a new
        ///     window if it doesn't already exist, or reuse it if it does. If undefined, the value of the <see cref="UrlTarget" /> is used.
        /// </summary>
        DotEscapeString LabelUrlTarget { get; set; }

        /// <summary>
        ///     Tooltip annotation attached to label of the edge. This is used only if the edge has a <see cref="Url" /> or
        ///     <see cref="LabelUrl" /> attribute specified.
        /// </summary>
        DotEscapeString LabelUrlTooltip { get; set; }

        /// <summary>
        ///     If defined, this is the link used for the non-label parts of the edge. This value overrides any primary <see cref="Url" />
        ///     defined for the edge. Also, this value is used near the head or tail node unless overridden by its head
        ///     <see cref="IDotEdgeHeadAttributes.Url" /> or tail <see cref="IDotEdgeTailAttributes.Url" />, respectively.
        /// </summary>
        DotEscapeString EdgeUrl { get; set; }

        /// <summary>
        ///     Synonym for <see cref="EdgeUrl" />.
        /// </summary>
        DotEscapeString EdgeHref { get; set; }

        /// <summary>
        ///     If the edge has a <see cref="Url" /> or <see cref="EdgeUrl" /> attribute, this attribute determines which window of the
        ///     browser is used for the URL attached to the non-label part of the edge. Setting it to <see cref="DotHyperlinkTargets.NewWindow" />
        ///     will open a new window if it doesn't already exist, or reuse it if it does. If undefined, the value of the
        ///     <see cref="UrlTarget" /> is used.
        /// </summary>
        DotEscapeString EdgeUrlTarget { get; set; }

        /// <summary>
        ///     Tooltip annotation attached to the non-label part of the edge. This is used only if the edge has a <see cref="Url" /> or
        ///     <see cref="EdgeUrl" /> attribute specified.
        /// </summary>
        DotEscapeString EdgeUrlTooltip { get; set; }
    }
}