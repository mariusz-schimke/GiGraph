using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;

namespace GiGraph.Dot.Entities.Attributes.Collections.Common
{
    public class DotHyperlinkAttributes : DotHyperlinkAttributes<IDotHyperlinkAttributes>
    {
        protected static readonly DotMemberAttributeKeyLookup EntityHyperlinkAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotHyperlinkAttributes, IDotHyperlinkAttributes>().Build();

        protected DotHyperlinkAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotHyperlinkAttributes(DotAttributeCollection attributes)
            : base(attributes, EntityHyperlinkAttributesKeyLookup)
        {
        }
    }
}