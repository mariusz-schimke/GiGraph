using System.Collections.Generic;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Clusters;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Graphs.Collections;

namespace GiGraph.Dot.Entities.Subgraphs
{
    /// <summary>
    ///     <para>
    ///         Represents a subgraph as a collection of nodes constrained with a rank attribute, that determines their layout. Use a
    ///         subgraph (<see cref="DotSubgraph" />) when you want to have more granular control on the layout and style of specific
    ///         nodes. However, when you want the nodes to be displayed together in a bounding box, use a cluster (
    ///         <see cref="DotCluster" />) instead.
    ///     </para>
    ///     <para>
    ///         Subgraph (<see cref="DotSubgraph" />) does not have any border or fill, as opposed to cluster subgraph (
    ///         <see cref="DotCluster" />), which supports them. However, it supports setting common style of nodes and edges within it,
    ///         as well as the layout of nodes (by the rank attribute).
    ///     </para>
    ///     <para>
    ///         Subgraph (<see cref="DotSubgraph" />) can also be used as a head or tail of an edge, in which case all nodes within them
    ///         are connected to the other side of the edge.
    ///     </para>
    /// </summary>
    public class DotSubgraph : DotSubgraphSection, IDotCommonGraph, IDotOrderable
    {
        protected DotSubgraph(string id, DotSubgraphSection rootSection, DotGraphSectionCollection<DotSubgraphSection> subsections)
            : base(rootSection)
        {
            Id = id;
            Subsections = subsections;
        }

        /// <summary>
        ///     Creates a new subgraph.
        /// </summary>
        /// <param name="id">
        ///     The identifier to assign to the subgraph.
        /// </param>
        public DotSubgraph(string id = null)
            : this(id, new DotSubgraphSection(), new DotGraphSectionCollection<DotSubgraphSection>())
        {
        }

        /// <summary>
        ///     Creates a new subgraph.
        /// </summary>
        /// <param name="id">
        ///     The identifier to assign to the subgraph.
        /// </param>
        /// <param name="rank">
        ///     The rank attribute to assign to the subgraph.
        /// </param>
        public DotSubgraph(string id, DotRank? rank)
            : this(id)
        {
            Attributes.Rank = rank;
        }

        /// <summary>
        ///     Creates a new subgraph.
        /// </summary>
        /// <param name="rank">
        ///     The rank attribute to assign to the subgraph.
        /// </param>
        public DotSubgraph(DotRank? rank)
            : this(id: null, rank)
        {
        }

        /// <summary>
        ///     <para>
        ///         The subsections of the graph. They appear consecutively in the output DOT script, and inherit the graph attributes, and
        ///         the global node and/or edge attributes of their predecessors. When overridden in any subsection, the new graph attributes
        ///         and global node/edge attributes apply to the elements the section itself contains, and also to those that belong to the
        ///         sections that follow it (if any).
        ///     </para>
        ///     <para>
        ///         Note that each subsection is dependent on the graph attributes and the global node and edge attributes specified by the
        ///         sections that precede it (including those of the root section represented by the current element). Note also that some
        ///         graph attributes cannot be overriden, and apply to the whole graph no matter in which section they are set.
        ///     </para>
        ///     <para>
        ///         As far as setting global node and/or edge attributes for a specific group of elements is concerned,
        ///         <see cref="Subgraphs" /> may be the cleaner and preferable way to achieve the effect.
        ///     </para>
        /// </summary>
        public virtual DotGraphSectionCollection<DotSubgraphSection> Subsections { get; }

        IEnumerable<DotCommonGraphSection> IDotCommonGraph.Subsections => Subsections;

        /// <summary>
        ///     Gets or sets the identifier of the subgraph (optional).
        /// </summary>
        public virtual string Id { get; set; }

        string IDotOrderable.OrderingKey => Id;

        /// <summary>
        ///     Creates a new subgraph, and populates it with the specified nodes.
        /// </summary>
        /// <param name="nodeIds">
        ///     The identifiers of nodes to populate the subgraph with.
        /// </param>
        public static DotSubgraph FromNodes(params string[] nodeIds)
        {
            return FromNodes(nodeIds, rank: null);
        }

        /// <summary>
        ///     Creates a new subgraph, and populates it with the specified nodes.
        /// </summary>
        /// <param name="id">
        ///     The identifier to assign to the subgraph.
        /// </param>
        /// <param name="rank">
        ///     The rank attribute to assign to the subgraph.
        /// </param>
        /// <param name="nodeIds">
        ///     The identifiers of nodes to populate the subgraph with.
        /// </param>
        public static DotSubgraph FromNodes(string id, DotRank? rank, params string[] nodeIds)
        {
            return FromNodes(nodeIds, rank, id);
        }

        /// <summary>
        ///     Creates a new subgraph, and populates it with the specified nodes.
        /// </summary>
        /// <param name="rank">
        ///     The rank attribute to assign to the subgraph.
        /// </param>
        /// <param name="nodeIds">
        ///     The identifiers of nodes to populate the subgraph with.
        /// </param>
        public static DotSubgraph FromNodes(DotRank? rank, params string[] nodeIds)
        {
            return FromNodes(nodeIds, rank);
        }

        /// <summary>
        ///     Creates a new subgraph, and populates it with the specified nodes.
        /// </summary>
        /// <param name="nodeIds">
        ///     The identifiers of nodes to populate the subgraph with.
        /// </param>
        /// <param name="rank">
        ///     The rank attribute to assign to the subgraph.
        /// </param>
        /// <param name="id">
        ///     The identifier to assign to the subgraph.
        /// </param>
        public static DotSubgraph FromNodes(IEnumerable<string> nodeIds, DotRank? rank = null, string id = null)
        {
            var result = new DotSubgraph(id, rank);
            result.Nodes.AddRange(nodeIds);
            return result;
        }
    }
}