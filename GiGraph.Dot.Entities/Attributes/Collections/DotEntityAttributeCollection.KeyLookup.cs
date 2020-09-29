using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Types.Attributes;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public abstract partial class DotEntityAttributeCollection<TIEntityAttributeProperties>
    {
        protected const BindingFlags AttributeKeyPropertyBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        protected const BindingFlags AttributeKeyDeclaredOnlyPropertyBindingFlags = BindingFlags.DeclaredOnly | AttributeKeyPropertyBindingFlags;

        private static DotMemberAttributeKeyLookup _propertyAccessorsAttributeKeyLookup = new DotMemberAttributeKeyLookup();
        private static readonly object AttributeKeyLookupUpdateLock = new object();

        protected readonly DotMemberAttributeKeyLookup _entityAttributePropertiesInterfaceKeyLookup;

        protected static void UpdateAttributeKeyLookupForDeclaredPropertyAccessorsOf(Type attributeCollectionType)
        {
            var lookup = CreateAttributeKeyLookupForDeclaredPropertyAccessorsOf(attributeCollectionType);
            UpdateAttributeKeyLookupForPropertyAccessorsFrom(lookup);
        }

        protected static void UpdateAttributeKeyLookupForPropertyAccessorsFrom(DotMemberAttributeKeyLookup source)
        {
            lock (AttributeKeyLookupUpdateLock)
            {
                var merged = DotMemberAttributeKeyLookup.Merge(_propertyAccessorsAttributeKeyLookup, source);
                _propertyAccessorsAttributeKeyLookup = merged.ToReadOnly();
            }
        }

        protected static DotMemberAttributeKeyLookup CreateAttributeKeyLookupForDeclaredPropertyAccessorsOf(Type attributeCollectionType)
        {
            var result = new DotMemberAttributeKeyLookup();

            var properties = attributeCollectionType.GetProperties(AttributeKeyDeclaredOnlyPropertyBindingFlags);
            
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

        protected static DotMemberAttributeKeyLookup CreateAttributeKeyLookupForEntityAttributePropertiesOf(Type attributeCollectionType)
        {
            var result = new DotMemberAttributeKeyLookup();

            CreateAttributeKeyLookupForEntityAttributePropertiesOf(
                result,
                _propertyAccessorsAttributeKeyLookup,
                attributeCollectionType,
                typeof(TIEntityAttributeProperties)
            );

            return result;
        }

        protected static void CreateAttributeKeyLookupForEntityAttributePropertiesOf(
            DotMemberAttributeKeyLookup result,
            DotMemberAttributeKeyLookup propertyAccessorsAttributeKeyLookup,
            Type attributeCollectionType,
            Type entityAttributePropertiesInterfaceType
        )
        {
            var interfaceProperties = entityAttributePropertiesInterfaceType.GetProperties(AttributeKeyPropertyBindingFlags);
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
    }
}