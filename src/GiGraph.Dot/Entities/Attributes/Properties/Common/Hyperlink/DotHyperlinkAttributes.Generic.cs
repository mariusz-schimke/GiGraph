using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Hyperlinks;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;

public abstract partial class DotHyperlinkAttributes<TIEntityHyperlinkAttributes, TEntityHyperlinkAttributes>
    : DotEntityAttributesWithMetadata<TIEntityHyperlinkAttributes, TEntityHyperlinkAttributes>, IDotHyperlinkAttributes
    where TIEntityHyperlinkAttributes : IDotHyperlinkAttributes
    where TEntityHyperlinkAttributes : DotHyperlinkAttributes<TIEntityHyperlinkAttributes, TEntityHyperlinkAttributes>, TIEntityHyperlinkAttributes
{
    protected DotHyperlinkAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <inheritdoc cref="IDotHyperlinkAttributes.Url"/>
    [DotAttributeKey(DotAttributeKeys.Url)]
    public virtual partial DotEscapeString? Url { get; set; }

    /// <inheritdoc cref="IDotHyperlinkAttributes.Href"/>
    [DotAttributeKey(DotAttributeKeys.Href)]
    public virtual partial DotEscapeString? Href { get; set; }

    /// <inheritdoc cref="IDotHyperlinkAttributes.Target"/>
    [DotAttributeKey(DotAttributeKeys.Target)]
    public virtual partial DotEscapeString? Target { get; set; }

    /// <summary>
    ///     Specifies hyperlink attributes.
    /// </summary>
    /// <param name="href">
    ///     The URL of the hyperlink. Equivalent to <paramref name="url"/>.
    /// </param>
    /// <param name="target">
    ///     The target of the hyperlink. See <see cref="DotHyperlinkTargets"/> for accepted values.
    /// </param>
    /// <param name="url">
    ///     The URL of the hyperlink. Equivalent to <paramref name="href"/>.
    /// </param>
    public virtual TEntityHyperlinkAttributes Set(DotEscapeString? href = null, DotEscapeString? target = null, DotEscapeString? url = null)
    {
        // make sure the param order of this method is equivalent to the order of params in equivalent methods in descendants
        // because they are all available as overloads, and it would be misleading if their initial params didn't overlap

        Href = href;
        Target = target;
        Url = url;

        return (TEntityHyperlinkAttributes) this;
    }

    /// <summary>
    ///     Specifies hyperlink attributes.
    /// </summary>
    /// <param name="attributes">
    ///     The attributes to set.
    /// </param>
    public virtual TEntityHyperlinkAttributes Set(DotHyperlink attributes) => Set(attributes.Href, attributes.Target, attributes.Url);
}