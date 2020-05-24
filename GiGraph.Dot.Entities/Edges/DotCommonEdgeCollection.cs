using GiGraph.Dot.Entities.Attributes.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GiGraph.Dot.Entities.Edges
{
    public class DotCommonEdgeCollection : IDotEntity, IEnumerable<DotCommonEdge>
    {
        protected readonly List<DotCommonEdge> _edges = new List<DotCommonEdge>();

        /// <summary>
        /// Adds the specified edge to the collection.
        /// </summary>
        /// <typeparam name="T">The type of edge added.</typeparam>
        /// <param name="edge">The edge to add.</param>
        public virtual T Add<T>(T edge)
            where T : DotCommonEdge
        {
            _edges.Add(edge);
            return edge;
        }

        /// <summary>
        /// Adds the specified edges to the collection.
        /// </summary>
        /// <param name="edges">The edges to add.</param>
        public virtual void AddRange(IEnumerable<DotCommonEdge> edges)
        {
            _edges.AddRange(edges);
        }

        /// <summary>
        /// Adds an edge to the collection, that connects two nodes with the specified identifiers.
        /// </summary>
        /// <param name="tailNodeId">The tail (source, left) node identifier.</param>
        /// <param name="headNodeId">The head (destination, right) node identifier.</param>
        public virtual DotEdge Add(string tailNodeId, string headNodeId)
        {
            return Add(new DotEdge(tailNodeId, headNodeId));
        }

        /// <summary>
        /// Adds an edge to the collection, that connects two nodes with the specified identifiers.
        /// </summary>
        /// <param name="tailNodeId">The tail (source, left) node identifier.</param>
        /// <param name="headNodeId">The head (destination, right) node identifier.</param>
        /// <param name="initEdge">An optional edge initializer delegate.</param>
        public virtual DotEdge Add(string tailNodeId, string headNodeId, Action<IDotEdgeAttributes> initEdge)
        {
            var edge = Add(tailNodeId, headNodeId);
            initEdge?.Invoke(edge.Attributes);
            return edge;
        }

        /// <summary>
        /// Adds multiple edges to the collection, that connect consecutive nodes with the specified identifiers.
        /// </summary>
        /// <param name="nodeIds">The identifiers of consecutive nodes to connect with edges.</param>
        public virtual DotEdgeChain Add(params string[] nodeIds)
        {
            return Add(initEdge: null, nodeIds);
        }

        /// <summary>
        /// Adds multiple edges to the collection, that connect consecutive nodes with the specified identifiers.
        /// </summary>
        /// <param name="initEdge">An edge initializer delegate.</param>
        /// <param name="nodeIds">The identifiers of consecutive nodes to connect with edges.</param>
        public virtual DotEdgeChain Add(Action<IDotEdgeAttributes> initEdge, params string[] nodeIds)
        {
            var edge = Add(new DotEdgeChain(nodeIds));
            initEdge?.Invoke(edge.Attributes);
            return edge;
        }

        /// <summary>
        /// Adds multiple edges to the collection, where the <paramref name="tailNodeId"/> as the tail node is connected
        /// to all <paramref name="headNodeIds"/> as the head nodes.
        /// </summary>
        /// <param name="tailNodeId">The identifier of the tail (source, left) node.</param>
        /// <param name="headNodeIds">The identifiers of the head (destination, right) nodes to connect the tail node to.</param>
        public virtual DotEdge[] AddOneToMany(string tailNodeId, params string[] headNodeIds)
        {
            return AddOneToMany(tailNodeId, initEdge: null, headNodeIds);
        }

        /// <summary>
        /// Adds multiple edges to the collection, where the <paramref name="tailNodeId"/> as the tail node is connected
        /// to all <paramref name="headNodeIds"/> as the head nodes.
        /// </summary>
        /// <param name="initEdge">An edge initializer delegate.</param>
        /// <param name="tailNodeId">The identifier of the tail (source, left) node.</param>
        /// <param name="headNodeIds">The identifiers of the head (destination, right) nodes to connect the tail node to.</param>
        public virtual DotEdge[] AddOneToMany(string tailNodeId, Action<IDotEdgeAttributes> initEdge, params string[] headNodeIds)
        {
            if (!headNodeIds.Any())
            {
                throw new ArgumentException("At least one head node identifier has to be specified.");
            }

            return headNodeIds.Select(headNodeId => Add(tailNodeId, headNodeId, initEdge)).ToArray();
        }

        /// <summary>
        /// Adds multiple edges to the collection, where all <paramref name="tailNodeIds"/> as tail nodes
        /// are connected to the <paramref name="headNodeId"/> as the head node.
        /// </summary>
        /// <param name="headNodeId">The identifier of the head (destination, right) node.</param>
        /// <param name="tailNodeIds">The identifiers of the tail (source, left) nodes to connect to the head node.</param>
        public virtual DotEdge[] AddManyToOne(string headNodeId, params string[] tailNodeIds)
        {
            return AddManyToOne(headNodeId, initEdge: null, tailNodeIds);
        }

        /// <summary>
        /// Adds multiple edges to the collection, where all <paramref name="tailNodeIds"/> as tail nodes
        /// are connected to the <paramref name="headNodeId"/> as the head node.
        /// </summary>
        /// <param name="initEdge">An edge initializer delegate.</param>
        /// <param name="headNodeId">The identifier of the head (destination, right) node.</param>
        /// <param name="tailNodeIds">The identifiers of the tail (source, left) nodes to connect to the head node.</param>
        public virtual DotEdge[] AddManyToOne(string headNodeId, Action<IDotEdgeAttributes> initEdge, params string[] tailNodeIds)
        {
            if (!tailNodeIds.Any())
            {
                throw new ArgumentException("At least one tail node identifier has to be specified.");
            }

            return tailNodeIds.Select(tailNodeId => Add(tailNodeId, headNodeId, initEdge)).ToArray();
        }

        /// <summary>
        /// Removes the specified edge from the collection.
        /// </summary>
        /// <param name="edge">The edge to remove.</param>
        public virtual int Remove(DotCommonEdge edge)
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
        /// <param name="tailNodeId">The tail (source, left) node identifier.</param>
        /// <param name="headNodeId">The head (destination, right) node identifier.</param>
        public virtual int Remove(string tailNodeId, string headNodeId)
        {
            return RemoveAll(commonEdge => commonEdge is DotEdge edge &&
                edge.TailNodeId == tailNodeId &&
                edge.HeadNodeId == headNodeId);
        }

        /// <summary>
        /// Removes all edges from the collection, that match the specified criteria.
        /// </summary>
        /// <param name="match">The predicate to use for matching edges.</param>
        public virtual int RemoveAll(Predicate<DotCommonEdge> match)
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

        public virtual IEnumerator<DotCommonEdge> GetEnumerator()
        {
            return ((IEnumerable<DotCommonEdge>)_edges).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<DotCommonEdge>)_edges).GetEnumerator();
        }
    }
}
