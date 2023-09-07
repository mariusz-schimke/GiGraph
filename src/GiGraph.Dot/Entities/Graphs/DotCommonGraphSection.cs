using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Clusters.Collections;
using GiGraph.Dot.Entities.Edges.Collections;
using GiGraph.Dot.Entities.Nodes.Collections;
using GiGraph.Dot.Entities.Subgraphs.Attributes;
using GiGraph.Dot.Entities.Subgraphs.Collections;
using GiGraph.Dot.Output.Entities;
using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Entities.Graphs;

public abstract class DotCommonGraphSection : IDotGraphSection, IDotAnnotatable
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

    protected DotCommonGraphSection(DotEntityAttributes attributes, DotClusterCollection clusters)
        : this(attributes, new(), new(), new(), clusters)
    {
    }

    protected DotCommonGraphSection(DotEntityAttributes attributes)
        : this(attributes, new())
    {
    }

    /// <summary>
    ///     Gets the collection of nodes.
    /// </summary>
    public DotNodeCollection Nodes { get; }

    /// <summary>
    ///     <para>
    ///         Gets the collection of edges.
    ///     </para>
    ///     <para>
    ///         Note that when an edge joins two endpoints belonging to two different subgraphs (or where one belongs to the root graph,
    ///         and the other belongs to a subgraph), then it should be added to the common upper level graph or subgraph, not to the
    ///         current graph.
    ///     </para>
    /// </summary>
    public DotEdgeCollection Edges { get; }

    /// <summary>
    ///     <para>
    ///         Gets the collection of subgraphs.
    ///     </para>
    ///     <para>
    ///         Use a subgraph when you want to have more granular control on the layout of the nodes it contains by constraining them
    ///         within a rank (see the subgraph's <see cref="IDotSubgraphAttributes.NodeRank" /> attribute). However, when you want the
    ///         nodes to be drawn together in a bounding rectangle, that has a custom color and fill, use a cluster instead (see
    ///         <see cref="Clusters" />). You can use either of these types to set a common style of nodes and edges within them.
    ///     </para>
    /// </summary>
    public DotSubgraphCollection Subgraphs { get; }

    /// <summary>
    ///     <para>
    ///         Gets the collection of clusters. A cluster is a collection of nodes and edges drawn within a bounding rectangle.
    ///     </para>
    ///     <para>
    ///         Use a cluster when you want the nodes within it to be drawn together in a bounding rectangle, that has a custom color and
    ///         fill. However, when you want to have more granular control on the layout of selected nodes, use a subgraph instead (see
    ///         <see cref="Subgraphs" />). You can use either of these types to set a common style of nodes and edges within them.
    ///     </para>
    /// </summary>
    public DotClusterCollection Clusters { get; }

    /// <inheritdoc cref="IDotAnnotatable.Annotation" />
    public virtual string Annotation { get; set; }

    IDotAttributeCollection IDotGraphSection.Attributes => _attributes.Collection;
}