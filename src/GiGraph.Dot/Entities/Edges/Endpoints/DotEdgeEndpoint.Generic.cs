using System;
using GiGraph.Dot.Entities.Edges.Endpoints.Attributes;
using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Entities.Edges.Endpoints;

public class DotEdgeEndpoint<TEndpoint> : DotEdgeEndpoint
    where TEndpoint : DotEndpointDefinition, IDotOrderable
{
    public DotEdgeEndpoint(TEndpoint endpoint, DotEdgeEndpointAttributes attributes)
        : base(attributes)
    {
        Endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint), "Edge endpoint must not be null.");
    }

    /// <summary>
    ///     The endpoint of the edge.
    /// </summary>
    public TEndpoint Endpoint { get; }
}