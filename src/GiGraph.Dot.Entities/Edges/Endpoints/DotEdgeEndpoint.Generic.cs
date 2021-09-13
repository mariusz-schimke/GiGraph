using System;
using GiGraph.Dot.Entities.Edges.Endpoints.Attributes;
using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    public abstract class DotEdgeEndpoint<TEndpoint> : DotEdgeEndpoint
        where TEndpoint : DotEndpointDefinition, IDotOrderable
    {
        protected DotEdgeEndpoint(TEndpoint endpoint, IDotEdgeEndpointAttributes attributes)
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