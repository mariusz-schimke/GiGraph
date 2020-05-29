using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Entities.Subgraphs;
using System;
using System.Collections.Generic;

namespace GiGraph.Dot.Entities.Edges.Collections
{
    public partial class DotCommonEdgeCollection : IDotEntity, ICollection<DotCommonEdge>
    {
        /// <summary>
        /// Adds a group of edges where all <paramref name="tailNodeIds"/> as tail nodes
        /// are connected to the <paramref name="headNodeId"/> as the head node.
        /// </summary>
        /// <param name="headNodeId">The identifier of the head (destination, right) node.</param>
        /// <param name="tailNodeIds">The identifiers of the tail (source, left) nodes to connect to the head node.</param>
        public virtual DotManyToOneEdgeGroup AddManyToOne(string headNodeId, params string[] tailNodeIds)
        {
            return AddManyToOne(tailNodeIds, headNodeId);
        }

        /// <summary>
        /// Adds a group of edges where all <paramref name="tailNodeIds"/> as tail nodes
        /// are connected to the <paramref name="headNodeId"/> as the head node.
        /// </summary>
        /// <param name="initEdge">An optional initializer delegate to call for the attributes of the created edge group.</param>
        /// <param name="headNodeId">The identifier of the head (destination, right) node.</param>
        /// <param name="tailNodeIds">The identifiers of the tail (source, left) nodes to connect to the head node.</param>
        public virtual DotManyToOneEdgeGroup AddManyToOne(Action<IDotEdgeAttributes> initEdge, string headNodeId, params string[] tailNodeIds)
        {
            return AddManyToOne(tailNodeIds, headNodeId, initEdge);
        }

        /// <summary>
        /// Adds a group of edges where all <paramref name="tailNodeIds"/> as tail nodes
        /// are connected to the <paramref name="headNodeId"/> as the head node.
        /// </summary>
        /// <param name="tailNodeIds">The identifiers of the tail (source, left) nodes to connect to the head node.</param>
        /// <param name="headNodeId">The identifier of the head (destination, right) node.</param>
        /// <param name="initEdge">An optional initializer delegate to call for the attributes of the created edge group.</param>
        public virtual DotManyToOneEdgeGroup AddManyToOne(IEnumerable<string> tailNodeIds, string headNodeId, Action<IDotEdgeAttributes> initEdge = null)
        {
            return Add(new DotManyToOneEdgeGroup(tailNodeIds, headNodeId), initEdge);
        }

        /// <summary>
        /// Adds a group of edges where all nodes in the specified tail endpoint group are connected to specified head endpoint.
        /// </summary>
        /// <param name="tail">The group whose nodes should be the tail endpoints.</param>
        /// <param name="head">The head (destination, right) node the <paramref name="tail"/> nodes should be connected to.</param>
        /// <param name="initEdge">An optional initializer delegate to call for the attributes of the created edge group.</param>
        public virtual DotManyToOneEdgeGroup AddManyToOne(DotEndpointGroup tail, DotEndpoint head, Action<IDotEdgeAttributes> initEdge = null)
        {
            return Add(new DotManyToOneEdgeGroup(tail, head), initEdge);
        }

        /// <summary>
        /// Adds a group of edges where all nodes in the specified tail endpoint group are connected to specified head endpoint.
        /// </summary>
        /// <param name="tail">The subgraph whose nodes should be the tail endpoints.</param>
        /// <param name="headNodeId">The identifier of the head (destination, right) node the <paramref name="tail"/> subgraph nodes should be connected to.</param>
        /// <param name="initEdge">An optional initializer delegate to call for the attributes of the created edge group.</param>
        public virtual DotManyToOneEdgeGroup AddManyToOne(DotSubgraph tail, string headNodeId, Action<IDotEdgeAttributes> initEdge = null)
        {
            return Add(new DotManyToOneEdgeGroup(tail, headNodeId), initEdge);
        }
    }
}
