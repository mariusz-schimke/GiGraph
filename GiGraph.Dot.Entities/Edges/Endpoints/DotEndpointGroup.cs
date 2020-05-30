using GiGraph.Dot.Entities.Subgraphs;
using System;
using System.Linq;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    /// <summary>
    /// Represents a collection of nodes in a subgraph as a group of endpoints.
    /// These nodes may be connected to a single node represented by the <see cref="DotEndpoint"/> class,
    /// or to multiple nodes represented by a second instance of the same <see cref="DotEndpointGroup"/> class.
    /// To make such connection, use <see cref="DotEdge{TTail, THead}"/> (or one of its more specific descendants),
    /// or <see cref="DotEdgeSequence"/>.
    /// </summary>
    public class DotEndpointGroup : DotCommonEndpoint
    {
        protected DotSubgraph _subgraph;

        /// <summary>
        /// Gets the subgraph whose nodes represent the endpoints of multiple edges.
        /// </summary>
        public DotSubgraph Subgraph
        {
            get => _subgraph;
            set => _subgraph = value ?? throw new ArgumentNullException(nameof(Subgraph), "Subgraph is required.");
        }

        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        /// <param name="subgraph">The subgraph whose nodes to use as the endpoints of multiple edges.</param>
        public DotEndpointGroup(DotSubgraph subgraph)
        {
            Subgraph = subgraph;
        }

        protected override string GetOrderingKey()
        {
            return string.Join(" ",
                _subgraph.Nodes
                         .Cast<IDotOrderableEntity>()
                         .Select(node => node.OrderingKey)
                         .OrderBy(key => key));
        }
    }
}
