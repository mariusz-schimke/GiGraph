using GiGraph.Dot.Entities.Subgraphs.Attributes;
using GiGraph.Dot.Types.Ranks;

namespace GiGraph.Dot.Entities.Subgraphs
{
    public partial class DotSubgraphSection
    {
        /// <inheritdoc cref="IDotSubgraphAttributes.NodeRank" />
        public virtual DotRank? NodeRank
        {
            get => ((IDotSubgraphAttributes) Attributes).NodeRank;
            set => ((IDotSubgraphAttributes) Attributes).NodeRank = value;
        }
    }
}