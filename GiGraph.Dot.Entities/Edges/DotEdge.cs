using GiGraph.Dot.Entities.Attributes.Collections.Edge;
using GiGraph.Dot.Entities.Edges.Endpoints;

namespace GiGraph.Dot.Entities.Edges
{
    /// <summary>
    ///     Represents an edge (joins two nodes).
    /// </summary>
    public class DotEdge : DotEdge<DotEndpoint, DotEndpoint>
    {
        protected DotEdge(DotEndpoint tail, DotEndpoint head, DotEdgeAttributes attributes)
            : base(tail, head, attributes)
        {
        }

        /// <summary>
        ///     Creates a new edge instance.
        /// </summary>
        /// <param name="tail">
        ///     The tail (source, left) node.
        /// </param>
        /// <param name="head">
        ///     The head (destination, right) node.
        /// </param>
        public DotEdge(DotEndpoint tail, DotEndpoint head)
            : base(tail, head)
        {
        }

        /// <summary>
        ///     Creates a new edge instance.
        /// </summary>
        /// <param name="tailNodeId">
        ///     The identifier of the tail (source, left) node.
        /// </param>
        /// <param name="headNodeId">
        ///     The identifier of the head (destination, right) node.
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
        ///     Indicates if the current instance is a loop edge.
        /// </summary>
        public virtual bool IsLoop => IsLoopEdge(this);

        /// <summary>
        ///     Determines whether the current edge joins the specified node to itself.
        /// </summary>
        /// <param name="nodeId">
        ///     The identifier of the node to check.
        /// </param>
        public virtual bool Loops(string nodeId)
        {
            return Equals(nodeId, nodeId);
        }

        /// <summary>
        ///     Determines whether the current edge joins the specified nodes.
        /// </summary>
        /// <param name="tailNodeId">
        ///     The identifier of the tail (source, left) node to check.
        /// </param>
        /// <param name="headNodeId">
        ///     The identifier of the head (destination, right) node to check.
        /// </param>
        public virtual bool Equals(string tailNodeId, string headNodeId)
        {
            return Equals(this, tailNodeId, headNodeId);
        }

        /// <summary>
        ///     Determines whether the specified edge joins the specified nodes.
        /// </summary>
        /// <param name="edge">
        ///     The edge whose endpoints to check.
        /// </param>
        /// <param name="tailId">
        ///     The identifier of the tail (source, left) endpoint to check.
        /// </param>
        /// <param name="headId">
        ///     The identifier of the head (destination, right) endpoint to check.
        /// </param>
        public static bool Equals(DotEdgeDefinition edge, string tailId, string headId)
        {
            return edge is DotEdge<DotEndpoint, DotEndpoint> e &&
                   Equals(e, tailId, headId);
        }

        /// <summary>
        ///     Determines whether the specified edge joins the specified nodes.
        /// </summary>
        /// <param name="edge">
        ///     The edge whose endpoints to check.
        /// </param>
        /// <param name="tailId">
        ///     The identifier of the tail (source, left) node to check.
        /// </param>
        /// <param name="headId">
        ///     The identifier of the head (destination, right) node to check.
        /// </param>
        public static bool Equals<TTail, THead>(DotEdge<TTail, THead> edge, string tailId, string headId)
            where TTail : DotEndpoint
            where THead : DotEndpoint
        {
            return edge is { } &&
                   edge.Tail.Id == tailId &&
                   edge.Head.Id == headId;
        }

        /// <summary>
        ///     Determines whether the specified edge is a loop edge.
        /// </summary>
        /// <param name="edge">
        ///     The edge to check.
        /// </param>
        public static bool IsLoopEdge(DotEdgeDefinition edge)
        {
            return edge is DotEdge<DotEndpoint, DotEndpoint> e &&
                   IsLoopEdge(e);
        }

        /// <summary>
        ///     Determines whether the specified edge is a loop edge.
        /// </summary>
        /// <param name="edge">
        ///     The edge to check.
        /// </param>
        public static bool IsLoopEdge<TTail, THead>(DotEdge<TTail, THead> edge)
            where TTail : DotEndpoint
            where THead : DotEndpoint
        {
            return edge.Tail.Id == edge.Head.Id;
        }
    }
}