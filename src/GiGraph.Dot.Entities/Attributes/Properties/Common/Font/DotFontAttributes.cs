using System;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.Font
{
    public class DotFontAttributes : DotFontAttributes<IDotFontAttributes, DotFontAttributes>
    {
        protected static readonly Lazy<DotMemberAttributeKeyLookup> EntityFontAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotFontAttributes, IDotFontAttributes>().BuildLazy();

        public DotFontAttributes(DotAttributeCollection attributes)
            : base(attributes, EntityFontAttributesKeyLookup)
        {
        }

        protected DotFontAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }
    }
}