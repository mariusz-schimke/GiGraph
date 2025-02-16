using System;
using System.Collections.Generic;
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
    /// <param name="nodeRank">
    ///     The rank constraints to apply to the nodes in the subgraph.
    /// </param>
    /// <param name="init">
    ///     An optional subgraph initializer delegate.
    /// </param>
    public virtual DotSubgraph Add(string? id, DotRank? nodeRank, Action<DotSubgraph>? init = null) => AddSubgraph(nodeIds: [], id, nodeRank, init);

    /// <summary>
    ///     Adds a new subgraph with the specified rank constraints to the collection, and returns it.
    /// </summary>
    /// <param name="nodeRank">
    ///     The rank constraints to apply to the nodes in the subgraph.
    /// </param>
    /// <param name="init">
    ///     An optional subgraph initializer delegate.
    /// </param>
    public virtual DotSubgraph Add(DotRank? nodeRank, Action<DotSubgraph>? init = null) => AddSubgraph(nodeIds: [], nodeRank: nodeRank, init: init);

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
    /// <param name="nodeRank">
    ///     The rank constraints to apply to the nodes in the subgraph.
    /// </param>
    /// <param name="nodeIds">
    ///     Optional node identifiers to populate the subgraph with.
    /// </param>
    public virtual DotSubgraph AddWithNodes(DotRank? nodeRank, params string[] nodeIds) => AddSubgraph(nodeIds, nodeRank: nodeRank);

    /// <summary>
    ///     Adds a new subgraph with the specified identifier and rank constraints to the collection, and returns it.
    /// </summary>
    /// <param name="id">
    ///     The identifier to assign to the subgraph.
    /// </param>
    /// <param name="nodeRank">
    ///     The rank constraints to apply to the nodes in the subgraph.
    /// </param>
    /// <param name="nodeIds">
    ///     Optional node identifiers to populate the subgraph with.
    /// </param>
    public virtual DotSubgraph AddWithNodes(string? id, DotRank? nodeRank, params string[] nodeIds) => AddSubgraph(nodeIds, id, nodeRank);

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
    /// <param name="nodeRank">
    ///     The rank constraints to apply to the nodes in the subgraph.
    /// </param>
    /// <param name="nodeIds">
    ///     A node identifier collection to populate the subgraph with.
    /// </param>
    public virtual DotSubgraph AddWithNodes(DotRank? nodeRank, IEnumerable<string> nodeIds) => AddSubgraph(nodeIds, nodeRank: nodeRank);

    /// <summary>
    ///     Adds a new subgraph with the specified identifier and rank constraints to the collection, and returns it.
    /// </summary>
    /// <param name="id">
    ///     The identifier to assign to the subgraph.
    /// </param>
    /// <param name="nodeRank">
    ///     The rank constraints to apply to the nodes in the subgraph.
    /// </param>
    /// <param name="nodeIds">
    ///     A node identifier collection to populate the subgraph with.
    /// </param>
    public virtual DotSubgraph AddWithNodes(string? id, DotRank? nodeRank, IEnumerable<string> nodeIds) => AddSubgraph(nodeIds, id, nodeRank);

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

    protected virtual DotSubgraph AddSubgraph(IEnumerable<string> nodeIds, string? id = null, DotRank? nodeRank = null, Action<DotSubgraph>? init = null) =>
        Add(DotSubgraph.FromNodes(nodeIds, nodeRank, id), init);
}