using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Entities.Nodes;

namespace GiGraph.Dot.Entities.Subgraphs
{
    /// <summary>
    /// Represents a subgraph as a collection of nodes constrained with a rank attribute, that determines their layout.
    /// Use a subgraph (<see cref="DotSubgraph"/>) when you want to have more granular control on the layout and style of specific nodes.
    /// However, when you want the nodes to be displayed together in a bounding box, use a cluster (<see cref="DotCluster"/>) instead.
    /// <para>
    ///     Subgraph (<see cref="DotSubgraph"/>) does not have any border or fill, as opposed to cluster subgraph (<see cref="DotCluster"/>), which supports them.
    ///     However, it supports setting common style of nodes and edges within it, as well as the layout of nodes (by the rank attribute).
    /// </para>
    /// <para>
    ///     Subgraph (<see cref="DotSubgraph"/>) can also be used as a head or tail of an edge, in which case all nodes within them
    ///     are connected to the other side of the edge.
    /// </para>
    /// </summary>
    public class DotSubgraph : DotCommonSubgraph
    {
        /// <summary>
        /// The attributes of the subgraph. The only valid attribute for a non-cluster subgraph is rank.
        /// </summary>
        public new DotSubgraphAttributeCollection Attributes => (DotSubgraphAttributeCollection)base.Attributes;

        protected DotSubgraph(string id,
            DotSubgraphAttributeCollection attributes,
            DotNodeCollection nodes,
            DotEdgeCollection edges,
            DotCommonSubgraphCollection subgraphs,
            DotNodeAttributeCollection defaultNodeAttributes,
            DotEdgeAttributeCollection defaultEdgeAttributes)
            : base(id, attributes, nodes, edges, subgraphs, defaultNodeAttributes, defaultEdgeAttributes)
        {
        }

        /// <summary>
        /// Creates a new subgraph.
        /// </summary>
        /// <param name="id">The unique identifier of the subgraph. Pass null if no identifier should be used.</param>
        public DotSubgraph(string id = null)
            : this
              (
                  id,
                  new DotSubgraphAttributeCollection(),
                  new DotNodeCollection(),
                  new DotEdgeCollection(),
                  new DotCommonSubgraphCollection(),
                  new DotNodeAttributeCollection(),
                  new DotEdgeAttributeCollection()
              )
        {
        }

        // TODO: dodać metodę wytwórczą, która przyjmuje rank i pramams string[] id węzłów
    }
}
