using GiGraph.Dot.Entities.Edges.Endpoints.Attributes;
using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    public class DotEdgeTail<TEndpoint> : DotEdgeEndpoint<TEndpoint>
        where TEndpoint : DotEndpointDefinition, IDotOrderable
    {
        public DotEdgeTail(TEndpoint endpoint, DotEdgeTailRootAttributes attributes)
            : base(endpoint, attributes)
        {
        }
    }
}