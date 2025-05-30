﻿using GiGraph.Dot.Entities.Html.Builder;
using GiGraph.Dot.Entities.Html.Font.Styles;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Html;

namespace GiGraph.Dot.Entities.Clusters.Attributes;

public interface IDotClusterAttributes
{
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
    ///     Tooltip annotation attached to the cluster (svg, cmap only). If unset, Graphviz will use the <see cref="Label"/> attribute if
    ///     defined.
    /// </summary>
    DotEscapeString? Tooltip { get; set; }

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
    ///     <para>
    ///         Determines whether the subgraph is a cluster (default false). Subgraph clusters are rendered differently, e.g. dot
    ///         renders a box around subgraph clusters, but doesn't draw a box around non-subgraph clusters.
    ///     </para>
    ///     <para>
    ///         Note: This library treats subgraphs and clusters as conceptually different types, with different intended uses and
    ///         different sets of attributes. So if you're setting <see cref="IsCluster"/> to <see langword="false"/>, it's usually
    ///         better to use a <see cref="DotSubgraph"/> instead of a <see cref="DotCluster"/>.
    ///     </para>
    ///     <para>
    ///         To make sure this attribute is respected by Graphviz as the only cluster discriminator, set the
    ///         <see cref="DotSyntaxOptions.ClusterOptions.Discriminator"/> property of cluster syntax options to
    ///         <see cref="DotClusterDiscriminators.Attribute"/> when generating the DOT output. This setting causes the attribute to be
    ///         automatically included with a value of <see langword="true"/> in the DOT output in all clusters, except those where you
    ///         explicitly set the <see cref="IsCluster"/> property to <see langword="false"/>. Also, such setting will disable using the
    ///         "cluster" prefix in the IDs of clusters so that the attribute is the only way to identify clusters in the DOT output.
    ///     </para>
    /// </summary>
    bool? IsCluster { get; set; }
}