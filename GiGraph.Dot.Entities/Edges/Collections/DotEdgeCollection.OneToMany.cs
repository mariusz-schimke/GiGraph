using System;
using System.Collections.Generic;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Entities.Subgraphs;

namespace GiGraph.Dot.Entities.Edges.Collections
{
    public partial class DotEdgeCollection
    {
        /// <summary>
        ///     Adds a group of edges where the <paramref name="tailNodeId" /> as the tail node is connected to all
        ///     <paramref name="headNodeIds" /> as the head nodes.
        /// </summary>
        /// <param name="tailNodeId">
        ///     The identifier of the tail (source, left) node.
        /// </param>
        /// <param name="headNodeIds">
        ///     The identifiers of the head (destination, right) nodes to connect the tail node to.
        /// </param>
        public virtual DotOneToManyEdgeGroup AddOneToMany(string tailNodeId, params string[] headNodeIds)
        {
            return Add(new DotOneToManyEdgeGroup(tailNodeId, headNodeIds), init: null);
        }

        /// <summary>
        ///     Adds a group of edges where the <paramref name="tailNodeId" /> as the tail node is connected to all
        ///     <paramref name="headNodeIds" /> as the head nodes.
        /// </summary>
        /// <param name="init">
        ///     An optional initializer delegate to call for the created edge group.
        /// </param>
        /// <param name="tailNodeId">
        ///     The identifier of the tail (source, left) node.
        /// </param>
        /// <param name="headNodeIds">
        ///     The identifiers of the head (destination, right) nodes to connect the tail node to.
        /// </param>
        public virtual DotOneToManyEdgeGroup AddOneToMany(Action<DotOneToManyEdgeGroup> init, string tailNodeId, params string[] headNodeIds)
        {
            return Add(new DotOneToManyEdgeGroup(tailNodeId, headNodeIds), init);
        }

        /// <summary>
        ///     Adds a group of edges where the <paramref name="tailNodeId" /> as the tail node is connected to all
        ///     <paramref name="headNodeIds" /> as the head nodes.
        /// </summary>
        /// <param name="tailNodeId">
        ///     The identifier of the tail (source, left) node.
        /// </param>
        /// <param name="headNodeIds">
        ///     The identifiers of the head (destination, right) nodes to connect the tail node to.
        /// </param>
        /// <param name="init">
        ///     An optional initializer delegate to call for the created edge group.
        /// </param>
        public virtual DotOneToManyEdgeGroup AddOneToMany(string tailNodeId, IEnumerable<string> headNodeIds, Action<DotOneToManyEdgeGroup> init = null)
        {
            return Add(new DotOneToManyEdgeGroup(tailNodeId, headNodeIds), init);
        }

        /// <summary>
        ///     Adds a group of edges where the tail endpoint is connected to all nodes in the specified head endpoint group.
        /// </summary>
        /// <param name="tail">
        ///     The tail (source, left) node. Note that if you want to specify a cluster as a tail, use <see cref="DotClusterEndpoint" />.
        /// </param>
        /// <param name="head">
        ///     The group whose nodes (as the head endpoints) the <paramref name="tail" /> node should be connected to.
        /// </param>
        /// <param name="init">
        ///     An optional initializer delegate to call for the created edge group.
        /// </param>
        public virtual DotOneToManyEdgeGroup AddOneToMany(DotEndpoint tail, DotEndpointGroup head, Action<DotOneToManyEdgeGroup> init = null)
        {
            return Add(new DotOneToManyEdgeGroup(tail, head), init);
        }

        /// <summary>
        ///     Adds a group of edges where the tail endpoint is connected to all nodes in the specified head subgraph.
        /// </summary>
        /// <param name="tailNodeId">
        ///     The identifier of the tail (source, left) node.
        /// </param>
        /// <param name="head">
        ///     The subgraph whose nodes (as the head endpoints) the <paramref name="tailNodeId" /> node should be connected to.
        /// </param>
        /// <param name="init">
        ///     An optional initializer delegate to call for the created edge group.
        /// </param>
        public virtual DotOneToManyEdgeGroup AddOneToMany(string tailNodeId, DotSubgraph head, Action<DotOneToManyEdgeGroup> init = null)
        {
            return Add(new DotOneToManyEdgeGroup(tailNodeId, head), init);
        }
    }
}