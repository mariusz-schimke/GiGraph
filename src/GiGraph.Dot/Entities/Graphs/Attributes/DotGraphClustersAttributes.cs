using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Clusters;

namespace GiGraph.Dot.Entities.Graphs.Attributes;

public partial class DotGraphClustersAttributes : DotEntityAttributesWithMetadata<IDotGraphClustersAttributes, DotGraphClustersAttributes>, IDotGraphClustersRootAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotGraphClustersAttributes, IDotGraphClustersAttributes>().BuildLazy();

    public DotGraphClustersAttributes(DotAttributeCollection attributes)
        : this(attributes, AttributeKeyLookup, new DotGraphClustersStyleAttributes(attributes))
    {
    }

    protected DotGraphClustersAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup,
        DotGraphClustersStyleAttributes styleAttributes
    )
        : base(attributes, attributeKeyLookup)
    {
        Style = styleAttributes;
    }

    public DotGraphClustersStyleAttributes Style { get; }

    [DotAttributeKey(DotAttributeKeys.Compound)]
    public virtual partial bool? EnableEdgeClipping { get; set; }

    [DotAttributeKey(DotAttributeKeys.ClusterRank)]
    public virtual partial DotClusterVisualizationMode? VisualizationMode { get; set; }
}