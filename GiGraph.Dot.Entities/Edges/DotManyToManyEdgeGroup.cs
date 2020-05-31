using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Entities.Subgraphs;
using System.Collections.Generic;

namespace GiGraph.Dot.Entities.Edges
{
    /// <summary>
    /// Represents a group of edges that join all nodes in a subgraph to all nodes in another subgraph.
    /// </summary>
    public class DotManyToManyEdgeGroup : DotEdge<DotEndpointGroup, DotEndpointGroup>
    {
        protected DotManyToManyEdgeGroup(DotEndpointGroup tail, DotEndpointGroup head, IDotEdgeAttributes attributes)
            : base(tail, head, attributes)
        {
        }

        /// <summary>
        /// Creates a new instance that joins all nodes in a subgraph to all nodes in another subgraph.
        /// </summary>
        /// <param name="tail">The group whose nodes should be the tail endpoints.</param>
        /// <param name="head">The group whose nodes (as the head endpoints) the <paramref name="tail"/> nodes should be connected to.</param>
        public DotManyToManyEdgeGroup(DotEndpointGroup tail, DotEndpointGroup head)
            : base(tail, head)
        {
        }

        /// <summary>
        /// Creates a new instance that joins all nodes in a subgraph to all nodes in another subgraph.
        /// </summary>
        /// <param name="tail">The subgraph whose nodes should be the tail endpoints.</param>
        /// <param name="head">The subgraph whose nodes (as the head endpoints) the <paramref name="tail"/> nodes should be connected to.</param>
        public DotManyToManyEdgeGroup(DotSubgraph tail, DotSubgraph head)
            : this(new DotEndpointGroup(tail), new DotEndpointGroup(head))
        {
        }

        /// <summary>
        /// Creates a new instance that joins all nodes in a subgraph to all nodes in another subgraph.
        /// </summary>
        /// <param name="tailNodeIds">The identifiers of the tail (source, left) nodes.</param>
        /// <param name="headNodeIds">The identifiers of the head (destination, right) nodes the <paramref name="tailNodeIds"/> nodes should be connected to.</param>
        public DotManyToManyEdgeGroup(IEnumerable<string> tailNodeIds, IEnumerable<string> headNodeIds)
            : this(new DotEndpointGroup(tailNodeIds), new DotEndpointGroup(headNodeIds))
        {
        }
    }
}
