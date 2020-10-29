using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Types.Attributes;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
    // TODO: właściwości tej klasy wymagają ustawienia komentarzy, bo dziedziczą niewłaściwe z klasy bazowej
    public class DotEdgeHeadHyperlinkAttributes : DotEdgeHyperlinkAttributes
    {
        protected static readonly DotMemberAttributeKeyLookup EdgeHeadHyperlinkAttributesKeyLookup = CreateAttributeKeyLookupForMembersOf(typeof(DotEdgeHeadHyperlinkAttributes));

        protected DotEdgeHeadHyperlinkAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotEdgeHeadHyperlinkAttributes(DotAttributeCollection attributes)
            : base(attributes, EdgeHeadHyperlinkAttributesKeyLookup)
        {
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
        public override DotEscapeString Target
        {
            get => base.Target;
            set => base.Target = value;
        }

        [DotAttributeKey("headtooltip")]
        public override DotEscapeString Tooltip
        {
            get => base.Tooltip;
            set => base.Tooltip = value;
        }
    }
}