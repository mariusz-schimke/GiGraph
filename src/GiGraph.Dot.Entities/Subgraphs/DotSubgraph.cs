using System.Collections.Generic;
using GiGraph.Dot.Entities.Clusters;
using GiGraph.Dot.Entities.Graphs.Collections;
using GiGraph.Dot.Output.Entities;
using GiGraph.Dot.Output.Qualities;
using GiGraph.Dot.Types.Ranks;

namespace GiGraph.Dot.Entities.Subgraphs;

/// <summary>
///     <para>
///         Represents a subgraph as a collection of nodes that may be constrained within one rank (see <see cref="DotRank" />). Use
///         a subgraph when you want to have more granular control on the layout or style of the nodes it contains. However, when you
///         want the nodes to be displayed together in a bounding box, use a cluster subgraph instead (<see cref="DotCluster" /> ).
///     </para>
///     <para>
///         Subgraph does not have any border or fill, as opposed to a cluster subgraph (<see cref="DotCluster" />). However, it
///         supports applying a common style to nodes and edges within it, as well as constraining the nodes within one rank.
///     </para>
///     <para>
///         Subgraph (<see cref="DotSubgraph" />) can also be used as a head or tail of an edge, in which case all nodes within them
///         are connected to the other side of the edge.
///     </para>
/// </summary>
public class DotSubgraph : DotSubgraphSection, IDotGraph, IDotOrderable
{
    /// <summary>
    ///     Creates a new subgraph.
    /// </summary>
    /// <param name="id">
    ///     The identifier to assign to the subgraph.
    /// </param>
    /// <param name="nodeRank">
    ///     The rank constraints to apply to the nodes in the subgraph.
    /// </param>
    public DotSubgraph(string id = null, DotRank? nodeRank = null)
        : this(new DotSubgraphSection(), new DotGraphSectionCollection<DotSubgraphSection>())
    {
        Id = id;

        if (nodeRank.HasValue)
        {
            NodeRank = nodeRank;
        }
    }

    /// <summary>
    ///     Creates a new subgraph.
    /// </summary>
    /// <param name="nodeRank">
    ///     The rank constraints to apply to the nodes in the subgraph.
    /// </param>
    public DotSubgraph(DotRank? nodeRank)
        : this(id: null, nodeRank)
    {
    }

    protected DotSubgraph(DotSubgraphSection rootSection, DotGraphSectionCollection<DotSubgraphSection> subsections)
        : base(rootSection)
    {
        Subsections = subsections;
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
    public DotGraphSectionCollection<DotSubgraphSection> Subsections { get; }

    IEnumerable<IDotGraphSection> IDotGraph.Subsections => Subsections;

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
        return FromNodes(nodeIds, nodeRank: null);
    }

    /// <summary>
    ///     Creates a new subgraph, and populates it with the specified nodes.
    /// </summary>
    /// <param name="id">
    ///     The identifier to assign to the subgraph.
    /// </param>
    /// <param name="nodeRank">
    ///     The rank constraints to apply to the nodes in the subgraph.
    /// </param>
    /// <param name="nodeIds">
    ///     The identifiers of nodes to populate the subgraph with.
    /// </param>
    public static DotSubgraph FromNodes(string id, DotRank? nodeRank, params string[] nodeIds)
    {
        return FromNodes(nodeIds, nodeRank, id);
    }

    /// <summary>
    ///     Creates a new subgraph, and populates it with the specified nodes.
    /// </summary>
    /// <param name="nodeRank">
    ///     The rank constraints to apply to the nodes in the subgraph.
    /// </param>
    /// <param name="nodeIds">
    ///     The identifiers of nodes to populate the subgraph with.
    /// </param>
    public static DotSubgraph FromNodes(DotRank? nodeRank, params string[] nodeIds)
    {
        return FromNodes(nodeIds, nodeRank);
    }

    /// <summary>
    ///     Creates a new subgraph, and populates it with the specified nodes.
    /// </summary>
    /// <param name="nodeIds">
    ///     The identifiers of nodes to populate the subgraph with.
    /// </param>
    /// <param name="nodeRank">
    ///     The rank constraints to apply to the nodes in the subgraph.
    /// </param>
    /// <param name="id">
    ///     The identifier to assign to the subgraph.
    /// </param>
    public static DotSubgraph FromNodes(IEnumerable<string> nodeIds, DotRank? nodeRank = null, string id = null)
    {
        var result = new DotSubgraph(id, nodeRank);
        result.Nodes.AddRange(nodeIds);
        return result;
    }
}