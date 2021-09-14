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
    public class DotEdgeTailRootAttributes : DotEdgeEndpointRootAttributes, IDotEdgeTailRootAttributes
    {
        private static readonly Lazy<DotMemberAttributeKeyLookup> EdgeTailRootAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotEdgeTailRootAttributes, IDotEdgeEndpointAttributes>().BuildLazy();

        public DotEdgeTailRootAttributes(DotAttributeCollection attributes)
            : this(attributes, EdgeTailRootAttributesKeyLookup, new DotEdgeTailHyperlinkAttributes(attributes))
        {
        }

        protected DotEdgeTailRootAttributes(
            DotAttributeCollection attributes,
            Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup,
            DotEdgeTailHyperlinkAttributes hyperlinkAttributes
        )
            : base(attributes, attributeKeyLookup)
        {
            Hyperlink = hyperlinkAttributes;
        }

        [DotAttributeKey(DotAttributeKeys.TailLabel)]
        public override DotLabel Label
        {
            get => base.Label;
            set => base.Label = value;
        }

        [DotAttributeKey(DotAttributeKeys.TailClip)]
        public override bool? ClipToNodeBoundary
        {
            get => base.ClipToNodeBoundary;
            set => base.ClipToNodeBoundary = value;
        }

        [DotAttributeKey(DotAttributeKeys.SameTail)]
        public override string GroupName
        {
            get => base.GroupName;
            set => base.GroupName = value;
        }

        [DotAttributeKey(DotAttributeKeys.TailPort)]
        public override DotEndpointPort Port
        {
            get => base.Port;
            set => base.Port = value;
        }

        [DotAttributeKey(DotAttributeKeys.LTail)]
        public override DotClusterId ClusterId
        {
            get => base.ClusterId;
            set => base.ClusterId = value;
        }

        [DotAttributeKey(DotAttributeKeys.ArrowTail)]
        public override DotArrowheadDefinition Arrowhead
        {
            get => base.Arrowhead;
            set => base.Arrowhead = value;
        }

        public virtual DotEdgeTailHyperlinkAttributes Hyperlink { get; }
    }
}