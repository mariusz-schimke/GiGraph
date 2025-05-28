using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Geometry;

namespace GiGraph.Dot.Entities.Nodes.Attributes;

public partial class DotNodeSizeAttributes : DotEntityAttributesWithMetadata<IDotNodeSizeAttributes, DotNodeSizeAttributes>, IDotNodeSizeAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup =
        new DotMemberAttributeKeyLookupBuilder<DotNodeSizeAttributes, IDotNodeSizeAttributes>().BuildLazy();

    public DotNodeSizeAttributes(DotAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotNodeSizeAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <inheritdoc cref="IDotNodeSizeAttributes.Width"/>
    [DotAttributeKey(DotAttributeKeys.Width)]
    public virtual partial double? Width { get; set; }

    /// <inheritdoc cref="IDotNodeSizeAttributes.Height"/>
    [DotAttributeKey(DotAttributeKeys.Height)]
    public virtual partial double? Height { get; set; }

    /// <inheritdoc cref="IDotNodeSizeAttributes.Mode"/>
    [DotAttributeKey(DotAttributeKeys.FixedSize)]
    public virtual partial DotSizing? Mode { get; set; }

    /// <summary>
    ///     Sets size attributes.
    /// </summary>
    /// <param name="width">
    ///     The width to set.
    /// </param>
    /// <param name="height">
    ///     The width to set.
    /// </param>
    public virtual DotNodeSizeAttributes Set(double? width, double? height)
    {
        Width = width;
        Height = height;
        return this;
    }

    /// <summary>
    ///     Sets size attributes.
    /// </summary>
    /// <param name="width">
    ///     The width to set.
    /// </param>
    /// <param name="height">
    ///     The width to set.
    /// </param>
    /// <param name="mode">
    ///     The sizing mode to set.
    /// </param>
    public virtual DotNodeSizeAttributes Set(double? width, double? height, DotSizing? mode)
    {
        Mode = mode;
        return Set(width, height);
    }

    /// <summary>
    ///     Sets size attributes.
    /// </summary>
    /// <param name="attributes">
    ///     The attributes to set.
    /// </param>
    public virtual DotNodeSizeAttributes Set(DotSize attributes) => Set(attributes.Width, attributes.Height, attributes.Mode);
}