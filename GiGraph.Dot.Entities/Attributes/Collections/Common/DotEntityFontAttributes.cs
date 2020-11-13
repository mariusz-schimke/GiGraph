using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;

namespace GiGraph.Dot.Entities.Attributes.Collections.Common
{
    public class DotEntityFontAttributes : DotEntityFontAttributes<IDotEntityFontAttributes>
    {
        protected static readonly DotMemberAttributeKeyLookup EntityFontAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotEntityFontAttributes, IDotEntityFontAttributes>().Build();

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