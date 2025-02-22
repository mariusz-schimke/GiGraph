﻿using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Fonts;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.Font;

public abstract partial class DotFontAttributes<TIEntityFontAttributes, TEntityFontAttributes>
    : DotEntityAttributesWithMetadata<TIEntityFontAttributes, TEntityFontAttributes>, IDotFontAttributes
    where TIEntityFontAttributes : IDotFontAttributes
    where TEntityFontAttributes : DotFontAttributes<TIEntityFontAttributes, TEntityFontAttributes>, TIEntityFontAttributes
{
    protected DotFontAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <inheritdoc cref="IDotFontAttributes.Name" />
    [DotAttributeKey(DotAttributeKeys.FontName)]
    public virtual partial string? Name { get; set; }

    /// <inheritdoc cref="IDotFontAttributes.Size" />
    [DotAttributeKey(DotAttributeKeys.FontSize)]
    public virtual partial double? Size { get; set; }

    /// <inheritdoc cref="IDotFontAttributes.Color" />
    [DotAttributeKey(DotAttributeKeys.FontColor)]
    public virtual partial DotColor? Color { get; set; }

    /// <summary>
    ///     Sets font attributes.
    /// </summary>
    /// <param name="name">
    ///     Font name.
    /// </param>
    /// <param name="size">
    ///     Font size.
    /// </param>
    /// <param name="color">
    ///     Font color.
    /// </param>
    public virtual void Set(string? name = null, double? size = null, DotColor? color = null)
    {
        Size = size;
        Color = color;
        Name = name;
    }

    /// <summary>
    ///     Sets font attributes.
    /// </summary>
    /// <param name="attributes">
    ///     The attributes to set.
    /// </param>
    public virtual void Set(DotFont attributes)
    {
        Set(attributes.Name, attributes.Size, attributes.Color);
    }

    /// <summary>
    ///     Copies font attributes from the specified instance.
    /// </summary>
    /// <param name="attributes">
    ///     The instance to copy the attributes from.
    /// </param>
    public virtual void Set(IDotFontAttributes attributes)
    {
        Set(attributes.Name, attributes.Size, attributes.Color);
    }
}