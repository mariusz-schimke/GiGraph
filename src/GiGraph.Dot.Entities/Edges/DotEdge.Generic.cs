using GiGraph.Dot.Entities.Edges.Attributes;
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
        protected DotEdge(TTail tail, THead head,
            DotEdgeRootAttributes rootAttributes,
            DotEdgeTailAttributes tailAttributes,
            DotEdgeHeadAttributes headAttributes
        )
            : base(rootAttributes)
        {
            Tail = new DotEdgeTail<TTail>(tail, tailAttributes);
            Head = new DotEdgeHead<THead>(head, headAttributes);
        }

        protected DotEdge(TTail tail, THead head, DotEdgeRootAttributes rootAttributes)
            : this(tail, head, rootAttributes,
                new DotEdgeTailAttributes(rootAttributes.Collection),
                new DotEdgeHeadAttributes(rootAttributes.Collection)
            )
        {
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
            : this(tail, head, new DotEdgeRootAttributes())
        {
        }

        /// <summary>
        ///     Gets the tail endpoint.
        /// </summary>
        public virtual DotEdgeTail<TTail> Tail { get; }

        /// <summary>
        ///     Gets the head endpoint.
        /// </summary>
        public virtual DotEdgeHead<THead> Head { get; }

        /// <summary>
        ///     Gets the endpoints of this edge.
        /// </summary>
        public override DotEndpointDefinition[] Endpoints => new DotEndpointDefinition[] { Tail.Endpoint, Head.Endpoint };

        protected override string GetOrderingKey()
        {
            return $"{Tail.Endpoint.OrderingKey} {Head.Endpoint.OrderingKey}";
        }
    }
}