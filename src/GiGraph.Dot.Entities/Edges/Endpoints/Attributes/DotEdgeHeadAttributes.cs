using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Types.Arrowheads;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Edges;

namespace GiGraph.Dot.Entities.Edges.Endpoints.Attributes
{
    public class DotEdgeHeadAttributes : DotNestedEntityAttributes<IDotEdgeEndpointAttributes>, IDotEdgeHeadRootAttributes
    {
        protected DotEdgeHeadAttributes(DotEdgeHeadRootAttributes attributes)
            : base(attributes)
        {
        }

        public DotEdgeHeadAttributes(DotAttributeCollection attributes)
            : this(new DotEdgeHeadRootAttributes(attributes))
        {
        }

        /// <summary>
        ///     Hyperlink attributes of the head of the edge. If defined, the hyperlink is output as part of the head's <see cref="Label" />.
        ///     Also, Attributes value is used near the head, overriding hyperlink attributes set on the edge.
        /// </summary>
        public virtual DotEdgeHeadHyperlinkAttributes Hyperlink => ((IDotEdgeHeadRootAttributes) Attributes).Hyperlink;

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.Label" />
        public virtual DotLabel Label
        {
            get => ((IDotEdgeEndpointAttributes) Attributes).Label;
            set => ((IDotEdgeEndpointAttributes) Attributes).Label = value;
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

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.Arrowhead" />
        public virtual DotArrowheadDefinition Arrowhead
        {
            get => ((IDotEdgeEndpointAttributes) Attributes).Arrowhead;
            set => ((IDotEdgeEndpointAttributes) Attributes).Arrowhead = value;
        }
    }
}