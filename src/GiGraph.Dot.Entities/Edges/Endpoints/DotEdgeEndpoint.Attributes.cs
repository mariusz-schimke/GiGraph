using GiGraph.Dot.Entities.Edges.Endpoints.Attributes;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Types.Arrowheads;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Edges;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    public abstract partial class DotEdgeEndpoint : IDotEdgeEndpointRootAttributes
    {
        /// <inheritdoc cref="IDotEdgeEndpointRootAttributes.Hyperlink" />
        public virtual DotEdgeEndpointHyperlinkAttributes Hyperlink => Attributes.Implementation.Hyperlink;

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.Label" />
        public virtual DotLabel Label
        {
            get => Attributes.Implementation.Label;
            set => Attributes.Implementation.Label = value;
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.Port" />
        public virtual DotEndpointPort Port
        {
            get => Attributes.Implementation.Port;
            set => Attributes.Implementation.Port = value;
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.ClusterId" />
        public virtual DotClusterId ClusterId
        {
            get => Attributes.Implementation.ClusterId;
            set => Attributes.Implementation.ClusterId = value;
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.ClipToNodeBoundary" />
        public virtual bool? ClipToNodeBoundary
        {
            get => Attributes.Implementation.ClipToNodeBoundary;
            set => Attributes.Implementation.ClipToNodeBoundary = value;
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.GroupName" />
        public virtual string GroupName
        {
            get => Attributes.Implementation.GroupName;
            set => Attributes.Implementation.GroupName = value;
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.Arrowhead" />
        public virtual DotArrowheadDefinition Arrowhead
        {
            get => Attributes.Implementation.Arrowhead;
            set => Attributes.Implementation.Arrowhead = value;
        }
    }
}