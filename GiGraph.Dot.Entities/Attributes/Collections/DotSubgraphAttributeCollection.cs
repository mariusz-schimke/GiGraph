using GiGraph.Dot.Entities.Attributes.Entities;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public class DotSubgraphAttributeCollection : DotEntityAttributeCollection<IDotSubgraphAttributes>, IDotSubgraphAttributeCollection
    {
        public virtual DotRank? Rank
        {
            get => TryGetValueAs<DotRank>("rank", out var result) ? result : (DotRank?) null;
            set => AddOrRemove("rank", value, (k, v) => new DotRankAttribute(k, v.Value));
        }

        public override void SetFilled(DotColorDefinition value)
        {
            // subgraphs do not supported a fill color
        }
    }
}