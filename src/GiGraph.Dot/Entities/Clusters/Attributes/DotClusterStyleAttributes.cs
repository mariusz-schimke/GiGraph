using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.GraphCluster;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Style;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Colors;

namespace GiGraph.Dot.Entities.Clusters.Attributes;

public partial class DotClusterStyleAttributes : DotGraphClusterCommonStyleAttributes<IDotClusterStyleAttributes, DotClusterStyleAttributes>, IDotClusterStyleAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotClusterStyleAttributes, IDotClusterStyleAttributes>().BuildLazy();

    public DotClusterStyleAttributes(DotAttributeCollection attributes)
        : this(attributes, AttributeKeyLookup, new DotStyleAttributeOptions(attributes))
    {
    }

    protected DotClusterStyleAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup, DotStyleAttributeOptions styleAttributeOptions)
        : base(attributes, attributeKeyLookup, styleAttributeOptions)
    {
    }

    [DotAttributeKey(DotAttributeKeys.ColorScheme)]
    public virtual partial string? ColorScheme { get; set; }

    [DotAttributeKey(DotAttributeKeys.GradientAngle)]
    public virtual partial int? GradientFillAngle { get; set; }

    [DotAttributeKey(DotAttributeKeys.BgColor)]
    public virtual partial DotColorDefinition? BackgroundColor { get; set; }
}