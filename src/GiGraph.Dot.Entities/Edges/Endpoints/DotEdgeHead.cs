using GiGraph.Dot.Entities.Edges.Endpoints.Attributes;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    public class DotEdgeHead : DotEdgeEndpoint, IDotEdgeHeadRootAttributes
    {
        public DotEdgeHead(DotEdgeHeadRootAttributes attributes)
            : base(attributes)
        {
        }

        /// <inheritdoc cref="IDotEdgeHeadRootAttributes.Hyperlink" />
        public virtual DotEdgeHeadHyperlinkAttributes Hyperlink => ((DotEdgeHeadRootAttributes) Attributes.Implementation).Hyperlink;
    }
}