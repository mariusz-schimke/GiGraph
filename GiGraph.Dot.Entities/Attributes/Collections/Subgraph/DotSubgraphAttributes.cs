using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.Common;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Ranks;

namespace GiGraph.Dot.Entities.Attributes.Collections.Subgraph
{
    public class DotSubgraphAttributes : DotEntityRootAttributes<IDotSubgraphAttributes>, IDotSubgraphAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup SubgraphAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotSubgraphAttributes, IDotSubgraphAttributes>().Build();

        protected DotSubgraphAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotSubgraphAttributes(DotAttributeCollection attributes)
            : this(attributes, SubgraphAttributesKeyLookup)
        {
        }

        public DotSubgraphAttributes()
            : this(new DotAttributeCollection())
        {
        }

        /// <inheritdoc cref="IDotSubgraphAttributes.NodeRank" />
        [DotAttributeKey(DotAttributeKeys.Rank)]
        public virtual DotRank? NodeRank
        {
            get => GetValueAs<DotRank>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotEnumAttribute<DotRank>(k, v!.Value));
        }
    }
}