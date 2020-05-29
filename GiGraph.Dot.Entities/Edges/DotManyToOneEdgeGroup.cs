using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Entities.Subgraphs;
using System.Collections.Generic;

namespace GiGraph.Dot.Entities.Edges
{
    /// <summary>
    /// Represents a group of edges that join the nodes in a subgraph with a single node.
    /// </summary>
    public class DotManyToOneEdgeGroup : DotEdge<DotEndpointGroup, DotEndpoint>
    {
        protected DotManyToOneEdgeGroup(DotEndpointGroup tail, DotEndpoint head, IDotEdgeAttributes attributes)
            : base(tail, head, attributes)
        {
        }

        /// <summary>
        /// Creates a new instance that joins the nodes in a subgraph with a single node.
        /// </summary>
        /// <param name="tail">The subgraph whose nodes should be the tail endpoints.</param>
        /// <param name="head">The head (destination, right) node the <paramref name="tail"/> nodes should be connected to.</param>
        public DotManyToOneEdgeGroup(DotEndpointGroup tail, DotEndpoint head)
            : base(tail, head)
        {
        }

        /// <summary>
        /// Creates a new instance that joins the nodes in a subgraph with a single node.
        /// </summary>
        /// <param name="tail">The subgraph whose nodes should be the tail endpoints.</param>
        /// <param name="headNodeId">The identifier of the head (destination, right) node the <paramref name="tail"/> nodes should be connected to.</param>
        public DotManyToOneEdgeGroup(DotSubgraph tail, string headNodeId)
            : this(new DotEndpointGroup(tail), new DotEndpoint(headNodeId))
        {
        }

        /// <summary>
        /// Creates a new instance that joins the nodes in a subgraph with a single node.
        /// </summary>
        /// <param name="headNodeId">The identifier of the head (destination, right) node the <paramref name="tailNodeIds"/> nodes should be connected to.</param>
        /// <param name="tailNodeIds">The identifiers of the tail (source, left) nodes.</param>
        public DotManyToOneEdgeGroup(string headNodeId, params string[] tailNodeIds)
            : this(tailNodeIds, headNodeId)
        {
        }

        /// <summary>
        /// Creates a new instance that joins the nodes in a subgraph with a single node.
        /// </summary>
        /// <param name="tailNodeIds">The identifiers of the tail (source, left) nodes.</param>
        /// <param name="headNodeId">The identifier of the head (destination, right) node the <paramref name="tailNodeIds"/> nodes should be connected to.</param>
        public DotManyToOneEdgeGroup(IEnumerable<string> tailNodeIds, string headNodeId)
            : this(DotSubgraph.FromNodes(tailNodeIds), headNodeId)
        {
        }
    }
}
