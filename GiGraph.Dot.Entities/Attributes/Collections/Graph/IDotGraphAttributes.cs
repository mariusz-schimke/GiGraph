using GiGraph.Dot.Entities.Attributes.Collections.Node;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Identifiers;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Points;
using GiGraph.Dot.Entities.Types.Scaling;
using GiGraph.Dot.Entities.Types.Strings;
using GiGraph.Dot.Entities.Types.Styles;

namespace GiGraph.Dot.Entities.Attributes.Collections.Graph
{
    public interface IDotGraphAttributes
    {
        /// <summary>
        ///     <para>
        ///         Gets or sets the style of the graph (default: unset). See the descriptions of individual <see cref="DotStyles" /> values
        ///         to learn which styles are applicable to this type of element.
        ///     </para>
        ///     <para>
        ///         Multiple styles can be used at once, for example: <see cref="Style" /> = <see cref="DotStyles.Rounded" /> |
        ///         <see cref="DotStyles.Bold" />;
        ///     </para>
        /// </summary>
        DotStyles? Style { get; set; }

        /// <summary>
        ///     Controls how, and if, edges are represented. By default, the attribute is unset. How this is interpreted depends on the
        ///     layout. For dot, the default is to draw edges as splines (<see cref="DotEdgeShape.Spline" />). For all other layouts, the
        ///     default is to draw edges as line segments (<see cref="DotEdgeShape.Line" />). Note that for these latter layouts, if
        ///     <see cref="DotEdgeShape.Spline" /> is used, this requires non-overlapping nodes (cf.
        ///     <see href="http://www.graphviz.org/doc/info/attrs.html#d:overlap">
        ///         overlap
        ///     </see>
        ///     ). If fdp is used for layout and <see cref="DotEdgeShape.Compound" /> is used, then the edges are drawn to avoid clusters as
        ///     well as nodes.
        /// </summary>
        DotEdgeShape? EdgeShape { get; set; }

        /// <summary>
        ///     <para>
        ///         Gets or sets the label to display on the graph. It may be plain text (<see cref="string" />) or HTML (
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
        ///     <para>
        ///         Gets or sets the background color of the graph (default: none). Used as the background for entire canvas.
        ///     </para>
        ///     <para>
        ///         When <see cref="DotGradientColor" /> is used, a gradient fill is generated. By default, this is a linear fill; applying
        ///         the <see cref="DotClusterFillStyle.Radial" /> fill style to the graph will cause a radial fill. If the second color is
        ///         <see cref="System.Drawing.Color.Empty" />, the default color is used for it. See also the <see cref="GradientAngle" />
        ///         attribute for setting a gradient angle.
        ///     </para>
        ///     <para>
        ///         For certain output formats, such as PostScript, no fill is done for the root graph unless background color is explicitly
        ///         set. For bitmap formats, however, the bits need to be initialized to something, so the canvas is filled with white by
        ///         default. This means that if the bitmap output is included in some other document, all of the bits within the bitmap
        ///         bounding box will be set, overwriting whatever color or graphics were already on the page. If this effect is not desired,
        ///         and you only want to set bits explicitly assigned in drawing the graph, set <see cref="BackgroundColor" /> =
        ///         <see cref="System.Drawing.Color.Transparent" />.
        ///     </para>
        /// </summary>
        DotColorDefinition BackgroundColor { get; set; }

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
        ///     Specifies the character encoding used when interpreting string input as a text label. The default value is "UTF-8". The other
        ///     legal value is "iso-8859-1" or, equivalently, "Latin1". The charset attribute is case-insensitive. Note that if the character
        ///     encoding used in the input does not match the charset value, the resulting output may be very strange.
        /// </summary>
        string Charset { get; set; }

        /// <summary>
        ///     Comments are inserted into output. Device-dependent.
        /// </summary>
        string Comment { get; set; }

        /// <summary>
        ///     <para>
        ///         Specifies a list of directories in which to look for image files used by nodes, referenced either by the
        ///         <see cref="DotNodeImageAttributes.Path" /> of their <see cref="DotNodeAttributes.Image" /> attributes, or from the IMG
        ///         element in HTML-like labels. The string should be a list of (absolute or relative) path names, each separated by a
        ///         semicolon (for Windows) or a colon (all other OS). The first directory in which a file of the given name is found will be
        ///         used to load the image.
        ///     </para>
        ///     <para>
        ///         If not set, relative path names for image files will be interpreted with respect to the current working directory.
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
        ///         Sets x and y margins of canvas, in inches (default: device-dependent). If the margin is a single double, both margins are
        ///         set equal to the given value.
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
        ///         If ratio is numeric (<see cref="DotGraphScalingAspectRatio" />), it is taken as the desired aspect ratio. Then, if the
        ///         actual aspect ratio is less than the desired ratio, the drawing height is scaled up to achieve the desired ratio; if the
        ///         actual ratio is greater than that desired ratio, the drawing width is scaled up.
        ///     </para>
        ///     <para>
        ///         See also <see cref="DotGraphScaling" /> for non-numeric options of the ratio.
        ///     </para>
        /// </summary>
        DotGraphScalingDefinition Scaling { get; set; }

        /// <summary>
        ///     Specifies the expected number of pixels per inch on a display device (svg, bitmap output only; default: 96.0, 0.0). For
        ///     bitmap output, this guarantees that text rendering will be done more accurately, both in size and in placement. For SVG
        ///     output, it is used to guarantee that the dimensions in the output correspond to the correct number of points or inches.
        /// </summary>
        double? Dpi { get; set; }

        /// <summary>
        ///     This is a synonym for the <see cref="Dpi" /> attribute (svg, bitmap output only; default: 96.0, 0.0).
        /// </summary>
        double? Resolution { get; set; }

        /// <summary>
        ///     <para>
        ///         The identifier of a node that should be used as the center of the layout and the root of the generated spanning tree
        ///         (circo, twopi only).
        ///     </para>
        ///     <para>
        ///         In twopi, root will actually be the central node. In circo, the block containing the node will be central in the drawing
        ///         of its connected component. If not defined, twopi will pick a most central node, and circo will pick a random node.
        ///     </para>
        ///     <para>
        ///         If the attribute is defined as the empty string, twopi will reset it to name of the node picked as the root node.
        ///     </para>
        ///     <para>
        ///         For twopi, it is possible to have multiple roots, presumably one for each component. If more than one node in a component
        ///         is marked as the root, twopi will pick one (see the <see cref="DotNodeAttributes.IsRoot" /> attribute on a node).
        ///     </para>
        /// </summary>
        DotId RootNodeId { get; set; }

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
        DotEscapeString Id { get; set; }
    }
}