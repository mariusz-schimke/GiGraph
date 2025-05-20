using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Edges.Endpoints.Attributes;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Hyperlinks;

namespace GiGraph.Dot.Entities.Edges.Attributes;

public partial class DotEdgeHyperlinkAttributes : DotHyperlinkAttributes<IDotEdgeHyperlinkAttributes, DotEdgeHyperlinkAttributes>, IDotEdgeHyperlinkAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotEdgeHyperlinkAttributes, IDotEdgeHyperlinkAttributes>().BuildLazy();

    public DotEdgeHyperlinkAttributes(DotAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotEdgeHyperlinkAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <summary>
    ///     If defined, this is the link used for the non-label parts of the edge (svg, map only). Used near the head or the tail node,
    ///     unless overridden by the <see cref="IDotHyperlinkAttributes.Url"/> on the head's or tail's
    ///     <see cref="IDotEdgeEndpointRootAttributes.Hyperlink"/> attributes of the edge. This value overrides any
    ///     <see cref="IDotHyperlinkAttributes.Url"/> specified for the edge's <see cref="IDotEdgeRootAttributes.Hyperlink"/>.
    /// </summary>
    [DotAttributeKey(DotAttributeKeys.EdgeUrl)]
    public override partial DotEscapeString? Url { get; set; }

    /// <summary>
    ///     Synonym for <see cref="Url"/> (svg, map only).
    /// </summary>
    [DotAttributeKey(DotAttributeKeys.EdgeHref)]
    public override partial DotEscapeString? Href { get; set; }

    /// <summary>
    ///     If <see cref="Url"/> is specified, or if the edge has a <see cref="IDotEdgeRootAttributes.Hyperlink"/>
    ///     <see cref="IDotHyperlinkAttributes.Url"/> attribute specified, determines which window of the browser is used for the URL
    ///     attached to the non-label part of the edge (svg, map only). Setting it to <see cref="DotHyperlinkTargets.Graphviz"/> will
    ///     open a new window if it doesn't already exist, or reuse it if it does. If undefined, the value of the edge's
    ///     <see cref="IDotEdgeRootAttributes.Hyperlink"/> <see cref="IDotHyperlinkAttributes.Target"/> is used.
    /// </summary>
    [DotAttributeKey(DotAttributeKeys.EdgeTarget)]
    public override partial DotEscapeString? Target { get; set; }

    /// <summary>
    ///     Tooltip annotation attached to the non-label part of the edge (svg, cmap only). This is used only if <see cref="Url"/> is
    ///     specified, or if the edge has a <see cref="IDotEdgeRootAttributes.Hyperlink"/> <see cref="IDotHyperlinkAttributes.Url"/>
    ///     specified.
    /// </summary>
    [DotAttributeKey(DotAttributeKeys.EdgeTooltip)]
    public virtual partial DotEscapeString? Tooltip { get; set; }

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
    /// <param name="tooltip">
    ///     The tooltip of the hyperlink.
    /// </param>
    public virtual DotEdgeHyperlinkAttributes Set(DotEscapeString? href = null, DotEscapeString? target = null, DotEscapeString? url = null, DotEscapeString? tooltip = null)
    {
        Tooltip = tooltip;

        // make sure the order of params here is equivalent to the order of params in the base method because they are both available
        // on the edge as overloads, and it would be misleading if the initial params didn't overlap
        return base.Set(href, target, url);
    }

    /// <summary>
    ///     Specifies hyperlink attributes.
    /// </summary>
    /// <param name="attributes">
    ///     The attributes to set.
    /// </param>
    public override DotEdgeHyperlinkAttributes Set(DotHyperlink attributes) => Set(attributes.Href, attributes.Target, attributes.Url, attributes.Tooltip);
}