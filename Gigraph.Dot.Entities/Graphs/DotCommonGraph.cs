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
        /// The attributes to be used as default for all nodes in this graph when not specified explicitly for individual nodes in the <see cref="Nodes"/> collection.
        /// </summary>
        public virtual DotNodeAttributeCollection NodeDefaults { get; }

        /// <summary>
        /// Gets the collection of edges.
        /// <para>
        ///     (!) When an edge connects two elements belonging to two different
        ///     subgraphs (or where one belongs to the root graph, and the other belongs to a subgraph),
        ///     then it should be added to the common upper level graph or subgraph, not to the current graph.
        /// </para>
        /// </summary>
        public virtual DotEdgeCollection Edges { get; }

        /// <summary>
        /// The attributes to be used as default for all edges in this graph when not specified explicitly for individual edges in the <see cref="Edges"/> collection.
        /// </summary>
        public virtual DotEdgeAttributeCollection EdgeDefaults { get; }

        /// <summary>
        /// Gets the collection of subgraphs. There are two supported types of subgraphs:
        /// <list type="bullet">
        ///     <item>
        ///         <see cref="DotSubgraph"/> as a collection of nodes constrained with a rank attribute that determines their layout,
        ///     </item>
        ///     <item>
        ///         <see cref="DotCluster"/> as a collection of nodes drawn within a bounding rectangle.
        ///     </item>
        /// </list>
        /// <para>
        ///     Use a subgraph (<see cref="DotSubgraph"/>) when you want to have more granular control on the layout of a specific group of nodes.
        ///     However, when you want the nodes to be drawn together in a bounding rectangle, that has a custom color and fill, use a cluster subgraph instead
        ///     (<see cref="DotCluster"/>). You can use either of these subgraphs to set a common style of nodes and edges within it,
        ///     but you cannot control the layout of nodes within a cluster subgraph.
        /// </para>
        /// </summary>
        public virtual DotCommonSubgraphCollection Subgraphs { get; }

        protected DotCommonGraph(
            string id,
            DotAttributeCollection attributes,
            DotNodeCollection nodes,
            DotEdgeCollection edges,
            DotCommonSubgraphCollection subgraphs,
            DotNodeAttributeCollection defaultNodeAttributes,
            DotEdgeAttributeCollection defaultEdgeAttributes)
        {
            Id = id;
            Attributes = attributes;
            Nodes = nodes;
            Edges = edges;
            Subgraphs = subgraphs;
            NodeDefaults = defaultNodeAttributes;
            EdgeDefaults = defaultEdgeAttributes;
        }
    }
}
