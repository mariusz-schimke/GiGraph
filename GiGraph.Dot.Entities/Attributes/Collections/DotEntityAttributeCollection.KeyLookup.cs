using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.Lookup;
using GiGraph.Dot.Entities.Types.Attributes;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public abstract partial class DotEntityAttributeCollection<TIExposedEntityAttributes>
    {
        private const BindingFlags PropertyBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        private static DotMemberAttributeKeyLookup _propertyAccessorsAttributeKeyLookup = new DotMemberAttributeKeyLookup();
        private static readonly object _propertyAccessorsAttributeKeyLookupLock = new object();

        protected readonly DotMemberAttributeKeyLookup _exposedEntityAttributesKeyLookup;

        protected static void UpdatePropertyAccessorsAttributeKeyLookupFor(Type attributeCollectionType)
        {
            var lookup = CreateAttributeKeyLookupForPropertyAccessorsOf(attributeCollectionType);
            UpdatePropertyAccessorsAttributeKeyLookupFrom(lookup);
        }

        private static void UpdatePropertyAccessorsAttributeKeyLookupFrom(DotMemberAttributeKeyLookup source)
        {
            lock (_propertyAccessorsAttributeKeyLookupLock)
            {
                var clone = new DotMemberAttributeKeyLookup(_propertyAccessorsAttributeKeyLookup);
                clone.UpdateFrom(source);
                _propertyAccessorsAttributeKeyLookup = clone;
            }
        }

        protected static DotMemberAttributeKeyLookup CreateAttributeKeyLookupForPropertyAccessorsOf(Type attributeCollectionType)
        {
            var result = new DotMemberAttributeKeyLookup();

            var properties = attributeCollectionType.GetProperties(PropertyBindingFlags);

            foreach (var property in properties)
            {
                if (!(property.GetCustomAttribute<DotAttributeKeyAttribute>() is {} attribute))
                {
                    continue;
                }

                if (property.GetMethod is {} getter)
                {
                    result.Update(getter, attribute.Key);
                }

                if (property.SetMethod is {} setter)
                {
                    result.Update(setter, attribute.Key);
                }
            }

            return result;
        }

        protected static DotMemberAttributeKeyLookup CreateAttributeKeyLookupForExposedEntityAttributesOf(Type attributeCollectionType)
        {
            var result = new DotMemberAttributeKeyLookup();

            var exposedAttributesInterfaceType = typeof(TIExposedEntityAttributes);

            if (IsAttributeGroupingInterface(exposedAttributesInterfaceType, attributeCollectionType))
            {
                CreateAttributeKeyLookupForExposedEntityAttributesOf(result, attributeCollectionType, exposedAttributesInterfaceType);
            }

            return result;
        }

        private static void CreateAttributeKeyLookupForExposedEntityAttributesOf(
            DotMemberAttributeKeyLookup result, Type attributeCollectionType, Type exposedAttributesInterfaceType
        )
        {
            var interfaceProperties = exposedAttributesInterfaceType.GetProperties(PropertyBindingFlags);

            var getters = interfaceProperties
               .Where(property => property.GetMethod is {})
               .ToDictionary(key => key.GetMethod);

            var setters = interfaceProperties
               .Where(property => property.SetMethod is {})
               .ToDictionary(key => key.SetMethod);

            var interfaceAccessors = getters.Concat(setters)
               .ToDictionary(key => key.Key, value => value.Value);

            var interfaceMap = attributeCollectionType.GetInterfaceMap(exposedAttributesInterfaceType);

            for (var index = 0; index < interfaceMap.InterfaceMethods.Length; index++)
            {
                var interfaceAccessor = interfaceMap.InterfaceMethods[index];
                var implementationAccessor = interfaceMap.TargetMethods[index];

                var interfaceProperty = interfaceAccessors[interfaceAccessor];

                if (IsAttributeGroupingInterface(interfaceProperty.PropertyType, attributeCollectionType))
                {
                    CreateAttributeKeyLookupForExposedEntityAttributesOf(result, attributeCollectionType, interfaceProperty.PropertyType);
                }

                // it is assumed that the attribute collection accessor is already present in the lookup
                else if (_propertyAccessorsAttributeKeyLookup.TryGetKey(implementationAccessor, out var key))
                {
                    result.Update(interfaceProperty, key);
                }
                else
                {
                    throw new KeyNotFoundException($"The attribute key lookup collection does not contain a key for the '{implementationAccessor}' member of the {implementationAccessor.DeclaringType} type.");
                }
            }
        }
    }
}