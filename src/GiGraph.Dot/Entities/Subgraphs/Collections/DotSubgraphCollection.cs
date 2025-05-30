﻿using GiGraph.Dot.Entities.Graphs.Collections;
using GiGraph.Dot.Types.Graphs.Layout.Spacing;

namespace GiGraph.Dot.Entities.Subgraphs.Collections;

public class DotSubgraphCollection : DotCommonGraphCollection<DotSubgraph>
{
    /// <summary>
    ///     Adds a new subgraph to the collection, and returns it.
    /// </summary>
    /// <param name="init">
    ///     An optional subgraph initializer delegate.
    /// </param>
    public virtual DotSubgraph Add(Action<DotSubgraph>? init = null) => Add(id: null, nodeRank: null, init);

    /// <summary>
    ///     Adds a new subgraph with the specified identifier to the collection, and returns it.
    /// </summary>
    /// <param name="id">
    ///     The identifier to assign to the subgraph.
    /// </param>
    /// <param name="init">
    ///     An optional subgraph initializer delegate.
    /// </param>
    public virtual DotSubgraph Add(string? id, Action<DotSubgraph>? init = null) => Add(id, nodeRank: null, init);

    /// <summary>
    ///     Adds a new subgraph with the specified rank constraints to the collection, and returns it.
    /// </summary>
    /// <param name="nodeRank">
    ///     The rank constraints to apply to the nodes in the subgraph.
    /// </param>
    /// <param name="init">
    ///     An optional subgraph initializer delegate.
    /// </param>
    public virtual DotSubgraph Add(DotRank? nodeRank, Action<DotSubgraph>? init = null) => Add(id: null, nodeRank, init);

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
    public virtual DotSubgraph Add(string? id, DotRank? nodeRank, Action<DotSubgraph>? init = null) =>
        Add(new DotSubgraph(id, nodeRank), init);

    /// <summary>
    ///     Adds a new subgraph with the specified rank constraints to the collection, and returns it.
    /// </summary>
    /// <param name="nodeRank">
    ///     The rank constraints to apply to the nodes in the subgraph.
    /// </param>
    /// <param name="nodeIds">
    ///     A node identifier collection to populate the subgraph with.
    /// </param>
    /// <param name="init">
    ///     An optional subgraph initializer delegate.
    /// </param>
    public virtual DotSubgraph AddWithNodes(DotRank? nodeRank, IEnumerable<string> nodeIds, Action<DotSubgraph>? init = null) => AddWithNodes(id: null, nodeRank, nodeIds, init);

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
    /// <param name="init">
    ///     An optional subgraph initializer delegate.
    /// </param>
    public virtual DotSubgraph AddWithNodes(string? id, DotRank? nodeRank, IEnumerable<string> nodeIds, Action<DotSubgraph>? init = null) =>
        Add(DotSubgraph.FromNodes(id, nodeRank, nodeIds), init);
}