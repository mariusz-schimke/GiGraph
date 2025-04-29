using GiGraph.Dot.Entities.Subgraphs.Attributes;
using GiGraph.Dot.Types.Graphs.Layout.Spacing;

namespace GiGraph.Dot.Entities.Subgraphs;

public partial class DotSubgraphSection : IDotSubgraphRootAttributes
{
    /// <inheritdoc cref="IDotSubgraphAttributes.IsCluster" />
    bool? IDotSubgraphAttributes.IsCluster
    {
        get => ((IDotSubgraphAttributes) Attributes.Implementation).IsCluster;
        set => ((IDotSubgraphAttributes) Attributes.Implementation).IsCluster = value;
    }

    /// <inheritdoc cref="IDotSubgraphAttributes.NodeRank" />
    public virtual DotRank? NodeRank
    {
        get => Attributes.Implementation.NodeRank;
        set => Attributes.Implementation.NodeRank = value;
    }
}