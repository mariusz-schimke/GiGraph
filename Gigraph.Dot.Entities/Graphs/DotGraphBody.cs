using Gigraph.Dot.Entities.Edges;
using Gigraph.Dot.Entities.Nodes;
using Gigraph.Dot.Entities.Subgraphs;

namespace Gigraph.Dot.Entities.Graphs
{
    public abstract class DotGraphBody : DotAttributedEntity
    {
        /// <summary>
        /// Gets the collection of nodes.
        /// </summary>
        public virtual DotNodeCollection Nodes { get; } = new DotNodeCollection();

        /// <summary>
        /// Gets the collection of edges. Mind the fact that when an edge connects two elements belonging to two different
        /// subgraphs (or where one belongs to the root graph, and the other belongs to a subgraph),
        /// then it should be added to the common upper level graph or subgraph.
        /// </summary>
        public virtual DotEdgeCollection Edges { get; } = new DotEdgeCollection();

        /// <summary>
        /// Gets the collection of subgraphs.
        /// </summary>
        public virtual DotSubgraphCollection Subgraphs { get; } = new DotSubgraphCollection();
    }
}
