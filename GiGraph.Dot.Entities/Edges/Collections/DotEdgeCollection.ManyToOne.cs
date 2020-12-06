using System;
using System.Collections.Generic;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Entities.Subgraphs;

namespace GiGraph.Dot.Entities.Edges.Collections
{
    public partial class DotEdgeCollection
    {
        /// <summary>
        ///     Adds a group of edges where all <paramref name="tailNodeIds" /> as tail nodes are connected to the
        ///     <paramref name="headNodeId" /> as the head node.
        /// </summary>
        /// <param name="headNodeId">
        ///     The identifier of the head (destination, right) node.
        /// </param>
        /// <param name="tailNodeIds">
        ///     The identifiers of the tail (source, left) nodes to connect to the head node.
        /// </param>
        public virtual DotManyToOneEdgeGroup AddManyToOne(string headNodeId, params string[] tailNodeIds)
        {
            return AddManyToOne(tailNodeIds, headNodeId);
        }

        /// <summary>
        ///     Adds a group of edges where all <paramref name="tailNodeIds" /> as tail nodes are connected to the
        ///     <paramref name="headNodeId" /> as the head node.
        /// </summary>
        /// <param name="init">
        ///     An optional initializer delegate to call for the created edge group.
        /// </param>
        /// <param name="headNodeId">
        ///     The identifier of the head (destination, right) node.
        /// </param>
        /// <param name="tailNodeIds">
        ///     The identifiers of the tail (source, left) nodes to connect to the head node.
        /// </param>
        public virtual DotManyToOneEdgeGroup AddManyToOne(Action<DotManyToOneEdgeGroup> init, string headNodeId, params string[] tailNodeIds)
        {
            return AddManyToOne(tailNodeIds, headNodeId, init);
        }

        /// <summary>
        ///     Adds a group of edges where all <paramref name="tailNodeIds" /> as tail nodes are connected to the
        ///     <paramref name="headNodeId" /> as the head node.
        /// </summary>
        /// <param name="tailNodeIds">
        ///     The identifiers of the tail (source, left) nodes to connect to the head node.
        /// </param>
        /// <param name="headNodeId">
        ///     The identifier of the head (destination, right) node.
        /// </param>
        /// <param name="init">
        ///     An optional initializer delegate to call for the created edge group.
        /// </param>
        public virtual DotManyToOneEdgeGroup AddManyToOne(IEnumerable<string> tailNodeIds, string headNodeId, Action<DotManyToOneEdgeGroup> init = null)
        {
            return Add(new DotManyToOneEdgeGroup(tailNodeIds, headNodeId), init);
        }

        /// <summary>
        ///     Adds a group of edges where all nodes in the specified tail endpoint group are connected to specified head endpoint.
        /// </summary>
        /// <param name="tail">
        ///     The group whose nodes should be the tail endpoints.
        /// </param>
        /// <param name="head">
        ///     The head (destination, right) node the <paramref name="tail" /> nodes should be connected to. Note that if you want to
        ///     specify a cluster as a head, use <see cref="DotClusterEndpoint" />.
        /// </param>
        /// <param name="init">
        ///     An optional initializer delegate to call for the created edge group.
        /// </param>
        public virtual DotManyToOneEdgeGroup AddManyToOne(DotEndpointGroup tail, DotEndpoint head, Action<DotManyToOneEdgeGroup> init = null)
        {
            return Add(new DotManyToOneEdgeGroup(tail, head), init);
        }

        /// <summary>
        ///     Adds a group of edges where all nodes in the specified tail subgraph are connected to specified head endpoint.
        /// </summary>
        /// <param name="tail">
        ///     The subgraph whose nodes should be the tail endpoints.
        /// </param>
        /// <param name="headNodeId">
        ///     The identifier of the head (destination, right) node the <paramref name="tail" /> subgraph nodes should be connected to.
        /// </param>
        /// <param name="init">
        ///     An optional initializer delegate to call for the created edge group.
        /// </param>
        public virtual DotManyToOneEdgeGroup AddManyToOne(DotSubgraph tail, string headNodeId, Action<DotManyToOneEdgeGroup> init = null)
        {
            return Add(new DotManyToOneEdgeGroup(tail, headNodeId), init);
        }
    }
}