using System;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Output.Qualities;

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
            if (endpoints is null)
            {
                throw new ArgumentNullException(nameof(endpoints), "Endpoint collection must not be null.");
            }

            Endpoints = endpoints.Any()
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
            : this(endpoints?.ToArray())
        {
        }

        /// <summary>
        ///     Gets the endpoints.
        /// </summary>
        public DotEndpoint[] Endpoints { get; }

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