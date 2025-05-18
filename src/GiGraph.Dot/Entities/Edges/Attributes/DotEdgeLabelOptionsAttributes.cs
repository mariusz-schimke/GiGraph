using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Entities.Edges.Attributes;

public partial class DotEdgeLabelOptionsAttributes : DotEntityAttributesWithMetadata<IDotEdgeLabelOptionsAttributes, DotEdgeLabelOptionsAttributes>, IDotEdgeLabelOptionsAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotEdgeLabelOptionsAttributes, IDotEdgeLabelOptionsAttributes>().BuildLazy();

    public DotEdgeLabelOptionsAttributes(DotAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotEdgeLabelOptionsAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <inheritdoc cref="IDotEdgeLabelOptionsAttributes.DisableJustification"/>
    [DotAttributeKey(DotAttributeKeys.NoJustify)]
    public virtual partial bool? DisableJustification { get; set; }

    /// <inheritdoc cref="IDotEdgeLabelOptionsAttributes.LabelConnector"/>
    [DotAttributeKey(DotAttributeKeys.Decorate)]
    public virtual partial bool? LabelConnector { get; set; }
}