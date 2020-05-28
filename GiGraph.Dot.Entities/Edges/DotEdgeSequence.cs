﻿using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Edges.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GiGraph.Dot.Entities.Edges
{
    /// <summary>
    /// Represents a sequence of edges that join a specified sequence of endpoints.
    /// </summary>
    public class DotEdgeSequence : DotCommonEdge
    {
        /// <summary>
        /// Gets the sequence of endpoints.
        /// </summary>
        public override IEnumerable<DotCommonEndpoint> Endpoints { get; }

        protected DotEdgeSequence(ICollection<DotCommonEndpoint> endpoints, IDotEdgeAttributes attributes)
            : base(attributes)
        {
            Endpoints = endpoints.Count > 1
                ? endpoints
                : throw new ArgumentException("At least a pair of endpoints has to be specified for an edge sequence.", nameof(endpoints));
        }

        /// <summary>
        /// Creates a new edge sequence initialized with the specified endpoints.
        /// At least a pair of endpoints has to be provided.
        /// </summary>
        /// <param name="endpoints">The endpoints to initialize the instance with.</param>
        public DotEdgeSequence(params DotCommonEndpoint[] endpoints)
            : this((IEnumerable<DotCommonEndpoint>)endpoints)
        {
        }

        /// <summary>
        /// Creates a new edge sequence initialized with the specified endpoints.
        /// At least a pair of endpoints has to be provided.
        /// </summary>
        /// <param name="endpoints">The endpoints to initialize the instance with.</param>
        public DotEdgeSequence(IEnumerable<DotCommonEndpoint> endpoints)
            : this(endpoints.ToArray(), new DotEntityAttributes())
        {
        }

        /// <summary>
        /// Creates a new edge sequence initialized with the specified endpoints.
        /// At least a pair of endpoints has to be provided.
        /// </summary>
        /// <param name="nodeIds">The node identifiers to initialize the instance with.</param>
        public static DotEdgeSequence FromNodes(params string[] nodeIds)
        {
            return FromNodes(nodeIds, initEndpoint: null);
        }

        /// <summary>
        /// Creates a new edge sequence initialized with the specified endpoints.
        /// At least a pair of endpoints has to be provided.
        /// </summary>
        /// <param name="nodeIds">The node identifiers to initialize the instance with.</param>
        /// <param name="initEndpoint">An optional endpoint initializer.</param>
        public static DotEdgeSequence FromNodes(Action<DotEndpoint> initEndpoint, params string[] nodeIds)
        {
            return FromNodes(nodeIds, initEndpoint);
        }

        /// <summary>
        /// Creates a new edge sequence initialized with the specified endpoints.
        /// At least a pair of endpoints has to be provided.
        /// </summary>
        /// <param name="nodeIds">The node identifiers to initialize the instance with.</param>
        /// <param name="initEndpoint">An optional endpoint initializer.</param>
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