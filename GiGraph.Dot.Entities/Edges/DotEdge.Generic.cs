using System;
using GiGraph.Dot.Entities.Attributes.Collections.Edge;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Output;

namespace GiGraph.Dot.Entities.Edges
{
    /// <summary>
    ///     Represents:
    ///     <list type="bullet">
    ///         <item>
    ///             <description>
    ///                 an edge that joins two nodes, when <typeparamref name="TTail" /> and <typeparamref name="THead" /> are both of
    ///                 <see cref="DotEndpoint" /> type,
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 a group of edges that join one <typeparamref name="TTail" /> <see cref="DotEndpoint" /> node to multiple
    ///                 <typeparamref name="THead" /> <see cref="DotSubgraphEndpoint" /> or <see cref="DotEndpointGroup" /> nodes,
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 a group of edges that join multiple <typeparamref name="TTail" /> <see cref="DotSubgraphEndpoint" /> or
    ///                 <see cref="DotEndpointGroup" /> nodes to one <typeparamref name="THead" /> <see cref="DotEndpoint" /> node,
    ///             </description>
    ///         </item>
    ///         <item>
    ///             <description>
    ///                 a group of edges that join multiple <typeparamref name="TTail" /> <see cref="DotSubgraphEndpoint" /> or
    ///                 <see cref="DotEndpointGroup" /> nodes to multiple <typeparamref name="THead" />
    ///                 <see cref="DotSubgraphEndpoint" /> or <see cref="DotEndpointGroup" /> nodes.
    ///             </description>
    ///         </item>
    ///     </list>
    /// </summary>
    /// <typeparam name="TTail">
    ///     The type of the tail endpoint.
    /// </typeparam>
    /// <typeparam name="THead">
    ///     The type of the head endpoint.
    /// </typeparam>
    public class DotEdge<TTail, THead> : DotEdgeDefinition
        where TTail : DotEndpointDefinition, IDotOrderable
        where THead : DotEndpointDefinition, IDotOrderable
    {
        protected DotEdge(TTail tail, THead head, DotEdgeAttributes attributes)
            : base(attributes)
        {
            Tail = tail ?? throw new ArgumentNullException(nameof(tail), "Edge tail must not be null.");
            Head = head ?? throw new ArgumentNullException(nameof(head), "Edge head must not be null.");
        }

        /// <summary>
        ///     Creates a new edge instance.
        /// </summary>
        /// <param name="tail">
        ///     The tail endpoint.
        /// </param>
        /// <param name="head">
        ///     The head endpoint.
        /// </param>
        public DotEdge(TTail tail, THead head)
            : this(tail, head, new DotEdgeAttributes())
        {
        }

        /// <summary>
        ///     Gets or sets the tail endpoint.
        /// </summary>
        public virtual TTail Tail { get; }

        /// <summary>
        ///     Gets or sets the head endpoint.
        /// </summary>
        public virtual THead Head { get; }

        /// <summary>
        ///     Gets the endpoints of this edge.
        /// </summary>
        public override DotEndpointDefinition[] Endpoints => new DotEndpointDefinition[] { Tail, Head };

        protected override string GetOrderingKey()
        {
            return $"{Tail.OrderingKey} {Head.OrderingKey}";
        }
    }
}