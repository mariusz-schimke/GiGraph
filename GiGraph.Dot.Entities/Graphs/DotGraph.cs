using System.Collections.Generic;
using GiGraph.Dot.Entities.Graphs.Collections;

namespace GiGraph.Dot.Entities.Graphs
{
    /// <summary>
    ///     Represents a graph (the root DOT graph).
    /// </summary>
    public class DotGraph : DotGraphSection, IDotCommonGraph, IDotOrderable
    {
        protected DotGraph(string id, bool directed, bool strict, DotGraphSection rootSection, DotGraphSectionCollection<DotGraphSection> subsections)
            : base(rootSection)
        {
            Id = id;
            IsDirected = directed;
            IsStrict = strict;
            Subsections = subsections;
        }

        /// <summary>
        ///     Creates a new graph instance.
        /// </summary>
        /// <param name="id">
        ///     The identifier of the graph. Pass null if no identifier should be used.
        /// </param>
        /// <param name="directed">
        ///     Determines if the graph should be directed. The edges of directed graphs are presented as arrows, whereas edges in undirected
        ///     graphs are presented as lines.
        /// </param>
        /// <param name="strict">
        ///     Determines if the graph is strict. Strict graph forbids the creation of multi-edges, i.e., there may be at most one edge with
        ///     a given tail node and head node in the directed case.
        /// </param>
        public DotGraph(string id = null, bool directed = true, bool strict = false)
            : this(id, directed, strict, new DotGraphSection(), new DotGraphSectionCollection<DotGraphSection>())
        {
        }

        /// <summary>
        ///     Gets or sets a value that indicates if the graph is directed. The edges of directed graphs are presented as arrows, whereas
        ///     edges in undirected graphs are presented as lines.
        /// </summary>
        public virtual bool IsDirected { get; set; }

        /// <summary>
        ///     Gets or sets a value that indicates if the graph is strict. Strict graph forbids the creation of multi-edges, i.e., there may
        ///     be at most one edge with a given tail node and head node in the directed case.
        /// </summary>
        public virtual bool IsStrict { get; set; }

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
        public virtual DotGraphSectionCollection<DotGraphSection> Subsections { get; }

        /// <summary>
        ///     Gets or sets the identifier of the graph (optional).
        /// </summary>
        public virtual string Id { get; set; }

        IEnumerable<DotCommonGraphSection> IDotCommonGraph.Subsections => Subsections;

        string IDotOrderable.OrderingKey => Id;
    }
}