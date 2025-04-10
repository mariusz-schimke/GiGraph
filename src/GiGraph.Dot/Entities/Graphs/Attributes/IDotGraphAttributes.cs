﻿using GiGraph.Dot.Entities.Html.Builder;
using GiGraph.Dot.Entities.Html.Font.Styles;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Entities.Nodes.Attributes;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Html;
using GiGraph.Dot.Types.Identifiers;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Graphs.Attributes;

public interface IDotGraphAttributes
{
    /// <summary>
    ///     <para>
    ///         Gets or sets the style of the graph (default: unset). See the descriptions of individual <see cref="DotStyles"/> values
    ///         to learn which styles are applicable to this type of element.
    ///     </para>
    ///     <para>
    ///         Multiple styles can be used at once, for example: <see cref="Style"/> = <see cref="DotStyles.Rounded"/> |
    ///         <see cref="DotStyles.Bold"/>;
    ///     </para>
    /// </summary>
    DotStyles? Style { get; set; }

    /// <summary>
    ///     Controls how, and if, edges are represented. By default, the attribute is unset. How this is interpreted depends on the
    ///     layout. For dot, the default is to draw edges as splines (<see cref="DotEdgeShape.Spline"/>). For all other layouts, the
    ///     default is to draw edges as line segments (<see cref="DotEdgeShape.Line"/>). Note that for these latter layouts, if
    ///     <see cref="DotEdgeShape.Spline"/> is used, this requires non-overlapping nodes (cf.
    ///     <see href="https://www.graphviz.org/docs/attrs/overlap">
    ///         overlap
    ///     </see>
    ///     ). If fdp is used for layout and <see cref="DotEdgeShape.Compound"/> is used, then the edges are drawn to avoid clusters as
    ///     well as nodes.
    /// </summary>
    DotEdgeShape? EdgeShape { get; set; }

    /// <summary>
    ///     <para>
    ///         Gets or sets the label to display on the graph. It may be plain text (<see cref="string"/>) or HTML (
    ///         <see cref="DotHtmlString"/>). See also <see cref="DotFormattedTextBuilder"/> for text justification and simple formatting
    ///         and <see cref="DotHtmlBuilder"/> for custom text styling and defining tables. The latter one gives the most possibilities
    ///         (specifying font, size, color, style, images, etc.).
    ///     </para>
    ///     <para>
    ///         Examples:
    ///         <list type="bullet">
    ///             <item>
    ///                 <description>
    ///                     <see cref="Label"/> = "My label";
    ///                 </description>
    ///             </item>
    ///             <item>
    ///                 <description>
    ///                     <see cref="Label"/> = new <see cref="DotHtmlBold"/>("My label");
    ///                 </description>
    ///             </item>
    ///             <item>
    ///                 <description>
    ///                     <see cref="Label"/> = (<see cref="DotHtmlString"/>) "&lt;b&gt;My label&lt;/b&gt;";
    ///                 </description>
    ///             </item>
    ///         </list>
    ///     </para>
    /// </summary>
    DotLabel? Label { get; set; }

    /// <summary>
    ///     <para>
    ///         Determines whether to justify multiline text vs the previous text line rather than the side of the container (default:
    ///         false).
    ///     </para>
    ///     <para>
    ///         By default, the justification of multi-line labels is done within the largest context that makes sense. Thus, in the
    ///         label of a polygonal node, a left-justified line will align with the left side of the node (shifted by the prescribed
    ///         margin). In record nodes, left-justified line will line up with the left side of the enclosing column of fields. If
    ///         <see cref="DisableLabelJustification"/> is true, multi-line labels will be justified in the context of itself. For
    ///         example, if <see cref="DisableLabelJustification"/> is set, the first label line is long, and the second is shorter and
    ///         left-justified, the second will align with the left-most character in the first line, regardless of how large the node
    ///         might be.
    ///     </para>
    /// </summary>
    bool? DisableLabelJustification { get; set; }

    /// <summary>
    ///     Specifies a color scheme namespace to use. If defined, specifies the context for interpreting color names. If no color scheme
    ///     is set, the standard <see cref="DotColorSchemes.X11"/> naming is used. For example, if
    ///     <see cref="DotColorSchemes.DotBrewerColorSchemes.BuGn9"/> Brewer color scheme is used, then a color named "7", e.g.
    ///     Color.FromName("7"), will be evaluated in the context of that specific color scheme. See <see cref="DotColorSchemes"/> for
    ///     supported scheme names.
    /// </summary>
    string? ColorScheme { get; set; }

    /// <summary>
    ///     Specifies the character encoding used when interpreting string input as a text label. The default value is "UTF-8". The other
    ///     legal value is "iso-8859-1" or, equivalently, "Latin1". The charset attribute is case-insensitive. Note that if the character
    ///     encoding used in the input does not match the charset value, the resulting output may be very strange.
    /// </summary>
    string? Charset { get; set; }

    /// <summary>
    ///     Comments are inserted into output. Device-dependent.
    /// </summary>
    string? Comment { get; set; }

    /// <summary>
    ///     Tooltip annotation attached to the graph (svg, cmap only). If unset, Graphviz will use the <see cref="Label"/> attribute if
    ///     defined.
    /// </summary>
    DotEscapeString? Tooltip { get; set; }

    /// <summary>
    ///     <para>
    ///         Specifies a list of directories in which to look for image files used by nodes, referenced either by the
    ///         <see cref="DotNodeImageAttributes.Path"/> of their <see cref="IDotNodeRootAttributes.Image"/> attributes, or from the IMG
    ///         element in HTML-like labels. The string should be a list of (absolute or relative) path names, each separated by a
    ///         semicolon (for Windows) or a colon (all other OS). The first directory in which a file of the given name is found will be
    ///         used to load the image.
    ///     </para>
    ///     <para>
    ///         If not set, relative path names for image files will be interpreted with respect to the current working directory.
    ///     </para>
    /// </summary>
    string? ImageDirectories { get; set; }

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
    ///         is marked as the root, twopi will pick one (see the <see cref="IDotNodeAttributes.IsRoot"/> attribute on a node).
    ///     </para>
    /// </summary>
    DotId? RootNodeId { get; set; }

    /// <summary>
    ///     <para>
    ///         Allows the graph author to provide an identifier for graph objects which is to be included in the output (svg,
    ///         postscript, map only).
    ///     </para>
    ///     <para>
    ///         Normal <see cref="DotEscapeString.NodeIdPlaceholder"/>, <see cref="DotEscapeString.EdgeDefinitionPlaceholder"/>,
    ///         <see cref="DotEscapeString.GraphIdPlaceholder"/> substitutions can be applied (see <see cref="DotFormattedTextBuilder"/>
    ///         ). Note, however, that <see cref="DotEscapeString.EdgeDefinitionPlaceholder"/> does not provide a unique ID for
    ///         multi-edges.
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
    DotEscapeString? ObjectId { get; set; }
}