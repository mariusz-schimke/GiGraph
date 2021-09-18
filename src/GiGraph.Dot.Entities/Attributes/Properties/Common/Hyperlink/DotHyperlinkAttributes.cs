using System;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.Hyperlink
{
    public class DotHyperlinkAttributes : DotHyperlinkAttributes<IDotHyperlinkAttributes, DotHyperlinkAttributes>
    {
        protected static readonly Lazy<DotMemberAttributeKeyLookup> EntityHyperlinkAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotHyperlinkAttributes, IDotHyperlinkAttributes>().BuildLazy();

        public DotHyperlinkAttributes(DotAttributeCollection attributes)
            : base(attributes, EntityHyperlinkAttributesKeyLookup)
        {
        }

        protected DotHyperlinkAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }
    }
}