using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Accessors;
using GiGraph.Dot.Entities.Edges.Attributes;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Output.Entities;
using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Entities.Edges.Collections;

/// <summary>
///     A collection of edges.
/// </summary>
public partial class DotEdgeCollection : List<DotEdgeDefinition>, IDotEntity, IDotAnnotatable
{
    public DotEdgeCollection()
        : this(new DotAttributeCollection())
    {
    }

    protected DotEdgeCollection(DotAttributeCollection attributes)
        : this(new DotEdgeRootAttributes(attributes))
    {
    }

    protected DotEdgeCollection(DotEdgeRootAttributes attributes)
    {
        Attributes = new(attributes);
    }

    /// <summary>
    ///     Provides access to the global attributes applied to edges.
    /// </summary>
    public DotEntityRootAttributesAccessor<IDotEdgeAttributes, DotEdgeRootAttributes> Attributes { get; }

    /// <inheritdoc cref="IDotAnnotatable.Annotation" />
    public virtual string? Annotation { get; set; }

    /// <summary>
    ///     Adds an edge to the collection and initializes its attributes.
    /// </summary>
    /// <typeparam name="TEdge">
    ///     The type of edge to add.
    /// </typeparam>
    /// <param name="edge">
    ///     The edge to add.
    /// </param>
    /// <param name="init">
    ///     An optional edge initializer delegate.
    /// </param>
    public virtual TEdge Add<TEdge>(TEdge edge, Action<TEdge>? init)
        where TEdge : DotEdgeDefinition
    {
        init?.Invoke(edge);
        Add(edge);
        return edge;
    }

    /// <summary>
    ///     Adds an edge that joins the two specified nodes.
    /// </summary>
    /// <param name="tailNodeId">
    ///     The tail node identifier.
    /// </param>
    /// <param name="headNodeId">
    ///     The head node identifier.
    /// </param>
    /// <param name="init">
    ///     An optional edge initializer delegate.
    /// </param>
    public virtual DotEdge Add(string tailNodeId, string headNodeId, Action<DotEdge>? init = null) => Add(new(tailNodeId, headNodeId), init);

    /// <summary>
    ///     Adds an edge that joins the two specified endpoints.
    /// </summary>
    /// <param name="tail">
    ///     The tail node identifier (note that if you want to specify a cluster as a tail, use <see cref="DotClusterEndpoint" />).
    /// </param>
    /// <param name="head">
    ///     The head node identifier (note that if you want to specify a cluster as a head, use <see cref="DotClusterEndpoint" />).
    /// </param>
    /// <param name="init">
    ///     An optional edge initializer delegate.
    /// </param>
    public virtual DotEdge Add(DotEndpoint tail, DotEndpoint head, Action<DotEdge>? init = null) => Add(new(tail, head), init);

    /// <summary>
    ///     Adds an edge that joins the specified endpoints or groups of endpoints.
    /// </summary>
    /// <param name="tail">
    ///     The tail node identifier. Use <see cref="DotEndpoint" /> for a node as a tail, <see cref="DotClusterEndpoint" /> for a
    ///     cluster as a tail, <see cref="DotEndpointGroup" /> for a group of nodes as tails, or <see cref="DotSubgraphEndpoint" /> for a
    ///     subgraph whose nodes will be used as tails.
    /// </param>
    /// <param name="head">
    ///     The head node identifier. Use <see cref="DotEndpoint" /> for a node as a head, <see cref="DotClusterEndpoint" /> for a
    ///     cluster as a head, <see cref="DotEndpointGroup" /> for a group of nodes as heads, or <see cref="DotSubgraphEndpoint" /> for a
    ///     subgraph whose nodes will be used as heads.
    /// </param>
    /// <param name="init">
    ///     An optional edge initializer delegate.
    /// </param>
    /// <typeparam name="TTail">
    ///     The type of the tail endpoint.
    /// </typeparam>
    /// <typeparam name="THead">
    ///     The type of the head endpoint.
    /// </typeparam>
    public virtual DotEdge<TTail, THead> Add<TTail, THead>(TTail tail, THead head, Action<DotEdge<TTail, THead>>? init = null)
        where THead : DotEndpointDefinition
        where TTail : DotEndpointDefinition =>
        Add(new(tail, head), init);
}