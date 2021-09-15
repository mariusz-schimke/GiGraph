using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Edges.Endpoints.Attributes;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    public partial class DotEdgeEndpoint
    {
        public DotEdgeEndpoint(DotEdgeEndpointRootAttributes attributes)
        {
            Attributes = new DotEntityAttributesAccessor<IDotEdgeEndpointAttributes, DotEdgeEndpointRootAttributes>(attributes);
        }

        /// <summary>
        ///     Provides access to edge attributes applied to the endpoint.
        /// </summary>
        public DotEntityAttributesAccessor<IDotEdgeEndpointAttributes, DotEdgeEndpointRootAttributes> Attributes { get; }
    }
}