using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;

namespace GiGraph.Dot.Entities.Attributes.Collections.Common
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