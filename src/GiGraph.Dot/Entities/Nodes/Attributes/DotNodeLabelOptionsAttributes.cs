using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Alignment;
using GiGraph.Dot.Types.Geometry;

namespace GiGraph.Dot.Entities.Nodes.Attributes;

public partial class DotNodeLabelOptionsAttributes : DotEntityAttributesWithMetadata<IDotNodeLabelOptionsAttributes, DotNodeLabelOptionsAttributes>, IDotNodeLabelOptionsAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotNodeLabelOptionsAttributes, IDotNodeLabelOptionsAttributes>().BuildLazy();

    public DotNodeLabelOptionsAttributes(DotAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotNodeLabelOptionsAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <inheritdoc cref="IDotNodeLabelOptionsAttributes.VerticalAlignment"/>
    [DotAttributeKey(DotAttributeKeys.LabelLoc)]
    public virtual partial DotVerticalAlignment? VerticalAlignment { get; set; }

    /// <inheritdoc cref="IDotNodeLabelOptionsAttributes.Margin"/>
    [DotAttributeKey(DotAttributeKeys.Margin)]
    public virtual partial DotPoint? Margin { get; set; }

    /// <inheritdoc cref="IDotNodeLabelOptionsAttributes.DisableJustification"/>
    [DotAttributeKey(DotAttributeKeys.NoJustify)]
    public virtual partial bool? DisableJustification { get; set; }
}