using GiGraph.Dot.Entities.Edges.Endpoints.Attributes;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Types.Arrowheads;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Edges;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    public abstract class DotEdgeEndpoint : IDotEdgeEndpointAttributes
    {
        protected readonly IDotEdgeEndpointAttributes _attributes;

        public DotEdgeEndpoint(IDotEdgeEndpointAttributes attributes)
        {
            _attributes = attributes;
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.Label" />
        public virtual DotLabel Label
        {
            get => _attributes.Label;
            set => _attributes.Label = value;
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.Port" />
        public virtual DotEndpointPort Port
        {
            get => _attributes.Port;
            set => _attributes.Port = value;
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.ClusterId" />
        public virtual DotClusterId ClusterId
        {
            get => _attributes.ClusterId;
            set => _attributes.ClusterId = value;
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.ClipToNodeBoundary" />
        public virtual bool? ClipToNodeBoundary
        {
            get => _attributes.ClipToNodeBoundary;
            set => _attributes.ClipToNodeBoundary = value;
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.GroupName" />
        public virtual string GroupName
        {
            get => _attributes.GroupName;
            set => _attributes.GroupName = value;
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.Arrowhead" />
        public virtual DotArrowheadDefinition Arrowhead
        {
            get => _attributes.Arrowhead;
            set => _attributes.Arrowhead = value;
        }
    }
}