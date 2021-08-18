using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet
{
    public class DotSvgStyleSheetAttributes : DotSvgStyleSheetAttributes<IDotSvgStyleSheetAttributes>
    {
        protected static readonly DotMemberAttributeKeyLookup EntitySvgStyleSheetAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotSvgStyleSheetAttributes, IDotSvgStyleSheetAttributes>().Build();

        protected DotSvgStyleSheetAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotSvgStyleSheetAttributes(DotAttributeCollection attributes)
            : base(attributes, EntitySvgStyleSheetAttributesKeyLookup)
        {
        }
    }
}