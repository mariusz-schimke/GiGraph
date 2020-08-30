using System.Drawing;
using GiGraph.Dot.Entities.Attributes.Collections.Cluster;
using GiGraph.Dot.Entities.Attributes.Collections.Edge;
using GiGraph.Dot.Entities.Attributes.Collections.Node;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Packing;
using GiGraph.Dot.Entities.Types.Points;
using GiGraph.Dot.Entities.Types.Ranks;
using GiGraph.Dot.Entities.Types.Scaling;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections.Graph
{
    public interface IDotGraphAttributes
    {
        /// <summary>
        ///     <para>
        ///         Gets or sets the label to display on the graph. It can be a string or an HTML (<see cref="DotHtmlLabel" />).
        ///     </para>
        ///     <para>
        ///         When assigning a value to this property, an implicit conversion is performed.
        ///         <list type="bullet">
        ///             <item>
        ///                 <see cref="Label" /> = "My label";
        ///             </item>
        ///             <item>
        ///                 <see cref="Label" /> = (<see cref="DotHtmlLabel" />) "&lt;TABLE&gt;...&lt;/TABLE&gt;";
        ///             </item>
        ///         </list>
        ///     </para>
        /// </summary>
        DotLabel Label { get; set; }

        /// <summary>
        ///     Justification for graph and cluster labels. Note that a subgraph inherits attributes from its parent. Thus, if the root graph
        ///     sets this attribute to <see cref="DotHorizontalAlignment.Left" />, the subgraph inherits this value. Default:
        ///     <see cref="DotHorizontalAlignment.Center" />.
        /// </summary>
        DotHorizontalAlignment? HorizontalLabelAlignment { get; set; }

        /// <summary>
        ///     Vertical placement of the label (default: <see cref="DotVerticalAlignment.Bottom" />; only
        ///     <see cref="DotVerticalAlignment.Top" /> and <see cref="DotVerticalAlignment.Bottom" /> are allowed). Note that a subgraph
        ///     inherits attributes from its parent. Thus, if the root graph sets this attribute to
        ///     <see cref="DotVerticalAlignment.Bottom" />, the subgraph inherits this value.
        /// </summary>
        DotVerticalAlignment? VerticalLabelAlignment { get; set; }

        /// <summary>
        ///     If true, all node <see cref="IDotNodeAttributes.ExternalLabel" /> and edge <see cref="IDotEdgeAttributes.ExternalLabel" />
        ///     attributes are placed, even if there is some overlap with nodes or other labels (default: true).
        /// </summary>
        bool? ForceExternalLabels { get; set; }

        /// <summary>
        ///     Gets or sets the color to use for clusters (default: <see cref="System.Drawing.Color.Black" />). If
        ///     <see cref="DotMultiColor" /> is used, with no weighted colors in its color collection (<see cref="DotColor" /> items only),
        ///     and the <see cref="Style" /> is <see cref="DotStyles.Filled" />, a linear gradient fill is done using the first two colors. If
        ///     weighted colors are present (see <see cref="DotWeightedColor" />), a degenerate linear gradient fill is done. This
        ///     essentially does a fill using two colors, with the <see cref="DotWeightedColor.Weight" /> specifying how much of region is
        ///     filled with each color. If the <see cref="Style" /> attribute contains the value <see cref="DotStyles.Radial" />, then a
        ///     radial gradient fill is done. These fills work with any shape. For certain shapes, the <see cref="Style" /> attribute can be
        ///     set to do fills using more than 2 colors (see <see cref="DotStyles.Striped" />).
        /// </summary>
        DotColorDefinition Color { get; set; }

        /// <summary>
        ///     <para>
        ///         Gets or sets the background color of the graph (default: none). Used as the background for entire canvas.
        ///     </para>
        ///     <para>
        ///         When <see cref="DotMultiColor" /> is used, a gradient fill is generated. By default, this is a linear fill; setting
        ///         <see cref="Style" /> to <see cref="DotStyles.Radial" /> will cause a radial fill. At present, only two colors are used. If
        ///         the second color is <see cref="System.Drawing.Color.Empty" />, the default color is used for it. See also the
        ///         <see cref="GradientAngle" /> attribute for setting the gradient angle.
        ///     </para>
        ///     <para>
        ///         For certain output formats, such as PostScript, no fill is done for the root graph unless background color is explicitly
        ///         set. For bitmap formats, however, the bits need to be initialized to something, so the canvas is filled with white by
        ///         default. This means that if the bitmap output is included in some other document, all of the bits within the bitmap's
        ///         bounding box will be set, overwriting whatever color or graphics were already on the page. If this effect is not desired,
        ///         and you only want to set bits explicitly assigned in drawing the graph, set <see cref="BackgroundColor" /> =
        ///         <see cref="System.Drawing.Color.Transparent" />.
        ///     </para>
        /// </summary>
        DotColorDefinition BackgroundColor { get; set; }

        /// <summary>
        ///     <para>
        ///         Gets or sets the color used to fill the background of clusters, assuming that their
        ///         <see cref="IDotClusterAttributes.Style" /> is <see cref="DotStyles.Filled" />. If <see cref="FillColor" /> is not defined,
        ///         <see cref="Color" /> is used. If <see cref="Color" /> is not defined,
        ///         <see cref="IDotClusterAttributes.BackgroundColor" /> is used. If it is not defined too, the default is used, except when
        ///         the output format is MIF, which use black by default.
        ///     </para>
        ///     <para>
        ///         When <see cref="DotMultiColor" /> is used, a gradient fill is generated. By default, this is a linear fill; setting
        ///         <see cref="Style" /> to <see cref="DotStyles.Radial" /> will cause a radial fill. At present, only two colors are used. If
        ///         the second color is missing, the default color is used for it. See also the <see cref="GradientAngle" /> attribute for
        ///         setting the gradient angle. Note that a cluster inherits the root graph's attributes if defined. Thus, if the root graph
        ///         has defined a fill color, this will override a <see cref="IDotClusterAttributes.Color" /> or
        ///         <see cref="IDotClusterAttributes.BackgroundColor" /> attribute set for the cluster.
        ///     </para>
        /// </summary>
        DotColorDefinition FillColor { get; set; }

        /// <summary>
        ///     Specifies a color scheme namespace. If defined, it specifies the context for interpreting color names. In particular, if a
        ///     color value has form "xxx" or "//xxx", then the color xxx will be evaluated according to the current color scheme. If no
        ///     color scheme is set, the standard X11 naming is used. For example, if "bugn9" color scheme is used, then a color named "7",
        ///     e.g.
        ///     <c>
        ///         Color.FromName("7")
        ///     </c>
        ///     , is interpreted as "/bugn9/7".
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
        ///     If 90, sets drawing orientation to landscape (default: 0).
        /// </summary>
        int? RotateBy { get; set; }

        /// <summary>
        ///     Specifies the width of the pen, in points, used to draw lines and curves, including the boundaries of edges and clusters. The
        ///     value is inherited by subclusters. It has no effect on text. Default: 1.0, minimum: 0.0.
        /// </summary>
        double? PenWidth { get; set; }

        /// <summary>
        ///     Color used to draw the bounding box around clusters (default: <see cref="System.Drawing.Color.Black" />). If
        ///     <see cref="PenColor" /> is not defined, <see cref="Color" /> is used. If this is not defined, the default is used. Note that
        ///     a cluster inherits the root graph's attributes if defined. Thus, if the root graph has defined a pen color, this will
        ///     override a <see cref="IDotClusterAttributes.Color" /> or <see cref="IDotClusterAttributes.BackgroundColor" /> attribute set
        ///     for the cluster.
        /// </summary>
        Color? PenColor { get; set; }

        /// <summary>
        ///     Gets or sets the direction of graph layout (default: <see cref="DotRankDirection.TopToBottom" />).
        /// </summary>
        DotRankDirection? LayoutDirection { get; set; }

        /// <summary>
        ///     Controls how, and if, edges are represented. By default, the attribute is unset. How this is interpreted depends on the
        ///     layout. For dot, the default is to draw edges as splines (<see cref="DotEdgeShape.Spline" />). For all other layouts, the
        ///     default is to draw edges as line segments (<see cref="DotEdgeShape.Line" />). Note that for these latter layouts, if
        ///     <see cref="DotEdgeShape.Spline" /> is used, this requires non-overlapping nodes (cf.
        ///     <see href="http://www.graphviz.org/doc/info/attrs.html#d:overlap">
        ///         overlap
        ///     </see>
        ///     ). If FDP is used for layout and <see cref="DotEdgeShape.Compound" /> is used, then the edges are drawn to avoid clusters as
        ///     well as nodes.
        /// </summary>
        DotEdgeShape? EdgeShape { get; set; }

        /// <summary>
        ///     <para>
        ///         Sets the style of the graph (default: null). See the descriptions of individual <see cref="DotStyles" /> values to learn
        ///         which styles are applicable to this element type.
        ///     </para>
        ///     <para>
        ///         Multiple styles can be used at once, for example:
        ///         <c>
        ///             <see cref="Style" /> = <see cref="DotStyles.Rounded" /> | <see cref="DotStyles.Bold" />;
        ///         </c>
        ///     </para>
        /// </summary>
        DotStyles? Style { get; set; }

        /// <summary>
        ///     Gets or sets the color used for text (default: <see cref="System.Drawing.Color.Black" />).
        /// </summary>
        Color? FontColor { get; set; }

        /// <summary>
        ///     <para>
        ///         Gets or sets the font used for text (default: "Times-Roman"). This very much depends on the output format and, for
        ///         non-bitmap output such as PostScript or SVG, the availability of the font when the graph is displayed or printed. As
        ///         such, it is best to rely on font faces that are generally available, such as Times-Roman, Helvetica or Courier.
        ///     </para>
        ///     <para>
        ///         How font names are resolved also depends on the underlying library that handles font name resolution. If Graphviz was
        ///         built using the fontconfig library, the latter library will be used to search for the font. See the commands fc-list,
        ///         fc-match and the other fontconfig commands for how names are resolved and which fonts are available. Other systems may
        ///         provide their own font package, such as Quartz for OS X.
        ///     </para>
        ///     <para>
        ///         Note that various font attributes, such as weight and slant, can be built into the font name. Unfortunately, the syntax
        ///         varies depending on which font system is dominant. Thus, using <see cref="FontName" /> = "times bold italic" will produce
        ///         a bold, slanted Times font using Pango, the usual main font library. Alternatively, <see cref="FontName" /> =
        ///         "times:italic" will produce a slanted Times font from fontconfig, while <see cref="FontName" /> = "times-bold" will
        ///         resolve to a bold Times using Quartz. You will need to ascertain which package is used by your Graphviz system and refer
        ///         to the relevant documentation.
        ///     </para>
        ///     <para>
        ///         If Graphviz is not built with a high-level font library, <see cref="FontName" /> will be considered the name of a Type 1
        ///         or True Type font file. If you specify <see cref="FontName" /> = "schlbk", the tool will look for a file named schlbk.ttf
        ///         or schlbk.pfa or schlbk.pfb in one of the directories specified by the <see cref="FontDirectories" /> attribute. The
        ///         lookup does support various aliases for the common fonts.
        ///     </para>
        /// </summary>
        string FontName { get; set; }

        /// <summary>
        ///     Gets or sets the directory list used by libgd to search for bitmap fonts if Graphviz was not built with the fontconfig
        ///     library. If <see cref="FontDirectories" /> is not set, the environment variable DOTFONTPATH is checked. If that is not set,
        ///     GDFONTPATH is checked. If not set, libgd uses its compiled-in font path. The default path is system dependent.
        /// </summary>
        string FontDirectories { get; set; }

        /// <summary>
        ///     Gets or sets the font size used for text (in points; 72 points per inch). Default: 14.0, minimum: 1.0.
        /// </summary>
        double? FontSize { get; set; }

        /// <summary>
        ///     Specifies the character encoding used when interpreting string input as a text label. The default value is "UTF-8". The other
        ///     legal value is "iso-8859-1" or, equivalently, "Latin1". The charset attribute is case-insensitive. Note that if the character
        ///     encoding used in the input does not match the charset value, the resulting output may be very strange.
        /// </summary>
        string Charset { get; set; }

        /// <summary>
        ///     If true, edge concentrators are used (default: false). This merges multiedges into a single edge, and causes partially
        ///     parallel edges to share part of their paths. The latter feature is not yet available outside of dot.
        /// </summary>
        bool? ConcentrateEdges { get; set; }

        /// <summary>
        ///     If true, allows edges between clusters (default: false). Use the <see cref="IDotEdgeAttributes.HeadClusterId" /> or
        ///     <see cref="IDotEdgeAttributes.TailClusterId" /> edge attributes to attach an edge head or tail to a cluster.
        /// </summary>
        bool? EdgesBetweenClusters { get; set; }

        /// <summary>
        ///     Comments are inserted into output. Device-dependent.
        /// </summary>
        string Comment { get; set; }

        /// <summary>
        ///     Hyperlinks incorporated into device-dependent output. At present, used in PS2, CMAP, I*MAP and SVG formats. For all these
        ///     formats, URLs can be attached to nodes, edges and clusters. URL attributes can also be attached to the root graph in PS2,
        ///     CMAP and I*MAP formats. This serves as the base URL for relative URLs in the former, and as the default image map file in the
        ///     latter.
        /// </summary>
        DotEscapeString Url { get; set; }

        /// <summary>
        ///     Synonym for <see cref="Url" />.
        /// </summary>
        DotEscapeString Href { get; set; }

        /// <summary>
        ///     If the object has a <see cref="Url" /> specified, this attribute determines which window of the browser is used for the URL.
        ///     See
        ///     <see href="http://www.w3.org/TR/html401/present/frames.html#adef-target">
        ///         W3C documentation
        ///     </see>
        ///     .
        /// </summary>
        DotEscapeString UrlTarget { get; set; }

        /// <summary>
        ///     <para>
        ///         In dot, this specifies the minimum space between two adjacent nodes in the same rank, in inches (default: 0.25, minimum:
        ///         0.02).
        ///     </para>
        ///     <para>
        ///         For other layouts, this affects the spacing between loops on a single node, or multiedges between a pair of nodes.
        ///     </para>
        /// </summary>
        double? NodeSeparation { get; set; }

        /// <summary>
        ///     <para>
        ///         In dot, this gives the desired rank separation, in inches (<see cref="DotRankSeparation" />; default: 0.5, minimum:
        ///         0.02). This is the minimum vertical distance between the bottom of the nodes in one rank and the tops of nodes in the
        ///         next.
        ///     </para>
        ///     <para>
        ///         In twopi, this attribute specifies the radial separation of concentric circles (default: 1, minimum: 0.02). For twopi,
        ///         this can also be a list of doubles (<see cref="DotRadialRankSeparation" />). The first double specifies the radius of the
        ///         inner circle; the second double specifies the increase in radius from the first circle to the second; etc. If there are
        ///         more circles than numbers, the last number is used as the increment for the remainder.
        ///     </para>
        /// </summary>
        DotRankSeparationDefinition RankSeparation { get; set; }

        /// <summary>
        ///     Mode used for handling clusters (dot only; default: <see cref="DotClusterMode.Bounded" />).
        /// </summary>
        DotClusterMode? ClusterMode { get; set; }

        /// <summary>
        ///     Determines how inedges and outedges, that is, edges with a node as their head or tail node respectively, are ordered (dot
        ///     only). If defined on a graph or subgraph level, the value is applied to all nodes in the graph or subgraph. Note that the
        ///     graph attribute takes precedence over the node attribute.
        /// </summary>
        DotEdgeOrderingMode? EdgeOrderingMode { get; set; }

        /// <summary>
        ///     <para>
        ///         Specifies a list of directories in which to look for image files as specified by the image attribute of nodes (
        ///         <see cref="IDotNodeAttributes.ImagePath" />) or using the IMG element in HTML-like labels. The string should be a list of
        ///         (absolute or relative) pathnames, each separated by a semicolon (for Windows) or a colon (all other OS). The first
        ///         directory in which a file of the given name is found will be used to load the image.
        ///     </para>
        ///     <para>
        ///         If not set, relative pathnames for image files will be interpreted with respect to the current working directory.
        ///     </para>
        /// </summary>
        string ImageDirectories { get; set; }

        /// <summary>
        ///     <para>
        ///         Specifies how much, in inches, to extend the drawing area around the minimal area needed to draw the graph. This area is
        ///         part of the drawing, and will be filled with the background color, if appropriate. Default: 0.0555 (4 points).
        ///     </para>
        ///     <para>
        ///         Normally, a small pad is used for aesthetic reasons, especially when a background color is used, to avoid having nodes
        ///         and edges abutting the boundary of the drawn region.
        ///     </para>
        /// </summary>
        DotPoint Padding { get; set; }

        /// <summary>
        ///     <para>
        ///         Sets x and y margins of canvas, in inches. If the margin is a single double, both margins are set equal to the given
        ///         value.
        ///     </para>
        ///     <para>
        ///         Note that the margin is not part of the drawing but just empty space left around the drawing. It basically corresponds to
        ///         a translation of drawing, as would be necessary to center a drawing on a page. Nothing is actually drawn in the margin.
        ///         To actually extend the background of a drawing, see the <see cref="Padding" /> attribute.
        ///     </para>
        /// </summary>
        DotPoint Margin { get; set; }

        /// <summary>
        ///     <para>
        ///         The maximum width and height of drawing, in inches. If only a single number is given, this is used for both the width and
        ///         the height.
        ///     </para>
        ///     <para>
        ///         If defined and the drawing is larger than the given size, the drawing is uniformly scaled down so that it fits within the
        ///         given size.
        ///     </para>
        ///     <para>
        ///         If <see cref="DotPoint.IsFixed" /> is set, then the size specified is taken to be the desired size. In this case, if both
        ///         dimensions of the drawing are less than size, the drawing is scaled up uniformly until at least one dimension equals its
        ///         dimension in size.
        ///     </para>
        ///     <para>
        ///         Note that there is some interaction between the <see cref="Size" /> and the <see cref="Scaling" /> attributes.
        ///     </para>
        /// </summary>
        DotPoint Size { get; set; }

        /// <summary>
        ///     <para>
        ///         Gets or sets the aspect ratio (drawing height / drawing width) for the drawing. Note that this is adjusted before the
        ///         <see cref="Size" /> attribute constraints are enforced. In addition, the calculations usually ignore the node sizes, so
        ///         the final drawing size may only approximate what is desired.
        ///     </para>
        ///     <para>
        ///         If ratio is numeric, it is taken as the desired aspect ratio. Then, if the actual aspect ratio is less than the desired
        ///         ratio, the drawing height is scaled up to achieve the desired ratio; if the actual ratio is greater than that desired
        ///         ratio, the drawing width is scaled up.
        ///     </para>
        ///     <para>
        ///         See also <see cref="DotGraphScaling" /> for non-numeric options of the ratio.
        ///     </para>
        /// </summary>
        DotGraphScalingDefinition Scaling { get; set; }

        /// <summary>
        ///     <para>
        ///         If enabled (see <see cref="DotPackingToggle" />), each connected component of the graph is laid out separately, and then
        ///         the graphs are packed together.
        ///     </para>
        ///     <para>
        ///         If an integral value is specified (see <see cref="DotPackingMargin" />), this is used as the size, in
        ///         <see href="http://www.graphviz.org/doc/info/attrs.html#points">
        ///             points
        ///         </see>
        ///         , of a margin around each part; otherwise, a default margin of 8 is used.
        ///     </para>
        ///     <para>
        ///         If disabled (see <see cref="DotPackingToggle" />), the entire graph is laid out together. The granularity and method of
        ///         packing is influenced by the <see cref="PackingMode" /> attribute.
        ///     </para>
        ///     <para>
        ///         Default: disabled (see <see cref="DotPackingToggle" />).
        ///     </para>
        /// </summary>
        DotPackingDefinition Packing { get; set; }

        /// <summary>
        ///     Indicates how connected components should be packed (default: <see cref="DotPackingGranularity.Node" />). Note that
        ///     specifying a value for this property will automatically turn on packing as though one had set <see cref="Packing" /> = true.
        /// </summary>
        DotPackingModeDefinition PackingMode { get; set; }

        /// <summary>
        ///     Gets or sets the sorting index of the graph (default: 0). If <see cref="PackingMode" /> indicates an array packing, this
        ///     attribute specifies an insertion order among the components, with smaller values inserted first.
        /// </summary>
        int? SortIndex { get; set; }
    }
}