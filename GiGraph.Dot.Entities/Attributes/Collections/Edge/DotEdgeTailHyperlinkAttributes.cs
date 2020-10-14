using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
    public class DotEdgeTailHyperlinkAttributes : DotEdgeEndpointHyperlinkAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup EdgeTailHyperlinkAttributesKeyLookup = CreateAttributeKeyLookupForMembersOf(typeof(DotEdgeTailHyperlinkAttributes));

        protected DotEdgeTailHyperlinkAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotEdgeTailHyperlinkAttributes(DotAttributeCollection attributes)
            : base(attributes, EdgeTailHyperlinkAttributesKeyLookup)
        {
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
        public override DotEscapeString Target
        {
            get => base.Target;
            set => base.Target = value;
        }

        [DotAttributeKey("tailtooltip")]
        public override DotEscapeString Tooltip
        {
            get => base.Tooltip;
            set => base.Tooltip = value;
        }
    }
}