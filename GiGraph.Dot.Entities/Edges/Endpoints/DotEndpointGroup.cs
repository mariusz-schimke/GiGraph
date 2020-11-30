using System;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Entities.Subgraphs;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    /// <summary>
    ///     Represents a collection of nodes in a subgraph as a group of endpoints. These nodes may be connected to a single node
    ///     represented by the <see cref="DotEndpoint" /> class, or to multiple nodes represented by a second instance of the same
    ///     <see cref="DotEndpointGroup" /> class. To make such connection, use <see cref="DotEdge{TTail, THead}" /> (or one of its more
    ///     specific descendants), or <see cref="DotEdgeSequence" />.
    /// </summary>
    public class DotEndpointGroup : DotEndpointDefinition
    {
        /// <summary>
        ///     Creates a new endpoint group initialized with a subgraph.
        /// </summary>
        /// <param name="subgraph">
        ///     The subgraph whose nodes to use as the endpoints of multiple edges.
        /// </param>
        public DotEndpointGroup(DotSubgraph subgraph)
        {
            Subgraph = subgraph ?? throw new ArgumentNullException(nameof(subgraph), "Subgraph is required.");
        }

        /// <summary>
        ///     Creates a new endpoint group initialized with the specified node identifiers. At least a pair of identifiers has to be
        ///     provided.
        /// </summary>
        /// <param name="nodeIds">
        ///     The identifiers of nodes to use as the endpoints of multiple edges.
        /// </param>
        public DotEndpointGroup(params string[] nodeIds)
            : this(DotSubgraph.FromNodes(nodeIds))
        {
        }

        /// <summary>
        ///     Creates a new endpoint group initialized with the specified node identifiers. At least a pair of identifiers has to be
        ///     provided.
        /// </summary>
        /// <param name="nodeIds">
        ///     The identifiers of nodes to use as the endpoints of multiple edges.
        /// </param>
        public DotEndpointGroup(IEnumerable<string> nodeIds)
            : this(DotSubgraph.FromNodes(nodeIds))
        {
        }

        public override string Annotation
        {
            get => Subgraph.Annotation;
            set => Subgraph.Annotation = value;
        }

        /// <summary>
        ///     Gets the subgraph whose nodes represent the endpoints of multiple edges.
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
    }
}