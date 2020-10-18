using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public class DotEntityFontAttributes : DotEntityFontAttributes<IDotEntityFontAttributes>
    {
        protected static readonly DotMemberAttributeKeyLookup EntityFontAttributesKeyLookup = CreateAttributeKeyLookupForMembersOf(typeof(DotEntityFontAttributes));

        protected DotEntityFontAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotEntityFontAttributes(DotAttributeCollection attributes)
            : base(attributes, EntityFontAttributesKeyLookup)
        {
        }
    }
}