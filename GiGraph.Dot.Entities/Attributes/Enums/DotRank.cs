using GiGraph.Dot.Entities.Attributes.Metadata;

namespace GiGraph.Dot.Entities.Attributes.Enums
{
    /// <summary>
    ///     Rank constraints for the nodes in a graph, subgraph or cluster.
    /// </summary>
    public enum DotRank
    {
        /// <summary>
        ///     All nodes are placed on the same rank.
        /// </summary>
        [DotAttributeValue("same")]
        Same,

        /// <summary>
        ///     All nodes are placed on the minimum rank (topmost or leftmost, depending on layout direction).
        /// </summary>
        [DotAttributeValue("min")]
        Min,

        /// <summary>
        ///     All nodes are placed on the maximum rank (bottommost or rightmost, depending on layout direction).
        /// </summary>
        [DotAttributeValue("max")]
        Max,

        /// <summary>
        ///     All nodes are placed on the minimum rank, and the only nodes on the minimum rank belong to some subgraph whose rank attribute
        ///     is <see cref="DotRank.Source" /> or <see cref="DotRank.Min" />.
        /// </summary>
        [DotAttributeValue("source")]
        Source,

        /// <summary>
        ///     All nodes are placed on the maximum rank, and the only nodes on the maximum rank belong to some subgraph whose rank attribute
        ///     is <see cref="DotRank.Source" /> or <see cref="DotRank.Max" />.
        /// </summary>
        [DotAttributeValue("sink")]
        Sink
    }
}