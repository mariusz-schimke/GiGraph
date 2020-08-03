﻿using System.Drawing;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Points;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Entities
{
    public interface IDotClusterAttributes
    {
        /// <summary>
        ///     <para>
        ///         Gets or sets the label to display on the cluster. It can be a string or an HTML (<see cref="DotHtmlLabel" />).
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
        ///     Justification for the label. Note that a subgraph inherits attributes from its parent. Thus, if the root graph sets this
        ///     attribute to <see cref="DotHorizontalAlignment.Left" />, the subgraph inherits this value. Default:
        ///     <see cref="DotHorizontalAlignment.Center" />.
        /// </summary>
        DotHorizontalAlignment? HorizontalLabelAlignment { get; set; }

        /// <summary>
        ///     Vertical placement of the label (default: <see cref="DotVerticalAlignment.Top" />; only
        ///     <see cref="DotVerticalAlignment.Top" /> and <see cref="DotVerticalAlignment.Bottom" /> are allowed). Note that a subgraph
        ///     inherits attributes from its parent. Thus, if the root graph sets this attribute to
        ///     <see cref="DotVerticalAlignment.Bottom" />, the subgraph inherits this value.
        /// </summary>
        DotVerticalAlignment? VerticalLabelAlignment { get; set; }

        /// <summary>
        ///     Tooltip annotation attached to the cluster. If unset, Graphviz will use the <see cref="Label" /> attribute if defined.
        /// </summary>
        DotEscapeString Tooltip { get; set; }

        /// <summary>
        ///     Gets or sets the color of the cluster (default: <see cref="System.Drawing.Color.Black" />). If <see cref="DotMultiColor" />
        ///     is used, with no weighted colors in its color collection (<see cref="DotColor" /> items only), and the <see cref="Style" />
        ///     is <see cref="DotStyle.Filled" />, a linear gradient fill is done using the first two colors. If weighted colors are present
        ///     (see <see cref="DotWeightedColor" />), a degenerate linear gradient fill is done. This essentially does a fill using two
        ///     colors, with the <see cref="DotWeightedColor.Weight" /> specifying how much of region is filled with each color. If the
        ///     <see cref="Style" /> attribute contains the value <see cref="DotStyle.Radial" />, then a radial gradient fill is done. These
        ///     fills work with any shape. For certain shapes, the <see cref="Style" /> attribute can be set to do fills using more than 2
        ///     colors (see <see cref="DotStyle.Striped" />).
        /// </summary>
        DotColorDefinition Color { get; set; }

        /// <summary>
        ///     <para>
        ///         Gets or sets the background color of the cluster (default: none). Used as the initial background for the cluster. If the
        ///         <see cref="Style" /> attribute of the cluster contains the <see cref="DotStyle.Filled" /> style, the cluster's
        ///         <see cref="FillColor" /> will overlay the background color.
        ///     </para>
        ///     <para>
        ///         When <see cref="DotMultiColor" /> is used, a gradient fill is generated. By default, this is a linear fill; setting
        ///         <see cref="Style" /> to <see cref="DotStyle.Radial" /> will cause a radial fill. At present, only two colors are used. If
        ///         the second color is <see cref="System.Drawing.Color.Empty" />, the default color is used for it. See also the
        ///         <see cref="GradientAngle" /> attribute for setting the gradient angle.
        ///     </para>
        /// </summary>
        DotColorDefinition BackgroundColor { get; set; }

        /// <summary>
        ///     <para>
        ///         Gets or sets the color used to fill the background of the cluster, assuming that <see cref="Style" /> is
        ///         <see cref="DotStyle.Filled" />. If <see cref="FillColor" /> is not defined, <see cref="Color" /> is used. If
        ///         <see cref="Color" /> is not defined, <see cref="BackgroundColor" /> is used. If it is not defined too, the default is
        ///         used, except when the output format is MIF, which use black by default.
        ///     </para>
        ///     <para>
        ///         When <see cref="DotMultiColor" /> is used, a gradient fill is generated. By default, this is a linear fill; setting
        ///         <see cref="Style" /> to <see cref="DotStyle.Radial" /> will cause a radial fill. At present, only two colors are used. If
        ///         the second color is missing, the default color is used for it. See also the <see cref="GradientAngle" /> attribute for
        ///         setting the gradient angle. Note that a cluster inherits the root graph's attributes if defined. Thus, if the root graph
        ///         has defined a fill color (<see cref="IDotGraphAttributes.FillColor" />), this will override a <see cref="Color" /> or
        ///         <see cref="BackgroundColor" /> attribute set for the cluster.
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
        ///     Specifies the width of the pen, in points, used to draw lines and curves, including the boundaries of edges and clusters. The
        ///     value is inherited by subclusters. It has no effect on text. Default: 1.0, minimum: 0.0.
        /// </summary>
        double? PenWidth { get; set; }

        /// <summary>
        ///     Color used to draw the bounding box around the cluster (default: <see cref="System.Drawing.Color.Black" />). If
        ///     <see cref="PenColor" /> is not defined, <see cref="Color" /> is used. If this is not defined, the default is used. Note that
        ///     a cluster inherits the root graph's attributes if defined. Thus, if the root graph has defined a pen color (
        ///     <see cref="IDotGraphAttributes.PenColor" />), this will override a <see cref="Color" /> or <see cref="BackgroundColor" />
        ///     attribute set for the cluster.
        /// </summary>
        Color? PenColor { get; set; }

        /// <summary>
        ///     <para>
        ///         Sets the style of the cluster (default: null). See the descriptions of individual <see cref="DotStyle" /> values to learn
        ///         which styles are applicable to this element type.
        ///     </para>
        ///     <para>
        ///         Multiple styles can be used at once, for example:
        ///         <c>
        ///             <see cref="Style" /> = <see cref="DotStyle.Rounded" /> | <see cref="DotStyle.Bold" />;
        ///         </c>
        ///     </para>
        /// </summary>
        DotStyle? Style { get; set; }

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
        ///     Sets the number of peripheries used in cluster boundaries (default: 1, minimum: 0, maximum: 1). Setting peripheries to 0 will
        ///     remove the boundaries.
        /// </summary>
        int? Peripheries { get; set; }

        /// <summary>
        ///     <para>
        ///         Hyperlinks incorporated into device-dependent output. At present, used in PS2, CMAP, I*MAP and SVG formats. For all these
        ///         formats, URLs can be attached to nodes, edges and clusters. URL attributes can also be attached to the root graph in PS2,
        ///         CMAP and I*MAP formats. This serves as the base URL for relative URLs in the former, and as the default image map file in
        ///         the latter.
        ///     </para>
        ///     <para>
        ///         The active area for a cluster is its bounding box.
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
        ///     Specifies the space between the nodes in the cluster and the cluster bounding box. By default, this is 8 points.
        /// </summary>
        DotPoint Margin { get; set; }
    }
}