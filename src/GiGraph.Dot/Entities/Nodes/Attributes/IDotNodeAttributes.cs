using GiGraph.Dot.Entities.Graphs.Attributes;
using GiGraph.Dot.Entities.Html.Builder;
using GiGraph.Dot.Entities.Html.Font.Styles;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Html;
using GiGraph.Dot.Types.Nodes;
using GiGraph.Dot.Types.Records;

namespace GiGraph.Dot.Entities.Nodes.Attributes;

public interface IDotNodeAttributes
{
    /// <summary>
    ///     <para>
    ///         Gets or sets the label to display on the node. It may be plain text (<see cref="string"/>), HTML (
    ///         <see cref="DotHtmlString"/>), or a record (<see cref="DotRecord"/>) for a record-shaped node (when <see cref="Shape"/> =
    ///         <see cref="DotNodeShape.Record"/> or <see cref="Shape"/> = <see cref="DotNodeShape.RoundedRecord"/>). When not specified,
    ///         node identifier is used.
    ///     </para>
    ///     <para>
    ///         See also <see cref="DotFormattedTextBuilder"/> for text justification and simple formatting,
    ///         <see cref="DotRecordBuilder"/> for building simple tables with records, and <see cref="DotHtmlBuilder"/> for custom text
    ///         styling and defining tables. The latter one gives the most possibilities (specifying font, size, color, style, images,
    ///         etc.).
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
    ///                     <see cref="Label"/> = new <see cref="DotRecord"/>("My field 1", "My field 2");
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
    ///     External label for the node. The label will be placed outside of the node but near it. This can be useful in DOT to avoid the
    ///     occasional problem when the use of edge labels distorts the layout. For other layouts, this attribute can be viewed as a
    ///     synonym for the <see cref="Label"/> attribute. These labels are added after all nodes and edges have been placed. The labels
    ///     will be placed so that they do not overlap any node or label. This means it may not be possible to place all of them. To
    ///     force placing all of them, use the <see cref="DotGraphLayoutAttributes.ForceExternalLabels"/> attribute of graph
    ///     <see cref="IDotGraphRootAttributes.Layout"/>.
    /// </summary>
    DotLabel? ExternalLabel { get; set; }

    /// <summary>
    ///     Tooltip annotation attached to the node (svg, cmap only). If unset, Graphviz will use the <see cref="Label"/> attribute if
    ///     defined. Note that if the label is a record specification or an HTML-like label, the resulting tooltip may be unhelpful. In
    ///     this case, if tooltips will be generated, the user should set a tooltip attribute explicitly.
    /// </summary>
    DotEscapeString? Tooltip { get; set; }

    /// <summary>
    ///     Gets or sets the shape of the node (default: <see cref="DotNodeShape.Ellipse"/>).
    /// </summary>
    DotNodeShape? Shape { get; set; }

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