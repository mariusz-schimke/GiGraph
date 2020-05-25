using GiGraph.Dot.Entities.Subgraphs;
using System;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    /// <summary>
    /// Represents a collection of nodes in a subgraph as edge endpoints.
    /// These nodes may be connected to a single node represented by the <see cref="DotNodeEndpoint"/> class,
    /// or to multiple nodes represented by a second instance of the same <see cref="DotSubgraphEndpoint"/> class.
    /// To make such connection, use <see cref="DotEdge{TTail, THead}"/> (or one of its specific descendants), or <see cref="DotWalk"/>.
    /// </summary>
    public class DotSubgraphEndpoint : DotEndpoint
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
        public DotSubgraphEndpoint(DotSubgraph subgraph)
        {
            Subgraph = subgraph;
        }
    }
}
