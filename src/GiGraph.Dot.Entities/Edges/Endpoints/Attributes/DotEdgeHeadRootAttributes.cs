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
    public class DotEdgeHeadRootAttributes : DotEdgeEndpointRootAttributes
    {
        private static readonly Lazy<DotMemberAttributeKeyLookup> EdgeHeadRootAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotEdgeHeadRootAttributes, IDotEdgeEndpointAttributes>().BuildLazy();

        public DotEdgeHeadRootAttributes(DotAttributeCollection attributes)
            : base(attributes, EdgeHeadRootAttributesKeyLookup, new DotEdgeHeadHyperlinkAttributes(attributes))
        {
        }

        [DotAttributeKey(DotAttributeKeys.HeadLabel)]
        public override DotLabel Label
        {
            get => base.Label;
            set => base.Label = value;
        }

        [DotAttributeKey(DotAttributeKeys.HeadClip)]
        public override bool? ClipToNodeBoundary
        {
            get => base.ClipToNodeBoundary;
            set => base.ClipToNodeBoundary = value;
        }

        [DotAttributeKey(DotAttributeKeys.SameHead)]
        public override string GroupName
        {
            get => base.GroupName;
            set => base.GroupName = value;
        }

        [DotAttributeKey(DotAttributeKeys.HeadPort)]
        public override DotEndpointPort Port
        {
            get => base.Port;
            set => base.Port = value;
        }

        [DotAttributeKey(DotAttributeKeys.LHead)]
        public override DotClusterId ClusterId
        {
            get => base.ClusterId;
            set => base.ClusterId = value;
        }

        [DotAttributeKey(DotAttributeKeys.Arrowhead)]
        public override DotArrowheadDefinition Arrowhead
        {
            get => base.Arrowhead;
            set => base.Arrowhead = value;
        }
    }
}