using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Geometry;
using GiGraph.Dot.Types.Nodes;

namespace GiGraph.Dot.Entities.Nodes.Attributes;

public partial class DotNodeSizeAttributes : DotEntityAttributesWithMetadata<IDotNodeSizeAttributes, DotNodeSizeAttributes>, IDotNodeSizeAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotNodeSizeAttributes, IDotNodeSizeAttributes>().BuildLazy();

    public DotNodeSizeAttributes(DotAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotNodeSizeAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <inheritdoc cref="IDotNodeSizeAttributes.Width" />
    [DotAttributeKey(DotAttributeKeys.Width)]
    public virtual partial double? Width { get; set; }

    /// <inheritdoc cref="IDotNodeSizeAttributes.Height" />
    [DotAttributeKey(DotAttributeKeys.Height)]
    public virtual partial double? Height { get; set; }

    /// <inheritdoc cref="IDotNodeSizeAttributes.Mode" />
    [DotAttributeKey(DotAttributeKeys.FixedSize)]
    public virtual partial DotNodeSizing? Mode { get; set; }

    /// <summary>
    ///     Sets size attributes.
    /// </summary>
    /// <paramref name="width">
    ///     The width to set.
    /// </paramref>
    /// <paramref name="height">
    ///     The width to set.
    /// </paramref>
    public virtual void Set(double? width, double? height)
    {
        Width = width;
        Height = height;
    }

    /// <summary>
    ///     Sets size attributes.
    /// </summary>
    /// <paramref name="width">
    ///     The width to set.
    /// </paramref>
    /// <paramref name="height">
    ///     The width to set.
    /// </paramref>
    /// <paramref name="mode">
    ///     The sizing mode to set.
    /// </paramref>
    public virtual void Set(double? width, double? height, DotNodeSizing? mode)
    {
        Set(width, height);
        Mode = mode;
    }

    /// <summary>
    ///     Sets size attributes.
    /// </summary>
    /// <param name="attributes">
    ///     The attributes to set.
    /// </param>
    public virtual void Set(DotSize attributes)
    {
        Set(attributes.Width, attributes.Height);
    }

    /// <summary>
    ///     Sets size attributes.
    /// </summary>
    /// <param name="attributes">
    ///     The attributes to set.
    /// </param>
    public virtual void Set(DotNodeSize attributes)
    {
        Set(attributes.Width, attributes.Height, attributes.Mode);
    }

    /// <summary>
    ///     Copies size attributes from the specified instance.
    /// </summary>
    /// <param name="attributes">
    ///     The instance to copy the attributes from.
    /// </param>
    public virtual void Set(IDotNodeSizeAttributes attributes)
    {
        Set(attributes.Width, attributes.Height, attributes.Mode);
    }
}