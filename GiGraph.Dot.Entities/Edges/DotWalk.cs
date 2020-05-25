using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Edges.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GiGraph.Dot.Entities.Edges
{
    /// <summary>
    /// Represents a walk (also called a chain), that is a sequence of nodes and edges in graph theory.
    /// </summary>
    public class DotWalk : DotCommonEdge
    {
        /// <summary>
        /// Gets the endpoints of this walk.
        /// </summary>
        public override IEnumerable<DotEndpoint> Endpoints { get; }

        protected DotWalk(ICollection<DotEndpoint> endpoints, IDotEdgeAttributes attributes)
            : base(attributes)
        {
            Endpoints = endpoints.Count > 1
                ? endpoints
                : throw new ArgumentException("At least a pair of endpoints has to be specified for a walk.", nameof(endpoints));
        }

        /// <summary>
        /// Creates a new walk initialized with the specified endpoints.
        /// At least a pair of endpoints has to be specified.
        /// </summary>
        /// <param name="endpoints">The endpoints to initialize the instance with.</param>
        public DotWalk(params DotEndpoint[] endpoints)
            : this((IEnumerable<DotEndpoint>)endpoints)
        {
        }

        /// <summary>
        /// Creates a new walk initialized with the specified endpoints.
        /// At least a pair of endpoints has to be specified.
        /// </summary>
        /// <param name="endpoints">The endpoints to initialize the instance with.</param>
        public DotWalk(IEnumerable<DotEndpoint> endpoints)
            : this(new List<DotEndpoint>(endpoints), new DotEntityAttributes())
        {
        }

        /// <summary>
        /// Creates a new walk initialized with the specified node identifiers.
        /// At least a pair of identifiers has to be specified.
        /// </summary>
        /// <param name="nodeIds">The node identifiers to initialize the instance with.</param>
        public static DotWalk FromNodes(params string[] nodeIds)
        {
            return FromNodes((IEnumerable<string>)nodeIds);
        }

        /// <summary>
        /// Creates a new walk initialized with the specified node identifiers.
        /// At least a pair of identifiers has to be specified.
        /// </summary>
        /// <param name="nodeIds">The node identifiers to initialize the instance with.</param>
        public static DotWalk FromNodes(IEnumerable<string> nodeIds)
        {
            return new DotWalk
            (
                nodeIds.Select(nodeId => new DotNodeEndpoint(nodeId))
            );
        }
    }
}
