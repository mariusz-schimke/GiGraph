using System;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;

namespace GiGraph.Dot.Entities.Attributes.Properties
{
    public abstract class DotNestedEntityAttributes : DotEntityAttributes, IDotNestedEntityAttributes
    {
        protected DotNestedEntityAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        protected abstract DotEntityAttributesAccessor GetAccessor();
        DotEntityAttributesAccessor IDotNestedEntityAttributes.Accessor => GetAccessor();
    }
}