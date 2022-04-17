using GiGraph.Dot.Types.Ranks;

namespace GiGraph.Dot.Entities.Subgraphs.Attributes;

public interface IDotSubgraphAttributes
{
    /// <summary>
    ///     Gets or sets the rank constraints on the nodes in the subgraph (dot only).
    /// </summary>
    DotRank? NodeRank { get; set; }
}