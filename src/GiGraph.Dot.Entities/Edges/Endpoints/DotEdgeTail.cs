using GiGraph.Dot.Entities.Edges.Endpoints.Attributes;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    public class DotEdgeTail : DotEdgeEndpoint, IDotEdgeTailRootAttributes
    {
        public DotEdgeTail(DotEdgeTailRootAttributes attributes)
            : base(attributes)
        {
        }

        /// <inheritdoc cref="IDotEdgeTailRootAttributes.Hyperlink" />
        public virtual DotEdgeTailHyperlinkAttributes Hyperlink => ((DotEdgeTailRootAttributes) Attributes.Implementation).Hyperlink;
    }
}