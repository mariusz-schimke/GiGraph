using System;
using GiGraph.Dot.Entities.Edges.Attributes;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Output;
using GiGraph.Dot.Types.Arrowheads;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Edges;

namespace GiGraph.Dot.Entities.Edges.Endpoints
{
    public abstract class DotEdgeEndpoint<TEndpoint> : IDotEdgeEndpointAttributes
        where TEndpoint : DotEndpointDefinition, IDotOrderable
    {
        public DotEdgeEndpoint(TEndpoint endpoint, DotEdgeEndpointAttributes attributes)
        {
            Endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint), "Edge endpoint must not be null.");
            Attributes = attributes;
        }

        /// <summary>
        ///     Gets the attributes of the endpoint.
        /// </summary>
        public virtual DotEdgeEndpointAttributes Attributes { get; }

        /// <summary>
        ///     The endpoint of the edge.
        /// </summary>
        public virtual TEndpoint Endpoint { get; }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.Label" />
        public virtual DotLabel Label
        {
            get => Attributes.Label;
            set => Attributes.Label = value;
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.Port" />
        public virtual DotEndpointPort Port
        {
            get => Attributes.Port;
            set => Attributes.Port = value;
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.ClusterId" />
        public virtual DotClusterId ClusterId
        {
            get => Attributes.ClusterId;
            set => Attributes.ClusterId = value;
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.ClipToNodeBoundary" />
        public virtual bool? ClipToNodeBoundary
        {
            get => Attributes.ClipToNodeBoundary;
            set => Attributes.ClipToNodeBoundary = value;
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.GroupName" />
        public virtual string GroupName
        {
            get => Attributes.GroupName;
            set => Attributes.GroupName = value;
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.Arrowhead" />
        public virtual DotArrowheadDefinition Arrowhead
        {
            get => Attributes.Arrowhead;
            set => Attributes.Arrowhead = value;
        }
    }
}