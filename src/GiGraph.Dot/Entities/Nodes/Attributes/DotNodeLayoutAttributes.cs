using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Edges.Layout;

namespace GiGraph.Dot.Entities.Nodes.Attributes;

public partial class DotNodeLayoutAttributes : DotEntityAttributesWithMetadata<IDotNodeLayoutAttributes, DotNodeLayoutAttributes>, IDotNodeLayoutAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotNodeLayoutAttributes, IDotNodeLayoutAttributes>().BuildLazy();

    public DotNodeLayoutAttributes(DotAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotNodeLayoutAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <inheritdoc cref="IDotNodeLayoutAttributes.EdgeOrderingMode"/>
    [DotAttributeKey(DotAttributeKeys.Ordering)]
    public virtual partial DotEdgeOrderingMode? EdgeOrderingMode { get; set; }

    /// <inheritdoc cref="IDotNodeLayoutAttributes.GroupName"/>
    [DotAttributeKey(DotAttributeKeys.Group)]
    public virtual partial string? GroupName { get; set; }

    /// <inheritdoc cref="IDotNodeLayoutAttributes.IsLayoutRoot"/>
    [DotAttributeKey(DotAttributeKeys.Root)]
    public virtual partial bool? IsLayoutRoot { get; set; }

    /// <inheritdoc cref="IDotNodeLayoutAttributes.SortIndex"/>
    [DotAttributeKey(DotAttributeKeys.SortV)]
    public virtual partial int? SortIndex { get; set; }
}