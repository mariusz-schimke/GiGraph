using System;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Entities.Attributes.Collections.Edge;
using GiGraph.Dot.Entities.Edges.Endpoints;

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
            Predicate<DotEdgeDefinition> matchLoopPredicate,
            DotEdgeAttributes attributes)
        {
            Attributes = attributes;
            _matchEdgePredicate = matchEdgePredicate;
            _matchLoopPredicate = matchLoopPredicate;
        }

        public DotEdgeCollection()
            : this
            (
                (tailNodeId, headNodeId) => edgeDefinition => DotEdge.Equals(edgeDefinition, tailNodeId, headNodeId),
                edgeDefinition => DotEdge.IsLoopEdge(edgeDefinition),
                new DotEdgeAttributes()
            )
        {
        }

        /// <summary>
        ///     Gets the attributes to apply by default to all edges of the graph.
        /// </summary>
        public virtual DotEdgeAttributes Attributes { get; }

        /// <inheritdoc cref="IDotAnnotatable.Annotation" />
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
        ///     Adds an edge that joins the two specified nodes.
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
        ///     Adds an edge that joins the two specified endpoints.
        /// </summary>
        /// <param name="tail">
        ///     The tail (source, left) node identifier. Note that if you want to specify a cluster as a tail, use
        ///     <see cref="DotClusterEndpoint" />.
        /// </param>
        /// <param name="head">
        ///     The head (destination, right) node identifier. Note that if you want to specify a cluster as a head, use
        ///     <see cref="DotClusterEndpoint" />.
        /// </param>
        /// <param name="init">
        ///     An optional edge initializer delegate.
        /// </param>
        public virtual DotEdge Add(DotEndpoint tail, DotEndpoint head, Action<DotEdge> init = null)
        {
            return Add(new DotEdge(tail, head), init);
        }

        /// <summary>
        ///     Adds an edge that joins the specified endpoints.
        /// </summary>
        /// <param name="tail">
        ///     The tail (source, left) node identifier. Use <see cref="DotEndpoint" /> for a node as a tail,
        ///     <see cref="DotClusterEndpoint" /> for a cluster as a tail, or <see cref="DotEndpointGroup" /> for a group of nodes as tails.
        /// </param>
        /// <param name="head">
        ///     The head (destination, right) node identifier. Use <see cref="DotEndpoint" /> for a node as a head,
        ///     <see cref="DotClusterEndpoint" /> for a cluster as a head, or <see cref="DotEndpointGroup" /> for a group of nodes as heads.
        /// </param>
        /// <param name="init">
        ///     An optional edge initializer delegate.
        /// </param>
        public virtual DotEdge<DotEndpointDefinition, DotEndpointDefinition> Add(
            DotEndpointDefinition tail, DotEndpointDefinition head,
            Action<DotEdge<DotEndpointDefinition, DotEndpointDefinition>> init = null)
        {
            return Add(new DotEdge<DotEndpointDefinition, DotEndpointDefinition>(tail, head), init);
        }

        /// <summary>
        ///     Gets the first matching edge that joins the two specified nodes.
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
        ///     Gets edges that join the two specified nodes.
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
        ///     Removes the first matching edge that joins the two specified nodes.
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
        ///     Removes all edges that join the two specified nodes.
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