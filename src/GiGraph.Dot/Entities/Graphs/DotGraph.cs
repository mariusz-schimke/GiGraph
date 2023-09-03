using System.Collections.Generic;
using GiGraph.Dot.Entities.Graphs.Collections;
using GiGraph.Dot.Output.Entities;
using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Entities.Graphs;

/// <summary>
///     Represents a graph (the root DOT graph).
/// </summary>
public class DotGraph : DotGraphSection, IDotGraph, IDotOrderable
{
    protected const bool DirectedDefault = true;
    protected const bool StrictDefault = false;

    /// <summary>
    ///     Creates and initializes a graph instance.
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
    public DotGraph(string id, bool directed = DirectedDefault, bool strict = StrictDefault)
        : this(new DotGraphSection(), new DotGraphSectionCollection<DotGraphSection>())
    {
        Id = id;
        IsDirected = directed;
        IsStrict = strict;
    }

    /// <summary>
    ///     Creates and initializes a graph instance.
    /// </summary>
    /// <param name="directed">
    ///     Determines if the graph should be directed. The edges of directed graphs are presented as arrows, whereas edges in undirected
    ///     graphs are presented as lines.
    /// </param>
    /// <param name="strict">
    ///     Determines if the graph is strict. Strict graph forbids the creation of multi-edges, i.e., there may be at most one edge with
    ///     a given tail node and head node in the directed case.
    /// </param>
    public DotGraph(bool directed = DirectedDefault, bool strict = StrictDefault)
        : this(id: null, directed, strict)
    {
    }

    protected DotGraph(DotGraphSection rootSection, DotGraphSectionCollection<DotGraphSection> subsections)
        : base(rootSection)
    {
        Subsections = subsections;
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
    public DotGraphSectionCollection<DotGraphSection> Subsections { get; }

    /// <summary>
    ///     Gets or sets the identifier of the graph (optional).
    /// </summary>
    public virtual string Id { get; set; }

    IEnumerable<IDotGraphSection> IDotGraph.Subsections => Subsections;

    string IDotOrderable.OrderingKey => Id;
}