using System;
using System.Collections.Generic;
using System.Linq;

namespace GiGraph.Dot.Entities.Edges.Collections
{
    /// <summary>
    ///     A collection of edges.
    /// </summary>
    public partial class DotEdgeCollection : List<DotEdgeDefinition>, IDotEntity, IDotAnnotatable
    {
        protected readonly Func<string, string, Predicate<DotEdgeDefinition>> _matchEdgePredicate;
        protected readonly Predicate<DotEdgeDefinition> _matchLoopPredicate;

        protected DotEdgeCollection(
            Func<string, string, Predicate<DotEdgeDefinition>> matchEdgePredicate,
            Predicate<DotEdgeDefinition> matchLoopPredicate)
        {
            _matchEdgePredicate = matchEdgePredicate;
            _matchLoopPredicate = matchLoopPredicate;
        }

        public DotEdgeCollection()
        {
            _matchEdgePredicate = (tailNodeId, headNodeId) => edgeDefinition => DotEdge.Equals(edgeDefinition, tailNodeId, headNodeId);
            _matchLoopPredicate = edgeDefinition => DotEdge.IsLoopEdge(edgeDefinition);
        }

        public virtual string Annotation { get; set; }

        /// <summary>
        ///     Adds an edge to the collection and initializes its attributes.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of edge to add.
        /// </typeparam>
        /// <param name="edge">
        ///     The edge to add.
        /// </param>
        /// <param name="init">
        ///     An optional edge initializer delegate.
        /// </param>
        public virtual T Add<T>(T edge, Action<T> init)
            where T : DotEdgeDefinition
        {
            Add(edge);
            init?.Invoke(edge);
            return edge;
        }

        /// <summary>
        ///     Adds an edge that joins two nodes with the specified identifiers.
        /// </summary>
        /// <param name="tailNodeId">
        ///     The tail (source, left) node identifier.
        /// </param>
        /// <param name="headNodeId">
        ///     The head (destination, right) node identifier.
        /// </param>
        /// <param name="init">
        ///     An optional edge initializer delegate.
        /// </param>
        public virtual DotEdge Add(string tailNodeId, string headNodeId, Action<DotEdge> init = null)
        {
            return Add(new DotEdge(tailNodeId, headNodeId), init);
        }

        /// <summary>
        ///     Gets the first matching edge that connects two nodes with the specified identifiers.
        /// </summary>
        /// <param name="tailNodeId">
        ///     The tail (source, left) node identifier.
        /// </param>
        /// <param name="headNodeId">
        ///     The head (destination, right) node identifier.
        /// </param>
        public virtual DotEdge Get(string tailNodeId, string headNodeId)
        {
            return GetAll(tailNodeId, headNodeId).FirstOrDefault();
        }

        /// <summary>
        ///     Gets edges that connect two nodes with the specified identifiers.
        /// </summary>
        /// <param name="tailNodeId">
        ///     The tail (source, left) node identifier.
        /// </param>
        /// <param name="headNodeId">
        ///     The head (destination, right) node identifier.
        /// </param>
        public virtual IEnumerable<DotEdge> GetAll(string tailNodeId, string headNodeId)
        {
            return this.OfType<DotEdge>()
               .Where(edge => edge.Equals(tailNodeId, headNodeId));
        }

        /// <summary>
        ///     Determines whether the specified edge is in the collection.
        /// </summary>
        /// <param name="tailNodeId">
        ///     The tail (source, left) node identifier to locate.
        /// </param>
        /// <param name="headNodeId">
        ///     The head (destination, right) node identifier to locate.
        /// </param>
        public virtual bool Contains(string tailNodeId, string headNodeId)
        {
            return Exists(_matchEdgePredicate(tailNodeId, headNodeId));
        }

        /// <summary>
        ///     Removes the first matching edge that connects two nodes with the specified identifiers.
        /// </summary>
        /// <param name="tailNodeId">
        ///     The tail (source, left) node identifier.
        /// </param>
        /// <param name="headNodeId">
        ///     The head (destination, right) node identifier.
        /// </param>
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
        ///     Removes all edges that connect two nodes with the specified identifiers.
        /// </summary>
        /// <param name="tailNodeId">
        ///     The tail (source, left) node identifier.
        /// </param>
        /// <param name="headNodeId">
        ///     The head (destination, right) node identifier.
        /// </param>
        public virtual int RemoveAll(string tailNodeId, string headNodeId)
        {
            return RemoveAll(_matchEdgePredicate(tailNodeId, headNodeId));
        }
    }
}