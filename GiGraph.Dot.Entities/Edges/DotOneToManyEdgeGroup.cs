using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Entities.Subgraphs;
using System.Collections.Generic;

namespace GiGraph.Dot.Entities.Edges
{
    /// <summary>
    /// Represents a group of edges that join a single node with the nodes in a subgraph.
    /// </summary>
    public class DotOneToManyEdgeGroup : DotEdge<DotEndpoint, DotEndpointGroup>
    {
        protected DotOneToManyEdgeGroup(DotEndpoint tail, DotEndpointGroup head, IDotEdgeAttributes attributes)
            : base(tail, head, attributes)
        {
        }

        /// <summary>
        /// Creates a new instance that joins a single node with the nodes in a subgraph.
        /// </summary>
        /// <param name="tail">The tail (source, left) node.</param>
        /// <param name="head">The subgraph whose nodes (as the head endpoints) the <paramref name="tail"/> node should be connected to.</param>
        public DotOneToManyEdgeGroup(DotEndpoint tail, DotEndpointGroup head)
            : base(tail, head)
        {
        }

        /// <summary>
        /// Creates a new instance that joins a single node with the nodes in a subgraph.
        /// </summary>
        /// <param name="tailNodeId">The identifier of the tail (source, left) node.</param>
        /// <param name="head">The subgraph whose nodes (as the head endpoints) the <paramref name="tailNodeId"/> node should be connected to.</param>
        public DotOneToManyEdgeGroup(string tailNodeId, DotSubgraph head)
            : this(new DotEndpoint(tailNodeId), new DotEndpointGroup(head))
        {
        }

        /// <summary>
        /// Creates a new instance that joins a single node with the nodes in a subgraph.
        /// </summary>
        /// <param name="tailNodeId">The identifier of the tail (source, left) node.</param>
        /// <param name="headNodeIds">The identifiers of the head (destination, right) nodes the <paramref name="tailNodeId"/> node should be connected to.</param>
        public static DotOneToManyEdgeGroup Create(string tailNodeId, params string[] headNodeIds)
        {
            return Create(tailNodeId, (IEnumerable<string>)headNodeIds);
        }

        /// <summary>
        /// Creates a new instance that joins a single node with the nodes in a subgraph.
        /// </summary>
        /// <param name="tailNodeId">The identifier of the tail (source, left) node.</param>
        /// <param name="headNodeIds">The identifiers of the head (destination, right) nodes the <paramref name="tailNodeId"/> node should be connected to.</param>
        public static DotOneToManyEdgeGroup Create(string tailNodeId, IEnumerable<string> headNodeIds)
        {
            return new DotOneToManyEdgeGroup(tailNodeId, DotSubgraph.FromNodes(headNodeIds));
        }
    }
}
