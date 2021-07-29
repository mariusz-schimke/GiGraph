using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Factories;
using GiGraph.Dot.Entities.Attributes.Properties.Common;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Ranks;

namespace GiGraph.Dot.Entities.Subgraphs.Attributes
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
            : this(new DotAttributeCollection(DotAttributeFactory.Instance))
        {
        }

        /// <inheritdoc cref="IDotSubgraphAttributes.NodeRank" />
        [DotAttributeKey(DotAttributeKeys.Rank)]
        public virtual DotRank? NodeRank
        {
            get => GetValueAs<DotRank>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }
    }
}