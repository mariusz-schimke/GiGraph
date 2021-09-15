using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Edges.Attributes;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Types.Arrowheads;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Edges;

namespace GiGraph.Dot.Entities.Edges.Endpoints.Attributes
{
    public class DotEdgeHeadAttributes : DotNestedEntityAttributes<IDotEdgeEndpointAttributes, DotEdgeHeadRootAttributes>, IDotEdgeEndpointRootAttributes
    {
        public DotEdgeHeadAttributes(DotAttributeCollection attributes)
            : this(new DotEdgeHeadRootAttributes(attributes))
        {
        }

        private DotEdgeHeadAttributes(DotEdgeHeadRootAttributes attributes)
            : base(attributes)
        {
        }

        /// <summary>
        ///     Hyperlink attributes of the head of the edge. If defined, the hyperlink is output as part of the head's <see cref="Label" />.
        ///     Also, this value is used near the head, overriding hyperlink attributes set on the edge.
        /// </summary>
        public virtual DotEdgeEndpointHyperlinkAttributes Hyperlink => Attributes.Implementation.Hyperlink;

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.Label" />
        public virtual DotLabel Label
        {
            get => Attributes.Implementation.Label;
            set => Attributes.Implementation.Label = value;
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

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.Arrowhead" />
        public virtual DotArrowheadDefinition Arrowhead
        {
            get => Attributes.Implementation.Arrowhead;
            set => Attributes.Implementation.Arrowhead = value;
        }
    }
}