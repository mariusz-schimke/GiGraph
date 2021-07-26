using System;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Output;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    /// <summary>
    ///     Represents a collection of nodes in a subgraph as a group of endpoints.
    /// </summary>
    public class DotSubgraphEndpoint : DotEndpointDefinition
    {
        /// <summary>
        ///     Creates a new endpoint group initialized with a subgraph.
        /// </summary>
        /// <param name="subgraph">
        ///     The subgraph whose nodes to use as the endpoints of multiple edges.
        /// </param>
        public DotSubgraphEndpoint(DotSubgraph subgraph)
        {
            Subgraph = subgraph ?? throw new ArgumentNullException(nameof(subgraph), "Subgraph must not be null.");
        }

        /// <summary>
        ///     Creates a new endpoint group initialized with the specified node identifiers.
        /// </summary>
        /// <param name="nodeIds">
        ///     The identifiers of nodes to use as the endpoints of multiple edges.
        /// </param>
        public DotSubgraphEndpoint(params string[] nodeIds)
            : this(DotSubgraph.FromNodes(nodeIds))
        {
        }

        /// <summary>
        ///     Creates a new endpoint group initialized with the specified node identifiers.
        /// </summary>
        /// <param name="nodeIds">
        ///     The identifiers of nodes to use as the endpoints of multiple edges.
        /// </param>
        public DotSubgraphEndpoint(IEnumerable<string> nodeIds)
            : this(DotSubgraph.FromNodes(nodeIds))
        {
        }

        public override string Annotation
        {
            get => Subgraph.Annotation;
            set => Subgraph.Annotation = value;
        }

        /// <summary>
        ///     Gets the subgraph whose nodes are used as endpoints.
        /// </summary>
        public virtual DotSubgraph Subgraph { get; }

        protected override string GetOrderingKey()
        {
            return string.Join(" ",
                Subgraph.Nodes
                   .Cast<IDotOrderable>()
                   .Select(node => node.OrderingKey)
                   .OrderBy(key => key));
        }

        // the type of endpoint may be specified explicitly as a generic param, in which case this implicit conversion may be useful
        // (e.g. graph.Edges.Add<DotSubgraphEndpoint, DotEndpoint>(DotSubgraph.FromNodes("node1", "node2"), "node3"))
        public static implicit operator DotSubgraphEndpoint(DotSubgraph subgraph)
        {
            return subgraph is { } ? new DotSubgraphEndpoint(subgraph) : null;
        }
    }
}