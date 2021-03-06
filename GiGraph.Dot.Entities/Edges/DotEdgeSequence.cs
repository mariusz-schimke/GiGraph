﻿using System;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Entities.Attributes.Collections.Edge;
using GiGraph.Dot.Entities.Edges.Endpoints;

namespace GiGraph.Dot.Entities.Edges
{
    /// <summary>
    ///     Represents a sequence of edges that join a specified sequence of endpoints.
    /// </summary>
    public class DotEdgeSequence : DotEdgeDefinition
    {
        protected readonly DotEndpointDefinition[] _endpoints;

        protected DotEdgeSequence(DotEndpointDefinition[] endpoints, DotEdgeAttributes attributes)
            : base(attributes)
        {
            if (endpoints is null)
            {
                throw new ArgumentNullException(nameof(endpoints), "Endpoint collection must not be null.");
            }

            _endpoints = endpoints.Length > 1
                ? endpoints
                : throw new ArgumentException("At least a pair of endpoints has to be specified for an edge sequence.", nameof(endpoints));
        }

        /// <summary>
        ///     Creates a new edge sequence initialized with the specified endpoints. At least a pair of endpoints has to be provided.
        /// </summary>
        /// <param name="endpoints">
        ///     The endpoints to initialize the instance with.
        /// </param>
        public DotEdgeSequence(params DotEndpointDefinition[] endpoints)
            : this(endpoints, new DotEdgeAttributes())
        {
        }

        /// <summary>
        ///     Creates a new edge sequence initialized with the specified endpoints. At least a pair of endpoints has to be provided.
        /// </summary>
        /// <param name="endpoints">
        ///     The endpoints to initialize the instance with.
        /// </param>
        public DotEdgeSequence(IEnumerable<DotEndpointDefinition> endpoints)
            : this(endpoints?.ToArray())
        {
        }

        /// <summary>
        ///     Creates a new edge sequence initialized with the specified node identifiers. At least a pair of identifiers has to be
        ///     provided.
        /// </summary>
        /// <param name="nodeIds">
        ///     The node identifiers to initialize the instance with.
        /// </param>
        public DotEdgeSequence(params string[] nodeIds)
            : this((IEnumerable<string>) nodeIds)
        {
        }

        /// <summary>
        ///     Creates a new edge sequence initialized with the specified node identifiers. At least a pair of identifiers has to be
        ///     provided.
        /// </summary>
        /// <param name="nodeIds">
        ///     The node identifiers to initialize the instance with.
        /// </param>
        public DotEdgeSequence(IEnumerable<string> nodeIds)
            : this(nodeIds?.Select(nodeId => new DotEndpoint(nodeId)))
        {
        }

        /// <summary>
        ///     Gets the sequence of endpoints.
        /// </summary>
        public override DotEndpointDefinition[] Endpoints => _endpoints;

        protected override string GetOrderingKey()
        {
            return string.Join
            (
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
        public static DotEdgeSequence FromNodes(Action<DotEndpoint> initEndpoint, params string[] nodeIds)
        {
            return FromNodes(nodeIds, initEndpoint);
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
        public static DotEdgeSequence FromNodes(IEnumerable<string> nodeIds, Action<DotEndpoint> initEndpoint = null)
        {
            return new DotEdgeSequence
            (
                nodeIds.Select(nodeId =>
                {
                    var endpoint = new DotEndpoint(nodeId);
                    initEndpoint?.Invoke(endpoint);
                    return endpoint;
                })
            );
        }
    }
}