using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public class DotEntityHyperlinkAttributes : DotEntityHyperlinkAttributes<IDotEntityHyperlinkAttributes>
    {
        protected static readonly DotMemberAttributeKeyLookup EntityHyperlinkAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotEntityHyperlinkAttributes, IDotEntityHyperlinkAttributes>().Build();

        protected DotEntityHyperlinkAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotEntityHyperlinkAttributes(DotAttributeCollection attributes)
            : base(attributes, EntityHyperlinkAttributesKeyLookup)
        {
        }
    }
}