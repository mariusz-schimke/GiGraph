using System;
using GiGraph.Dot.Entities.Edges.Attributes;
using GiGraph.Dot.Entities.Edges.Endpoints.Attributes;
using GiGraph.Dot.Output;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    public abstract partial class DotEdgeEndpoint<TEndpoint>
        where TEndpoint : DotEndpointDefinition, IDotOrderable
    {
        protected readonly IDotEdgeEndpointAttributes _attributes;

        public DotEdgeEndpoint(TEndpoint endpoint, IDotEdgeEndpointAttributes attributes)
        {
            Endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint), "Edge endpoint must not be null.");
            _attributes = attributes;
        }

        /// <summary>
        ///     The endpoint of the edge.
        /// </summary>
        public virtual TEndpoint Endpoint { get; }
    }
}