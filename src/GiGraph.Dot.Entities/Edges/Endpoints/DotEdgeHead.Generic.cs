using GiGraph.Dot.Entities.Edges.Endpoints.Attributes;
using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    public class DotEdgeHead<TEndpoint> : DotEdgeEndpoint<TEndpoint>, IDotEdgeHeadRootAttributes
        where TEndpoint : DotEndpointDefinition, IDotOrderable
    {
        public DotEdgeHead(TEndpoint endpoint, DotEdgeHeadRootAttributes attributes)
            : base(endpoint, attributes)
        {
        }

        /// <inheritdoc cref="IDotEdgeHeadRootAttributes.Hyperlink" />
        public virtual DotEdgeHeadHyperlinkAttributes Hyperlink => ((DotEdgeHeadRootAttributes) Attributes.Implementation).Hyperlink;
    }
}