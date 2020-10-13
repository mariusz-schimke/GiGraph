using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Types.Arrows;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Edges;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
    public class DotEdgeTailAttributes : DotEdgeEndpointAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup EdgeTailAttributesLookup = CreateAttributeKeyLookupForMembersOf(typeof(DotEdgeTailAttributes));

        protected DotEdgeTailAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup propertyAttributeKeyLookup)
            : base(attributes, propertyAttributeKeyLookup)
        {
        }

        public DotEdgeTailAttributes(DotAttributeCollection attributes)
            : base(attributes, EdgeTailAttributesLookup)
        {
        }

        [DotAttributeKey("taillabel")]
        public override DotLabel Label
        {
            get => base.Label;
            set => base.Label = value;
        }

        [DotAttributeKey("tailURL")]
        public override DotEscapeString Url
        {
            get => base.Url;
            set => base.Url = value;
        }

        [DotAttributeKey("tailhref")]
        public override DotEscapeString Href
        {
            get => base.Href;
            set => base.Href = value;
        }

        [DotAttributeKey("tailtarget")]
        public override DotEscapeString UrlTarget
        {
            get => base.UrlTarget;
            set => base.UrlTarget = value;
        }

        [DotAttributeKey("tailtooltip")]
        public override DotEscapeString UrlTooltip
        {
            get => base.UrlTooltip;
            set => base.UrlTooltip = value;
        }

        [DotAttributeKey("tailclip")]
        public override bool? ClipToNodeBoundary
        {
            get => base.ClipToNodeBoundary;
            set => base.ClipToNodeBoundary = value;
        }

        [DotAttributeKey("sametail")]
        public override string GroupName
        {
            get => base.GroupName;
            set => base.GroupName = value;
        }

        [DotAttributeKey("tailport")]
        public override DotEndpointPort Port
        {
            get => base.Port;
            set => base.Port = value;
        }

        [DotAttributeKey("ltail")]
        public override string ClusterId
        {
            get => base.ClusterId;
            set => base.ClusterId = value;
        }

        [DotAttributeKey("arrowtail")]
        public override DotArrowheadDefinition Arrowhead
        {
            get => base.Arrowhead;
            set => base.Arrowhead = value;
        }
    }
}