using System.Diagnostics.CodeAnalysis;
using GiGraph.Dot.Entities.Clusters;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.Identifiers;
using GiGraph.Dot.Types.Nodes;

namespace GiGraph.Dot.Entities.Edges.Endpoints;

/// <summary>
///     Represents a node as an endpoint.
/// </summary>
public class DotEndpoint : DotEndpointDefinition
{
    /// <summary>
    ///     Creates a new instance of the class.
    /// </summary>
    /// <param name="id">
    ///     The node identifier.
    /// </param>
    /// <param name="portName">
    ///     Determines the edge placement to aim for the specified port. If specified, the corresponding node, referred to by the
    ///     <paramref name="id"/> parameter, must either have a record shape (<see cref="DotNodeShape.Record"/>,
    ///     <see cref="DotNodeShape.RoundedRecord"/>) with one of its fields having the given port name, or have an HTML-like label, one
    ///     of whose components has a PORT attribute set to the specified port name.
    /// </param>
    /// <param name="compassPoint">
    ///     Determines the edge placement to aim for the specified compass point on the <paramref name="portName"/> if specified, or on
    ///     the node itself otherwise. If no compass point is specified explicitly, the default value is
    ///     <see cref="DotCompassPoint.Center"/>.
    /// </param>
    public DotEndpoint(string id, string? portName, DotCompassPoint? compassPoint = null)
        : this(id, new DotEndpointPort(portName, compassPoint))
    {
    }

    /// <summary>
    ///     Creates a new instance of the class.
    /// </summary>
    /// <param name="id">
    ///     The node identifier.
    /// </param>
    /// <param name="compassPoint">
    ///     Determines the edge placement to aim for the specified compass point on the node. If no compass point is specified
    ///     explicitly, the default value is <see cref="DotCompassPoint.Center"/>.
    /// </param>
    public DotEndpoint(string id, DotCompassPoint? compassPoint = null)
        : this(id, new DotEndpointPort(compassPoint))
    {
    }

    /// <summary>
    ///     Creates a new instance of the class.
    /// </summary>
    /// <param name="id">
    ///     The node identifier.
    /// </param>
    /// <param name="port">
    ///     The endpoint port, that is a point on a node an edge will be attached to.
    /// </param>
    public DotEndpoint(string id, DotEndpointPort port)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id), "Endpoint identifier must not be null.");
        Port = port ?? throw new ArgumentNullException(nameof(port), "Endpoint port must not be null.");
    }

    /// <summary>
    ///     Gets the node identifier.
    /// </summary>
    public virtual string Id { get; }

    /// <summary>
    ///     Gets or sets the endpoint port, that is a point on a node where an edge is attached to.
    /// </summary>
    public virtual DotEndpointPort Port { get; set; }

    protected override string GetOrderingKey() => $"{Id}:{Port.Name}:{Port.CompassPoint}";

    /// <summary>
    ///     Determines the equality of endpoint identifiers (ignores port). Ensures that the endpoints are of the same type.
    /// </summary>
    /// <param name="endpoint">
    ///     The endpoint to check.
    /// </param>
    public virtual bool IsSameEndpoint(DotEndpoint? endpoint) =>
        endpoint is not null &&
        endpoint.Id == Id &&
        endpoint.GetType() == GetType();

    // the type of endpoint may be specified explicitly as a generic param, in which case this implicit conversion may be useful
    // (e.g. graph.Edges.Add<DotClusterEndpoint, DotEndpoint>("cluster 1", "node1"))
    [return: NotNullIfNotNull(nameof(id))]
    public static implicit operator DotEndpoint?(string? id) => id is not null ? new DotEndpoint(id) : null;

    [return: NotNullIfNotNull(nameof(node))]
    public static implicit operator DotEndpoint?(DotNode? node) => node is not null ? new DotEndpoint(node.Id) : null;

    // this way a cluster may be used directly for DotEndpoint parameters as well
    [return: NotNullIfNotNull(nameof(cluster))]
    public static implicit operator DotEndpoint?(DotCluster? cluster) => (DotClusterEndpoint?) cluster;

    [return: NotNullIfNotNull(nameof(id))]
    public static implicit operator DotEndpoint?(DotId? id) => id is not null ? new DotEndpoint(id) : null;

    [return: NotNullIfNotNull(nameof(clusterId))]
    public static implicit operator DotEndpoint?(DotClusterId? clusterId) => (DotClusterEndpoint?) clusterId;
}