using GiGraph.Dot.Entities.Edges.Endpoints.Attributes;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    public class DotEdgeHead : DotEdgeEndpoint, IDotEdgeEndpointRootAttributes
    {
        public DotEdgeHead(DotEdgeHeadRootAttributes attributes)
            : base(attributes)
        {
        }
    }
}