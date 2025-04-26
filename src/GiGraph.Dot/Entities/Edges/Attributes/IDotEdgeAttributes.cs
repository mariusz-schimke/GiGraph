using GiGraph.Dot.Entities.Edges.Endpoints.Attributes;
using GiGraph.Dot.Entities.Graphs.Attributes;
using GiGraph.Dot.Entities.Html.Builder;
using GiGraph.Dot.Entities.Html.Font.Styles;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Html;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Edges.Attributes;

public interface IDotEdgeAttributes
{
    /// <summary>
    ///     <para>
    ///         Gets or sets the style of the edge (default: unset). See the descriptions of individual <see cref="DotStyles"/> values to
    ///         learn which styles are applicable to this type of element.
    ///     </para>
    ///     <para>
    ///         Multiple styles can be used at once, for example: <see cref="Style"/> = <see cref="DotStyles.Rounded"/> |
    ///         <see cref="DotStyles.Bold"/>;
    ///     </para>
    /// </summary>
    DotStyles? Style { get; set; }

    /// <summary>
    ///     <para>
    ///         Gets or sets the label to display next to the edge. It may be plain text (<see cref="string"/>) or HTML (
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
    ///         External label for the edge. The label will be placed near the center of the edge. This can be useful in dot to avoid the
    ///         occasional problem when the use of edge labels distorts the layout. For other layouts, this attribute can be viewed as a
    ///         synonym for the <see cref="Label"/> attribute.
    ///     </para>
    ///     <para>
    ///         These labels are added after all nodes and edges have been placed. The labels will be placed so that they do not overlap
    ///         any node or label. This means it may not be possible to place all of them. To force placing all of them, use the
    ///         <see cref="DotGraphLayoutAttributes.ForceExternalLabels"/> attribute on the graph.
    ///     </para>
    /// </summary>
    DotLabel? ExternalLabel { get; set; }

    /// <summary>
    ///     Tooltip annotation attached to the edge (svg, cmap only). If unset, Graphviz will use the <see cref="Label"/> attribute if
    ///     defined.
    /// </summary>
    DotEscapeString? Tooltip { get; set; }

    /// <summary>
    ///     <para>
    ///         Gets or sets edge type for drawing arrowheads. Default: <see cref="DotEdgeDirections.Forward"/> (for directed graphs),
    ///         <see cref="DotEdgeDirections.None"/> (for undirected graphs).
    ///     </para>
    ///     <para>
    ///         Indicates which ends of the edge should be decorated with an arrowhead. The actual style of the arrowhead may be
    ///         specified using the <see cref="IDotEdgeEndpointAttributes.Arrowhead"/> attribute on the head or tail of the edge.
    ///     </para>
    ///     <para>
    ///         A glyph is drawn at the head end of the edge if and only if the direction is <see cref="DotEdgeDirections.Forward"/> or
    ///         <see cref="DotEdgeDirections.Both"/>.
    ///     </para>
    ///     <para>
    ///         A glyph is drawn at the tail end of the edge if and only if the direction is <see cref="DotEdgeDirections.Backward"/> or
    ///         <see cref="DotEdgeDirections.Both"/>.
    ///     </para>
    ///     <para>
    ///         For undirected edges T -- H, one of the nodes, usually the right hand one, is treated as the head for the purpose of
    ///         interpreting <see cref="DotEdgeDirections.Forward"/> and <see cref="DotEdgeDirections.Backward"/>.
    ///     </para>
    /// </summary>
    DotEdgeDirections? Directions { get; set; }

    /// <summary>
    ///     Comments are inserted into output. Device-dependent.
    /// </summary>
    string? Comment { get; set; }

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