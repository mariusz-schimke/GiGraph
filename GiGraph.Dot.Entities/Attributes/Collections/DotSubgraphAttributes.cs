using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public class DotSubgraphAttributes : DotEntityAttributes, IDotSubgraphAttributes
    {
        public virtual DotRank? Rank
        {
            get => TryGetValueAs<DotRank>("rank", out var result) ? result : (DotRank?) null;
            set => AddOrRemove("rank", value, v => new DotRankAttribute("rank", v.Value));
        }

        public override void SetFilled(DotColorDefinition value)
        {
            // subgraphs do not supported a fill color
        }
    }
}