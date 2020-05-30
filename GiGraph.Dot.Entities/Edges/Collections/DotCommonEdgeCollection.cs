using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Edges.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GiGraph.Dot.Entities.Edges.Collections
{
    /// <summary>
    /// A collection of edges.
    /// </summary>
    public partial class DotCommonEdgeCollection : List<DotCommonEdge>, IDotEntity
    {
        protected virtual T Add<T>(T edge, Action<IDotEdgeAttributes> initEdge)
            where T : DotCommonEdge
        {
            Add(edge);
            initEdge?.Invoke(edge.Attributes);
            return edge;
        }

        /// <summary>
        /// Adds an edge that joins two nodes with the specified identifiers.
        /// </summary>
        /// <param name="tailNodeId">The tail (source, left) node identifier.</param>
        /// <param name="headNodeId">The head (destination, right) node identifier.</param>
        /// <param name="initEdge">An optional edge initializer delegate.</param>
        public virtual DotEdge Add(string tailNodeId, string headNodeId, Action<IDotEdgeAttributes> initEdge = null)
        {
            return Add(new DotEdge(tailNodeId, headNodeId), initEdge);
        }

        /// <summary>
        /// Adds a loop edge that connects the specified node to itself.
        /// </summary>
        /// <param name="nodeId">The node identifier.</param>
        /// <param name="initEdge">An optional edge initializer delegate.</param>
        public virtual DotEdge AddLoop(string nodeId, Action<IDotEdgeAttributes> initEdge = null)
        {
            return Add(DotEdge.Loop(nodeId), initEdge);
        }

        /// <summary>
        /// Gets edges that connect two nodes with the specified identifiers.
        /// </summary>
        /// <param name="tailNodeId">The tail (source, left) node identifier.</param>
        /// <param name="headNodeId">The head (destination, right) node identifier.</param>
        public virtual IEnumerable<DotEdge> GetAll(string tailNodeId, string headNodeId)
        {
            return this
                .OfType<DotEdge>()
                .Where(edge => edge.Equals(tailNodeId, headNodeId));
        }

        /// <summary>
        /// Gets loop edges that connect the specified node to itself.
        /// </summary>
        /// <param name="nodeId">The node identifier.</param>
        public virtual IEnumerable<DotEdge> GetLoops(string nodeId)
        {
            return GetAll(nodeId, nodeId);
        }

        /// <summary>
        /// Determines whether the specified edge is in the collection.
        /// </summary>
        /// <param name="tailNodeId">The tail (source, left) node identifier to locate.</param>
        /// <param name="headNodeId">The head (destination, right) node identifier to locate.</param>
        public virtual bool Contains(string tailNodeId, string headNodeId)
        {
            return this
                .OfType<DotEdge<DotEndpoint, DotEndpoint>>()
                .Where(edge => edge.Tail.NodeId == tailNodeId)
                .Where(edge => edge.Head.NodeId == headNodeId)
                .Any();
        }

        /// <summary>
        /// Determines whether the collection contains any loop edge that connects the specified node to itself.
        /// </summary>
        /// <param name="nodeId">The node identifier.</param>
        public virtual bool ContainsLoop(string nodeId)
        {
            return GetLoops(nodeId).Any();
        }

        /// <summary>
        /// Removes all edges that connect two nodes with the specified identifiers.
        /// </summary>
        /// <param name="tailNodeId">The tail (source, left) node identifier.</param>
        /// <param name="headNodeId">The head (destination, right) node identifier.</param>
        public virtual int RemoveAll(string tailNodeId, string headNodeId)
        {
            return RemoveAll(commonEdge => commonEdge is DotEdge<DotEndpoint, DotEndpoint> edge &&
                edge.Tail.NodeId == tailNodeId &&
                edge.Head.NodeId == headNodeId);
        }

        /// <summary>
        /// Removes all loop edges that connect the specified node to itself.
        /// </summary>
        /// <param name="nodeId">The node identifier.</param>
        public virtual int RemoveLoops(string nodeId)
        {
            return RemoveAll(nodeId, nodeId);
        }
    }
}
