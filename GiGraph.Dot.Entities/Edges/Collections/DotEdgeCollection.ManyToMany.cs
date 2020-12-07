using System;
using System.Collections.Generic;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Entities.Subgraphs;

namespace GiGraph.Dot.Entities.Edges.Collections
{
    public partial class DotEdgeCollection
    {
        /// <summary>
        ///     Adds a group of edges where all <paramref name="tailNodeIds" /> as tail nodes are joined to all
        ///     <paramref name="headNodeIds" /> as head nodes.
        /// </summary>
        /// <param name="tailNodeIds">
        ///     The identifiers of the tail nodes.
        /// </param>
        /// <param name="headNodeIds">
        ///     The identifiers of the head nodes.
        /// </param>
        /// <param name="init">
        ///     An optional initializer delegate to call for the created edge group.
        /// </param>
        public virtual DotEdge<DotSubgraphEndpoint, DotSubgraphEndpoint> AddManyToMany(
            IEnumerable<string> tailNodeIds, IEnumerable<string> headNodeIds,
            Action<DotEdge<DotSubgraphEndpoint, DotSubgraphEndpoint>> init = null)
        {
            return AddManyToMany(DotSubgraph.FromNodes(tailNodeIds), DotSubgraph.FromNodes(headNodeIds), init);
        }

        /// <summary>
        ///     Adds a group of edges where all <paramref name="tailNodeIds" /> as tail nodes are joined to all
        ///     <paramref name="headNodeIds" /> as head nodes.
        /// </summary>
        /// <param name="tailNodeIds">
        ///     The identifiers of the tail nodes.
        /// </param>
        /// <param name="headNodeIds">
        ///     The identifiers of the head nodes.
        /// </param>
        public virtual DotEdge<DotSubgraphEndpoint, DotSubgraphEndpoint> AddManyToMany(IEnumerable<string> tailNodeIds, params string[] headNodeIds)
        {
            return AddManyToMany(DotSubgraph.FromNodes(tailNodeIds), DotSubgraph.FromNodes(headNodeIds), init: null);
        }

        /// <summary>
        ///     Adds a group of edges where all <paramref name="tailNodeIds" /> as tail nodes are joined to all
        ///     <paramref name="headNodeIds" /> as head nodes.
        /// </summary>
        /// <param name="init">
        ///     An optional initializer delegate to call for the created edge group.
        /// </param>
        /// <param name="tailNodeIds">
        ///     The identifiers of the tail nodes.
        /// </param>
        /// <param name="headNodeIds">
        ///     The identifiers of the head nodes.
        /// </param>
        public virtual DotEdge<DotSubgraphEndpoint, DotSubgraphEndpoint> AddManyToMany(
            Action<DotEdge<DotSubgraphEndpoint, DotSubgraphEndpoint>> init,
            IEnumerable<string> tailNodeIds, params string[] headNodeIds)
        {
            return AddManyToMany(DotSubgraph.FromNodes(tailNodeIds), DotSubgraph.FromNodes(headNodeIds), init);
        }

        /// <summary>
        ///     Adds a group of edges where all nodes in the specified tail endpoint group are joined to all nodes in the specified head
        ///     endpoint group.
        /// </summary>
        /// <param name="tails">
        ///     The group whose endpoints to use as tails
        /// </param>
        /// <param name="heads">
        ///     The group whose endpoints to use as heads.
        /// </param>
        /// <param name="init">
        ///     An optional initializer delegate to call for the created edge group.
        /// </param>
        public virtual DotEdge<DotEndpointGroup, DotEndpointGroup> AddManyToMany(
            DotEndpointGroup tails, DotEndpointGroup heads,
            Action<DotEdge<DotEndpointGroup, DotEndpointGroup>> init = null)
        {
            return Add(tails, heads, init);
        }

        /// <summary>
        ///     Adds a group of edges where all nodes in the specified tail subgraph are joined to all nodes in the specified head subgraph.
        /// </summary>
        /// <param name="tails">
        ///     The subgraph whose nodes to use as tail endpoints.
        /// </param>
        /// <param name="heads">
        ///     The subgraph whose nodes to use as head endpoints.
        /// </param>
        /// <param name="init">
        ///     An optional initializer delegate to call for the created edge group.
        /// </param>
        public virtual DotEdge<DotSubgraphEndpoint, DotSubgraphEndpoint> AddManyToMany(
            DotSubgraphEndpoint tails, DotSubgraphEndpoint heads,
            Action<DotEdge<DotSubgraphEndpoint, DotSubgraphEndpoint>> init = null)
        {
            return Add(tails, heads, init);
        }

        /// <summary>
        ///     Adds a group of edges where all nodes in the specified tail subgraph are joined to all nodes in the specified head subgraph.
        /// </summary>
        /// <param name="tails">
        ///     The subgraph whose nodes to use as tail endpoints.
        /// </param>
        /// <param name="heads">
        ///     The subgraph whose nodes to use as head endpoints.
        /// </param>
        /// <param name="init">
        ///     An optional initializer delegate to call for the created edge group.
        /// </param>
        public virtual DotEdge<DotSubgraphEndpoint, DotSubgraphEndpoint> AddManyToMany(
            DotSubgraph tails, DotSubgraph heads,
            Action<DotEdge<DotSubgraphEndpoint, DotSubgraphEndpoint>> init = null)
        {
            return Add(new DotSubgraphEndpoint(tails), new DotSubgraphEndpoint(heads), init);
        }
    }
}