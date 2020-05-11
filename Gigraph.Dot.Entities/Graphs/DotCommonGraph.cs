using Gigraph.Dot.Entities.Attributes.Collections;
using Gigraph.Dot.Entities.Edges;
using Gigraph.Dot.Entities.Nodes;
using Gigraph.Dot.Entities.Subgraphs;

namespace Gigraph.Dot.Entities.Graphs
{
    public abstract class DotCommonGraph : IDotEntity
    {
        /// <summary>
        /// Gets or sets the identifier of the graph. Set null if no identifier should be used.
        /// </summary>
        public virtual string Id { get; set; }

        /// <summary>
        /// The collection of attributes of the element.
        /// </summary>
        public virtual DotAttributeCollection Attributes { get; }

        /// <summary>
        /// Gets the collection of nodes.
        /// </summary>
        public virtual DotNodeCollection Nodes { get; }

        /// <summary>
        /// Gets the collection of edges. Mind the fact that when an edge connects two elements belonging to two different
        /// subgraphs (or where one belongs to the root graph, and the other belongs to a subgraph),
        /// then it should be added to the common upper level graph or subgraph.
        /// </summary>
        public virtual DotEdgeCollection Edges { get; }

        /// <summary>
        /// Gets the collection of subgraphs. There are two supported types of subgraphs:
        /// <list type="bullet">
        ///     <item>
        ///         <see cref="DotSubgraph"/> as a collection of nodes constrained with a rank attribute that determines their layout,
        ///     </item>
        ///     <item>
        ///         <see cref="DotCluster"/>, as a collection of nodes drawn within a bounding rectangle
        ///     </item>
        /// </list>
        /// A subgraph 
        /// 
        /// <para>
        /// Use a subgraph (<see cref="DotSubgraph"/>) when you want to have more granular control on the layout of a specific group of nodes.
        /// But when you want the nodes to be drawn together in a bounding rectangle, that has a custom color and fill, use a cluster instead
        /// (<see cref="DotCluster"/>).
        /// </para>
        /// </summary>
        public virtual DotCommonSubgraphCollection Subgraphs { get; }

        /// <summary>
        /// Gets the collection of clusters. A cluster is a special type of subgraph whose appearance can be customized.
        /// If supported, the layout engine used to render it, will do the layout so that the nodes belonging to the cluster
        /// are drawn together, with the entire drawing of the cluster contained within a bounding rectangle.
        /// Note that cluster subgraphs are not part of the DOT language, but solely a syntactic convention adhered to by certain of the layout engines.
        /// </summary>
        // public virtual DotClusterCollection Clusters { get; }

        protected DotCommonGraph(string id, DotAttributeCollection attributes, DotNodeCollection nodes, DotEdgeCollection edges, DotCommonSubgraphCollection subgraphs)
        {
            Id = id;
            Attributes = attributes;
            Nodes = nodes;
            Edges = edges;
            Subgraphs = subgraphs;
        }
    }
}
