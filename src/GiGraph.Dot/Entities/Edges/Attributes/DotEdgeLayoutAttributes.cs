using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Entities.Edges.Attributes;

public partial class DotEdgeLayoutAttributes : DotEntityAttributesWithMetadata<IDotEdgeLayoutAttributes, DotEdgeLayoutAttributes>, IDotEdgeLayoutAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotEdgeLayoutAttributes, IDotEdgeLayoutAttributes>().BuildLazy();

    public DotEdgeLayoutAttributes(DotAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotEdgeLayoutAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <inheritdoc cref="IDotEdgeLayoutAttributes.Weight"/>
    [DotAttributeKey(DotAttributeKeys.Weight)]
    public virtual partial double? Weight { get; set; }

    /// <inheritdoc cref="IDotEdgeLayoutAttributes.Length"/>
    [DotAttributeKey(DotAttributeKeys.Len)]
    public virtual partial double? Length { get; set; }

    /// <inheritdoc cref="IDotEdgeLayoutAttributes.MinLength"/>
    [DotAttributeKey(DotAttributeKeys.MinLen)]
    public virtual partial int? MinLength { get; set; }

    /// <inheritdoc cref="IDotEdgeLayoutAttributes.AllowLabelFloating"/>
    [DotAttributeKey(DotAttributeKeys.LabelFloat)]
    public virtual partial bool? AllowLabelFloating { get; set; }

    /// <inheritdoc cref="IDotEdgeLayoutAttributes.IncludeInNodeRanking"/>
    [DotAttributeKey(DotAttributeKeys.Constraint)]
    public virtual partial bool? IncludeInNodeRanking { get; set; }
}