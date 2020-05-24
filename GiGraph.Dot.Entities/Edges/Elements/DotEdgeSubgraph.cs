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
        /// <summary>
        /// Gets the subgraph to use as a head or as a tail of an edge.
        /// </summary>
        public DotSubgraph Subgraph { get; }

        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        /// <param name="subgraph">The subgraph to use as a head or as a tail of an edge.</param>
        public DotEdgeSubgraph(DotSubgraph subgraph)
        {
            Subgraph = subgraph ?? throw new ArgumentNullException(nameof(subgraph), "Subgraph is required."); ;
        }
    }
}
