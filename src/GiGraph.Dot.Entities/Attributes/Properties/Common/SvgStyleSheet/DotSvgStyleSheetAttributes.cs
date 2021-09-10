using System;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.SvgStyleSheet
{
    public class DotSvgStyleSheetAttributes : DotSvgStyleSheetAttributes<IDotSvgStyleSheetAttributes>
    {
        protected static readonly Lazy<DotMemberAttributeKeyLookup> SvgStyleSheetAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotSvgStyleSheetAttributes, IDotSvgStyleSheetAttributes>().BuildLazy();

        protected DotSvgStyleSheetAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotSvgStyleSheetAttributes(DotAttributeCollection attributes)
            : base(attributes, SvgStyleSheetAttributesKeyLookup)
        {
        }
    }
}