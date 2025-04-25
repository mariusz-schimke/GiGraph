using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.Edges.Arrowheads;

namespace GiGraph.Dot.Entities.Edges.Endpoints.Attributes;

public partial class DotEdgeTailAttributes : DotEdgeEndpointAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotEdgeTailAttributes, IDotEdgeEndpointAttributes>().BuildLazy();

    public DotEdgeTailAttributes(DotAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup, new DotEdgeTailHyperlinkAttributes(attributes))
    {
    }

    /// <inheritdoc cref="IDotEdgeEndpointAttributes.Label" />
    [DotAttributeKey(DotAttributeKeys.TailLabel)]
    public override partial DotLabel? Label { get; set; }

    /// <inheritdoc cref="IDotEdgeEndpointAttributes.ClipToNodeBoundary" />
    [DotAttributeKey(DotAttributeKeys.TailClip)]
    public override partial bool? ClipToNodeBoundary { get; set; }

    /// <inheritdoc cref="IDotEdgeEndpointAttributes.GroupName" />
    [DotAttributeKey(DotAttributeKeys.SameTail)]
    public override partial string? GroupName { get; set; }

    /// <inheritdoc cref="IDotEdgeEndpointAttributes.Port" />
    [DotAttributeKey(DotAttributeKeys.TailPort)]
    public override partial DotEndpointPort? Port { get; set; }

    /// <inheritdoc cref="IDotEdgeEndpointAttributes.ClusterId" />
    [DotAttributeKey(DotAttributeKeys.LTail)]
    public override partial DotClusterId? ClusterId { get; set; }

    /// <inheritdoc cref="IDotEdgeEndpointAttributes.Arrowhead" />
    [DotAttributeKey(DotAttributeKeys.ArrowTail)]
    public override partial DotArrowheadDefinition? Arrowhead { get; set; }
}