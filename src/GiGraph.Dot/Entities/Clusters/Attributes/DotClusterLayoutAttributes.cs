using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Geometry;
using GiGraph.Dot.Types.Graphs.Layout.Spacing;

namespace GiGraph.Dot.Entities.Clusters.Attributes;

public partial class DotClusterLayoutAttributes : DotEntityAttributesWithMetadata<IDotClusterLayoutAttributes, DotClusterLayoutAttributes>, IDotClusterLayoutAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotClusterLayoutAttributes, IDotClusterLayoutAttributes>().BuildLazy();

    public DotClusterLayoutAttributes(DotAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotClusterLayoutAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <inheritdoc cref="IDotClusterLayoutAttributes.Padding"/>
    [DotAttributeKey(DotAttributeKeys.Margin)]
    public virtual partial DotPoint? Padding { get; set; }

    /// <inheritdoc cref="IDotClusterLayoutAttributes.NodeRank"/>
    [DotAttributeKey(DotAttributeKeys.Rank)]
    public virtual partial DotRank? NodeRank { get; set; }

    /// <inheritdoc cref="IDotClusterLayoutAttributes.SortIndex"/>
    [DotAttributeKey(DotAttributeKeys.SortV)]
    public virtual partial int? SortIndex { get; set; }
}