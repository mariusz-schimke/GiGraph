using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.Common;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Attributes.Collections.Subgraph;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Attributes.Metadata;

namespace GiGraph.Dot.Entities.Attributes.Collections.Graph
{
    public class DotGraphSubgraphAttributes : DotEntityMappableAttributes<IDotSubgraphAttributes>, IDotSubgraphAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup GraphClusterAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotGraphSubgraphAttributes, IDotSubgraphAttributes>().Build();

        protected DotGraphSubgraphAttributes(DotGraphAttributes graphAttributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(graphAttributes.Collection, attributeKeyLookup)
        {
        }

        public DotGraphSubgraphAttributes(DotGraphAttributes graphAttributes)
            : this(graphAttributes, GraphClusterAttributesKeyLookup)
        {
        }

        /// <inheritdoc cref="IDotSubgraphAttributes.Rank" />
        [DotAttributeKey(DotAttributeKeys.Rank)]
        public virtual DotRank? Rank
        {
            get => GetValueAs<DotRank>(MethodBase.GetCurrentMethod(), out var result) ? result : (DotRank?) null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value, (k, v) => new DotRankAttribute(k, v.Value));
        }
    }
}