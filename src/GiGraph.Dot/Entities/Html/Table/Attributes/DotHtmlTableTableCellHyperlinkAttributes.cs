using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Hyperlinks;

namespace GiGraph.Dot.Entities.Html.Table.Attributes;

public partial class DotHtmlTableTableCellHyperlinkAttributes : DotEntityAttributes<IDotHtmlTableHyperlinkAttributes, DotHtmlTableTableCellHyperlinkAttributes>, IDotHtmlTableHyperlinkAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotHtmlTableTableCellHyperlinkAttributes, IDotHtmlTableHyperlinkAttributes>().BuildLazy();

    public DotHtmlTableTableCellHyperlinkAttributes(DotHtmlAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotHtmlTableTableCellHyperlinkAttributes(DotHtmlAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
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

    /// <summary>
    ///     Specifies hyperlink attributes.
    /// </summary>
    /// <param name="href">
    ///     The URL of the hyperlink.
    /// </param>
    /// <param name="target">
    ///     The target of the hyperlink. See <see cref="DotHyperlinkTargets"/> for accepted values.
    /// </param>
    /// <param name="tooltip">
    ///     The tooltip of the hyperlink. Equivalent to <paramref name="title"/>.
    /// </param>
    /// <param name="title">
    ///     The tooltip of the hyperlink. Equivalent to <paramref name="tooltip"/>.
    /// </param>
    public virtual void Set(DotEscapeString? href, DotEscapeString? target = null, DotEscapeString? tooltip = null, DotEscapeString? title = null)
    {
        Href = href;
        Target = target;
        Tooltip = tooltip;
        Title = title;
    }

    /// <summary>
    ///     Specifies hyperlink attributes.
    /// </summary>
    /// <param name="attributes">
    ///     The attributes to set.
    /// </param>
    public virtual void Set(DotHyperlink attributes)
    {
        Set(attributes.Href, attributes.Target, attributes.Tooltip, attributes.Title);
    }
}