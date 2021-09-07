using GiGraph.Dot.Entities.Edges.Endpoints.Attributes;
using GiGraph.Dot.Output;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    public class DotEdgeHead<TEndpoint> : DotEdgeEndpoint<TEndpoint>, IDotEdgeHeadRootAttributes
        where TEndpoint : DotEndpointDefinition, IDotOrderable
    {
        public DotEdgeHead(TEndpoint endpoint, DotEdgeHeadRootAttributes attributes)
            : base(endpoint, attributes)
        {
        }

        /// <summary>
        ///     Gets the head attributes of the edge.
        /// </summary>
        public virtual DotEdgeHeadRootAttributes Attributes => (DotEdgeHeadRootAttributes) _attributes;

        /// <inheritdoc cref="IDotEdgeHeadRootAttributes.Hyperlink" />
        public virtual DotEdgeHeadHyperlinkAttributes Hyperlink => ((IDotEdgeHeadRootAttributes) Attributes).Hyperlink;
    }
}