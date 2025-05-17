using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Edges.Attributes;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Entities.Edges;

/// <summary>
///     Represents a sequence of edges that join a specified sequence of endpoints.
/// </summary>
public class DotEdgeSequence : DotEdgeDefinition
{
    /// <summary>
    ///     Creates a new edge sequence initialized with the specified endpoints. At least a pair of endpoints has to be provided.
    /// </summary>
    /// <param name="endpoints">
    ///     The endpoints to initialize the instance with.
    /// </param>
    public DotEdgeSequence(params DotEndpointDefinition[] endpoints)
        : this(endpoints, new DotAttributeCollection())
    {
    }

    /// <summary>
    ///     Creates a new edge sequence initialized with the specified endpoints. At least a pair of endpoints has to be provided.
    /// </summary>
    /// <param name="endpoints">
    ///     The endpoints to initialize the instance with.
    /// </param>
    public DotEdgeSequence(IEnumerable<DotEndpointDefinition> endpoints)
        : this(endpoints.ToArray())
    {
    }

    /// <summary>
    ///     Creates a new edge sequence initialized with the specified node identifiers. At least a pair of identifiers has to be
    ///     provided.
    /// </summary>
    /// <param name="nodeIds">
    ///     The node identifiers to initialize the instance with.
    /// </param>
    public DotEdgeSequence(params IEnumerable<string> nodeIds)
        : this(nodeIds.Select(nodeId => new DotEndpoint(nodeId)))
    {
    }

    protected DotEdgeSequence(DotEndpointDefinition[] endpoints, DotAttributeCollection attributes)
        : this(endpoints, new DotEdgeRootAttributes(attributes))
    {
    }

    protected DotEdgeSequence(DotEndpointDefinition[] endpoints, DotEdgeRootAttributes attributes)
        : base(endpoints, attributes)
    {
        Tails = new DotEdgeEndpoint(attributes.Tail);
        Heads = new DotEdgeEndpoint(attributes.Head);
    }

    /// <summary>
    ///     Attributes applied to the heads of the edges in this sequence.
    /// </summary>
    public DotEdgeEndpoint Heads { get; }

    /// <summary>
    ///     Attributes applied to the tails of the edges in this sequence.
    /// </summary>
    public DotEdgeEndpoint Tails { get; }

    protected override string GetOrderingKey()
    {
        return string.Join(
            " ",
            Endpoints.Cast<IDotOrderable>()
                .Select(endpoint => endpoint.OrderingKey)
        );
    }

    /// <summary>
    ///     Creates a new edge sequence initialized with the specified node identifiers. At least a pair of identifiers has to be
    ///     provided.
    /// </summary>
    /// <param name="nodeIds">
    ///     The node identifiers to initialize the instance with.
    /// </param>
    /// <param name="initEndpoint">
    ///     An optional endpoint initializer to call for each created endpoint.
    /// </param>
    public static DotEdgeSequence FromNodes(IEnumerable<string> nodeIds, Action<DotEndpoint>? initEndpoint = null)
    {
        return new DotEdgeSequence(
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