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
        /// <param name="tailNodeId">The left (source, tail) node identifier.</param>
        /// <param name="headNodeId">The right (destination, head) node identifier.</param>
        public virtual DotEdge Add(string tailNodeId, string headNodeId)
        {
            return Add(new DotEdge(tailNodeId, headNodeId));
        }

        /// <summary>
        /// Adds an edge to the collection, that connects two nodes with the specified identifiers.
        /// </summary>
        /// <param name="tailNodeId">The left (source, tail) node identifier.</param>
        /// <param name="headNodeId">The right (destination, head) node identifier.</param>
        /// <param name="initEdge">An optional edge initializer delegate.</param>
        public virtual DotEdge Add(string tailNodeId, string headNodeId, Action<DotEdge> initEdge)
        {
            var edge = Add(tailNodeId, headNodeId);
            initEdge?.Invoke(edge);
            return edge;
        }

        /// <summary>
        /// Adds multiple edges to the collection, that connect consecutive nodes with the specified identifiers.
        /// </summary>
        /// <param name="nodeIds">The identifiers of consecutive nodes to connect with edges.</param>
        public virtual DotEdge[] Add(params string[] nodeIds)
        {
            return Add(initEdge: null, nodeIds);
        }

        /// <summary>
        /// Adds multiple edges to the collection, that connect consecutive nodes with the specified identifiers.
        /// </summary>
        /// <param name="initEdge">An edge initializer delegate.</param>
        /// <param name="nodeIds">The identifiers of consecutive nodes to connect with edges.</param>
        public virtual DotEdge[] Add(Action<DotEdge> initEdge, params string[] nodeIds)
        {
            if (nodeIds.Length < 2)
            {
                throw new ArgumentException("At least two node identifiers have to be specified.");
            }

            var edges = new List<DotEdge>();

            for (int i = 0; i < nodeIds.Length - 1; i++)
            {
                var edge = Add
                (
                    tailNodeId: nodeIds[i],
                    headNodeId: nodeIds[i + 1],
                    initEdge
                );

                edges.Add(edge);
            }

            return edges.ToArray();
        }

        /// <summary>
        /// Removes the specified edge from the collection.
        /// </summary>
        /// <param name="edge">The edge to remove.</param>
        public virtual int Remove(DotEdge edge)
        {
            var result = 0;

            while (_edges.Remove(edge))
            {
                result++;
            }

            return result;
        }

        /// <summary>
        /// Removes an edge from the collection, that connects two nodes with the specified identifiers.
        /// </summary>
        /// <param name="tailNodeId">The left (source, tail) node identifier.</param>
        /// <param name="headNodeId">The right (destination, head) node identifier.</param>
        public virtual int Remove(string tailNodeId, string headNodeId)
        {
            return RemoveAll(edge => edge.TailNodeId == tailNodeId &&
                                     edge.HeadNodeId == headNodeId);
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
