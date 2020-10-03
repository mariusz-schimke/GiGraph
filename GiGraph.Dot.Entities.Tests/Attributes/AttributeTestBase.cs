using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GiGraph.Dot.Entities.Tests.Attributes
{
    public abstract class AttributesTestBase
    {
        protected const BindingFlags AttributePropertyFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        protected static PropertyInfo[] GetEntityAttributePropertiesOf(Type attributeCollectionType, Type entityAttributePropertiesInterfaceType)
        {
            var result = new List<PropertyInfo>();
            AddEntityAttributePropertiesOf(result, attributeCollectionType, entityAttributePropertiesInterfaceType);
            return result.Distinct().ToArray();
        }

        private static void AddEntityAttributePropertiesOf(List<PropertyInfo> result, Type attributeCollectionType, Type entityAttributePropertiesInterfaceType)
        {
            var interfaceProperties = entityAttributePropertiesInterfaceType.GetProperties(AttributePropertyFlags);
            var interfaceMap = attributeCollectionType.GetInterfaceMap(entityAttributePropertiesInterfaceType);

            for (var index = 0; index < interfaceMap.InterfaceMethods.Length; index++)
            {
                var interfacePropertyAccessor = interfaceMap.InterfaceMethods[index];

                var interfaceProperty = interfaceProperties.First(property =>
                    interfacePropertyAccessor.Equals(property.GetMethod) ||
                    interfacePropertyAccessor.Equals(property.SetMethod)
                );

                if (IsAttributeGroupingProperty(interfaceProperty, attributeCollectionType))
                {
                    AddEntityAttributePropertiesOf(result, attributeCollectionType, interfaceProperty.PropertyType);
                }
                else
                {
                    result.Add(interfaceProperty);
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