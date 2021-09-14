using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Edges.Endpoints.Attributes;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    public class DotEdgeTail : DotEdgeEndpoint, IDotEdgeTailRootAttributes
    {
        public DotEdgeTail(DotEdgeTailRootAttributes attributes)
            : base(attributes)
        {
            Attributes = new DotEntityAttributesAccessor<IDotEdgeEndpointAttributes, DotEdgeTailRootAttributes>(attributes);
        }

        /// <summary>
        ///     Provides access to the attributes of the edge's tail.
        /// </summary>
        public virtual DotEntityAttributesAccessor<IDotEdgeEndpointAttributes, DotEdgeTailRootAttributes> Attributes { get; }

        /// <inheritdoc cref="IDotEdgeTailRootAttributes.Hyperlink" />
        public virtual DotEdgeTailHyperlinkAttributes Hyperlink => Attributes.Implementation.Hyperlink;
    }
}