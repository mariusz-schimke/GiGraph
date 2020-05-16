using GiGraph.Dot.Entities.Attributes.Collections;
using System;

namespace GiGraph.Dot.Entities.Edges
{
    /// <summary>
    /// Represents a graph edge that connects two consecutive nodes.
    /// </summary>
    public class DotEdge : IDotEntity
    {
        protected string _leftNodeId;
        protected string _rightNodeId;

        /// <summary>
        /// The identifier of the left (source) node the edge is connected to.
        /// </summary>
        public virtual string LeftNodeId
        {
            get => _leftNodeId;
            set => _leftNodeId = value ?? throw new ArgumentNullException(nameof(LeftNodeId), "Node identifier cannot be null.");
        }

        /// <summary>
        /// The identifier of the right (destination) node the edge is connected to.
        /// </summary>
        public virtual string RightNodeId
        {
            get => _rightNodeId;
            set => _rightNodeId = value ?? throw new ArgumentNullException(nameof(RightNodeId), "Node identifier cannot be null.");
        }

        /// <summary>
        /// The attributes of the edge.
        /// </summary>
        public virtual DotEdgeAttributeCollection Attributes { get; }

        protected DotEdge(string leftNodeId, string rightNodeId, DotEdgeAttributeCollection attributes)
        {
            LeftNodeId = leftNodeId;
            RightNodeId = rightNodeId;
            Attributes = attributes;
        }

        /// <summary>
        /// Creates a new edge connecting two nodes.
        /// </summary>
        /// <param name="leftNodeId">The identifier of the left (source) node the edge should be connected to.</param>
        /// <param name="rightNodeId">The identifier of the right (destination) node the should be connected to.</param>
        public DotEdge(string leftNodeId, string rightNodeId)
            : this(leftNodeId, rightNodeId, new DotEdgeAttributeCollection())
        {
        }
    }
}
