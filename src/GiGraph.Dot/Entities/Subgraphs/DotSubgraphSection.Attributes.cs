using GiGraph.Dot.Entities.Subgraphs.Attributes;
using GiGraph.Dot.Types.Ranks;

namespace GiGraph.Dot.Entities.Subgraphs;

public partial class DotSubgraphSection : IDotSubgraphRootAttributes
{
    /// <inheritdoc cref="IDotSubgraphAttributes.IsCluster" />
    bool? IDotSubgraphAttributes.IsCluster
    {
        get => ((IDotSubgraphAttributes) Attributes.Implementation).IsCluster;
        set => ((IDotSubgraphAttributes) Attributes.Implementation).IsCluster = value;
    }

    /// <inheritdoc cref="IDotSubgraphAttributes.NodeRankAlignment" />
    public virtual DotRankAlignment? NodeRankAlignment
    {
        get => Attributes.Implementation.NodeRankAlignment;
        set => Attributes.Implementation.NodeRankAlignment = value;
    }
}