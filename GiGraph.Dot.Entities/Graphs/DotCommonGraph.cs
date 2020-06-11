using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Edges.Collections;
using GiGraph.Dot.Entities.Nodes.Collections;
using GiGraph.Dot.Entities.Subgraphs.Collections;

namespace GiGraph.Dot.Entities.Graphs
{
    public abstract class DotCommonGraph : IDotOrderableEntity
    {
        /// <summary>
        /// Gets or sets the identifier of the graph. Set null if no identifier should be used.
        /// </summary>
        public virtual string Id { get; set; }

        /// <summary>
        /// The collection of attributes of the element.
        /// </summary>
        public virtual IDotAttributeCollection Attributes { get; }

        /// <summary>
        /// Gets the collection of nodes.
        /// </summary>
        public virtual DotNodeCollection Nodes { get; }

        /// <summary>
        /// The attributes to be used as default for all nodes in this graph when not specified explicitly for individual nodes in the <see cref="Nodes"/> collection.
        /// </summary>
        public virtual IDotNodeAttributes NodeDefaults { get; }

        /// <summary>
        /// Gets the collection of edges.
        /// <para>
        ///     (!) When an edge connects two elements belonging to two different
        ///     subgraphs (or where one belongs to the root graph, and the other belongs to a subgraph),
        ///     then it should be added to the common upper level graph or subgraph, not to the current graph.
        /// </para>
        /// </summary>
        public virtual DotEdgeDefinitionCollection Edges { get; }

        /// <summary>
        /// The attributes to be used as default for all edges in this graph when not specified explicitly for individual edges in the <see cref="Edges"/> collection.
        /// </summary>
        public virtual IDotEdgeAttributes EdgeDefaults { get; }

        /// <summary>
        /// Gets the collection of subgraphs.
        /// A subgraph is interpreted as a collection of nodes constrained with a rank attribute that determines their layout.
        /// <para>
        ///     Use a subgraph when you want to have more granular control on the layout of a specific group of nodes.
        ///     However, when you want the nodes to be drawn together in a bounding rectangle, that has a custom color and fill, use a cluster instead
        ///     (<see cref="Clusters"/>). You can use either of these types to set a common style of nodes and edges within them,
        ///     but you cannot control the layout of nodes within a cluster.
        /// </para>
        /// </summary>
        public virtual DotSubgraphCollection Subgraphs { get; }

        /// <summary>
        /// Gets the collection of clusters.
        /// A cluster is interpreted as a collection of nodes drawn within a bounding rectangle.
        /// <para>
        ///     Use a cluster when you want the nodes within it to be drawn together in a bounding rectangle, that has a custom color and fill.
        ///     However, when you want to have more granular control on the layout of a specific group of nodes, use a subgraph instead (<see cref="Subgraphs"/>).
        ///     You can use either of these types to set a common style of nodes and edges within them, but you cannot control the layout of nodes within a cluster.
        /// </para>
        /// </summary>
        public virtual DotClusterCollection Clusters { get; }

        string IDotOrderableEntity.OrderingKey => Id;

        protected DotCommonGraph(
            string id,
            IDotAttributeCollection attributes,
            DotNodeCollection nodes,
            DotEdgeDefinitionCollection edges,
            DotSubgraphCollection subgraphs,
            DotClusterCollection clusters,
            IDotNodeAttributes defaultNodeAttributes,
            IDotEdgeAttributes defaultEdgeAttributes)
        {
            Id = id;
            Attributes = attributes;
            Nodes = nodes;
            Edges = edges;
            Subgraphs = subgraphs;
            Clusters = clusters;
            NodeDefaults = defaultNodeAttributes;
            EdgeDefaults = defaultEdgeAttributes;
        }
    }
}
