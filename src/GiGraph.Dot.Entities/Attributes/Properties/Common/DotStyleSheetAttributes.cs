using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common
{
    public class DotStyleSheetAttributes : DotStyleSheetAttributes<IDotStyleSheetAttributes>
    {
        protected static readonly DotMemberAttributeKeyLookup EntityStyleSheetAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotStyleSheetAttributes, IDotStyleSheetAttributes>().Build();

        protected DotStyleSheetAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotStyleSheetAttributes(DotAttributeCollection attributes)
            : base(attributes, EntityStyleSheetAttributesKeyLookup)
        {
        }
    }
}