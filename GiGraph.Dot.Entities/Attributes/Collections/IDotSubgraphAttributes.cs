using GiGraph.Dot.Entities.Attributes.Enums;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public interface IDotSubgraphAttributes : IDotAttributeCollection
    {
        /// <summary>
        ///     <para>
        ///         Gets or sets the rank constraints on the nodes in the subgraph.
        ///     </para>
        ///     <para>
        ///         If rank is <see cref="DotRank.Same" />, all nodes are placed on the same rank.
        ///     </para>
        ///     <para>
        ///         If rank is <see cref="DotRank.Min" />, all nodes are placed on the minimum rank.
        ///     </para>
        ///     <para>
        ///         If rank is <see cref="DotRank.Source" />, all nodes are placed on the minimum rank, and the only nodes on the minimum
        ///         rank belong to some subgraph whose rank attribute is <see cref="DotRank.Source" /> or <see cref="DotRank.Min" />.
        ///     </para>
        ///     <para>
        ///         Analogous criteria hold for rank <see cref="DotRank.Max" /> and <see cref="DotRank.Sink" />.
        ///     </para>
        ///     <para>
        ///         (Note: the minimum rank is topmost or leftmost, and the maximum rank is bottommost or rightmost.)
        ///     </para>
        /// </summary>
        DotRank? Rank { get; set; }
    }
}