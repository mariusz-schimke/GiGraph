using GiGraph.Dot.Entities.Attributes.Properties.Accessors;
using GiGraph.Dot.Entities.Edges.Endpoints.Attributes;

namespace GiGraph.Dot.Entities.Edges.Endpoints;

public partial class DotEdgeEndpoint
{
    public DotEdgeEndpoint(DotEdgeEndpointAttributes attributes)
    {
        Attributes = new(attributes);
    }

    /// <summary>
    ///     Provides access to edge attributes applied to the endpoint.
    /// </summary>
    public DotEntityAttributesAccessor<IDotEdgeEndpointAttributes, DotEdgeEndpointAttributes> Attributes { get; }
}