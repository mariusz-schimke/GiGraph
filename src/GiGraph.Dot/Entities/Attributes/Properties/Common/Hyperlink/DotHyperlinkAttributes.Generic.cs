﻿using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Hyperlinks;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;

public abstract class DotHyperlinkAttributes<TIEntityHyperlinkAttributes, TEntityHyperlinkAttributes>
    : DotEntityAttributesWithMetadata<TIEntityHyperlinkAttributes, TEntityHyperlinkAttributes>, IDotHyperlinkAttributes
    where TIEntityHyperlinkAttributes : IDotHyperlinkAttributes
    where TEntityHyperlinkAttributes : DotHyperlinkAttributes<TIEntityHyperlinkAttributes, TEntityHyperlinkAttributes>, TIEntityHyperlinkAttributes
{
    protected DotHyperlinkAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <inheritdoc cref="IDotHyperlinkAttributes.Url" />
    [DotAttributeKey(DotAttributeKeys.Url)]
    public virtual DotEscapeString? Url
    {
        get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
        set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
    }

    /// <inheritdoc cref="IDotHyperlinkAttributes.Href" />
    [DotAttributeKey(DotAttributeKeys.Href)]
    public virtual DotEscapeString? Href
    {
        get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
        set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
    }

    /// <inheritdoc cref="IDotHyperlinkAttributes.Target" />
    [DotAttributeKey(DotAttributeKeys.Target)]
    public virtual DotEscapeString? Target
    {
        get => GetValueAsEscapeString(MethodBase.GetCurrentMethod());
        set => SetOrRemove(MethodBase.GetCurrentMethod(), value);
    }

    /// <summary>
    ///     Specifies hyperlink attributes.
    /// </summary>
    /// <param name="url">
    ///     The URL of the hyperlink.
    /// </param>
    /// <param name="target">
    ///     The target of the hyperlink. See <see cref="DotHyperlinkTargets" /> for accepted values.
    /// </param>
    public virtual void Set(DotEscapeString? url, DotEscapeString? target = null)
    {
        Url = url;
        Target = target;
    }

    protected virtual void SetAll(DotEscapeString? url, DotEscapeString? target, DotEscapeString? href)
    {
        Href = href;
        Set(url, target);
    }

    /// <summary>
    ///     Specifies hyperlink attributes.
    /// </summary>
    /// <param name="attributes">
    ///     The attributes to set.
    /// </param>
    public virtual void Set(DotHyperlink attributes)
    {
        SetAll(attributes.Url, attributes.Target, attributes.Href);
    }

    /// <summary>
    ///     Copies hyperlink attributes from the specified instance.
    /// </summary>
    /// <param name="attributes">
    ///     The instance to copy the attributes from.
    /// </param>
    public virtual void Set(IDotHyperlinkAttributes attributes)
    {
        SetAll(attributes.Url, attributes.Target, attributes.Href);
    }
}