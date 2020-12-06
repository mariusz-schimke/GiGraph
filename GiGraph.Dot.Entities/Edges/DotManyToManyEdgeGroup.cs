using System.Collections.Generic;
using GiGraph.Dot.Entities.Attributes.Collections.Edge;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Entities.Subgraphs;

namespace GiGraph.Dot.Entities.Edges
{
    /// <summary>
    ///     Represents a group of edges that join all nodes in a subgraph to all nodes in another subgraph.
    /// </summary>
    public class DotManyToManyEdgeGroup : DotEdge<DotSubgraphEndpoint, DotSubgraphEndpoint>
    {
        protected DotManyToManyEdgeGroup(DotSubgraphEndpoint tail, DotSubgraphEndpoint head, DotEdgeAttributes attributes)
            : base(tail, head, attributes)
        {
        }

        /// <summary>
        ///     Creates a new instance that joins all nodes in a subgraph to all nodes in another subgraph.
        /// </summary>
        /// <param name="tail">
        ///     The group whose nodes should be the tail endpoints.
        /// </param>
        /// <param name="head">
        ///     The group whose nodes (as the head endpoints) the <paramref name="tail" /> nodes should be connected to.
        /// </param>
        public DotManyToManyEdgeGroup(DotSubgraphEndpoint tail, DotSubgraphEndpoint head)
            : base(tail, head)
        {
        }

        /// <summary>
        ///     Creates a new instance that joins all nodes in a subgraph to all nodes in another subgraph.
        /// </summary>
        /// <param name="tail">
        ///     The subgraph whose nodes should be the tail endpoints.
        /// </param>
        /// <param name="head">
        ///     The subgraph whose nodes (as the head endpoints) the <paramref name="tail" /> nodes should be connected to.
        /// </param>
        public DotManyToManyEdgeGroup(DotSubgraph tail, DotSubgraph head)
            : this(new DotSubgraphEndpoint(tail), new DotSubgraphEndpoint(head))
        {
        }

        /// <summary>
        ///     Creates a new instance that joins all nodes in a subgraph to all nodes in another subgraph.
        /// </summary>
        /// <param name="tailNodeIds">
        ///     The identifiers of the tail (source, left) nodes.
        /// </param>
        /// <param name="headNodeIds">
        ///     The identifiers of the head (destination, right) nodes the <paramref name="tailNodeIds" /> nodes should be connected to.
        /// </param>
        public DotManyToManyEdgeGroup(IEnumerable<string> tailNodeIds, IEnumerable<string> headNodeIds)
            : this(new DotSubgraphEndpoint(tailNodeIds), new DotSubgraphEndpoint(headNodeIds))
        {
        }
    }
}