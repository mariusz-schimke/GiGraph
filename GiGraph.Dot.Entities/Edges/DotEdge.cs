using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Edges.Endpoints;
using System.Collections.Generic;

namespace GiGraph.Dot.Entities.Edges
{
    /// <summary>
    /// Represents an edge that joins:
    /// <list type="bullet">
    ///     <item>
    ///         two nodes, when <typeparamref name="TTail"/> and <typeparamref name="THead"/> are both
    ///         <see cref="DotNodeEndpoint"/>,
    ///     </item>
    ///     <item>
    ///         a set of edges that join one <typeparamref name="TTail"/> <see cref="DotNodeEndpoint"/> node
    ///         to multiple <typeparamref name="THead"/> <see cref="DotSubgraphEndpoint"/> nodes,
    ///     </item>
    ///     <item>
    ///         or a set of edges that join multiple <typeparamref name="TTail"/> <see cref="DotSubgraphEndpoint"/> nodes
    ///         to one <typeparamref name="THead"/> <see cref="DotNodeEndpoint"/> node,
    ///     </item>
    ///     <item>
    ///         or a set of edges that join multiple <typeparamref name="TTail"/> <see cref="DotSubgraphEndpoint"/> nodes
    ///         to multiple <typeparamref name="THead"/> <see cref="DotSubgraphEndpoint"/> nodes.
    ///     </item>
    /// </list>
    /// </summary>
    /// <typeparam name="TTail">The type of the tail endpoint.</typeparam>
    /// <typeparam name="THead">The type of the head endpoint.</typeparam>
    public class DotEdge<TTail, THead> : DotCommonEdge
        where TTail : DotEndpoint
        where THead : DotEndpoint
    {
        /// <summary>
        /// The tail (source, left) endpoint.
        /// </summary>
        public virtual TTail Tail { get; set; }

        /// <summary>
        /// The head (destination, right) endpoint.
        /// </summary>
        public virtual THead Head { get; set; }

        /// <summary>
        /// Gets the endpoints of this edge.
        /// </summary>
        public override IEnumerable<DotEndpoint> Endpoints => new DotEndpoint[] { Tail, Head };

        protected DotEdge(TTail tail, THead head, IDotEdgeAttributes attributes)
            : base(attributes)
        {
            Tail = tail;
            Head = head;
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
    }
}
