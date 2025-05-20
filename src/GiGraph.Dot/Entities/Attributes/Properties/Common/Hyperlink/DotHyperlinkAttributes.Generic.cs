using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Hyperlinks;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;

public abstract partial class DotHyperlinkAttributes<TIEntityHyperlinkAttributes, TEntityHyperlinkAttributes>
    : DotEntityAttributesWithMetadata<TIEntityHyperlinkAttributes, TEntityHyperlinkAttributes>, IDotHyperlinkAttributes, IDotHasHyperlink
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
    /// <param name="attributes">
    ///     The attributes to set.
    /// </param>
    public virtual TEntityHyperlinkAttributes Set(DotHyperlink attributes)
    {
        Url = attributes.Url;
        Href = attributes.Href;
        Target = attributes.Target;
        return (TEntityHyperlinkAttributes) this;
    }
}