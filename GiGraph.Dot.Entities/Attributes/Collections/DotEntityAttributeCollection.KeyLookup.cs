using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
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

        protected static void UpdatePropertyAccessorsAttributeKeyLookupFrom(DotMemberAttributeKeyLookup source)
        {
            lock (_propertyAccessorsAttributeKeyLookupLock)
            {
                var clone = new DotMemberAttributeKeyLookup(_propertyAccessorsAttributeKeyLookup);
                clone.MergeFrom(source);
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
                    result.Set(getter, attribute.Key);
                }

                if (property.SetMethod is {} setter)
                {
                    result.Set(setter, attribute.Key);
                }
            }

            return result;
        }

        protected static DotMemberAttributeKeyLookup CreateAttributeKeyLookupForExposedEntityAttributesOf(Type attributeCollectionType)
        {
            var result = new DotMemberAttributeKeyLookup();
            CreateAttributeKeyLookupForExposedEntityAttributesOf(result, attributeCollectionType, typeof(TIExposedEntityAttributes));

            return result;
        }

        private static void CreateAttributeKeyLookupForExposedEntityAttributesOf(
            DotMemberAttributeKeyLookup result, Type attributeCollectionType, Type exposedEntityAttributesInterfaceType
        )
        {
            var interfaceProperties = exposedEntityAttributesInterfaceType.GetProperties(PropertyBindingFlags);
            var interfaceMap = attributeCollectionType.GetInterfaceMap(exposedEntityAttributesInterfaceType);

            for (var index = 0; index < interfaceMap.InterfaceMethods.Length; index++)
            {
                var interfacePropertyAccessor = interfaceMap.InterfaceMethods[index];
                var implementationPropertyAccessor = interfaceMap.TargetMethods[index];

                var interfaceProperty = interfaceProperties.First(property =>
                    interfacePropertyAccessor.Equals(property.GetMethod) || interfacePropertyAccessor.Equals(property.SetMethod)
                );

                if (IsAttributeGroupingProperty(interfaceProperty, attributeCollectionType))
                {
                    CreateAttributeKeyLookupForExposedEntityAttributesOf(result, attributeCollectionType, interfaceProperty.PropertyType);
                }

                // it is assumed that the attribute collection accessor is already present in the lookup
                else if (_propertyAccessorsAttributeKeyLookup.TryGetKey(implementationPropertyAccessor, out var key))
                {
                    result.Set(interfaceProperty, key);
                }
                else
                {
                    throw new KeyNotFoundException(
                        $"The attribute key lookup collection does not contain a key for the '{implementationPropertyAccessor}' member of the {implementationPropertyAccessor.DeclaringType} type."
                    );
                }
            }
        }
    }
}