using System;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Edges.Attributes;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Entities.Edges.Endpoints.Attributes;
using GiGraph.Dot.Output;

namespace GiGraph.Dot.Entities.Edges
{
    /// <summary>
    ///     Represents a sequence of edges that join a specified sequence of endpoints.
    /// </summary>
    public class DotEdgeSequence : DotEdgeDefinition
    {
        /// <summary>
        ///     Creates a new edge sequence initialized with the specified endpoints. At least a pair of endpoints has to be provided.
        /// </summary>
        /// <param name="endpoints">
        ///     The endpoints to initialize the instance with.
        /// </param>
        public DotEdgeSequence(params DotEndpointDefinition[] endpoints)
            : this(endpoints, new DotAttributeCollection())
        {
        }

        private DotEdgeSequence(DotEndpointDefinition[] endpoints, DotAttributeCollection attributes)
            : base(endpoints, new DotEdgeRootAttributes(attributes))
        {
            Tails = new DotEdgeTail(new DotEdgeTailRootAttributes(attributes));
            Heads = new DotEdgeHead(new DotEdgeHeadRootAttributes(attributes));
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
        ///     Attributes applied to the heads of the edges in this sequence.
        /// </summary>
        public virtual DotEdgeHead Heads { get; }

        /// <summary>
        ///     Attributes applied to the tails of the edges in this sequence.
        /// </summary>
        public virtual DotEdgeTail Tails { get; }

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