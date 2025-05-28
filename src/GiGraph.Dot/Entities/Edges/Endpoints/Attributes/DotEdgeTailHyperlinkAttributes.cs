using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Edges.Attributes;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Hyperlinks;

namespace GiGraph.Dot.Entities.Edges.Endpoints.Attributes;

public partial class DotEdgeTailHyperlinkAttributes : DotEdgeEndpointHyperlinkAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotEdgeTailHyperlinkAttributes, IDotEdgeHyperlinkAttributes>().BuildLazy();

    public DotEdgeTailHyperlinkAttributes(DotAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup)
    {
    }

    /// <summary>
    ///     If defined, it is output as part of the tail <see cref="IDotEdgeEndpointAttributes.Label" /> of the edge (svg, map only).
    ///     Also, this value is used near the tail node, overriding any <see cref="IDotEdgeRootAttributes.Hyperlink" />
    ///     <see cref="IDotHyperlinkAttributes.Url" /> set for the edge.
    /// </summary>
    [DotAttributeKey(DotAttributeKeys.TailUrl)]
    public override partial DotEscapeString? Url { get; set; }

    /// <summary>
    ///     Synonym for <see cref="Url" /> (svg, map only).
    /// </summary>
    [DotAttributeKey(DotAttributeKeys.TailHref)]
    public override partial DotEscapeString? Href { get; set; }

    /// <summary>
    ///     If <see cref="Url" /> is specified, this attribute determines which window of the browser is used for the URL (svg, map
    ///     only). Setting it to <see cref="DotHyperlinkTargets.Graphviz" /> will open a new window if it doesn't already exist, or
    ///     reuse it if it does. If undefined, the value of the edge's <see cref="IDotEdgeRootAttributes.Hyperlink" />
    ///     <see cref="IDotHyperlinkAttributes.Target" /> is used.
    /// </summary>
    [DotAttributeKey(DotAttributeKeys.TailTarget)]
    public override partial DotEscapeString? Target { get; set; }

    /// <summary>
    ///     Tooltip annotation attached to the tail of an edge (svg, cmap only). This is used only if <see cref="Url" /> is specified.
    /// </summary>
    [DotAttributeKey(DotAttributeKeys.TailTooltip)]
    public override partial DotEscapeString? Tooltip { get; set; }
}