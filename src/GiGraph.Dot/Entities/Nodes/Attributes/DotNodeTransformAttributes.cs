using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Geometry;

namespace GiGraph.Dot.Entities.Nodes.Attributes;

public partial class DotNodeTransformAttributes : DotEntityAttributesWithMetadata<IDotNodeTransformAttributes, DotNodeTransformAttributes>,
    IDotNodeTransformAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup =
        new DotMemberAttributeKeyLookupBuilder<DotNodeTransformAttributes, IDotNodeTransformAttributes>().BuildLazy();

    public DotNodeTransformAttributes(DotAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotNodeTransformAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <inheritdoc cref="IDotNodeTransformAttributes.Rotation"/>
    [DotAttributeKey(DotAttributeKeys.Orientation)]
    public virtual partial double? Rotation { get; set; }

    /// <inheritdoc cref="IDotNodeTransformAttributes.Skew"/>
    [DotAttributeKey(DotAttributeKeys.Skew)]
    public virtual partial double? Skew { get; set; }

    /// <inheritdoc cref="IDotNodeTransformAttributes.Distortion"/>
    [DotAttributeKey(DotAttributeKeys.Distortion)]
    public virtual partial double? Distortion { get; set; }

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
    public virtual DotNodeTransformAttributes Set(double? rotation, double? skew, double? distortion)
    {
        Rotation = rotation;
        Skew = skew;
        Distortion = distortion;
        return this;
    }

    /// <summary>
    ///     Sets polygon transform attributes.
    /// </summary>
    /// <param name="attributes">
    ///     The attributes to set.
    /// </param>
    public virtual DotNodeTransformAttributes Set(DotTransform attributes) => Set(attributes.Rotation, attributes.Skew, attributes.Distortion);
}