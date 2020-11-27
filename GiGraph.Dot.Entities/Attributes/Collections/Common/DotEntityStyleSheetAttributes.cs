using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;

namespace GiGraph.Dot.Entities.Attributes.Collections.Common
{
    public class DotEntityStyleSheetAttributes : DotEntityStyleSheetAttributes<IDotEntityStyleSheetAttributes>
    {
        protected static readonly DotMemberAttributeKeyLookup EntityStyleSheetAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotEntityStyleSheetAttributes, IDotEntityStyleSheetAttributes>().Build();

        protected DotEntityStyleSheetAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotEntityStyleSheetAttributes(DotAttributeCollection attributes)
            : base(attributes, EntityStyleSheetAttributesKeyLookup)
        {
        }
    }
}