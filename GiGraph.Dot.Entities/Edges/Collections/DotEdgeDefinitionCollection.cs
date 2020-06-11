﻿using GiGraph.Dot.Entities.Attributes.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GiGraph.Dot.Entities.Edges.Collections
{
    /// <summary>
    /// A collection of edges.
    /// </summary>
    public partial class DotEdgeDefinitionCollection : List<DotEdgeDefinition>, IDotEntity
    {
        protected readonly Func<string, string, Predicate<DotEdgeDefinition>> _matchEdgePredicate;
        protected readonly Predicate<DotEdgeDefinition> _matchLoopPredicate;

        protected DotEdgeDefinitionCollection(
            Func<string, string, Predicate<DotEdgeDefinition>> matchEdgePredicate,
            Predicate<DotEdgeDefinition> matchLoopPredicate)
        {
            _matchEdgePredicate = matchEdgePredicate;
            _matchLoopPredicate = matchLoopPredicate;
        }

        public DotEdgeDefinitionCollection()
        {
            _matchEdgePredicate = (tailNodeId, headNodeId) => commonEdge => DotEdge.Equals(commonEdge, tailNodeId, headNodeId);
            _matchLoopPredicate = commonEdge => DotEdge.IsLoopEdge(commonEdge);
        }

        /// <summary>
        /// Adds an edge to the collection and initializes its attributes.
        /// </summary>
        /// <typeparam name="T">The type of edge to add.</typeparam>
        /// <param name="edge">The edge to add.</param>
        /// <param name="initAttrs">An optional edge attributes initializer delegate.</param>
        public virtual T Add<T>(T edge, Action<IDotEdgeAttributes> initAttrs)
            where T : DotEdgeDefinition
        {
            Add(edge);
            initAttrs?.Invoke(edge.Attributes);
            return edge;
        }

        /// <summary>
        /// Adds an edge that joins two nodes with the specified identifiers.
        /// </summary>
        /// <param name="tailNodeId">The tail (source, left) node identifier.</param>
        /// <param name="headNodeId">The head (destination, right) node identifier.</param>
        /// <param name="initAttrs">An optional edge attributes initializer delegate.</param>
        public virtual DotEdge Add(string tailNodeId, string headNodeId, Action<IDotEdgeAttributes> initAttrs = null)
        {
            return Add(new DotEdge(tailNodeId, headNodeId), initAttrs);
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