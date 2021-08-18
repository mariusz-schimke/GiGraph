using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.Font
{
    public class DotFontAttributes : DotFontAttributes<IDotFontAttributes>
    {
        protected static readonly DotMemberAttributeKeyLookup EntityFontAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotFontAttributes, IDotFontAttributes>().Build();

        protected DotFontAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotFontAttributes(DotAttributeCollection attributes)
            : base(attributes, EntityFontAttributesKeyLookup)
        {
        }
    }
}