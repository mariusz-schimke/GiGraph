using GiGraph.Dot.Entities.Edges.Attributes;
using GiGraph.Dot.Output;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    public class DotEdgeHead<TEndpoint> : DotEdgeEndpoint<TEndpoint>, IDotEdgeHeadAttributesRoot
        where TEndpoint : DotEndpointDefinition, IDotOrderable
    {
        public DotEdgeHead(TEndpoint endpoint, DotEdgeHeadAttributes attributes)
            : base(endpoint, attributes)
        {
        }

        /// <inheritdoc cref="IDotEdgeHeadAttributesRoot.Hyperlink" />
        public virtual DotEdgeHeadHyperlinkAttributes Hyperlink => ((DotEdgeHeadAttributes) Attributes).Hyperlink;
    }
}