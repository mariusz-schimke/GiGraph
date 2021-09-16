using System;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Arrowheads;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Edges;

namespace GiGraph.Dot.Entities.Edges.Endpoints.Attributes
{
    public class DotEdgeTailAttributes : DotEdgeEndpointAttributes
    {
        private static readonly Lazy<DotMemberAttributeKeyLookup> EdgeTailRootAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotEdgeTailAttributes, IDotEdgeEndpointAttributes>().BuildLazy();

        public DotEdgeTailAttributes(DotAttributeCollection attributes)
            : base(attributes, EdgeTailRootAttributesKeyLookup, new DotEdgeTailHyperlinkAttributes(attributes))
        {
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.Label" />
        [DotAttributeKey(DotAttributeKeys.TailLabel)]
        public override DotLabel Label
        {
            get => base.Label;
            set => base.Label = value;
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.ClipToNodeBoundary" />
        [DotAttributeKey(DotAttributeKeys.TailClip)]
        public override bool? ClipToNodeBoundary
        {
            get => base.ClipToNodeBoundary;
            set => base.ClipToNodeBoundary = value;
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.GroupName" />
        [DotAttributeKey(DotAttributeKeys.SameTail)]
        public override string GroupName
        {
            get => base.GroupName;
            set => base.GroupName = value;
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.Port" />
        [DotAttributeKey(DotAttributeKeys.TailPort)]
        public override DotEndpointPort Port
        {
            get => base.Port;
            set => base.Port = value;
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.ClusterId" />
        [DotAttributeKey(DotAttributeKeys.LTail)]
        public override DotClusterId ClusterId
        {
            get => base.ClusterId;
            set => base.ClusterId = value;
        }

        /// <inheritdoc cref="IDotEdgeEndpointAttributes.Arrowhead" />
        [DotAttributeKey(DotAttributeKeys.ArrowTail)]
        public override DotArrowheadDefinition Arrowhead
        {
            get => base.Arrowhead;
            set => base.Arrowhead = value;
        }
    }
}