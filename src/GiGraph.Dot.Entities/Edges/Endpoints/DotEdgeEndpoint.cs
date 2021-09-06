using System;
using GiGraph.Dot.Entities.Edges.Attributes;
using GiGraph.Dot.Output;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    public abstract partial class DotEdgeEndpoint<TEndpoint>
        where TEndpoint : DotEndpointDefinition, IDotOrderable
    {
        public DotEdgeEndpoint(TEndpoint endpoint, DotEdgeEndpointRootAttributes attributes)
        {
            Endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint), "Edge endpoint must not be null.");
            Attributes = attributes;
        }

        /// <summary>
        ///     Gets the attributes of the endpoint.
        /// </summary>
        public virtual DotEdgeEndpointRootAttributes Attributes { get; }

        /// <summary>
        ///     The endpoint of the edge.
        /// </summary>
        public virtual TEndpoint Endpoint { get; }
    }
}