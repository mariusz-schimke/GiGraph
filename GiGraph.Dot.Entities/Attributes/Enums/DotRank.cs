namespace GiGraph.Dot.Entities.Attributes.Enums
{
    /// <summary>
    ///     Rank constraints for the nodes in a subgraph.
    /// </summary>
    public enum DotRank
    {
        /// <summary>
        ///     All nodes are placed on the same rank.
        /// </summary>
        Same,

        /// <summary>
        ///     All nodes are placed on the minimum rank.
        /// </summary>
        Min,

        /// <summary>
        ///     All nodes are placed on the maximum rank.
        /// </summary>
        Max,

        /// <summary>
        ///     All nodes are placed on the minimum rank, and the only nodes on the minimum rank belong to some subgraph whose rank attribute
        ///     is <see cref="DotRank.Source" /> or <see cref="DotRank.Min" />.
        /// </summary>
        Source,

        Sink
    }
}