using GiGraph.Dot.Entities.Subgraphs.Attributes;
using GiGraph.Dot.Types.Ranks;

namespace GiGraph.Dot.Entities.Subgraphs
{
    public partial class DotSubgraphSection : IDotSubgraphRootAttributes
    {
        private DotSubgraphRootAttributes SubgraphAttributes => (DotSubgraphRootAttributes) _attributes;

        /// <inheritdoc cref="IDotSubgraphAttributes.NodeRank" />
        public virtual DotRank? NodeRank
        {
            get => SubgraphAttributes.NodeRank;
            set => SubgraphAttributes.NodeRank = value;
        }
    }
}