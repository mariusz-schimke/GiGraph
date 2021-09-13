using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Edges.Endpoints.Attributes;
using GiGraph.Dot.Output;
using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    public class DotEdgeHead<TEndpoint> : DotEdgeEndpoint<TEndpoint>, IDotEdgeHeadRootAttributes
        where TEndpoint : DotEndpointDefinition, IDotOrderable
    {
        public DotEdgeHead(TEndpoint endpoint, DotEdgeHeadRootAttributes attributes)
            : base(endpoint, attributes)
        {
            Attributes = new DotEntityAttributesAccessor<IDotEdgeHeadRootAttributes, DotEdgeHeadRootAttributes>(attributes);
        }

        /// <summary>
        ///     Provides access to the attributes of the edge's head.
        /// </summary>
        public virtual DotEntityAttributesAccessor<IDotEdgeHeadRootAttributes, DotEdgeHeadRootAttributes> Attributes { get; }

        /// <inheritdoc cref="IDotEdgeHeadRootAttributes.Hyperlink" />
        public virtual DotEdgeHeadHyperlinkAttributes Hyperlink => Attributes.Implementation.Hyperlink;
    }
}