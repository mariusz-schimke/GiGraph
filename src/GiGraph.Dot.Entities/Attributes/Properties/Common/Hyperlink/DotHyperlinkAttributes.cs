using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink
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