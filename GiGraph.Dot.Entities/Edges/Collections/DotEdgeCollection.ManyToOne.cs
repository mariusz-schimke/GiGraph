using System;
using System.Collections.Generic;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Entities.Subgraphs;

namespace GiGraph.Dot.Entities.Edges.Collections
{
    public partial class DotEdgeCollection
    {
        /// <summary>
        ///     Adds a group of edges where all <paramref name="tailNodeIds" /> as tail nodes are joined to the
        ///     <paramref name="headNodeId" /> as the head node.
        /// </summary>
        /// <param name="headNodeId">
        ///     The identifier of the head node.
        /// </param>
        /// <param name="tailNodeIds">
        ///     The identifiers of the tail nodes.
        /// </param>
        public virtual DotManyToOneEdgeGroup AddManyToOne(string headNodeId, params string[] tailNodeIds)
        {
            return AddManyToOne(tailNodeIds, headNodeId);
        }

        /// <summary>
        ///     Adds a group of edges where all <paramref name="tailNodeIds" /> as tail nodes are joined to the
        ///     <paramref name="headNodeId" /> as the head node.
        /// </summary>
        /// <param name="init">
        ///     An optional initializer delegate to call for the created edge group.
        /// </param>
        /// <param name="headNodeId">
        ///     The identifier of the head node.
        /// </param>
        /// <param name="tailNodeIds">
        ///     The identifiers of the tail nodes.
        /// </param>
        public virtual DotManyToOneEdgeGroup AddManyToOne(Action<DotManyToOneEdgeGroup> init, string headNodeId, params string[] tailNodeIds)
        {
            return AddManyToOne(tailNodeIds, headNodeId, init);
        }

        /// <summary>
        ///     Adds a group of edges where all <paramref name="tailNodeIds" /> as tail nodes are joined to the
        ///     <paramref name="headNodeId" /> as the head node.
        /// </summary>
        /// <param name="tailNodeIds">
        ///     The identifiers of the tail nodes.
        /// </param>
        /// <param name="headNodeId">
        ///     The identifier of the head node.
        /// </param>
        /// <param name="init">
        ///     An optional initializer delegate to call for the created edge group.
        /// </param>
        public virtual DotManyToOneEdgeGroup AddManyToOne(IEnumerable<string> tailNodeIds, string headNodeId, Action<DotManyToOneEdgeGroup> init = null)
        {
            return Add(new DotManyToOneEdgeGroup(tailNodeIds, headNodeId), init);
        }

        /// <summary>
        ///     Adds a group of edges where all nodes in the specified tail endpoint group are joined to specified head endpoint.
        /// </summary>
        /// <param name="tails">
        ///     The group whose endpoints to use as tails.
        /// </param>
        /// <param name="head">
        ///     The head node (note that if you want to specify a cluster as a head, use <see cref="DotClusterEndpoint" />).
        /// </param>
        /// <param name="init">
        ///     An optional initializer delegate to call for the created edge group.
        /// </param>
        public virtual DotEdge<DotEndpointGroup, DotEndpoint> AddManyToOne(DotEndpointGroup tails, DotEndpoint head, Action<DotEdge<DotEndpointGroup, DotEndpoint>> init = null)
        {
            return Add(tails, head, init);
        }

        /// <summary>
        ///     Adds a group of edges where all nodes in the specified tail subgraph are joined to the specified head endpoint.
        /// </summary>
        /// <param name="tails">
        ///     The subgraph whose nodes to use as tail endpoints.
        /// </param>
        /// <param name="head">
        ///     The head node (note that if you want to specify a cluster as a head, use <see cref="DotClusterEndpoint" />).
        /// </param>
        /// <param name="init">
        ///     An optional initializer delegate to call for the created edge group.
        /// </param>
        public virtual DotManyToOneEdgeGroup AddManyToOne(DotSubgraphEndpoint tails, DotEndpoint head, Action<DotManyToOneEdgeGroup> init = null)
        {
            return Add(new DotManyToOneEdgeGroup(tails, head), init);
        }

        /// <summary>
        ///     Adds a group of edges where all nodes in the specified tail subgraph are joined to specified head endpoint.
        /// </summary>
        /// <param name="tails">
        ///     The subgraph whose nodes to use as tail endpoints.
        /// </param>
        /// <param name="headNodeId">
        ///     The identifier of the head node.
        /// </param>
        /// <param name="init">
        ///     An optional initializer delegate to call for the created edge group.
        /// </param>
        public virtual DotManyToOneEdgeGroup AddManyToOne(DotSubgraph tails, string headNodeId, Action<DotManyToOneEdgeGroup> init = null)
        {
            return Add(new DotManyToOneEdgeGroup(tails, headNodeId), init);
        }
    }
}