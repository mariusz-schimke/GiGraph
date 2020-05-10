using Gigraph.Dot.Entities.Attributes.Collections;

namespace Gigraph.Dot.Entities.Edges
{
    /// <summary>
    /// Represents a graph edge that connects two consecutive nodes.
    /// </summary>
    public class DotEdge : IDotEntity
    {
        /// <summary>
        /// The identifier of the left (source) node the edge is connected to.
        /// </summary>
        public string LeftNodeId { get; set; }

        /// <summary>
        /// The identifier of the right (destination) node the edge is connected to.
        /// </summary>
        public string RightNodeId { get; set; }

        /// <summary>
        /// The attributes of the edge.
        /// </summary>
        public virtual DotEdgeAttributeCollection Attributes { get; protected set; } = new DotEdgeAttributeCollection();

        /// <summary>
        /// Creates a new edge connecting two nodes.
        /// </summary>
        /// <param name="leftNodeId">The identifier of the left (source) node the edge should be connected to.</param>
        /// <param name="rightNodeId">The identifier of the right (destination) node the should be connected to.</param>
        public DotEdge(string leftNodeId, string rightNodeId)
        {
            LeftNodeId = leftNodeId;
            RightNodeId = rightNodeId;
        }
    }
}
