using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.GraphCluster;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;

namespace GiGraph.Dot.Entities.Graphs.Attributes;

public partial class DotGraphClustersStyleAttributes : DotGraphClusterCommonStyleAttributes<IDotGraphClustersStyleAttributes, DotGraphClustersStyleAttributes>, IDotGraphClustersStyleAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotGraphClustersStyleAttributes, IDotGraphClustersStyleAttributes>().BuildLazy();
    protected readonly DotGraphStyleAttributes _graphStyleAttributes;

    public DotGraphClustersStyleAttributes(DotAttributeCollection attributes)
        : this(attributes, new DotGraphStyleAttributes(attributes), AttributeKeyLookup)
    {
    }

    protected DotGraphClustersStyleAttributes(DotAttributeCollection attributes, DotGraphStyleAttributes graphStyleAttributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
        _graphStyleAttributes = graphStyleAttributes;
    }
}