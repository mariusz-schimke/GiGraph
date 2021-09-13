using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Edges.Endpoints.Attributes;
using GiGraph.Dot.Output;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    public class DotEdgeTail<TEndpoint> : DotEdgeEndpoint<TEndpoint>, IDotEdgeTailRootAttributes
        where TEndpoint : DotEndpointDefinition, IDotOrderable
    {
        public DotEdgeTail(TEndpoint endpoint, DotEdgeTailRootAttributes attributes)
            : base(endpoint, attributes)
        {
            Attributes = new DotEntityAttributesAccessor<IDotEdgeTailRootAttributes, DotEdgeTailRootAttributes>(attributes);
        }

        /// <summary>
        ///     Provides access to the attributes of the edge's tail.
        /// </summary>
        public virtual DotEntityAttributesAccessor<IDotEdgeTailRootAttributes, DotEdgeTailRootAttributes> Attributes { get; }

        /// <inheritdoc cref="IDotEdgeTailRootAttributes.Hyperlink" />
        public virtual DotEdgeTailHyperlinkAttributes Hyperlink => Attributes.Implementation.Hyperlink;
    }
}