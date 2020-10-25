using System;
using System.Collections.Generic;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public abstract partial class DotEntityAttributes
    {
        protected static readonly BindingFlags AttributeKeyPropertyBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        protected readonly DotMemberAttributeKeyLookup _attributeKeyLookup;
        protected readonly DotAttributeCollection _attributes;

        protected DotEntityAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
        {
            _attributes = attributes;
            _attributeKeyLookup = attributeKeyLookup;
        }

        protected virtual string GetAttributeKey(MethodBase accessor)
        {
            var method = (MethodInfo) accessor;

            return TryGetAttributeKey(method, out var key)
                ? key
                : throw new KeyNotFoundException($"No attribute key is defined for the '{accessor}' property accessor of the {accessor.DeclaringType} type.");
        }

        protected virtual bool TryGetAttributeKey(MethodInfo accessor, out string key)
        {
            return _attributeKeyLookup.TryGetKey(accessor.GetRuntimeBaseDefinition(), out key);
        }

        protected internal virtual string GetAttributeKey(PropertyInfo property)
        {
            // the lookup contains only interface properties and property accessors of implementing classes
            return _attributeKeyLookup.TryGetKey(property, out var key) ||
                   // the following calls are used only when retrieving a complete attribute key mapping, not for the base functionality of the library,
                   // so including properties of implementing classes in the lookup (to optimize this use case) seems redundant
                   TryGetAttributeKey(property.GetMethod, out key) ||
                   TryGetAttributeKey(property.SetMethod, out key)
                ? key
                : throw new KeyNotFoundException($"No attribute key is defined for the '{property}' property of the {property.DeclaringType} type.");
        }

        protected virtual void AddOrRemove<TAttribute, TValue>(MethodBase propertyAccessor, TValue value, Func<string, TValue, TAttribute> newAttribute)
            where TAttribute : DotAttribute
        {
            AddOrRemove(GetAttributeKey(propertyAccessor), value, newAttribute);
        }

        protected virtual void AddOrRemove<TAttribute, TValue>(string key, TValue value, Func<string, TValue, TAttribute> newAttribute)
            where TAttribute : DotAttribute
        {
            AddOrRemove(key, value is null ? null : newAttribute(key, value));
        }

        protected virtual void AddOrRemove<T>(string key, T attribute)
            where T : DotAttribute
        {
            if (attribute is null)
            {
                _attributes.Remove(key);
            }
            else
            {
                _attributes.Set(attribute);
            }
        }
    }
}