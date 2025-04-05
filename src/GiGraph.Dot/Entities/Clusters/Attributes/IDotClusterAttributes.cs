﻿using GiGraph.Dot.Entities.Graphs.Attributes;
using GiGraph.Dot.Entities.Html.Builder;
using GiGraph.Dot.Entities.Html.Font.Styles;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Geometry;
using GiGraph.Dot.Types.Html;
using GiGraph.Dot.Types.Ranks;
using GiGraph.Dot.Types.Styling;

namespace GiGraph.Dot.Entities.Clusters.Attributes;

public interface IDotClusterAttributes
{
    /// <summary>
    ///     <para>
    ///         Gets or sets the style of the cluster (default: unset). See the descriptions of individual <see cref="DotStyles"/> values
    ///         to learn which styles are applicable to this type of element.
    ///     </para>
    ///     <para>
    ///         Multiple styles can be used at once, for example: <see cref="Style"/> = <see cref="DotStyles.Rounded"/> |
    ///         <see cref="DotStyles.Bold"/>;
    ///     </para>
    /// </summary>
    DotStyles? Style { get; set; }

    /// <summary>
    ///     <para>
    ///         Gets or sets the label to display on the cluster. It may be plain text (<see cref="string"/>) or HTML (
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
    ///     Tooltip annotation attached to the cluster (svg, cmap only). If unset, Graphviz will use the <see cref="Label"/> attribute if
    ///     defined.
    /// </summary>
    DotEscapeString? Tooltip { get; set; }

    /// <summary>
    ///     Sets the number of peripheries used in cluster boundaries (default: 1, minimum: 0, maximum: 1). Setting peripheries to 0 will
    ///     remove the boundaries.
    /// </summary>
    int? Peripheries { get; set; }

    /// <summary>
    ///     Specifies the space between the nodes in the cluster and bounding box of the cluster. By default, this is 8 points.
    /// </summary>
    DotPoint? Padding { get; set; }

    /// <summary>
    ///     Gets or sets the sorting index of the cluster (default: 0). If <see cref="DotGraphLayoutAttributes.PackingMode"/> indicates
    ///     an array packing, this attribute specifies an insertion order among the components, with smaller values inserted first.
    /// </summary>
    int? SortIndex { get; set; }

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

    /// <summary>
    ///     Gets or sets the rank constraints on the nodes in the cluster (dot only).
    /// </summary>
    DotRankAlignment? NodeRankAlignment { get; set; }

    /// <summary>
    ///     <para>
    ///         Determines whether the subgraph is a cluster (default false). Subgraph clusters are rendered differently, e.g. dot
    ///         renders a box around subgraph clusters, but doesn't draw a box around non-subgraph clusters.
    ///     </para>
    ///     <para>
    ///         For this attribute to be respected, set the <see cref="DotSyntaxOptions.ClusterOptions.PreferClusterAttribute"/> syntax
    ///         option to <see langword="true"/> when generating the output script. In such case, the attribute will be included
    ///         automatically on output script generation with the value of <see langword="true"/> (unless set otherwise explicitly).
    ///         Note, however, that this library makes a strong distinction between subgraphs and clusters (in terms of what purpose they
    ///         are used for and what attributes are settable on each of them). Therefore, you should consider using a
    ///         <see cref="DotSubgraph"/> rather than a <see cref="DotCluster"/> when your intention is to set the
    ///         <see cref="IsCluster"/> attribute here to <see langword="false"/>.
    ///     </para>
    /// </summary>
    bool? IsCluster { get; set; }
}