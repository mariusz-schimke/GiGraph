using GiGraph.Dot.Entities.Subgraphs;
using System;

namespace GiGraph.Dot.Entities.Edges.Elements
{
    /// <summary>
    /// Represents a subgraph as a head or a tail of an edge.
    /// When used, all nodes within the subgraph become the heads or the tails respectively.
    /// </summary>
    public class DotEdgeSubgraph : DotEdgeElement
    {
        protected DotSubgraph _subgraph;

        /// <summary>
        /// Gets the subgraph to use as a head or as a tail of an edge.
        /// </summary>
        public DotSubgraph Subgraph
        {
            get => _subgraph;
            set => _subgraph = value ?? throw new ArgumentNullException(nameof(Subgraph), "Subgraph is required.");
        }

        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        /// <param name="subgraph">The subgraph to use as a head or as a tail of an edge.</param>
        public DotEdgeSubgraph(DotSubgraph subgraph)
        {
            Subgraph = subgraph;
        }
    }
}
