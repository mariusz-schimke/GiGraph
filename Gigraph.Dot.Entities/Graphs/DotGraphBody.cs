using Gigraph.Dot.Entities.Attributes.Collections;
using Gigraph.Dot.Entities.Edges;
using Gigraph.Dot.Entities.Nodes;
using Gigraph.Dot.Entities.Subgraphs;

namespace Gigraph.Dot.Entities.Graphs
{
    public abstract class DotGraphBody : IDotEntity
    {
        /// <summary>
        /// The collection of attributes of the element.
        /// </summary>
        public virtual DotAttributeCollection Attributes { get; protected set; } = new DotAttributeCollection();

        /// <summary>
        /// Gets the collection of nodes.
        /// </summary>
        public virtual DotNodeCollection Nodes { get; protected set; } = new DotNodeCollection();

        /// <summary>
        /// Gets the collection of edges. Mind the fact that when an edge connects two elements belonging to two different
        /// subgraphs (or where one belongs to the root graph, and the other belongs to a subgraph),
        /// then it should be added to the common upper level graph or subgraph.
        /// </summary>
        public virtual DotEdgeCollection Edges { get; protected set; } = new DotEdgeCollection();

        /// <summary>
        /// Gets the collection of subgraphs.
        /// </summary>
        public virtual DotSubgraphCollection Subgraphs { get; protected set; } = new DotSubgraphCollection();

        /// <summary>
        /// Gets the collection of clusters.
        /// </summary>
        public virtual DotClusterCollection Clusters { get; protected set; } = new DotClusterCollection();
    }
}
