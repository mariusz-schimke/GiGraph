using GiGraph.Dot.Entities.Types.Ranks;

namespace GiGraph.Dot.Entities.Attributes.Collections.Subgraph
{
    public interface IDotSubgraphAttributes
    {
        /// <summary>
        ///     Gets or sets the rank constraints on the nodes in the subgraph (dot only).
        /// </summary>
        DotRank? NodeRank { get; set; }
    }
}