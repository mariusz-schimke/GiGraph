using GiGraph.Dot.Entities.Edges.Endpoints.Attributes;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    public abstract partial class DotEdgeEndpoint
    {
        protected readonly IDotEdgeEndpointAttributes _attributes;

        protected DotEdgeEndpoint(IDotEdgeEndpointAttributes attributes)
        {
            _attributes = attributes;
        }
    }
}