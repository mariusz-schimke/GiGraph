using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Edges.Endpoints.Attributes;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    public class DotEdgeHead : DotEdgeEndpoint, IDotEdgeHeadRootAttributes
    {
        public DotEdgeHead(DotEdgeHeadRootAttributes attributes)
            : base(attributes)
        {
            Attributes = new DotEntityAttributesAccessor<IDotEdgeEndpointAttributes, DotEdgeHeadRootAttributes>(attributes);
        }

        /// <summary>
        ///     Provides access to the attributes of the edge's head.
        /// </summary>
        public virtual DotEntityAttributesAccessor<IDotEdgeEndpointAttributes, DotEdgeHeadRootAttributes> Attributes { get; }

        /// <inheritdoc cref="IDotEdgeHeadRootAttributes.Hyperlink" />
        public virtual DotEdgeHeadHyperlinkAttributes Hyperlink => Attributes.Implementation.Hyperlink;
    }
}