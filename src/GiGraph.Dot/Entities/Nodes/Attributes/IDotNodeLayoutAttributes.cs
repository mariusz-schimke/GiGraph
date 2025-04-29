using GiGraph.Dot.Entities.Graphs.Attributes;
using GiGraph.Dot.Types.Edges.Layout;

namespace GiGraph.Dot.Entities.Nodes.Attributes;

public interface IDotNodeLayoutAttributes
{
    /// <summary>
    ///     Determines how inedges and outedges, that is, edges with the node as their head or tail node respectively, are ordered (dot
    ///     only). If defined on a graph or subgraph, the value is applied to all nodes in the graph or subgraph. Note that the
    ///     corresponding graph attribute takes precedence over the node attribute.
    /// </summary>
    DotEdgeOrderingMode? EdgeOrderingMode { get; set; }

    /// <summary>
    ///     The name of the group the node belongs to (dot only). If the endpoints of an edge belong to the same group (have the same
    ///     group name assigned), parameters are set to avoid crossings and keep the edges straight (dot only).
    /// </summary>
    string? GroupName { get; set; }

    /// <summary>
    ///     Gets or sets the sorting index of the node (default: 0). If <see cref="DotGraphLayoutAttributes.PackingMode"/> of graph
    ///     <see cref="IDotGraphRootAttributes.Layout"/> indicates an array packing, this attribute specifies an insertion order among
    ///     the components, with smaller values inserted first.
    /// </summary>
    int? SortIndex { get; set; }

    /// <summary>
    ///     <para>
    ///         Specifies whether the node should be used as the center of the layout and the root of the generated spanning tree
    ///         (default: false; circo, twopi only).
    ///     </para>
    ///     <para>
    ///         In twopi, root will actually be the central node. In circo, the block containing the node will be central in the drawing
    ///         of its connected component. If not defined, twopi will pick a most central node, and circo will pick a random node.
    ///     </para>
    ///     <para>
    ///         If the <see cref="IDotGraphLayoutAttributes.RootNodeId"/> attribute on the graph is defined as the empty string, twopi
    ///         will reset it to name of the node picked as the root node.
    ///     </para>
    ///     <para>
    ///         For twopi, it is possible to have multiple roots, presumably one for each component. If more than one node in a component
    ///         is marked as the root, twopi will pick one.
    ///     </para>
    /// </summary>
    bool? IsLayoutRoot { get; set; }
}