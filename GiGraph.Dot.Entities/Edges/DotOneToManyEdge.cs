using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Entities.Subgraphs;
using System.Collections.Generic;

namespace GiGraph.Dot.Entities.Edges
{
    /// <summary>
    /// Represents a set of edges that join a single node with the nodes in a subgraph.
    /// </summary>
    public class DotOneToManyEdge : DotEdge<DotNodeEndpoint, DotSubgraphEndpoint>
    {
        protected DotOneToManyEdge(DotNodeEndpoint tail, DotSubgraphEndpoint head, IDotEdgeAttributes attributes)
            : base(tail, head, attributes)
        {
        }

        /// <summary>
        /// Creates a new instance that joins a single node with the nodes in a subgraph.
        /// </summary>
        /// <param name="tail">The tail (source, left) node.</param>
        /// <param name="head">The subgraph whose nodes (as the head endpoints) the <paramref name="tail"/> node should be connected to.</param>
        public DotOneToManyEdge(DotNodeEndpoint tail, DotSubgraphEndpoint head)
            : base(tail, head)
        {
        }

        /// <summary>
        /// Creates a new instance that joins a single node with the nodes in a subgraph.
        /// </summary>
        /// <param name="tailNodeId">The identifier of the tail (source, left) node.</param>
        /// <param name="head">The subgraph whose nodes (as the head endpoints) the <paramref name="tailNodeId"/> node should be connected to.</param>
        public DotOneToManyEdge(string tailNodeId, DotSubgraph head)
            : this(new DotNodeEndpoint(tailNodeId), new DotSubgraphEndpoint(head))
        {
        }

        /// <summary>
        /// Creates a new instance that joins a single node with the nodes in a subgraph.
        /// </summary>
        /// <param name="tailNodeId">The identifier of the tail (source, left) node.</param>
        /// <param name="headNodeIds">The identifiers of the head (destination, right) nodes the <paramref name="tailNodeId"/> node should be connected to.</param>
        public static DotOneToManyEdge Create(string tailNodeId, params string[] headNodeIds)
        {
            return Create(tailNodeId, (IEnumerable<string>)headNodeIds);
        }

        /// <summary>
        /// Creates a new instance that joins a single node with the nodes in a subgraph.
        /// </summary>
        /// <param name="tailNodeId">The identifier of the tail (source, left) node.</param>
        /// <param name="headNodeIds">The identifiers of the head (destination, right) nodes the <paramref name="tailNodeId"/> node should be connected to.</param>
        public static DotOneToManyEdge Create(string tailNodeId, IEnumerable<string> headNodeIds)
        {
            return new DotOneToManyEdge(tailNodeId, DotSubgraph.FromNodes(headNodeIds));
        }
    }
}
