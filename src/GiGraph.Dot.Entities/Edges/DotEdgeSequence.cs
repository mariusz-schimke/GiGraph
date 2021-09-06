using System;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Entities.Edges.Attributes;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Output;

namespace GiGraph.Dot.Entities.Edges
{
    /// <summary>
    ///     Represents a sequence of edges that join a specified sequence of endpoints.
    /// </summary>
    public class DotEdgeSequence : DotEdgeDefinition
    {
        protected readonly DotEndpointDefinition[] _endpoints;

        protected DotEdgeSequence(DotEndpointDefinition[] endpoints, DotEdgeRootAttributes rootAttributes,
            DotEdgeTailAttributes tailAttributes, DotEdgeHeadAttributes headAttributes
        )
            : base(rootAttributes)
        {
            if (endpoints is null)
            {
                throw new ArgumentNullException(nameof(endpoints), "Endpoint collection must not be null.");
            }

            _endpoints = endpoints.Length > 1
                ? endpoints
                : throw new ArgumentException("At least a pair of endpoints has to be specified for an edge sequence.", nameof(endpoints));

            Tails = tailAttributes;
            Heads = headAttributes;
        }

        protected DotEdgeSequence(DotEndpointDefinition[] endpoints, DotEdgeRootAttributes rootAttributes)
            : this(
                endpoints,
                rootAttributes,
                new DotEdgeTailAttributes(rootAttributes.Collection),
                new DotEdgeHeadAttributes(rootAttributes.Collection)
            )
        {
        }

        /// <summary>
        ///     Creates a new edge sequence initialized with the specified endpoints. At least a pair of endpoints has to be provided.
        /// </summary>
        /// <param name="endpoints">
        ///     The endpoints to initialize the instance with.
        /// </param>
        public DotEdgeSequence(params DotEndpointDefinition[] endpoints)
            : this(endpoints, new DotEdgeRootAttributes())
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

        /// <summary>
        ///     Attributes applied to the heads of the edges in this sequence.
        /// </summary>
        public virtual DotEdgeHeadAttributes Heads { get; }

        /// <summary>
        ///     Attributes applied to the tails of the edges in this sequence.
        /// </summary>
        public virtual DotEdgeTailAttributes Tails { get; }

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