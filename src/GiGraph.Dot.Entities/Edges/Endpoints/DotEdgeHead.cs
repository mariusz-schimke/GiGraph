using GiGraph.Dot.Entities.Edges.Attributes;
using GiGraph.Dot.Output;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    public class DotEdgeHead<TEndpoint> : DotEdgeEndpoint<TEndpoint>, IDotEdgeHeadRootAttributes
        where TEndpoint : DotEndpointDefinition, IDotOrderable
    {
        public DotEdgeHead(TEndpoint endpoint, DotEdgeHeadAttributes attributes)
            : base(endpoint, attributes)
        {
        }

        /// <inheritdoc cref="IDotEdgeHeadRootAttributes.Hyperlink" />
        public virtual DotEdgeHeadHyperlinkAttributes Hyperlink => ((DotEdgeHeadAttributes) Attributes).Hyperlink;
    }
}