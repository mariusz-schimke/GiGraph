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
        protected readonly Func<string, string, Predicate<DotCommonEdge>> _matchEdgePredicate;
        protected readonly Predicate<DotCommonEdge> _matchLoopPredicate;

        protected DotCommonEdgeCollection(
            Func<string, string, Predicate<DotCommonEdge>> matchEdgePredicate,
            Predicate<DotCommonEdge> matchLoopPredicate)
        {
            _matchEdgePredicate = matchEdgePredicate;
            _matchLoopPredicate = matchLoopPredicate;
        }

        public DotCommonEdgeCollection()
        {
            _matchEdgePredicate = (tailNodeId, headNodeId) => commonEdge => commonEdge is DotEdge<DotEndpoint, DotEndpoint> edge &&
                edge.Tail.NodeId == tailNodeId &&
                edge.Head.NodeId == headNodeId;

            _matchLoopPredicate = commonEdge => commonEdge is DotEdge<DotEndpoint, DotEndpoint> edge &&
                edge.Tail.NodeId == edge.Head.NodeId;
        }

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
        /// Gets the first matching edge that connects two nodes with the specified identifiers.
        /// </summary>
        /// <param name="tailNodeId">The tail (source, left) node identifier.</param>
        /// <param name="headNodeId">The head (destination, right) node identifier.</param>
        public virtual DotEdge Get(string tailNodeId, string headNodeId)
        {
            return GetAll(tailNodeId, headNodeId).FirstOrDefault();
        }

        /// <summary>
        /// Gets edges that connect two nodes with the specified identifiers.
        /// </summary>
        /// <param name="tailNodeId">The tail (source, left) node identifier.</param>
        /// <param name="headNodeId">The head (destination, right) node identifier.</param>
        public virtual IEnumerable<DotEdge> GetAll(string tailNodeId, string headNodeId)
        {
            return this.OfType<DotEdge>()
                       .Where(edge => edge.Equals(tailNodeId, headNodeId));
        }

        /// <summary>
        /// Determines whether the specified edge is in the collection.
        /// </summary>
        /// <param name="tailNodeId">The tail (source, left) node identifier to locate.</param>
        /// <param name="headNodeId">The head (destination, right) node identifier to locate.</param>
        public virtual bool Contains(string tailNodeId, string headNodeId)
        {
            return Exists(_matchEdgePredicate(tailNodeId, headNodeId));
        }

        /// <summary>
        /// Removes the first matching edge that connects two nodes with the specified identifiers.
        /// </summary>
        /// <param name="tailNodeId">The tail (source, left) node identifier.</param>
        /// <param name="headNodeId">The head (destination, right) node identifier.</param>
        public virtual bool Remove(string tailNodeId, string headNodeId)
        {
            var index = FindIndex(_matchEdgePredicate(tailNodeId, headNodeId));

            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Removes all edges that connect two nodes with the specified identifiers.
        /// </summary>
        /// <param name="tailNodeId">The tail (source, left) node identifier.</param>
        /// <param name="headNodeId">The head (destination, right) node identifier.</param>
        public virtual int RemoveAll(string tailNodeId, string headNodeId)
        {
            return RemoveAll(_matchEdgePredicate(tailNodeId, headNodeId));
        }
    }
}
