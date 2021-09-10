using System;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Types.Arrowheads;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Edges;

namespace GiGraph.Dot.Entities.Edges.Endpoints.Attributes
{
    public class DotEdgeHeadAttributes : DotEdgeHeadRootAttributes
    {
        protected DotEdgeHeadAttributes(
            DotAttributeCollection attributes,
            Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup,
            DotEdgeHeadHyperlinkAttributes edgeHeadHyperlinkAttributes
        )
            : base(attributes, attributeKeyLookup, edgeHeadHyperlinkAttributes)
        {
        }

        public DotEdgeHeadAttributes(DotAttributeCollection attributes)
            : this(attributes, EdgeHeadRootAttributesKeyLookup, new DotEdgeHeadHyperlinkAttributes(attributes))
        {
        }

        /// <summary>
        ///     Hyperlink attributes of the head of the edge. If defined, the hyperlink is output as part of the head's <see cref="Label" />.
        ///     Also, this value is used near the head, overriding hyperlink attributes set on the edge.
        /// </summary>
        public virtual DotEdgeHeadHyperlinkAttributes Hyperlink => ((IDotEdgeHeadRootAttributes) this).Hyperlink;

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.Label" />
        public virtual DotLabel Label
        {
            get => ((IDotEdgeEndpointAttributes) this).Label;
            set => ((IDotEdgeEndpointAttributes) this).Label = value;
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.ClipToNodeBoundary" />
        public virtual bool? ClipToNodeBoundary
        {
            get => ((IDotEdgeEndpointAttributes) this).ClipToNodeBoundary;
            set => ((IDotEdgeEndpointAttributes) this).ClipToNodeBoundary = value;
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.GroupName" />
        public virtual string GroupName
        {
            get => ((IDotEdgeEndpointAttributes) this).GroupName;
            set => ((IDotEdgeEndpointAttributes) this).GroupName = value;
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.Port" />
        public virtual DotEndpointPort Port
        {
            get => ((IDotEdgeEndpointAttributes) this).Port;
            set => ((IDotEdgeEndpointAttributes) this).Port = value;
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.ClusterId" />
        public virtual DotClusterId ClusterId
        {
            get => ((IDotEdgeEndpointAttributes) this).ClusterId;
            set => ((IDotEdgeEndpointAttributes) this).ClusterId = value;
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.Arrowhead" />
        public virtual DotArrowheadDefinition Arrowhead
        {
            get => ((IDotEdgeEndpointAttributes) this).Arrowhead;
            set => ((IDotEdgeEndpointAttributes) this).Arrowhead = value;
        }
    }
}