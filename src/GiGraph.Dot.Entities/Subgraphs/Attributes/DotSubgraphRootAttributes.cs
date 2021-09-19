using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Ranks;

namespace GiGraph.Dot.Entities.Subgraphs.Attributes
{
    public class DotSubgraphRootAttributes : DotEntityAttributesWithMetadata<IDotSubgraphAttributes, DotSubgraphRootAttributes>, IDotSubgraphRootAttributes
    {
        private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotSubgraphRootAttributes, IDotSubgraphAttributes>().BuildLazy();

        public DotSubgraphRootAttributes(DotAttributeCollection attributes)
            : this(attributes, AttributeKeyLookup)
        {
        }

        protected DotSubgraphRootAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        [DotAttributeKey(DotAttributeKeys.Rank)]
        public virtual DotRank? NodeRank
        {
            get => GetValueAs<DotRank>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }
    }
}