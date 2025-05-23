using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.Edges.Arrowheads;

namespace GiGraph.Dot.Entities.Edges.Endpoints.Attributes;

public abstract class DotEdgeEndpointAttributes(
    DotAttributeCollection attributes,
    Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup,
    DotEdgeEndpointHyperlinkAttributes hyperlinkAttributes
)
    : DotEntityAttributesWithMetadata<IDotEdgeEndpointAttributes, DotEdgeEndpointAttributes>(attributes, attributeKeyLookup), IDotEdgeEndpointRootAttributes
{
    /// <inheritdoc cref="IDotEdgeEndpointRootAttributes.Hyperlink" />
    public DotEdgeEndpointHyperlinkAttributes Hyperlink { get; } = hyperlinkAttributes;

    /// <inheritdoc cref="IDotEdgeEndpointAttributes.Label" />
    public abstract DotLabel? Label { get; set; }

    /// <inheritdoc cref="IDotEdgeEndpointAttributes.ClipToNodeBoundary" />
    public abstract bool? ClipToNodeBoundary { get; set; }

    /// <inheritdoc cref="IDotEdgeEndpointAttributes.GroupName" />
    public abstract string? GroupName { get; set; }

    /// <inheritdoc cref="IDotEdgeEndpointAttributes.Port" />
    public abstract DotEndpointPort? Port { get; set; }

    /// <inheritdoc cref="IDotEdgeEndpointAttributes.ClusterId" />
    public abstract DotClusterId? ClusterId { get; set; }

    /// <inheritdoc cref="IDotEdgeEndpointAttributes.Arrowhead" />
    public abstract DotArrowheadDefinition? Arrowhead { get; set; }
}