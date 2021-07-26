using GiGraph.Dot.Entities.Attributes.Collections.Edge;
using GiGraph.Dot.Entities.Edges.Endpoints;

namespace GiGraph.Dot.Entities.Edges
{
    /// <summary>
    ///     Represents an edge (joins two endpoints).
    /// </summary>
    public class DotEdge : DotEdge<DotEndpoint, DotEndpoint>
    {
        protected DotEdge(DotEndpoint tail, DotEndpoint head, DotEdgeAttributes attributes)
            : base(tail, head, attributes)
        {
        }

        /// <summary>
        ///     Creates a new edge.
        /// </summary>
        /// <param name="tail">
        ///     The tail endpoint.
        /// </param>
        /// <param name="head">
        ///     The head endpoint.
        /// </param>
        public DotEdge(DotEndpoint tail, DotEndpoint head)
            : base(tail, head)
        {
        }

        /// <summary>
        ///     Creates a new edge.
        /// </summary>
        /// <param name="tailNodeId">
        ///     The identifier of the tail node.
        /// </param>
        /// <param name="headNodeId">
        ///     The identifier of the head node.
        /// </param>
        public DotEdge(string tailNodeId, string headNodeId)
            : this(new DotEndpoint(tailNodeId), new DotEndpoint(headNodeId))
        {
        }

        /// <summary>
        ///     Creates a new loop edge.
        /// </summary>
        /// <param name="nodeId">
        ///     The identifier of the node.
        /// </param>
        public DotEdge(string nodeId)
            : this(nodeId, nodeId)
        {
        }

        /// <summary>
        ///     Creates a new loop edge.
        /// </summary>
        /// <param name="endpoint">
        ///     The endpoint (note that if you want to specify a cluster as an endpoint, use <see cref="DotClusterEndpoint" />).
        /// </param>
        public DotEdge(DotEndpoint endpoint)
            : base(endpoint, endpoint)
        {
        }

        /// <summary>
        ///     Indicates if the edge is a loop.
        /// </summary>
        public virtual bool IsLoop => Tail.IsSameEndpoint(Head);

        /// <summary>
        ///     Determines whether the edge joins the specified endpoint to itself.
        /// </summary>
        /// <param name="endpointId">
        ///     The identifier of the endpoint to check.
        /// </param>
        public virtual bool Loops(string endpointId)
        {
            // IsLoop is checked here to make sure that both the endpoints are of the same type
            // (they may represent a node ID or a cluster ID)
            return Equals(endpointId, endpointId) && IsLoop;
        }

        /// <summary>
        ///     Determines whether the edge joins the specified endpoint to itself.
        /// </summary>
        /// <param name="endpoint">
        ///     The endpoint to check (note that if you want to check a cluster as an endpoint, use <see cref="DotClusterEndpoint" />).
        /// </param>
        public virtual bool Loops(DotEndpoint endpoint)
        {
            return Tail.IsSameEndpoint(endpoint) &&
                Head.IsSameEndpoint(endpoint);
        }

        /// <summary>
        ///     Determines whether the edge joins the specified endpoints.
        /// </summary>
        /// <param name="tailId">
        ///     The identifier of the tail endpoint to check.
        /// </param>
        /// <param name="headId">
        ///     The identifier of the head endpoint to check.
        /// </param>
        public virtual bool Equals(string tailId, string headId)
        {
            return Tail.Id == tailId &&
                Head.Id == headId;
        }

        /// <summary>
        ///     Determines whether the edge joins the specified endpoints.
        /// </summary>
        /// <param name="tail">
        ///     The identifier of the tail endpoint to check.
        /// </param>
        /// <param name="head">
        ///     The identifier of the head endpoint to check.
        /// </param>
        public virtual bool Equals(DotEndpoint tail, DotEndpoint head)
        {
            return Tail.IsSameEndpoint(tail) &&
                Head.IsSameEndpoint(head);
        }
    }
}