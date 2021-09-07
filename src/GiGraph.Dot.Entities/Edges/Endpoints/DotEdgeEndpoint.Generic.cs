using System;
using GiGraph.Dot.Entities.Edges.Endpoints.Attributes;
using GiGraph.Dot.Output;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    public abstract class DotEdgeEndpoint<TEndpoint> : DotEdgeEndpoint
        where TEndpoint : DotEndpointDefinition, IDotOrderable
    {
        public DotEdgeEndpoint(TEndpoint endpoint, IDotEdgeEndpointAttributes attributes)
            : base(attributes)
        {
            Endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint), "Edge endpoint must not be null.");
        }

        /// <summary>
        ///     The endpoint of the edge.
        /// </summary>
        public virtual TEndpoint Endpoint { get; }
    }
}