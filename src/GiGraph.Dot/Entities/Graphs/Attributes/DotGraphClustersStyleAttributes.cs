using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.GraphCluster;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Style;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;

namespace GiGraph.Dot.Entities.Graphs.Attributes;

public class DotGraphClustersStyleAttributes : DotGraphClusterCommonStyleAttributes<IDotGraphClustersStyleAttributes, DotGraphClustersStyleAttributes>, IDotGraphClustersStyleAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotGraphClustersStyleAttributes, IDotGraphClustersStyleAttributes>().BuildLazy();

    public DotGraphClustersStyleAttributes(DotAttributeCollection attributes)
        : this(attributes, AttributeKeyLookup, new DotStyleAttributeOptions(attributes))
    {
    }

    protected DotGraphClustersStyleAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup, DotStyleAttributeOptions styleAttributeOptions)
        : base(attributes, attributeKeyLookup, styleAttributeOptions)
    {
    }
}