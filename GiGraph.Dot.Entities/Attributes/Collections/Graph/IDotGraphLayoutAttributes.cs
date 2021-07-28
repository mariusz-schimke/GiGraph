using GiGraph.Dot.Entities.Attributes.Collections.Edge;
using GiGraph.Dot.Entities.Attributes.Collections.Node;
using GiGraph.Dot.Entities.Attributes.Collections.Subgraph;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.Layout;
using GiGraph.Dot.Types.Packing;
using GiGraph.Dot.Types.Ranks;

namespace GiGraph.Dot.Entities.Attributes.Collections.Graph
{
    public interface IDotGraphLayoutAttributes
    {
        /// <summary>
        ///     <para>
        ///         Specifies the name of the layout algorithm to use, such as dot or neato (see <see cref="DotLayoutEngines" /> for a list
        ///         of available layout engines).
        ///     </para>
        ///     <para>
        ///         Normally, graphs should be kept independent of a type of layout. In some cases, however, it can be convenient to embed
        ///         the type of layout desired within the graph. For example, a graph containing position information from a layout might
        ///         want to record what the associated layout algorithm was. This attribute takes precedence over the -K flag or the actual
        ///         command name used.
        ///     </para>
        /// </summary>
        string Engine { get; set; }

        /// <summary>
        ///     Gets or sets the direction of graph layout (dot only, default: <see cref="DotLayoutDirection.TopToBottom" />).
        /// </summary>
        DotLayoutDirection? Direction { get; set; }

        /// <summary>
        ///     Determines how inedges and outedges, that is, edges with a node as their head or tail node respectively, are ordered (dot
        ///     only). If defined on a graph or subgraph, the value is applied to all nodes in the graph or subgraph. Note that the graph
        ///     attribute takes precedence over a corresponding attribute on nodes.
        /// </summary>
        DotEdgeOrderingMode? EdgeOrderingMode { get; set; }

        /// <summary>
        ///     If true, all node <see cref="DotNodeAttributes.ExternalLabel" /> and edge <see cref="DotEdgeAttributes.ExternalLabel" />
        ///     attributes are placed, even if there is some overlap with nodes or other labels (default: true).
        /// </summary>
        bool? ForceExternalLabels { get; set; }

        /// <summary>
        ///     Rotates the final layout counter-clockwise by the specified number of degrees (sfdp only; default: 0).
        /// </summary>
        double? Rotation { get; set; }

        /// <summary>
        ///     If true, edge concentrators are used (default: false). This merges multiedges into a single edge, and causes partially
        ///     parallel edges to share part of their paths. The latter feature is not yet available outside of dot.
        /// </summary>
        bool? ConcentrateEdges { get; set; }

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
        ///     Gets or sets the rank constraints on the nodes in the graph (dot only). See also <see cref="UseGlobalRanking" />.
        /// </summary>
        DotRank? NodeRank { get; set; }

        /// <summary>
        ///     <para>
        ///         In dot, this gives the desired rank separation, in inches (<see cref="DotRankSeparation" />; default: 0.5, minimum: 0.02.
        ///         This is the minimum vertical distance between the bottom of the nodes in one rank and the tops of nodes in the next.
        ///     </para>
        ///     <para>
        ///         In twopi, this attribute specifies the radial separation of concentric circles (default: 1, minimum: 0.02). For twopi,
        ///         this can also be a list of doubles (<see cref="DotRadialRankSeparation" />). The first double specifies the radius of the
        ///         inner circle; the second double specifies the increase in radius from the first circle to the second; etc. If there are
        ///         more circles than numbers, the last number is used as the increment for the remainder.
        ///     </para>
        ///     <para>
        ///         Twopi, dot only.
        ///     </para>
        /// </summary>
        DotRankSeparationDefinition RankSeparation { get; set; }

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
        ///     If true and there are multiple clusters, runs crossing minimization a second time (dot only, default: true).
        /// </summary>
        bool? RepeatCrossingMinimization { get; set; }

        /// <summary>
        ///     <para>
        ///         Determines whether to use a single global ranking, ignoring clusters (dot only, default: false).
        ///     </para>
        ///     <para>
        ///         The original ranking algorithm in dot is recursive on clusters. This can produce fewer ranks and a more compact layout,
        ///         but sometimes at the cost of a head node being placed on a higher rank than the tail node. It also assumes that a node is
        ///         not constrained in separate, incompatible subgraphs. For example, a node cannot be in a cluster and also be constrained
        ///         by a rank of <see cref="DotRank.Same" /> with a node not in the cluster (see
        ///         <see cref="DotSubgraphAttributes.NodeRank" /> on subgraph attributes).
        ///     </para>
        ///     <para>
        ///         This allows nodes to be subject to multiple constraints. Rank constraints will usually take precedence over edge
        ///         constraints. See also <see cref="NodeRank" />.
        ///     </para>
        /// </summary>
        bool? UseGlobalRanking { get; set; }

        /// <summary>
        ///     Gets or sets the sorting index of the graph (default: 0). If <see cref="PackingMode" /> indicates an array packing, this
        ///     attribute specifies an insertion order among the components, with smaller values inserted first.
        /// </summary>
        int? SortIndex { get; set; }
    }
}