using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Factories;
using GiGraph.Dot.Entities.Attributes.Properties.Common;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Ranks;

namespace GiGraph.Dot.Entities.Subgraphs.Attributes
{
    public class DotSubgraphRootAttributes : DotEntityRootAttributes<IDotSubgraphAttributes>, IDotSubgraphRootAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup SubgraphRootAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotSubgraphRootAttributes, IDotSubgraphAttributes>().Build();

        protected DotSubgraphRootAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotSubgraphRootAttributes(DotAttributeCollection attributes)
            : this(attributes, SubgraphRootAttributesKeyLookup)
        {
        }

        public DotSubgraphRootAttributes()
            : this(new DotAttributeCollection(DotAttributeFactory.Instance))
        {
        }

        [DotAttributeKey(DotAttributeKeys.Rank)]
        DotRank? IDotSubgraphAttributes.NodeRank
        {
            get => GetValueAs<DotRank>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }
    }
}