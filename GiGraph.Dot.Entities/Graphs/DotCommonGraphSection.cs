using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Collections.Subgraph;
using GiGraph.Dot.Entities.Clusters.Collections;
using GiGraph.Dot.Entities.Edges.Collections;
using GiGraph.Dot.Entities.Nodes.Collections;
using GiGraph.Dot.Entities.Subgraphs.Collections;

namespace GiGraph.Dot.Entities.Graphs
{
    public abstract class DotCommonGraphSection : IDotCommonGraphSection, IDotAnnotatable
    {
        protected readonly DotEntityAttributes _attributes;

        protected DotCommonGraphSection(
            DotEntityAttributes attributes,
            DotNodeCollection nodes,
            DotEdgeCollection edges,
            DotSubgraphCollection subgraphs,
            DotClusterCollection clusters)
        {
            _attributes = attributes;
            Nodes = nodes;
            Edges = edges;
            Subgraphs = subgraphs;
            Clusters = clusters;
        }

        protected DotCommonGraphSection(DotCommonGraphSection source)
            : this(source._attributes, source.Nodes, source.Edges, source.Subgraphs, source.Clusters)
        {
        }

        protected DotCommonGraphSection(DotEntityAttributes attributes, DotSubgraphCollection subgraphs, DotClusterCollection clusters)
            : this(
                attributes,
                new DotNodeCollection(),
                new DotEdgeCollection(),
                subgraphs,
                clusters
            )
        {
        }

        protected DotCommonGraphSection(DotEntityAttributes attributes)
            : this(
                attributes,
                new DotSubgraphCollection(),
                new DotClusterCollection()
            )
        {
        }

        /// <summary>
        ///     Gets the collection of nodes.
        /// </summary>
        public virtual DotNodeCollection Nodes { get; }

        /// <summary>
        ///     <para>
        ///         Gets the collection of edges.
        ///     </para>
        ///     <para>
        ///         (!) When an edge connects two elements belonging to two different subgraphs (or where one belongs to the root graph, and
        ///         the other belongs to a subgraph), then it should be added to the common upper level graph or subgraph, not to the current
        ///         graph.
        ///     </para>
        /// </summary>
        public virtual DotEdgeCollection Edges { get; }

        /// <summary>
        ///     <para>
        ///         Gets the collection of subgraphs.
        ///     </para>
        ///     <para>
        ///         Use a subgraph when you want to have more granular control on the layout of the nodes it contains by constraining them
        ///         within a rank (see the subgraph's <see cref="DotSubgraphAttributes.NodeRank" /> attribute). However, when you want
        ///         the nodes to be drawn together in a bounding rectangle, that has a custom color and fill, use a cluster instead (
        ///         <see cref="Clusters" />). You can use either of these types to set a common style of nodes and edges within them.
        ///     </para>
        /// </summary>
        public virtual DotSubgraphCollection Subgraphs { get; }

        /// <summary>
        ///     <para>
        ///         Gets the collection of clusters. A cluster is a collection of nodes drawn within a bounding rectangle.
        ///     </para>
        ///     <para>
        ///         Use a cluster when you want the nodes within it to be drawn together in a bounding rectangle, that has a custom color and
        ///         fill. However, when you want to have more granular control on the layout of selected nodes, use a subgraph instead (
        ///         <see cref="Subgraphs" />). You can use either of these types to set a common style of nodes and edges within them.
        ///     </para>
        /// </summary>
        public virtual DotClusterCollection Clusters { get; }

        protected abstract DotAttributeCollection AttributeCollection { get; }

        /// <inheritdoc cref="IDotAnnotatable.Annotation" />
        public virtual string Annotation { get; set; }

        DotAttributeCollection IDotCommonGraphSection.Attributes => AttributeCollection;
    }
}