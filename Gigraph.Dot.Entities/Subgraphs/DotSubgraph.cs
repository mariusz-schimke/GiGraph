using Gigraph.Dot.Entities.Attributes.Collections;
using Gigraph.Dot.Entities.Edges;
using Gigraph.Dot.Entities.Graphs;
using Gigraph.Dot.Entities.Nodes;

namespace Gigraph.Dot.Entities.Subgraphs
{
    /// <summary>
    /// Represents a subgraph as a collection of nodes constrained with a rank attribute, that determines their layout.
    /// Use a subgraph when you want to have more granular control on the layout of specific nodes.
    /// When you also want to control the appearance of the subgraph bounding box, use a cluster instead (<see cref="DotCluster"/>).
    /// </summary>
    public class DotSubgraph : DotCommonSubgraph
    {
        /// <summary>
        /// The attributes of the subgraph. The only valid attribute for a non-cluster subgraph is rank.
        /// </summary>
        public new DotSubgraphAttributeCollection Attributes => (DotSubgraphAttributeCollection)base.Attributes;

        protected DotSubgraph(string id, DotSubgraphAttributeCollection attributes, DotNodeCollection nodes, DotEdgeCollection edges, DotCommonSubgraphCollection subgraphs)
            : base(id, attributes, nodes, edges, subgraphs)
        {
        }

        /// <summary>
        /// Creates a new subgraph.
        /// </summary>
        /// <param name="id">The unique identifier of the subgraph. Pass null if no identifier should be used.</param>
        public DotSubgraph(string id = null)
            : this(id, new DotSubgraphAttributeCollection(), new DotNodeCollection(), new DotEdgeCollection(), new DotCommonSubgraphCollection())
        {
        }

        // TODO: dodać metodę wytwórczą, która przyjmuje rank i pramams string[] id węzłów
    }
}
