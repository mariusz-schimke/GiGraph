using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Hyperlinks;

namespace GiGraph.Dot.Entities.Edges.Attributes;

public partial class DotEdgeLabelHyperlinkAttributes : DotEdgeHyperlinkAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotEdgeLabelHyperlinkAttributes, IDotEdgeHyperlinkAttributes>().BuildLazy();

    public DotEdgeLabelHyperlinkAttributes(DotAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    protected DotEdgeLabelHyperlinkAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
    }

    /// <summary>
    ///     If defined, this is the link used for the label of the edge (svg, map only). This value overrides any
    ///     <see cref="IDotEdgeRootAttributes.Hyperlink" /> <see cref="IDotHyperlinkAttributes.Url" /> defined for the edge.
    /// </summary>
    [DotAttributeKey(DotAttributeKeys.LabelUrl)]
    public override partial DotEscapeString? Url { get; set; }

    /// <summary>
    ///     Synonym for <see cref="Url" /> (svg, map only).
    /// </summary>
    [DotAttributeKey(DotAttributeKeys.LabelHref)]
    public override partial DotEscapeString? Href { get; set; }

    /// <summary>
    ///     If <see cref="Url" /> is specified, or if the edge has a <see cref="IDotEdgeRootAttributes.Hyperlink" />
    ///     <see cref="IDotHyperlinkAttributes.Url" /> specified, this attribute determines which window of the browser is used for the
    ///     URL attached to the label (svg, map only). Setting it to <see cref="DotHyperlinkTargets.NewWindow" /> will open a new window
    ///     if it doesn't already exist, or reuse it if it does. If undefined, the value of the edge's
    ///     <see cref="IDotEdgeRootAttributes.Hyperlink" /> <see cref="IDotHyperlinkAttributes.Target" /> is used.
    /// </summary>
    [DotAttributeKey(DotAttributeKeys.LabelTarget)]
    public override partial DotEscapeString? Target { get; set; }

    /// <summary>
    ///     Tooltip annotation attached to the label of the edge (svg, cmap only). This is used only if <see cref="Url" /> is specified,
    ///     or if the edge has a <see cref="IDotEdgeRootAttributes.Hyperlink" /> <see cref="IDotHyperlinkAttributes.Url" /> specified.
    /// </summary>
    [DotAttributeKey(DotAttributeKeys.LabelTooltip)]
    public override partial DotEscapeString? Tooltip { get; set; }
}