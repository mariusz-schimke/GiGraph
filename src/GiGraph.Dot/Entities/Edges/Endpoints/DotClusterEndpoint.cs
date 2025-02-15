using GiGraph.Dot.Entities.Clusters;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Edges;

namespace GiGraph.Dot.Entities.Edges.Endpoints;

/// <summary>
///     Represents a cluster as an endpoint.
/// </summary>
public class DotClusterEndpoint : DotEndpoint
{
    /// <summary>
    ///     Creates a new instance of the class.
    /// </summary>
    /// <param name="clusterId">
    ///     The cluster identifier.
    /// </param>
    /// <param name="compassPoint">
    ///     Determines the edge placement to aim for the specified compass point on the cluster. If no compass point is specified
    ///     explicitly, the default value is <see cref="DotCompassPoint.Center" />.
    /// </param>
    public DotClusterEndpoint(string clusterId, DotCompassPoint? compassPoint = null)
        : base(clusterId, compassPoint)
    {
    }

    /// <summary>
    ///     Gets the cluster identifier.
    /// </summary>
    public override string Id => base.Id;

    /// <summary>
    ///     Gets or sets the endpoint port, that is a point on a cluster where an edge is attached to.
    /// </summary>
    public override DotEndpointPort Port
    {
        get => base.Port;
        set => base.Port = value;
    }

    protected override void SetId(string id)
    {
        // allow null (it will generate an ID of 'cluster')
        Id = id;
    }

    // the type of endpoint may be specified explicitly as a generic param, in which case this implicit conversion may be useful
    // (e.g. graph.Edges.Add<DotClusterEndpoint, DotEndpoint>("cluster 1", "node1"))
    [return: NotNullIfNotNull(nameof(clusterId))]
    public static implicit operator DotClusterEndpoint?(string? clusterId) => clusterId is not null ? new DotClusterEndpoint(clusterId) : null;

    [return: NotNullIfNotNull(nameof(cluster))]
    public static implicit operator DotClusterEndpoint?(DotCluster? cluster) => cluster is not null ? new DotClusterEndpoint(cluster.Id) : null;

    [return: NotNullIfNotNull(nameof(clusterId))]
    public static implicit operator DotClusterEndpoint?(DotClusterId? clusterId) => clusterId is not null ? new DotClusterEndpoint(clusterId) : null;
}