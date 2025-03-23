using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Clusters.Attributes;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Colors;

namespace GiGraph.Dot.Entities.Graphs.Attributes;

public partial class DotGraphClustersAttributes : DotEntityAttributesWithMetadata<IDotGraphClustersAttributes, DotGraphClustersAttributes>, IDotGraphClustersRootAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotGraphClustersAttributes, IDotGraphClustersAttributes>().BuildLazy();

    public DotGraphClustersAttributes(DotAttributeCollection attributes)
        : this(attributes, AttributeKeyLookup, new DotClusterStyleAttributeOptions(attributes))
    {
    }

    protected DotGraphClustersAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup,
        DotClusterStyleAttributeOptions styleAttributeOptions
    )
        : base(attributes, attributeKeyLookup)
    {
        Style = styleAttributeOptions;
    }

    public DotClusterStyleAttributeOptions Style { get; }

    [DotAttributeKey(DotAttributeKeys.Color)]
    public virtual partial DotColorDefinition? Color { get; set; }

    [DotAttributeKey(DotAttributeKeys.PenWidth)]
    public virtual partial double? BorderWidth { get; set; }

    [DotAttributeKey(DotAttributeKeys.PenColor)]
    public virtual partial DotColor? BorderColor { get; set; }

    [DotAttributeKey(DotAttributeKeys.FillColor)]
    public virtual partial DotColorDefinition? FillColor { get; set; }

    [DotAttributeKey(DotAttributeKeys.Compound)]
    public virtual partial bool? EnableEdgeClipping { get; set; }

    [DotAttributeKey(DotAttributeKeys.ClusterRank)]
    public virtual partial DotClusterVisualizationMode? VisualizationMode { get; set; }
}