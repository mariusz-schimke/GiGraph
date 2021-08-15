using GiGraph.Dot.Entities.Edges.Attributes;
using GiGraph.Dot.Output;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    public class DotEdgeTail<TEndpoint> : DotEdgeEndpoint<TEndpoint>, IDotEdgeTailAttributesRoot
        where TEndpoint : DotEndpointDefinition, IDotOrderable
    {
        public DotEdgeTail(TEndpoint endpoint, DotEdgeTailAttributes attributes)
            : base(endpoint, attributes)
        {
        }

        /// <inheritdoc cref="IDotEdgeTailAttributesRoot.Hyperlink" />
        public virtual DotEdgeTailHyperlinkAttributes Hyperlink => ((DotEdgeTailAttributes) _attributes).Hyperlink;
    }
}