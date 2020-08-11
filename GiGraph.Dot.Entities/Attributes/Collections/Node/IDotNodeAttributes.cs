using System.Drawing;
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
        ///         Gets or sets the label to display on the node. It can be a string, an HTML (<see cref="DotHtmlLabel" />), or a record (
        ///         <see cref="DotRecordLabel" />) for a record-based node (<see cref="Shape" /> = <see cref="DotNodeShape.Record" /> or
        ///         <see cref="Shape" /> = <see cref="DotNodeShape.RoundedRecord" />).
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
        ///             <item>
        ///                 <see cref="Label" /> = new <see cref="DotRecord" />("My field 1", "My field 2");
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
        ///     force placing all of them, use the <see cref="IDotGraphAttributes.ForceExternalLabels" /> attribute on the graph.
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
        ///     Gets or sets the color of the node (default: <see cref="System.Drawing.Color.Black" />). If <see cref="DotMultiColor" /> is
        ///     used, with no weighted colors in its color collection (<see cref="DotColor" /> items only), and the <see cref="Style" /> is
        ///     <see cref="DotStyle.Filled" />, a linear gradient fill is done using the first two colors. If weighted colors are present
        ///     (see <see cref="DotWeightedColor" />), a degenerate linear gradient fill is done. This essentially does a fill using two
        ///     colors, with the <see cref="DotWeightedColor.Weight" /> specifying how much of region is filled with each color. If the
        ///     <see cref="Style" /> attribute contains the value <see cref="DotStyle.Radial" />, then a radial gradient fill is done. These
        ///     fills work with any shape. For certain shapes, the <see cref="Style" /> attribute can be set to do fills using more than 2
        ///     colors (see <see cref="DotStyle.Striped" /> and <see cref="DotStyle.Wedged" />).
        /// </summary>
        DotColorDefinition Color { get; set; }

        /// <summary>
        ///     <para>
        ///         Gets or sets the color used to fill the background of the node, assuming that <see cref="Style" /> is
        ///         <see cref="DotStyle.Filled" />. If <see cref="FillColor" /> is not defined, <see cref="Color" /> is used. If it is not
        ///         defined too, the default is used, except for <see cref="Shape" /> of <see cref="DotNodeShape.Point" />, or when the
        ///         output format is MIF, which use black by default.
        ///     </para>
        ///     <para>
        ///         If <see cref="DotMultiColor" /> is used, a gradient fill is generated. By default, this is a linear fill; setting
        ///         <see cref="Style" /> to <see cref="DotStyle.Radial" /> will cause a radial fill. At present, only two colors are used. If
        ///         the second color is missing, the default color is used for it. See also the <see cref="GradientAngle" /> attribute for
        ///         setting the gradient angle.
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
        ///     <para>
        ///         Gives the name of a file containing an image to be displayed inside the node. The image file must be in one of the
        ///         <see href="http://www.graphviz.org/doc/info/output.html#d:image_fmts">
        ///             recognized formats
        ///         </see>
        ///         , typically JPEG, PNG, GIF, BMP, SVG or Postscript, and be able to be converted into the desired output format.
        ///     </para>
        ///     <para>
        ///         The file must contain the image size information. This is usually trivially true for the bitmap formats. For PostScript,
        ///         the file must contain a line starting with %%BoundingBox: followed by four integers specifying the lower left x and y
        ///         coordinates and the upper right x and y coordinates of the bounding box for the image, the coordinates being in points.
        ///         An SVG image file must contain width and height attributes, typically as part of the svg element. The values for these
        ///         should have the form of a floating point number, followed by optional units, e.g., width="76pt". Recognized units are in,
        ///         px, pc, pt, cm and mm for inches, pixels, picas, points, centimeters and millimeters, respectively. The default unit is
        ///         points.
        ///     </para>
        ///     <para>
        ///         Unlike with the shapefile attribute, the image is treated as node content rather than the entire node. In particular, an
        ///         image can be contained in a node of any shape, not just a rectangle.
        ///     </para>
        /// </summary>
        string ImagePath { get; set; }

        /// <summary>
        ///     Controls how an image is positioned within its containing node. This only has an effect when the image is smaller than the
        ///     containing node. The default is to be centered both horizontally and vertically (<see cref="DotAlignment.MiddleCenter" />).
        /// </summary>
        DotAlignment? ImageAlignment { get; set; }

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
        double? PenWidth { get; set; }

        /// <summary>
        ///     Gets or sets the shape of the node (default: <see cref="DotNodeShape.Ellipse" />).
        /// </summary>
        DotNodeShape? Shape { get; set; }

        /// <summary>
        ///     <para>
        ///         Sets the style of the node (default: null). See the descriptions of individual <see cref="DotStyle" /> values to learn
        ///         which styles are applicable to this element type.
        ///     </para>
        ///     <para>
        ///         Multiple styles can be used at once, for example:
        ///         <c>
        ///             <see cref="Style" /> = <see cref="DotStyle.Solid" /> | <see cref="DotStyle.Bold" />;
        ///         </c>
        ///     </para>
        /// </summary>
        DotStyle? Style { get; set; }

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
        ///         or schlbk.pfa or schlbk.pfb in one of the directories specified by the <see cref="IDotGraphAttributes.FontDirectories" />
        ///         attribute. The lookup does support various aliases for the common fonts.
        ///     </para>
        /// </summary>
        string FontName { get; set; }

        /// <summary>
        ///     Gets or sets the font size used for text (in points; 72 points per inch). Default: 14.0, minimum: 1.0.
        /// </summary>
        double? FontSize { get; set; }

        /// <summary>
        ///     Comments are inserted into output. Device-dependent.
        /// </summary>
        string Comment { get; set; }

        /// <summary>
        ///     If true, forces polygon to be regular, i.e., the vertices of the polygon will lie on a circle whose center is the center of
        ///     the node (default: false).
        /// </summary>
        bool? Regular { get; set; }

        /// <summary>
        ///     Sets the number of peripheries used in polygonal shapes (<see cref="Shape" />). The default value is shape dependent, the
        ///     minimum value is 0. Note that user-defined shapes (see
        ///     <see href="http://www.graphviz.org/doc/info/shapes.html#epsf">
        ///         documentation
        ///     </see>
        ///     ) are treated as a form of box shape, so the default peripheries value is 1, and the user-defined shape will be drawn in a
        ///     bounding rectangle. Setting peripheries to 0 will turn this off.
        /// </summary>
        int? Peripheries { get; set; }

        /// <summary>
        ///     Number of sides if <see cref="Shape" /> is set to <see cref="DotNodeShape.Polygon" /> (default: 4, minimum: 0).
        /// </summary>
        int? Sides { get; set; }

        /// <summary>
        ///     Skew factor for <see cref="Shape" /> set to <see cref="DotNodeShape.Polygon" /> (default: 0, minimum: -100). Positive values
        ///     skew top of polygon to right; negative to left.
        /// </summary>
        double? Skew { get; set; }

        /// <summary>
        ///     Distortion factor for <see cref="Shape" /> set to <see cref="DotNodeShape.Polygon" /> (default: 0, minimum: -100). Positive
        ///     values cause top part to be larger than bottom; negative values do the opposite.
        /// </summary>
        double? Distortion { get; set; }

        /// <summary>
        ///     Angle, in degrees, used to rotate polygon node shapes (<see cref="Shape" /> = <see cref="DotNodeShape.Polygon" />). For any
        ///     number of polygon sides, 0 degrees rotation results in a flat base. Default: 0, maximum: 360.
        /// </summary>
        double? Orientation { get; set; }

        /// <summary>
        ///     <para>
        ///         Hyperlinks incorporated into device-dependent output. At present, used in PS2, CMAP, I*MAP and SVG formats. For all these
        ///         formats, URLs can be attached to nodes, edges and clusters. URL attributes can also be attached to the root graph in PS2,
        ///         CMAP and I*MAP formats. This serves as the base URL for relative URLs in the former, and as the default image map file in
        ///         the latter.
        ///     </para>
        ///     <para>
        ///         For SVG, CMAPX and IMAP output, the active area for a node is its visible image. For example, an unfilled node with no
        ///         drawn boundary will only be active on its label. For other output, the active area is its bounding box.
        ///     </para>
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
        ///     Determines how inedges and outedges, that is, edges with the node as their head or tail node respectively, are ordered (dot
        ///     only; default: <see cref="DotEdgeOrderingMode.None" />). If defined on a graph or subgraph level, the value is applied to all
        ///     nodes in the graph or subgraph. Note that the graph attribute takes precedence over the node attribute.
        /// </summary>
        DotEdgeOrderingMode? EdgeOrderingMode { get; set; }

        /// <summary>
        ///     The name of the group the node belongs to. If the endpoints of an edge belong to the same group (have the same group name
        ///     assigned), parameters are set to avoid crossings and keep the edges straight (dot only).
        /// </summary>
        string GroupName { get; set; }

        /// <summary>
        ///     Gets or sets the sorting index of the element (default: 0). If <see cref="IDotGraphAttributes.PackingMode" /> indicates an
        ///     array packing, this attribute specifies an insertion order among the components, with smaller values inserted first.
        /// </summary>
        int? SortIndex { get; set; }
    }
}