using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.GraphCluster;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;

namespace GiGraph.Dot.Entities.Graphs.Attributes;

public class DotGraphClustersStyleAttributes : DotGraphClusterCommonStyleAttributes<IDotGraphClustersStyleAttributes, DotGraphClustersStyleAttributes>, IDotGraphClustersStyleAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotGraphClustersStyleAttributes, IDotGraphClustersStyleAttributes>().BuildLazy();

    public DotGraphClustersStyleAttributes(DotAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotGraphClustersStyleAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }
}