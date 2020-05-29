using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Edges.Endpoints;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GiGraph.Dot.Entities.Edges
{
    /// <summary>
    /// A collection of edges.
    /// </summary>
    public class DotCommonEdgeCollection : IDotEntity, ICollection<DotCommonEdge>
    {
        protected readonly List<DotCommonEdge> _edges = new List<DotCommonEdge>();

        /// <summary>
        /// Gets the number of elements contained in the collection.
        /// </summary>
        public virtual int Count => _edges.Count;

        bool ICollection<DotCommonEdge>.IsReadOnly => ((ICollection<DotCommonEdge>)_edges).IsReadOnly;

        /// <summary>
        /// Adds the specified edge to the collection.
        /// </summary>
        /// <typeparam name="T">The type of edge added.</typeparam>
        /// <param name="edge">The edge to add.</param>
        public virtual T Add<T>(T edge)
            where T : DotCommonEdge
        {
            return Add(edge, initEdge: null);
        }

        protected virtual T Add<T>(T edge, Action<IDotEdgeAttributes> initEdge)
            where T : DotCommonEdge
        {
            _edges.Add(edge);
            initEdge?.Invoke(edge.Attributes);
            return edge;
        }

        void ICollection<DotCommonEdge>.Add(DotCommonEdge item)
        {
            Add(item);
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
        /// Adds a sequence of edges that join consecutive nodes with the specified identifiers.
        /// </summary>
        /// <param name="nodeIds">The identifiers of consecutive nodes to connect with edges.</param>
        public virtual DotEdgeSequence AddSequence(params string[] nodeIds)
        {
            return AddSequence(nodeIds, initEdge: null);
        }

        /// <summary>
        /// Adds a sequence of edges that connect consecutive nodes with the specified identifiers.
        /// </summary>
        /// <param name="initEdge">An optional edge initializer delegate.</param>
        /// <param name="nodeIds">The identifiers of consecutive nodes to connect with edges.</param>
        public virtual DotEdgeSequence AddSequence(Action<IDotEdgeAttributes> initEdge, params string[] nodeIds)
        {
            return AddSequence(nodeIds, initEdge);
        }

        /// <summary>
        /// Adds a sequence of edges that connect consecutive nodes with the specified identifiers.
        /// </summary>
        /// <param name="nodeIds">The identifiers of consecutive nodes to connect with edges.</param>
        /// <param name="initEdge">An optional edge initializer delegate.</param>
        public virtual DotEdgeSequence AddSequence(IEnumerable<string> nodeIds, Action<IDotEdgeAttributes> initEdge = null)
        {
            return Add(DotEdgeSequence.FromNodes(nodeIds), initEdge);
        }

        /// <summary>
        /// Adds a group of edges where the <paramref name="tailNodeId"/> as the tail node is connected
        /// to all <paramref name="headNodeIds"/> as the head nodes.
        /// </summary>
        /// <param name="tailNodeId">The identifier of the tail (source, left) node.</param>
        /// <param name="headNodeIds">The identifiers of the head (destination, right) nodes to connect the tail node to.</param>
        public virtual DotOneToManyEdgeGroup AddOneToMany(string tailNodeId, params string[] headNodeIds)
        {
            return AddOneToMany(tailNodeId, (IEnumerable<string>)headNodeIds);
        }

        /// <summary>
        /// Adds a group of edges where the <paramref name="tailNodeId"/> as the tail node is connected
        /// to all <paramref name="headNodeIds"/> as the head nodes.
        /// </summary>
        /// <param name="initEdge">An optional edge initializer delegate.</param>
        /// <param name="tailNodeId">The identifier of the tail (source, left) node.</param>
        /// <param name="headNodeIds">The identifiers of the head (destination, right) nodes to connect the tail node to.</param>
        public virtual DotOneToManyEdgeGroup AddOneToMany(Action<IDotEdgeAttributes> initEdge, string tailNodeId, params string[] headNodeIds)
        {
            return AddOneToMany(tailNodeId, headNodeIds, initEdge);
        }

        /// <summary>
        /// Adds a group of edges where the <paramref name="tailNodeId"/> as the tail node is connected
        /// to all <paramref name="headNodeIds"/> as the head nodes.
        /// </summary>
        /// <param name="tailNodeId">The identifier of the tail (source, left) node.</param>
        /// <param name="headNodeIds">The identifiers of the head (destination, right) nodes to connect the tail node to.</param>
        /// <param name="initEdge">An optional edge initializer delegate.</param>
        public virtual DotOneToManyEdgeGroup AddOneToMany(string tailNodeId, IEnumerable<string> headNodeIds, Action<IDotEdgeAttributes> initEdge = null)
        {
            return Add(new DotOneToManyEdgeGroup(tailNodeId, headNodeIds), initEdge);
        }

        /// <summary>
        /// Adds a group of edges where all <paramref name="tailNodeIds"/> as tail nodes
        /// are connected to the <paramref name="headNodeId"/> as the head node.
        /// </summary>
        /// <param name="headNodeId">The identifier of the head (destination, right) node.</param>
        /// <param name="tailNodeIds">The identifiers of the tail (source, left) nodes to connect to the head node.</param>
        public virtual DotManyToOneEdgeGroup AddManyToOne(string headNodeId, params string[] tailNodeIds)
        {
            return AddManyToOne(tailNodeIds, headNodeId);
        }

        /// <summary>
        /// Adds a group of edges where all <paramref name="tailNodeIds"/> as tail nodes
        /// are connected to the <paramref name="headNodeId"/> as the head node.
        /// </summary>
        /// <param name="initEdge">An optional edge initializer delegate.</param>
        /// <param name="headNodeId">The identifier of the head (destination, right) node.</param>
        /// <param name="tailNodeIds">The identifiers of the tail (source, left) nodes to connect to the head node.</param>
        public virtual DotManyToOneEdgeGroup AddManyToOne(Action<IDotEdgeAttributes> initEdge, string headNodeId, params string[] tailNodeIds)
        {
            return AddManyToOne(tailNodeIds, headNodeId, initEdge);
        }

        /// <summary>
        /// Adds a group of edges where all <paramref name="tailNodeIds"/> as tail nodes
        /// are connected to the <paramref name="headNodeId"/> as the head node.
        /// </summary>
        /// <param name="tailNodeIds">The identifiers of the tail (source, left) nodes to connect to the head node.</param>
        /// <param name="headNodeId">The identifier of the head (destination, right) node.</param>
        /// <param name="initEdge">An optional edge initializer delegate.</param>
        public virtual DotManyToOneEdgeGroup AddManyToOne(IEnumerable<string> tailNodeIds, string headNodeId, Action<IDotEdgeAttributes> initEdge = null)
        {
            return Add(new DotManyToOneEdgeGroup(tailNodeIds, headNodeId), initEdge);
        }

        /// <summary>
        /// Adds a group of edges where all <paramref name="tailNodeIds"/> as tail nodes
        /// are connected to all <paramref name="headNodeIds"/> as head nodes.
        /// </summary>
        /// <param name="tailNodeIds">The identifiers of the tail (source, left) nodes.</param>
        /// <param name="headNodeIds">The identifiers of the head (destination, right) nodes.</param>
        /// <param name="initEdge">An optional edge initializer delegate.</param>
        public virtual DotManyToManyEdgeGroup AddManyToMany(IEnumerable<string> tailNodeIds, IEnumerable<string> headNodeIds,
            Action<IDotEdgeAttributes> initEdge = null)
        {
            return Add(new DotManyToManyEdgeGroup(tailNodeIds, headNodeIds), initEdge);
        }

        /// <summary>
        /// Gets edges that connect two nodes with the specified identifiers.
        /// </summary>
        /// <param name="tailNodeId">The tail (source, left) node identifier.</param>
        /// <param name="headNodeId">The head (destination, right) node identifier.</param>
        public virtual IEnumerable<DotEdge> GetAll(string tailNodeId, string headNodeId)
        {
            return _edges
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
        /// <param name="item">The edge to locate in the collection.</param>
        public virtual bool Contains(DotCommonEdge item)
        {
            return _edges.Contains(item);
        }

        /// <summary>
        /// Determines whether the specified edge is in the collection.
        /// </summary>
        /// <param name="tailNodeId">The tail (source, left) node identifier to locate.</param>
        /// <param name="headNodeId">The head (destination, right) node identifier to locate.</param>
        public virtual bool Contains(string tailNodeId, string headNodeId)
        {
            return _edges
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

        bool ICollection<DotCommonEdge>.Remove(DotCommonEdge item)
        {
            return Remove(item) > 0;
        }

        /// <summary>
        /// Removes all edges that connect two nodes with the specified identifiers.
        /// </summary>
        /// <param name="tailNodeId">The tail (source, left) node identifier.</param>
        /// <param name="headNodeId">The head (destination, right) node identifier.</param>
        public virtual int Remove(string tailNodeId, string headNodeId)
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
            return Remove(nodeId, nodeId);
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

        public virtual void CopyTo(DotCommonEdge[] array, int arrayIndex)
        {
            _edges.CopyTo(array, arrayIndex);
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
