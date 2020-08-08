using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Collections.Edge;
using GiGraph.Dot.Entities.Attributes.Collections.Node;
using GiGraph.Dot.Entities.Clusters.Collections;
using GiGraph.Dot.Entities.Edges.Collections;
using GiGraph.Dot.Entities.Graphs.Collections;
using GiGraph.Dot.Entities.Nodes.Collections;
using GiGraph.Dot.Entities.Subgraphs.Collections;

namespace GiGraph.Dot.Entities.Graphs
{
    public abstract class DotCommonGraph<TAttributes> : DotCommonGraphSection<TAttributes>, IDotOrderable
        where TAttributes : IDotAttributeCollection
    {
        protected DotCommonGraph(
            string id,
            TAttributes attributes,
            DotNodeCollection nodes,
            DotEdgeCollection edges,
            DotSubgraphCollection subgraphs,
            DotClusterCollection clusters,
            IDotNodeAttributeCollection nodeDefaults,
            IDotEdgeAttributeCollection edgeDefaults,
            DotGraphSectionCollection<TAttributes> subsections)
            : base(attributes, nodes, edges, subgraphs, clusters, nodeDefaults, edgeDefaults)
        {
            Id = id;
            Subsections = subsections;
        }

        protected DotCommonGraph(
            string id,
            DotCommonGraphSection<TAttributes> section,
            DotGraphSectionCollection<TAttributes> subsections)
            : this(id, section.Attributes, section.Nodes, section.Edges, section.Subgraphs, section.Clusters, section.NodeDefaults, section.EdgeDefaults, subsections)
        {
        }

        /// <summary>
        ///     Gets or sets the identifier of the graph. Set null if no identifier should be used.
        /// </summary>
        public virtual string Id { get; set; }

        /// <summary>
        ///     <para>
        ///         Gets the subsections of the graph. They appear consecutively in the output DOT script, and each may override the node
        ///         and/or edge defaults of the preceding sections.
        ///     </para>
        ///     <para>
        ///         Note that each subsection is dependent on the edge and node defaults (if set) of the sections that precede it (including
        ///         the root section represented by the current element). As far as overriding node and/or edge defaults for a group of nodes
        ///         and/or edges is concerned, <see cref="Subgraphs" /> may be the cleaner and preferable way to achieve the effect.
        ///     </para>
        /// </summary>
        public virtual DotGraphSectionCollection<TAttributes> Subsections { get; }

        string IDotOrderable.OrderingKey => Id;
    }
}