using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Edges.Endpoints;

namespace GiGraph.Dot.Entities.Edges
{
    /// <summary>
    /// Represents an edge that joins two nodes.
    /// </summary>
    public class DotOneToOneEdge : DotEdge<DotNodeEndpoint, DotNodeEndpoint>
    {
        protected DotOneToOneEdge(DotNodeEndpoint tail, DotNodeEndpoint head, IDotEdgeAttributes attributes)
            : base(tail, head, attributes)
        {
        }

        /// <summary>
        /// Creates a new edge instance.
        /// </summary>
        /// <param name="tail">The tail (source, left) node.</param>
        /// <param name="head">The head (destination, right) node.</param>
        public DotOneToOneEdge(DotNodeEndpoint tail, DotNodeEndpoint head)
            : base(tail, head)
        {
        }

        /// <summary>
        /// Creates a new edge instance.
        /// </summary>
        /// <param name="tailNodeId">The identifier of the tail (source, left) node.</param>
        /// <param name="headNodeId">The identifier of the head (destination, right) node.</param>
        public DotOneToOneEdge(string tailNodeId, string headNodeId)
            : this(new DotNodeEndpoint(tailNodeId), new DotNodeEndpoint(headNodeId))
        {
        }
    }
}
