using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Geometry;

namespace GiGraph.Dot.Entities.Nodes.Attributes;

public partial class DotNodeGeometryAttributes : DotEntityAttributesWithMetadata<IDotNodeGeometryAttributes, DotNodeGeometryAttributes>,
    IDotNodeGeometryAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup =
        new DotMemberAttributeKeyLookupBuilder<DotNodeGeometryAttributes, IDotNodeGeometryAttributes>().BuildLazy();

    public DotNodeGeometryAttributes(DotAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotNodeGeometryAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <inheritdoc cref="IDotNodeGeometryAttributes.Sides"/>
    [DotAttributeKey(DotAttributeKeys.Sides)]
    public virtual partial int? Sides { get; set; }

    /// <inheritdoc cref="IDotNodeGeometryAttributes.Regular"/>
    [DotAttributeKey(DotAttributeKeys.Regular)]
    public virtual partial bool? Regular { get; set; }

    /// <summary>
    ///     Sets polygon geometry attributes.
    /// </summary>
    /// <param name="sides">
    ///     The number of sides.
    /// </param>
    /// <param name="regular">
    ///     Determines whether the shape should be regular.
    /// </param>
    public virtual DotNodeGeometryAttributes Set(int? sides, bool? regular)
    {
        Sides = sides;
        Regular = regular;
        return this;
    }

    /// <summary>
    ///     Sets polygon geometry attributes.
    /// </summary>
    /// <param name="attributes">
    ///     The attributes to set.
    /// </param>
    public virtual DotNodeGeometryAttributes Set(DotPolygon attributes) => Set(attributes.Sides, attributes.Regular);
}