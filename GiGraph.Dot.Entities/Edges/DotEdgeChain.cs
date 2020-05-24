using GiGraph.Dot.Entities.Attributes.Collections;
using System;
using System.Collections.Generic;

namespace GiGraph.Dot.Entities.Edges
{
    /// <summary>
    /// Represents an chain of edges that connect multiple consecutive nodes.
    /// </summary>
    public class DotEdgeChain : DotCommonEdge
    {
        /// <summary>
        /// The attributes of the edge chain.
        /// </summary>
        public override IDotEdgeAttributes Attributes => base.Attributes;

        /// <summary>
        /// Gets the identifiers of nodes of this edge chain.
        /// </summary>
        public virtual IEnumerable<string> NodeIds { get; }

        protected DotEdgeChain(ICollection<string> nodeIds, IDotEdgeAttributes attributes)
            : base(attributes)
        {
            NodeIds = nodeIds.Count > 1
                ? nodeIds
                : throw new ArgumentException("At least a pair of node identifiers has to be specified for an edge chain.", nameof(nodeIds));
        }

        /// <summary>
        /// Creates a new edge chain initialized with the specified node identifiers.
        /// At least a pair of identifiers has to be specified.
        /// </summary>
        /// <param name="nodeIds">The node identifiers to initialize the instance with.</param>
        public DotEdgeChain(params string[] nodeIds)
            : this((IEnumerable<string>)nodeIds)
        {
        }

        /// <summary>
        /// Creates a new edge chain initialized with the specified node identifiers.
        /// At least a pair of identifiers has to be specified.
        /// </summary>
        /// <param name="nodeIds">The node identifiers to initialize the instance with.</param>
        public DotEdgeChain(IEnumerable<string> nodeIds)
            : this(new List<string>(nodeIds), new DotEntityAttributes())
        {
        }

        /// <summary>
        /// Gets the identifiers of the nodes of this edge chain.
        /// </summary>
        protected override IEnumerable<string> GetNodeIds() => NodeIds;
    }
}
