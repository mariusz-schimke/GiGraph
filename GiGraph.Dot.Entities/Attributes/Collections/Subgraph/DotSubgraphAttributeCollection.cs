using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Colors;

namespace GiGraph.Dot.Entities.Attributes.Collections.Subgraph
{
    public class DotSubgraphAttributeCollection : DotEntityAttributeCollection<IDotSubgraphAttributes>, IDotSubgraphAttributeCollection
    {
        protected static readonly DotMemberAttributeKeyLookup EntityAttributePropertiesInterfaceKeyLookup;

        static DotSubgraphAttributeCollection()
        {
            var type = typeof(DotSubgraphAttributeCollection);
            UpdateAttributeKeyLookupForDeclaredPropertyAccessorsOf(type);
            EntityAttributePropertiesInterfaceKeyLookup = CreateAttributeKeyLookupForEntityAttributePropertiesOf(type).ToReadOnly();
        }

        protected DotSubgraphAttributeCollection(DotMemberAttributeKeyLookup entityAttributePropertiesInterfaceKeyLookup)
            : base(entityAttributePropertiesInterfaceKeyLookup)
        {
        }

        public DotSubgraphAttributeCollection()
            : base(EntityAttributePropertiesInterfaceKeyLookup)
        {
        }

        [DotAttributeKey("rank")]
        public virtual DotRank? Rank
        {
            get => GetValueAs<DotRank>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotRank?) null;
            set => AddOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotRankAttribute(k, v.Value));
        }

        public override void SetFilled(DotColorDefinition value)
        {
            // subgraphs do not supported a fill color
        }
    }
}