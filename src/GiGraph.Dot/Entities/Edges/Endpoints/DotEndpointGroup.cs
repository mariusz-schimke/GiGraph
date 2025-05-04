using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Entities.Edges.Endpoints;

/// <summary>
///     Represents a collection of endpoints.
/// </summary>
public class DotEndpointGroup : DotEndpointDefinition
{
    /// <summary>
    ///     Creates a new endpoint group initialized with the specified endpoints.
    /// </summary>
    /// <param name="endpoints">
    ///     The endpoints to use.
    /// </param>
    public DotEndpointGroup(params DotEndpoint[] endpoints)
    {
        if (endpoints is null)
        {
            throw new ArgumentNullException(nameof(endpoints), "Endpoint collection must not be null.");
        }

        Endpoints = endpoints.Length > 0
            ? endpoints
            : throw new ArgumentException("At least one endpoint has to be specified for an endpoint group.", nameof(endpoints));
    }

    /// <summary>
    ///     Creates a new endpoint group initialized with the specified endpoints.
    /// </summary>
    /// <param name="endpoints">
    ///     The endpoints to use.
    /// </param>
    public DotEndpointGroup(IEnumerable<DotEndpoint> endpoints)
        : this(endpoints.ToArray())
    {
    }

    /// <summary>
    ///     Creates a new endpoint group initialized with the specified node identifiers.
    /// </summary>
    /// <param name="nodeIds">
    ///     The identifiers of nodes to use as endpoints.
    /// </param>
    public DotEndpointGroup(params IEnumerable<string> nodeIds)
        : this(nodeIds.Select(nodeId => new DotEndpoint(nodeId)))
    {
    }

    /// <summary>
    ///     Gets the endpoints.
    /// </summary>
    public DotEndpoint[] Endpoints { get; }

    protected override string GetOrderingKey()
    {
        return string.Join(
            " ",
            Endpoints
                .Cast<IDotOrderable>()
                .Select(endpoint => endpoint.OrderingKey)
                .OrderBy(key => key, StringComparer.InvariantCulture)
        );
    }

    /// <summary>
    ///     Creates a new endpoint group initialized with the specified node identifiers. At least one identifier has to be provided.
    /// </summary>
    /// <param name="nodeIds">
    ///     The node identifiers to initialize the instance with.
    /// </param>
    /// <param name="initEndpoint">
    ///     An optional endpoint initializer to call for each created endpoint.
    /// </param>
    public static DotEndpointGroup FromNodes(IEnumerable<string> nodeIds, Action<DotEndpoint>? initEndpoint = null)
    {
        return new DotEndpointGroup(
            nodeIds.Select(nodeId =>
                {
                    var endpoint = new DotEndpoint(nodeId);
                    initEndpoint?.Invoke(endpoint);
                    return endpoint;
                }
            )
        );
    }
}