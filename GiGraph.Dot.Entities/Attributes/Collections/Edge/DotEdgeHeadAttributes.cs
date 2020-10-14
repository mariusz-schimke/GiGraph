using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Types.Arrows;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Edges;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
    public class DotEdgeHeadAttributes : DotEdgeEndpointAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup EdgeHeadAttributesKeyLookup = CreateAttributeKeyLookupForMembersOf(typeof(DotEdgeHeadAttributes));

        protected DotEdgeHeadAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotEdgeHeadAttributes(DotAttributeCollection attributes)
            : base(attributes, EdgeHeadAttributesKeyLookup)
        {
        }

        [DotAttributeKey("headlabel")]
        public override DotLabel Label
        {
            get => base.Label;
            set => base.Label = value;
        }

        [DotAttributeKey("headURL")]
        public override DotEscapeString Url
        {
            get => base.Url;
            set => base.Url = value;
        }

        [DotAttributeKey("headhref")]
        public override DotEscapeString Href
        {
            get => base.Href;
            set => base.Href = value;
        }

        [DotAttributeKey("headtarget")]
        public override DotEscapeString UrlTarget
        {
            get => base.UrlTarget;
            set => base.UrlTarget = value;
        }

        [DotAttributeKey("headtooltip")]
        public override DotEscapeString UrlTooltip
        {
            get => base.UrlTooltip;
            set => base.UrlTooltip = value;
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