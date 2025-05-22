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

    /// <inheritdoc cref="IDotNodeGeometryAttributes.Rotation"/>
    [DotAttributeKey(DotAttributeKeys.Orientation)]
    public virtual partial double? Rotation { get; set; }

    /// <inheritdoc cref="IDotNodeGeometryAttributes.Skew"/>
    [DotAttributeKey(DotAttributeKeys.Skew)]
    public virtual partial double? Skew { get; set; }

    /// <inheritdoc cref="IDotNodeGeometryAttributes.Distortion"/>
    [DotAttributeKey(DotAttributeKeys.Distortion)]
    public virtual partial double? Distortion { get; set; }

    /// <summary>
    ///     Sets polygon geometry attributes.
    /// </summary>
    /// <param name="sides">
    ///     The number of sides.
    /// </param>
    /// <param name="regular">
    ///     Determines whether the shape should be regular.
    /// </param>
    public virtual DotNodeGeometryAttributes SetGeometry(int? sides, bool? regular)
    {
        Sides = sides;
        Regular = regular;
        return this;
    }

    /// <summary>
    ///     Sets polygon transform attributes.
    /// </summary>
    /// <param name="rotation">
    ///     The rotation angle.
    /// </param>
    /// <param name="skew">
    ///     The skew factor.
    /// </param>
    /// <param name="distortion">
    ///     The distortion factor.
    /// </param>
    public virtual DotNodeGeometryAttributes SetTransform(double? rotation, double? skew, double? distortion)
    {
        Rotation = rotation;
        Skew = skew;
        Distortion = distortion;
        return this;
    }

    /// <summary>
    ///     Sets polygon geometry attributes.
    /// </summary>
    /// <param name="attributes">
    ///     The attributes to set.
    /// </param>
    public virtual DotNodeGeometryAttributes SetGeometry(DotPolygon attributes) => SetGeometry(attributes.Sides, attributes.Regular);

    /// <summary>
    ///     Sets polygon transform attributes.
    /// </summary>
    /// <param name="attributes">
    ///     The attributes to set.
    /// </param>
    public virtual DotNodeGeometryAttributes SetTransform(DotTransform attributes) => SetTransform(attributes.Rotation, attributes.Skew, attributes.Distortion);
}