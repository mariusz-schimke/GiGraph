using System.Collections.Generic;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Graphs.Collections;
using GiGraph.Dot.Output;

namespace GiGraph.Dot.Entities.Clusters
{
    /// <summary>
    ///     Represents a cluster subgraph. A cluster subgraph is a special type of subgraph whose appearance can be customized. If
    ///     supported, the layout engine used to render it, will do the layout so that the nodes belonging to the cluster are drawn
    ///     together, with the entire drawing of the cluster contained within a bounding rectangle. Note that cluster subgraphs are not
    ///     part of the DOT language, but solely a syntactic convention adhered to by certain of the layout engines.
    /// </summary>
    public class DotCluster : DotClusterSection, IDotCommonGraph, IDotOrderable
    {
        protected DotCluster(string id, DotClusterSection rootSection, DotGraphSectionCollection<DotClusterSection> subsections)
            : base(rootSection)
        {
            Id = id;
            Subsections = subsections;
        }

        /// <summary>
        ///     Creates a new cluster subgraph.
        /// </summary>
        /// <param name="id">
        ///     The unique identifier of the cluster.
        /// </param>
        public DotCluster(string id)
            : this(id, new DotClusterSection(), new DotGraphSectionCollection<DotClusterSection>())
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
        public virtual DotGraphSectionCollection<DotClusterSection> Subsections { get; }

        IEnumerable<DotCommonGraphSection> IDotCommonGraph.Subsections => Subsections;

        /// <summary>
        ///     Gets or sets the identifier of the cluster (optional).
        /// </summary>
        public virtual string Id { get; set; }

        string IDotOrderable.OrderingKey => Id;

        /// <summary>
        ///     Creates a new cluster with the specified nodes.
        /// </summary>
        /// <param name="id">
        ///     The unique identifier of the cluster.
        /// </param>
        /// <param name="nodeIds">
        ///     The identifiers of nodes to add to the subgraph.
        /// </param>
        public static DotCluster FromNodes(string id, params string[] nodeIds)
        {
            return FromNodes(id, (IEnumerable<string>) nodeIds);
        }

        /// <summary>
        ///     Creates a new cluster with the specified nodes.
        /// </summary>
        /// <param name="id">
        ///     The unique identifier of the cluster.
        /// </param>
        /// <param name="nodeIds">
        ///     The identifiers of nodes to add to the subgraph.
        /// </param>
        public static DotCluster FromNodes(string id, IEnumerable<string> nodeIds)
        {
            var result = new DotCluster(id);
            result.Nodes.AddRange(nodeIds);
            return result;
        }
    }
}