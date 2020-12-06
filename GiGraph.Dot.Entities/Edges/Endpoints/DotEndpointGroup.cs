using System;
using System.Collections.Generic;
using System.Linq;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    /// <summary>
    ///     Represents a collection of endpoints.
    /// </summary>
    public class DotEndpointGroup : DotEndpointDefinition
    {
        /// <summary>
        ///     Creates a new endpoint group initialized with the specified node identifiers.
        /// </summary>
        /// <param name="nodeIds">
        ///     The identifiers of nodes to use as endpoints.
        /// </param>
        public DotEndpointGroup(params string[] nodeIds)
            : this(nodeIds?.Select(nodeId => new DotEndpoint(nodeId)))
        {
        }

        /// <summary>
        ///     Creates a new endpoint group initialized with the specified node identifiers.
        /// </summary>
        /// <param name="nodeIds">
        ///     The identifiers of nodes to use as endpoints.
        /// </param>
        public DotEndpointGroup(IEnumerable<string> nodeIds)
            : this(nodeIds?.Select(nodeId => new DotEndpoint(nodeId)))
        {
        }

        /// <summary>
        ///     Creates a new endpoint group initialized with the specified endpoints.
        /// </summary>
        /// <param name="endpoints">
        ///     The endpoints to use.
        /// </param>
        public DotEndpointGroup(params DotEndpoint[] endpoints)
        {
            Endpoints = endpoints ?? throw new ArgumentNullException(nameof(endpoints), "Endpoints cannot be null.");
        }

        /// <summary>
        ///     Creates a new endpoint group initialized with the specified endpoints.
        /// </summary>
        /// <param name="endpoints">
        ///     The endpoints to use.
        /// </param>
        public DotEndpointGroup(IEnumerable<DotEndpoint> endpoints)
            : this(endpoints?.ToArray())
        {
        }

        /// <summary>
        ///     Gets the endpoints.
        /// </summary>
        public virtual DotEndpoint[] Endpoints { get; }

        protected override string GetOrderingKey()
        {
            return string.Join(" ",
                Endpoints
                   .Cast<IDotOrderable>()
                   .Select(endpoint => endpoint.OrderingKey)
                   .OrderBy(key => key));
        }
    }
}