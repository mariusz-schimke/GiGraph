using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;

namespace GiGraph.Dot.Entities.Attributes.Properties
{
    public abstract class DotEntityAttributesAccessor : DotEntityAttributes
    {
        protected DotEntityAttributesAccessor(DotEntityAttributes source)
            : base(source)
        {
        }

        protected DotEntityAttributesAccessor(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        protected virtual string GetPropertyKey(PropertyInfo property)
        {
            // the lookup contains only interface properties and property accessors of implementing classes
            return _attributeKeyLookup.Value.GetPropertyKey(property);
        }
    }
}