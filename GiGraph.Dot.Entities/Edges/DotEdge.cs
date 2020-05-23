using GiGraph.Dot.Entities.Attributes.Collections;
using System;

namespace GiGraph.Dot.Entities.Edges
{
    /// <summary>
    /// Represents a graph edge that connects two consecutive nodes.
    /// </summary>
    public class DotEdge : IDotEntity
    {
        protected string _tailNodeId;
        protected string _headNodeId;

        /// <summary>
        /// The identifier of the left (source) node the edge is connected to.
        /// </summary>
        public virtual string TailNodeId
        {
            get => _tailNodeId;
            set => _tailNodeId = value ?? throw new ArgumentNullException(nameof(TailNodeId), "Tail node identifier cannot be null.");
        }

        /// <summary>
        /// The identifier of the right (destination) node the edge is connected to.
        /// </summary>
        public virtual string HeadNodeId
        {
            get => _headNodeId;
            set => _headNodeId = value ?? throw new ArgumentNullException(nameof(HeadNodeId), "Head node identifier cannot be null.");
        }

        /// <summary>
        /// The attributes of the edge.
        /// </summary>
        public virtual IDotEdgeAttributes Attributes { get; }

        protected DotEdge(string tailNodeId, string headNodeId, IDotEdgeAttributes attributes)
        {
            TailNodeId = tailNodeId;
            HeadNodeId = headNodeId;
            Attributes = attributes;
        }

        /// <summary>
        /// Creates a new edge connecting two nodes.
        /// </summary>
        /// <param name="tailNodeId">The identifier of the tail (source, left) node the edge should be connected to.</param>
        /// <param name="headNodeId">The identifier of the head (destination, right) node the should be connected to.</param>
        public DotEdge(string tailNodeId, string headNodeId)
            : this(tailNodeId, headNodeId, new DotEntityAttributes())
        {
        }
    }
}
