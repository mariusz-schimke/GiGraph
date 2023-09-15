using System;
using System.Collections.Generic;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Entities.Subgraphs;

namespace GiGraph.Dot.Entities.Edges.Collections;

public partial class DotEdgeCollection
{
    /// <summary>
    ///     Adds a group of edges where the <paramref name="tailNodeId" /> as the tail node is joined to all
    ///     <paramref name="headNodeIds" /> as the head nodes.
    /// </summary>
    /// <param name="tailNodeId">
    ///     The identifier of the tail node.
    /// </param>
    /// <param name="headNodeIds">
    ///     The identifiers of the head nodes.
    /// </param>
    public virtual DotEdge<DotEndpoint, DotSubgraphEndpoint> AddOneToMany(string tailNodeId, params string[] headNodeIds) => AddOneToMany(tailNodeId, DotSubgraph.FromNodes(headNodeIds), init: null);

    /// <summary>
    ///     Adds a group of edges where the <paramref name="tailNodeId" /> as the tail node is joined to all
    ///     <paramref name="headNodeIds" /> as the head nodes.
    /// </summary>
    /// <param name="init">
    ///     An optional initializer delegate to call for the created edge group.
    /// </param>
    /// <param name="tailNodeId">
    ///     The identifier of the tail node.
    /// </param>
    /// <param name="headNodeIds">
    ///     The identifiers of the head nodes.
    /// </param>
    public virtual DotEdge<DotEndpoint, DotSubgraphEndpoint> AddOneToMany(Action<DotEdge<DotEndpoint, DotSubgraphEndpoint>> init, string tailNodeId, params string[] headNodeIds) => AddOneToMany(tailNodeId, headNodeIds, init);

    /// <summary>
    ///     Adds a group of edges where the <paramref name="tailNodeId" /> as the tail node is joined to all
    ///     <paramref name="headNodeIds" /> as the head nodes.
    /// </summary>
    /// <param name="tailNodeId">
    ///     The identifier of the tail node.
    /// </param>
    /// <param name="headNodeIds">
    ///     The identifiers of the head nodes.
    /// </param>
    /// <param name="init">
    ///     An optional initializer delegate to call for the created edge group.
    /// </param>
    public virtual DotEdge<DotEndpoint, DotSubgraphEndpoint> AddOneToMany(
        string tailNodeId, IEnumerable<string> headNodeIds,
        Action<DotEdge<DotEndpoint, DotSubgraphEndpoint>> init = null) =>
        AddOneToMany(tailNodeId, DotSubgraph.FromNodes(headNodeIds), init);

    /// <summary>
    ///     Adds a group of edges where the tail endpoint is joined to all nodes in the specified head endpoint group.
    /// </summary>
    /// <param name="tail">
    ///     The tail node (note that if you want to specify a cluster as a tail, use <see cref="DotClusterEndpoint" />).
    /// </param>
    /// <param name="heads">
    ///     The group whose endpoints to use as heads.
    /// </param>
    /// <param name="init">
    ///     An optional initializer delegate to call for the created edge group.
    /// </param>
    public virtual DotEdge<DotEndpoint, DotEndpointGroup> AddOneToMany(
        DotEndpoint tail, DotEndpointGroup heads,
        Action<DotEdge<DotEndpoint, DotEndpointGroup>> init = null) =>
        Add(tail, heads, init);

    /// <summary>
    ///     Adds a group of edges where the tail endpoint is joined to all nodes in the specified head subgraph.
    /// </summary>
    /// <param name="tail">
    ///     The tail node (note that if you want to specify a cluster as a tail, use <see cref="DotClusterEndpoint" />).
    /// </param>
    /// <param name="heads">
    ///     The subgraph whose nodes to use as head endpoints.
    /// </param>
    /// <param name="init">
    ///     An optional initializer delegate to call for the created edge group.
    /// </param>
    public virtual DotEdge<DotEndpoint, DotSubgraphEndpoint> AddOneToMany(
        DotEndpoint tail, DotSubgraphEndpoint heads,
        Action<DotEdge<DotEndpoint, DotSubgraphEndpoint>> init = null) =>
        Add(tail, heads, init);

    /// <summary>
    ///     Adds a group of edges where the tail endpoint is joined to all nodes in the specified head subgraph.
    /// </summary>
    /// <param name="tailNodeId">
    ///     The identifier of the tail node.
    /// </param>
    /// <param name="heads">
    ///     The subgraph whose nodes to use as head endpoints.
    /// </param>
    /// <param name="init">
    ///     An optional initializer delegate to call for the created edge group.
    /// </param>
    public virtual DotEdge<DotEndpoint, DotSubgraphEndpoint> AddOneToMany(
        string tailNodeId, DotSubgraph heads,
        Action<DotEdge<DotEndpoint, DotSubgraphEndpoint>> init = null) =>
        Add(new(tailNodeId), new(heads), init);
}