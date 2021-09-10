using System;
using System.Collections.Generic;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;

namespace GiGraph.Dot.Entities.Attributes.Properties
{
    public abstract partial class DotEntityAttributes
    {
        protected readonly Lazy<DotMemberAttributeKeyLookup> _attributeKeyLookup;
        protected readonly DotAttributeCollection _attributes;

        protected DotEntityAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        {
            _attributes = attributes;
            _attributeKeyLookup = attributeKeyLookup;
        }

        protected virtual string GetKey(MethodBase accessor)
        {
            var method = (MethodInfo) accessor;

            return _attributeKeyLookup.Value.TryGetKey(method.GetRuntimeBaseDefinition(), out var key)
                ? key
                : throw new KeyNotFoundException($"No attribute key is defined for the '{accessor}' property accessor of the {accessor.DeclaringType} type.");
        }

        protected internal virtual string GetKey(PropertyInfo property)
        {
            // the lookup contains only interface properties and property accessors of implementing classes
            return _attributeKeyLookup.Value.TryGetKey(property, out var key)
                ? key
                : throw new KeyNotFoundException($"No attribute key is defined for the '{property}' property of the {property.DeclaringType} type.");
        }
    }
}