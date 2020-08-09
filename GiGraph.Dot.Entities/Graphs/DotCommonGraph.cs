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
    public abstract class DotCommonGraph<TAttributes> : DotGraphSection<TAttributes>, IDotOrderable
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
            DotGraphSection<TAttributes> section,
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
        ///         The subsections of the graph. They appear consecutively in the output DOT script, and inherit the graph attributes and
        ///         the node, and/or edge defaults of their predecessors. When overridden in any subsection, the new graph attributes and
        ///         node/edge defaults apply to the elements the section itself contains, and also to those that belong to the sections that
        ///         follow it (if any).
        ///     </para>
        ///     <para>
        ///         Note that each subsection is dependent on the graph attributes and the node and edge defaults specified by the sections
        ///         that precede it (including those of the root section represented by the current element). Note also that some graph
        ///         attributes cannot be overriden, and apply to the whole graph no matter in which section they are set.
        ///     </para>
        ///     <para>
        ///         As far as setting node and/or edge defaults for a specific group of elements is concerned, <see cref="Subgraphs" /> may
        ///         be the cleaner and preferable way to achieve the effect.
        ///     </para>
        /// </summary>
        public virtual DotGraphSectionCollection<TAttributes> Subsections { get; }

        string IDotOrderable.OrderingKey => Id;
    }
}