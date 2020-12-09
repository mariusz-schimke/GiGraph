using System;
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
        ///     The identifier of the endpoint.
        /// </param>
        public DotEdge(DotEndpoint endpoint)
            : base(endpoint, endpoint)
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
            // IsLoop is checked here because the endpoints may be of different types
            // (e.g. cluster ID and node ID), in which case the edge should not be considered a loop
            return IsLoop && Equals(nodeId, nodeId);
        }

        /// <summary>
        ///     Determines whether the current edge joins the specified nodes.
        /// </summary>
        /// <param name="tailNodeId">
        ///     The identifier of the tail node to check.
        /// </param>
        /// <param name="headNodeId">
        ///     The identifier of the head node to check.
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
        ///     The identifier of the tail endpoint to check.
        /// </param>
        /// <param name="headId">
        ///     The identifier of the head endpoint to check.
        /// </param>
        public static bool Equals(DotEdgeDefinition edge, string tailId, string headId)
        {
            return edge is { } &&
                   edge.Endpoints.Length == 2 &&
                   edge.Endpoints[0] is DotEndpoint tail && tail.Id == tailId &&
                   edge.Endpoints[1] is DotEndpoint head && head.Id == headId;
        }

        /// <summary>
        ///     Determines whether the specified edge joins the specified nodes.
        /// </summary>
        /// <param name="edge">
        ///     The edge whose endpoints to check.
        /// </param>
        /// <param name="tailId">
        ///     The identifier of the tail node to check.
        /// </param>
        /// <param name="headId">
        ///     The identifier of the head node to check.
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
            if (edge is null)
            {
                return false;
            }

            for (var i = 0; i < edge.Endpoints.Length - 1; i++)
            {
                if (edge.Endpoints[i] is DotEndpoint ep1)
                {
                    var index = Array.FindIndex(
                        edge.Endpoints,
                        i + 1,
                        ep => ep is DotEndpoint ep2 && ep1.Equals(ep2)
                    );

                    if (index >= 0)
                    {
                        return true;
                    }
                }
            }

            return false;
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
            return edge is { } &&
                   edge.Tail.Equals(edge.Head);
        }
    }
}