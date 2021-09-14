using GiGraph.Dot.Entities.Edges.Endpoints.Attributes;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    public class DotEdgeTail : DotEdgeEndpoint, IDotEdgeEndpointRootAttributes
    {
        public DotEdgeTail(DotEdgeTailRootAttributes attributes)
            : base(attributes)
        {
        }
    }
}