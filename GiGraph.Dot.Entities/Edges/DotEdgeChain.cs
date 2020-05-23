using GiGraph.Dot.Entities.Attributes.Collections;
using System;
using System.Collections.Generic;

namespace GiGraph.Dot.Entities.Edges
{
    public class DotEdgeChain : DotCommonEdge
    {
        protected readonly ICollection<string> _nodeIds;

        /// <summary>
        /// Gets the identifiers of nodes of this edge chain.
        /// </summary>
        public override IEnumerable<string> NodeIds => _nodeIds;

        protected DotEdgeChain(IDotEdgeAttributes attributes, ICollection<string> nodeIds)
            : base(attributes)
        {
            _nodeIds = nodeIds.Count > 1
                ? nodeIds
                : throw new ArgumentException("At least a pair of node identifiers has to be specified for an edge chain.");
        }

        /// <summary>
        /// Creates a new edge chain initialized with the specified node identifiers.
        /// Any number of identifiers is accepted, except one.
        /// </summary>
        /// <param name="nodeIds">The node identifiers to initialize the instance with.</param>
        public DotEdgeChain(params string[] nodeIds)
            : this((IEnumerable<string>)nodeIds)
        {
        }

        /// <summary>
        /// Creates a new edge chain initialized with the specified node identifiers.
        /// Any number of identifiers is accepted, except one.
        /// </summary>
        /// <param name="nodeIds">The node identifiers to initialize the instance with.</param>
        public DotEdgeChain(IEnumerable<string> nodeIds)
            : this(new DotEntityAttributes(), new List<string>(nodeIds))
        {
        }
    }
}
