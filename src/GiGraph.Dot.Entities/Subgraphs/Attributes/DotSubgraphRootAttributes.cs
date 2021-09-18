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
        protected static readonly Lazy<DotMemberAttributeKeyLookup> SubgraphRootAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotSubgraphRootAttributes, IDotSubgraphAttributes>().BuildLazy();

        protected DotSubgraphRootAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotSubgraphRootAttributes(DotAttributeCollection attributes)
            : this(attributes, SubgraphRootAttributesKeyLookup)
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