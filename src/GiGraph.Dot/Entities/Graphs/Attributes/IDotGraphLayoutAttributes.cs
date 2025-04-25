using GiGraph.Dot.Entities.Edges.Attributes;
using GiGraph.Dot.Entities.Nodes.Attributes;
using GiGraph.Dot.Entities.Subgraphs.Attributes;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.Graphs.Layout;
using GiGraph.Dot.Types.Graphs.Layout.Packing;
using GiGraph.Dot.Types.Graphs.Layout.Spacing;
using GiGraph.Dot.Types.Identifiers;

namespace GiGraph.Dot.Entities.Graphs.Attributes;

public interface IDotGraphLayoutAttributes
{
    /// <summary>
    ///     <para>
    ///         Specifies the name of the layout algorithm to use, such as dot or neato (see <see cref="DotLayoutEngines"/> for a list of
    ///         available layout engines).
    ///     </para>
    ///     <para>
    ///         Normally, graphs should be kept independent of a type of layout. In some cases, however, it can be convenient to embed
    ///         the type of layout desired within the graph. For example, a graph containing position information from a layout might
    ///         want to record what the associated layout algorithm was. This attribute takes precedence over the -K flag or the actual
    ///         command name used.
    ///     </para>
    /// </summary>
    string? Engine { get; set; }

    /// <summary>
    ///     Gets or sets the direction of graph layout (dot only, default: <see cref="DotLayoutDirection.TopToBottom"/>).
    /// </summary>
    DotLayoutDirection? Direction { get; set; }

    /// <summary>
    ///     Determines how inedges and outedges, that is, edges with a node as their head or tail node respectively, are ordered (dot
    ///     only). If defined on a graph or subgraph, the value is applied to all nodes in the graph or subgraph. Note that the graph
    ///     attribute takes precedence over a corresponding attribute on nodes.
    /// </summary>
    DotEdgeOrderingMode? EdgeOrderingMode { get; set; }

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
    ///     If true, all node <see cref="IDotNodeAttributes.ExternalLabel"/> and edge <see cref="IDotEdgeAttributes.ExternalLabel"/>
    ///     attributes are placed, even if there is some overlap with nodes or other labels (default: true).
    /// </summary>
    bool? ForceExternalLabels { get; set; }

    /// <summary>
    ///     Determines whether to draw circo graphs around one circle (circo only; default: false).
    /// </summary>
    bool? UseCircularLayout { get; set; }

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
    ///         is marked as the root, twopi will pick one (see the <see cref="IDotNodeLayoutAttributes.IsLayoutRoot"/> node layout
    ///         attribute).
    ///     </para>
    /// </summary>
    DotId? RootNodeId { get; set; }

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
    ///     Gets or sets the rank constraints on the nodes in the graph (dot only). See also <see cref="EnableGlobalRanking"/>.
    /// </summary>
    DotRank? NodeRank { get; set; }

    /// <summary>
    ///     Determines which rank to move floating (loose) nodes to. The valid options are <see cref="DotRank.Min"/> or
    ///     <see cref="DotRank.Max"/>. Otherwise, floating nodes are placed anywhere.
    /// </summary>
    DotRank? FloatingNodeRank { get; set; }

    /// <summary>
    ///     <para>
    ///         In dot, this gives the desired rank separation, in inches (<see cref="DotRankSeparation"/>; default: 0.5, minimum: 0.02).
    ///         This is the minimum vertical distance between the bottom of the nodes in one rank and the tops of nodes in the next.
    ///     </para>
    ///     <para>
    ///         In twopi, this attribute specifies the radial separation of concentric circles (default: 1, minimum: 0.02). For twopi,
    ///         this can also be a list of doubles (<see cref="DotRadialRankSeparation"/>). The first double specifies the radius of the
    ///         inner circle; the second double specifies the increase in radius from the first circle to the second; etc. If there are
    ///         more circles than numbers, the last number is used as the increment for the remainder.
    ///     </para>
    ///     <para>
    ///         Twopi, dot only.
    ///     </para>
    /// </summary>
    DotRankSeparationDefinition? RankSeparation { get; set; }

    /// <summary>
    ///     <para>
    ///         If enabled (see <see cref="DotPackingEnabled"/>), each connected component of the graph is laid out separately, and then
    ///         the graphs are packed together.
    ///     </para>
    ///     <para>
    ///         If an integral value is specified (see <see cref="DotPackingMargin"/>), this is used as the size, in points, of a margin
    ///         around each part; otherwise, a default margin of 8 is used.
    ///     </para>
    ///     <para>
    ///         If disabled (see <see cref="DotPackingEnabled"/>), the entire graph is laid out together. The granularity and method of
    ///         packing is influenced by the <see cref="PackingMode"/> attribute.
    ///     </para>
    ///     <para>
    ///         Default: disabled (see <see cref="DotPackingEnabled"/>).
    ///     </para>
    /// </summary>
    DotPackingDefinition? Packing { get; set; }

    /// <summary>
    ///     Indicates how connected components should be packed (default: <see cref="DotPackingGranularity.Node"/>). Note that specifying
    ///     a value for this property will automatically turn on packing as though one had set <see cref="Packing"/> = true.
    /// </summary>
    DotPackingModeDefinition? PackingMode { get; set; }

    /// <summary>
    ///     If there are multiple clusters, determines whether to run edge crossing minimization a second time (dot only, default: true).
    /// </summary>
    bool? RepeatEdgeCrossingMinimization { get; set; }

    /// <summary>
    ///     <para>
    ///         Scale factor for mincross (mc) edge crossing minimiser parameters (dot only, default: 1.0).
    ///     </para>
    ///     <para>
    ///         Multiplicative scale factor used to alter the MinQuit (default = 8) and MaxIter (default = 24) parameters used during
    ///         crossing minimization. These correspond to the number of tries without improvement before quitting and the maximum number
    ///         of iterations in each pass.
    ///     </para>
    /// </summary>
    double? EdgeCrossingMinimizationScaleFactor { get; set; }

    /// <summary>
    ///     <para>
    ///         Determines whether to use a single global ranking, ignoring clusters (dot only, default: false).
    ///     </para>
    ///     <para>
    ///         The original ranking algorithm in dot is recursive on clusters. This can produce fewer ranks and a more compact layout,
    ///         but sometimes at the cost of a head node being placed on a higher rank than the tail node. It also assumes that a node is
    ///         not constrained in separate, incompatible subgraphs. For example, a node cannot be in a cluster and also be constrained
    ///         by a rank of <see cref="DotRank.Same"/> with a node not in the cluster (see <see cref="IDotSubgraphAttributes.NodeRank"/>
    ///         on subgraph attributes).
    ///     </para>
    ///     <para>
    ///         This allows nodes to be subject to multiple constraints. Rank constraints will usually take precedence over edge
    ///         constraints. See also <see cref="NodeRank"/>.
    ///     </para>
    /// </summary>
    bool? EnableGlobalRanking { get; set; }

    /// <summary>
    ///     Gets or sets the sorting index of the graph (default: 0). If <see cref="PackingMode"/> indicates an array packing, this
    ///     attribute specifies an insertion order among the components, with smaller values inserted first.
    /// </summary>
    int? SortIndex { get; set; }

    /// <summary>
    ///     Specifies the order in which nodes and edges are drawn.
    /// </summary>
    DotOutputOrder? OutputOrder { get; set; }
}