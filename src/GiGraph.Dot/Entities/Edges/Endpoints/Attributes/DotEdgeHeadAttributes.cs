using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.Edges.Arrowheads;

namespace GiGraph.Dot.Entities.Edges.Endpoints.Attributes;

public partial class DotEdgeHeadAttributes : DotEdgeEndpointAttributes
{
    private static readonly Lazy<DotMemberAttributeKeyLookup> AttributeKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotEdgeHeadAttributes, IDotEdgeEndpointAttributes>().BuildLazy();

    public DotEdgeHeadAttributes(DotAttributeCollection attributes)
        : base(attributes, AttributeKeyLookup, new DotEdgeHeadHyperlinkAttributes(attributes))
    {
    }

    /// <inheritdoc cref="IDotEdgeEndpointAttributes.Label" />
    [DotAttributeKey(DotAttributeKeys.HeadLabel)]
    public override partial DotLabel? Label { get; set; }

    /// <inheritdoc cref="IDotEdgeEndpointAttributes.ClipToNodeBoundary" />
    [DotAttributeKey(DotAttributeKeys.HeadClip)]
    public override partial bool? ClipToNodeBoundary { get; set; }

    /// <inheritdoc cref="IDotEdgeEndpointAttributes.GroupName" />
    [DotAttributeKey(DotAttributeKeys.SameHead)]
    public override partial string? GroupName { get; set; }

    /// <inheritdoc cref="IDotEdgeEndpointAttributes.Port" />
    [DotAttributeKey(DotAttributeKeys.HeadPort)]
    public override partial DotEndpointPort? Port { get; set; }

    /// <inheritdoc cref="IDotEdgeEndpointAttributes.ClusterId" />
    [DotAttributeKey(DotAttributeKeys.LHead)]
    public override partial DotClusterId? ClusterId { get; set; }

    /// <inheritdoc cref="IDotEdgeEndpointAttributes.Arrowhead" />
    [DotAttributeKey(DotAttributeKeys.Arrowhead)]
    public override partial DotArrowheadDefinition? Arrowhead { get; set; }
}