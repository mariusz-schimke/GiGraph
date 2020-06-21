using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Edges.Endpoints;
using System;
using System.Collections.Generic;

namespace GiGraph.Dot.Entities.Edges
{
    /// <summary>
    /// Represents:
    /// <list type="bullet">
    ///     <item>
    ///         an edge that joins two nodes, when <typeparamref name="TTail"/> and <typeparamref name="THead"/> are both <see cref="DotEndpoint"/>,
    ///     </item>
    ///     <item>
    ///         a group of edges that join one <typeparamref name="TTail"/> <see cref="DotEndpoint"/> node
    ///         to multiple <typeparamref name="THead"/> <see cref="DotEndpointGroup"/> nodes,
    ///     </item>
    ///     <item>
    ///         a group of edges that join multiple <typeparamref name="TTail"/> <see cref="DotEndpointGroup"/> nodes
    ///         to one <typeparamref name="THead"/> <see cref="DotEndpoint"/> node,
    ///     </item>
    ///     <item>
    ///         a group of edges that join multiple <typeparamref name="TTail"/> <see cref="DotEndpointGroup"/> nodes
    ///         to multiple <typeparamref name="THead"/> <see cref="DotEndpointGroup"/> nodes.
    ///     </item>
    /// </list>
    /// </summary>
    /// <typeparam name="TTail">The type of the tail endpoint.</typeparam>
    /// <typeparam name="THead">The type of the head endpoint.</typeparam>
    public class DotEdge<TTail, THead> : DotEdgeDefinition
        where TTail : DotEndpointDefinition, IDotOrderable
        where THead : DotEndpointDefinition, IDotOrderable
    {
        /// <summary>
        /// Gets or sets the tail (source, left) endpoint.
        /// </summary>
        public virtual TTail Tail { get; }

        /// <summary>
        /// Gets or sets the head (destination, right) endpoint.
        /// </summary>
        public virtual THead Head { get; }

        /// <summary>
        /// Gets the endpoints of this edge.
        /// </summary>
        public override IEnumerable<DotEndpointDefinition> Endpoints => new DotEndpointDefinition[] { Tail, Head };

        protected DotEdge(TTail tail, THead head, IDotEdgeAttributes attributes)
            : base(attributes)
        {
            Tail = tail ?? throw new ArgumentNullException(nameof(tail), "Edge tail cannot be null.");
            Head = head ?? throw new ArgumentNullException(nameof(head), "Edge head cannot be null.");
        }

        /// <summary>
        /// Creates a new edge instance.
        /// </summary>
        /// <param name="tail">The tail (source, left) endpoint.</param>
        /// <param name="head">The head (destination, right) endpoint.</param>
        public DotEdge(TTail tail, THead head)
            : this(tail, head, new DotEntityAttributes())
        {
        }

        protected override string GetOrderingKey()
        {
            return $"{Tail.OrderingKey} {Head.OrderingKey}";
        }
    }
}