using GiGraph.Dot.Entities.Edges.Attributes;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Types.Arrowheads;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Edges;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    public abstract partial class DotEdgeEndpoint<TEndpoint> : IDotEdgeEndpointAttributes
    {
        /// <inheritdoc cref="IDotEdgeEndpointAttributes.Label" />
        public virtual DotLabel Label
        {
            get => ((IDotEdgeEndpointAttributes) Attributes).Label;
            set => ((IDotEdgeEndpointAttributes) Attributes).Label = value;
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.Port" />
        public virtual DotEndpointPort Port
        {
            get => ((IDotEdgeEndpointAttributes) Attributes).Port;
            set => ((IDotEdgeEndpointAttributes) Attributes).Port = value;
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.ClusterId" />
        public virtual DotClusterId ClusterId
        {
            get => ((IDotEdgeEndpointAttributes) Attributes).ClusterId;
            set => ((IDotEdgeEndpointAttributes) Attributes).ClusterId = value;
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.ClipToNodeBoundary" />
        public virtual bool? ClipToNodeBoundary
        {
            get => ((IDotEdgeEndpointAttributes) Attributes).ClipToNodeBoundary;
            set => ((IDotEdgeEndpointAttributes) Attributes).ClipToNodeBoundary = value;
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.GroupName" />
        public virtual string GroupName
        {
            get => ((IDotEdgeEndpointAttributes) Attributes).GroupName;
            set => ((IDotEdgeEndpointAttributes) Attributes).GroupName = value;
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.Arrowhead" />
        public virtual DotArrowheadDefinition Arrowhead
        {
            get => ((IDotEdgeEndpointAttributes) Attributes).Arrowhead;
            set => ((IDotEdgeEndpointAttributes) Attributes).Arrowhead = value;
        }
    }
}