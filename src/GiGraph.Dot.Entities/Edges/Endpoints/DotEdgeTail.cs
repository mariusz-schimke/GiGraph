using GiGraph.Dot.Entities.Edges.Attributes;
using GiGraph.Dot.Output;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    public class DotEdgeTail<TEndpoint> : DotEdgeEndpoint<TEndpoint>, IDotEdgeTailRootAttributes
        where TEndpoint : DotEndpointDefinition, IDotOrderable
    {
        public DotEdgeTail(TEndpoint endpoint, DotEdgeTailRootAttributes attributes)
            : base(endpoint, attributes)
        {
        }

        /// <inheritdoc cref="IDotEdgeTailRootAttributes.Hyperlink" />
        public virtual DotEdgeTailHyperlinkAttributes Hyperlink => ((IDotEdgeTailRootAttributes) Attributes).Hyperlink;
    }
}