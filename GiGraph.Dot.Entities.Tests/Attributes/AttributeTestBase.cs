using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Types.Attributes;

namespace GiGraph.Dot.Entities.Tests.Attributes
{
    public abstract class AttributesTestBase
    {
        protected const BindingFlags AttributePropertyFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        protected static DotMemberAttributeKeyLookup CreateAttributeKeyLookupForPropertyAccessorsOf(Type attributeCollectionType)
        {
            var result = new DotMemberAttributeKeyLookup();

            var type = attributeCollectionType;
            while (type is {})
            {
                AddAttributeKeyLookupForDeclaredPropertyAccessorsOf(result, type);
                type = type.BaseType;
            }

            return result;
        }

        private static void AddAttributeKeyLookupForDeclaredPropertyAccessorsOf(DotMemberAttributeKeyLookup lookup, Type attributeCollectionType)
        {
            var properties = attributeCollectionType.GetProperties(BindingFlags.DeclaredOnly | AttributePropertyFlags);

            foreach (var property in properties)
            {
                if (!(property.GetCustomAttribute<DotAttributeKeyAttribute>() is {} attribute))
                {
                    continue;
                }

                if (property.GetMethod is {} getter)
                {
                    lookup.Set(getter, attribute.Key);
                }

                if (property.SetMethod is {} setter)
                {
                    lookup.Set(setter, attribute.Key);
                }
            }
        }

        protected static DotMemberAttributeKeyLookup CreateAttributeKeyLookupForEntityAttributePropertiesOf(
            Type attributeCollectionType,
            Type entityAttributePropertiesInterfaceType,
            DotMemberAttributeKeyLookup propertyAccessorsAttributeKeyLookup
        )
        {
            var result = new DotMemberAttributeKeyLookup();

            CreateAttributeKeyLookupForEntityAttributePropertiesOf(
                result,
                propertyAccessorsAttributeKeyLookup,
                attributeCollectionType,
                entityAttributePropertiesInterfaceType
            );

            return result;
        }

        private static void CreateAttributeKeyLookupForEntityAttributePropertiesOf(
            DotMemberAttributeKeyLookup result,
            DotMemberAttributeKeyLookup propertyAccessorsAttributeKeyLookup,
            Type attributeCollectionType,
            Type entityAttributePropertiesInterfaceType
        )
        {
            var interfaceProperties = entityAttributePropertiesInterfaceType.GetProperties(AttributePropertyFlags);
            var interfaceMap = attributeCollectionType.GetInterfaceMap(entityAttributePropertiesInterfaceType);

            for (var index = 0; index < interfaceMap.InterfaceMethods.Length; index++)
            {
                var interfacePropertyAccessor = interfaceMap.InterfaceMethods[index];
                var implementationPropertyAccessor = interfaceMap.TargetMethods[index];

                var interfaceProperty = interfaceProperties.First(property =>
                    interfacePropertyAccessor.Equals(property.GetMethod) || interfacePropertyAccessor.Equals(property.SetMethod)
                );

                if (IsAttributeGroupingProperty(interfaceProperty, attributeCollectionType))
                {
                    CreateAttributeKeyLookupForEntityAttributePropertiesOf(
                        result,
                        propertyAccessorsAttributeKeyLookup,
                        attributeCollectionType,
                        interfaceProperty.PropertyType
                    );
                }

                // it is assumed that the attribute collection accessor is already present in the lookup
                else if (propertyAccessorsAttributeKeyLookup.TryGetKey(implementationPropertyAccessor, out var key))
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

        private static bool IsAttributeGroupingProperty(PropertyInfo property, Type attributeCollectionType)
        {
            return property.PropertyType.IsInterface &&
                   property.PropertyType.IsAssignableFrom(attributeCollectionType);
        }
    }
}