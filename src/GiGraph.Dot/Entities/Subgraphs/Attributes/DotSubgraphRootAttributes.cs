using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Ranks;

namespace GiGraph.Dot.Entities.Subgraphs.Attributes;

public partial class DotSubgraphRootAttributes : DotEntityAttributesWithMetadata<IDotSubgraphAttributes, DotSubgraphRootAttributes>, IDotSubgraphRootAttributes
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
    public virtual partial DotRank? NodeRank { get; set; }

    [DotAttributeKey(DotAttributeKeys.Cluster)]
    bool? IDotSubgraphAttributes.IsCluster
    {
        get => _attributes.GetValue(DotAttributeKeys.Cluster, out bool? result) ? result : null;
        set => _attributes.SetOrRemove(DotAttributeKeys.Cluster, value);
    }
}