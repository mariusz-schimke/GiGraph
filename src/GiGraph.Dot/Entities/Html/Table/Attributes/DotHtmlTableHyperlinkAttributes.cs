using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.EscapeString;

namespace GiGraph.Dot.Entities.Html.Table.Attributes;

public partial class DotHtmlTableHyperlinkAttributes : DotEntityAttributes<IDotHtmlTableHyperlinkAttributes, DotHtmlTableHyperlinkAttributes>, IDotHtmlTableHyperlinkAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotHtmlTableHyperlinkAttributes, IDotHtmlTableHyperlinkAttributes>().BuildLazy();

    public DotHtmlTableHyperlinkAttributes(DotHtmlAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotHtmlTableHyperlinkAttributes(DotHtmlAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <inheritdoc cref="IDotHtmlTableHyperlinkAttributes.Href"/>
    [DotAttributeKey("href")]
    public virtual partial DotEscapeString? Href { get; set; }

    /// <inheritdoc cref="IDotHtmlTableHyperlinkAttributes.Target"/>
    [DotAttributeKey("target")]
    public virtual partial DotEscapeString? Target { get; set; }

    /// <inheritdoc cref="IDotHtmlTableHyperlinkAttributes.Title"/>
    [DotAttributeKey("title")]
    public virtual partial DotEscapeString? Title { get; set; }

    /// <inheritdoc cref="IDotHtmlTableHyperlinkAttributes.Tooltip"/>
    [DotAttributeKey("tooltip")]
    public virtual partial DotEscapeString? Tooltip { get; set; }
}