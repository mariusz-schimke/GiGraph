using System;
using System.Collections;
using System.Collections.Generic;

namespace GiGraph.Dot.Entities.Edges
{
    public class DotEdgeCollection : IDotEntity, IEnumerable<DotEdge>
    {
        protected readonly List<DotEdge> _edges = new List<DotEdge>();

        /// <summary>
        /// Adds the specified edge to the collection.
        /// </summary>
        /// <param name="edge">The edge to add.</param>
        public virtual DotEdge Add(DotEdge edge)
        {
            _edges.Add(edge);
            return edge;
        }

        /// <summary>
        /// Adds an edge to the collection, that connects two nodes with the specified identifiers.
        /// </summary>
        /// <param name="leftNodeId">The left (source) node identifier.</param>
        /// <param name="rightNodeId">The right (destination) node identifier.</param>
        public virtual DotEdge Add(string leftNodeId, string rightNodeId)
        {
            return Add(new DotEdge(leftNodeId, rightNodeId));
        }

        /// <summary>
        /// Removes the specified edge from the collection.
        /// </summary>
        /// <param name="edge">The edge to remove.</param>
        public virtual int Remove(DotEdge node)
        {
            var result = 0;

            while (_edges.Remove(node))
            {
                result++;
            }

            return result;
        }

        /// <summary>
        /// Removes an edge from the collection, that connects two nodes with the specified identifiers.
        /// </summary>
        /// <param name="leftNodeId">The left (source) node identifier.</param>
        /// <param name="rightNodeId">The right (destination) node identifier.</param>
        public virtual int Remove(string leftNodeId, string rightNodeId)
        {
            return RemoveAll(edge => edge.LeftNodeId == leftNodeId &&
                                     edge.RightNodeId == rightNodeId);
        }

        /// <summary>
        /// Removes all edges from the collection, that match the specified criteria.
        /// </summary>
        /// <param name="match">The predicate to use for matching edges.</param>
        public virtual int RemoveAll(Predicate<DotEdge> match)
        {
            return _edges.RemoveAll(match);
        }

        /// <summary>
        /// Clears the collection.
        /// </summary>
        public virtual void Clear()
        {
            _edges.Clear();
        }

        public virtual IEnumerator<DotEdge> GetEnumerator()
        {
            return ((IEnumerable<DotEdge>)_edges).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<DotEdge>)_edges).GetEnumerator();
        }
    }
}
