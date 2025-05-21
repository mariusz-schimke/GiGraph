using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Hyperlinks;

namespace GiGraph.Dot.Entities.Html.Table.Attributes;

public partial class DotHtmlTableTableCellHyperlinkAttributes : DotEntityAttributes<IDotHtmlTableTableCellHyperlinkAttributes, DotHtmlTableTableCellHyperlinkAttributes>,
    IDotHtmlTableTableCellHyperlinkAttributes, IDotHasHyperlinkAttributesWithTooltip
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotHtmlTableTableCellHyperlinkAttributes, IDotHtmlTableTableCellHyperlinkAttributes>().BuildLazy();

    public DotHtmlTableTableCellHyperlinkAttributes(DotHtmlAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotHtmlTableTableCellHyperlinkAttributes(DotHtmlAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <inheritdoc cref="IDotHtmlTableTableCellHyperlinkAttributes.Href"/>
    [DotAttributeKey("href")]
    public virtual partial DotEscapeString? Href { get; set; }

    /// <inheritdoc cref="IDotHtmlTableTableCellHyperlinkAttributes.Target"/>
    [DotAttributeKey("target")]
    public virtual partial DotEscapeString? Target { get; set; }

    /// <inheritdoc cref="IDotHtmlTableTableCellHyperlinkAttributes.Title"/>
    [DotAttributeKey("title")]
    public virtual partial DotEscapeString? Title { get; set; }

    /// <inheritdoc cref="IDotHtmlTableTableCellHyperlinkAttributes.Tooltip"/>
    [DotAttributeKey("tooltip")]
    public virtual partial DotEscapeString? Tooltip { get; set; }

    /// <summary>
    ///     Specifies hyperlink attributes.
    /// </summary>
    /// <param name="attributes">
    ///     The attributes to set.
    /// </param>
    public virtual DotHtmlTableTableCellHyperlinkAttributes Set(DotHyperlink attributes)
    {
        Href = attributes.Href;
        Target = attributes.Target;
        Title = attributes.Title;
        Tooltip = attributes.Tooltip;
        return this;
    }
}