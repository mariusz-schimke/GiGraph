using GiGraph.Dot.Entities.Graphs.Collections;
using GiGraph.Dot.Types.Ranks;

namespace GiGraph.Dot.Entities.Subgraphs.Collections;

public class DotSubgraphCollection : DotCommonGraphCollection<DotSubgraph>
{
    /// <summary>
    ///     Adds a new subgraph to the collection, and returns it.
    /// </summary>
    /// <param name="init">
    ///     An optional subgraph initializer delegate.
    /// </param>
    public virtual DotSubgraph Add(Action<DotSubgraph>? init = null) => AddSubgraph(nodeIds: [], init: init);

    /// <summary>
    ///     Adds a new subgraph with the specified identifier to the collection, and returns it.
    /// </summary>
    /// <param name="id">
    ///     The identifier to assign to the subgraph.
    /// </param>
    /// <param name="init">
    ///     An optional subgraph initializer delegate.
    /// </param>
    public virtual DotSubgraph Add(string? id, Action<DotSubgraph>? init = null) => AddSubgraph(nodeIds: [], id, init: init);

    /// <summary>
    ///     Adds a new subgraph with the specified identifier and rank constraints to the collection, and returns it.
    /// </summary>
    /// <param name="id">
    ///     The identifier to assign to the subgraph.
    /// </param>
    /// <param name="nodeRankAlignment">
    ///     The rank constraints to apply to the nodes in the subgraph.
    /// </param>
    /// <param name="init">
    ///     An optional subgraph initializer delegate.
    /// </param>
    public virtual DotSubgraph Add(string? id, DotRankAlignment? nodeRankAlignment, Action<DotSubgraph>? init = null) => AddSubgraph(nodeIds: [], id, nodeRankAlignment, init);

    /// <summary>
    ///     Adds a new subgraph with the specified rank constraints to the collection, and returns it.
    /// </summary>
    /// <param name="nodeRankAlignment">
    ///     The rank constraints to apply to the nodes in the subgraph.
    /// </param>
    /// <param name="init">
    ///     An optional subgraph initializer delegate.
    /// </param>
    public virtual DotSubgraph Add(DotRankAlignment? nodeRankAlignment, Action<DotSubgraph>? init = null) => AddSubgraph(nodeIds: [], nodeRankAlignment: nodeRankAlignment, init: init);

    /// <summary>
    ///     Adds a new subgraph to the collection, and returns it.
    /// </summary>
    /// <param name="nodeIds">
    ///     Optional node identifiers to populate the subgraph with.
    /// </param>
    public virtual DotSubgraph AddWithNodes(params string[] nodeIds) => AddSubgraph(nodeIds);

    /// <summary>
    ///     Adds a new subgraph with the specified rank constraints to the collection, and returns it.
    /// </summary>
    /// <param name="nodeRankAlignment">
    ///     The rank constraints to apply to the nodes in the subgraph.
    /// </param>
    /// <param name="nodeIds">
    ///     Optional node identifiers to populate the subgraph with.
    /// </param>
    public virtual DotSubgraph AddWithNodes(DotRankAlignment? nodeRankAlignment, params string[] nodeIds) => AddSubgraph(nodeIds, nodeRankAlignment: nodeRankAlignment);

    /// <summary>
    ///     Adds a new subgraph with the specified identifier and rank constraints to the collection, and returns it.
    /// </summary>
    /// <param name="id">
    ///     The identifier to assign to the subgraph.
    /// </param>
    /// <param name="nodeRankAlignment">
    ///     The rank constraints to apply to the nodes in the subgraph.
    /// </param>
    /// <param name="nodeIds">
    ///     Optional node identifiers to populate the subgraph with.
    /// </param>
    public virtual DotSubgraph AddWithNodes(string? id, DotRankAlignment? nodeRankAlignment, params string[] nodeIds) => AddSubgraph(nodeIds, id, nodeRankAlignment);

    /// <summary>
    ///     Adds a new subgraph to the collection, and returns it.
    /// </summary>
    /// <param name="nodeIds">
    ///     A node identifier collection to populate the subgraph with.
    /// </param>
    public virtual DotSubgraph AddWithNodes(IEnumerable<string> nodeIds) => AddSubgraph(nodeIds);

    /// <summary>
    ///     Adds a new subgraph with the specified rank constraints to the collection, and returns it.
    /// </summary>
    /// <param name="nodeRankAlignment">
    ///     The rank constraints to apply to the nodes in the subgraph.
    /// </param>
    /// <param name="nodeIds">
    ///     A node identifier collection to populate the subgraph with.
    /// </param>
    public virtual DotSubgraph AddWithNodes(DotRankAlignment? nodeRankAlignment, IEnumerable<string> nodeIds) => AddSubgraph(nodeIds, nodeRankAlignment: nodeRankAlignment);

    /// <summary>
    ///     Adds a new subgraph with the specified identifier and rank constraints to the collection, and returns it.
    /// </summary>
    /// <param name="id">
    ///     The identifier to assign to the subgraph.
    /// </param>
    /// <param name="nodeRankAlignment">
    ///     The rank constraints to apply to the nodes in the subgraph.
    /// </param>
    /// <param name="nodeIds">
    ///     A node identifier collection to populate the subgraph with.
    /// </param>
    public virtual DotSubgraph AddWithNodes(string? id, DotRankAlignment? nodeRankAlignment, IEnumerable<string> nodeIds) => AddSubgraph(nodeIds, id, nodeRankAlignment);

    /// <summary>
    ///     Adds a new subgraph with the specified identifier to the collection, and returns it.
    /// </summary>
    /// <param name="id">
    ///     The identifier to assign to the subgraph.
    /// </param>
    /// <param name="nodeIds">
    ///     A node identifier collection to populate the subgraph with.
    /// </param>
    public virtual DotSubgraph AddWithNodes(string? id, IEnumerable<string> nodeIds) => AddSubgraph(nodeIds, id);

    protected virtual DotSubgraph AddSubgraph(IEnumerable<string> nodeIds, string? id = null, DotRankAlignment? nodeRankAlignment = null, Action<DotSubgraph>? init = null) =>
        Add(DotSubgraph.FromNodes(nodeIds, nodeRankAlignment, id), init);
}