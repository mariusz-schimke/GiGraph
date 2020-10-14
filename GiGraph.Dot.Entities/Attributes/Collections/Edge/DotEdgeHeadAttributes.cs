using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Types.Arrows;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Edges;
using GiGraph.Dot.Entities.Types.Labels;

namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
    public class DotEdgeHeadAttributes : DotEdgeEndpointAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup EdgeHeadAttributesKeyLookup = CreateAttributeKeyLookupForMembersOf(typeof(DotEdgeHeadAttributes));

        protected DotEdgeHeadAttributes(
            DotAttributeCollection attributes,
            DotMemberAttributeKeyLookup attributeKeyLookup,
            DotEdgeHeadHyperlinkAttributes edgeHeadHyperlinkAttributes
        )
            : base(attributes, attributeKeyLookup, edgeHeadHyperlinkAttributes)
        {
        }

        public DotEdgeHeadAttributes(DotAttributeCollection attributes)
            : this(attributes, EdgeHeadAttributesKeyLookup, new DotEdgeHeadHyperlinkAttributes(attributes))
        {
        }

        [DotAttributeKey("headlabel")]
        public override DotLabel Label
        {
            get => base.Label;
            set => base.Label = value;
        }

        [DotAttributeKey("headclip")]
        public override bool? ClipToNodeBoundary
        {
            get => base.ClipToNodeBoundary;
            set => base.ClipToNodeBoundary = value;
        }

        [DotAttributeKey("samehead")]
        public override string GroupName
        {
            get => base.GroupName;
            set => base.GroupName = value;
        }

        [DotAttributeKey("headport")]
        public override DotEndpointPort Port
        {
            get => base.Port;
            set => base.Port = value;
        }

        [DotAttributeKey("lhead")]
        public override string ClusterId
        {
            get => base.ClusterId;
            set => base.ClusterId = value;
        }

        [DotAttributeKey("arrowhead")]
        public override DotArrowheadDefinition Arrowhead
        {
            get => base.Arrowhead;
            set => base.Arrowhead = value;
        }
    }
}