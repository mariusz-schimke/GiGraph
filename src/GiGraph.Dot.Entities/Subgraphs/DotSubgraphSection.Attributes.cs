using GiGraph.Dot.Entities.Subgraphs.Attributes;
using GiGraph.Dot.Types.Ranks;

namespace GiGraph.Dot.Entities.Subgraphs
{
    public partial class DotSubgraphSection : IDotSubgraphRootAttributes
    {
        /// <inheritdoc cref="IDotSubgraphAttributes.NodeRank" />
        public virtual DotRank? NodeRank
        {
            get => Attributes.Attributes.NodeRank;
            set => Attributes.Attributes.NodeRank = value;
        }
    }
}