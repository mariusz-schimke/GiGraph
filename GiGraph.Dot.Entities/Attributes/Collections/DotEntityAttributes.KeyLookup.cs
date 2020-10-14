using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Types.Attributes;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public abstract partial class DotEntityAttributes<TIEntityAttributeProperties>
    {
        protected const BindingFlags AttributeKeyPropertyBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        protected readonly DotMemberAttributeKeyLookup _attributeKeyLookup;

        public virtual string GetAttributeKey<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
        {
            var propertyInfo = GetProperty(property);
            return GetAttributeKey(propertyInfo);
        }

        protected virtual string GetAttributeKey(MethodBase accessor)
        {
            var method = (MethodInfo) accessor;

            return _attributeKeyLookup.TryGetKey(method.GetRuntimeBaseDefinition(), out var key)
                ? key
                : throw new KeyNotFoundException($"No attribute key is defined for the '{accessor}' property accessor of the {accessor.DeclaringType} type.");
        }

        protected virtual string GetAttributeKey(PropertyInfo property)
        {
            return _attributeKeyLookup.TryGetKey(property, out var key)
                ? key
                : throw new KeyNotFoundException($"No attribute key is defined for the '{property}' property of the {property.DeclaringType} type.");
        }

        protected virtual PropertyInfo GetProperty<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
        {
            var propertyInfo = (property.Body as MemberExpression)?.Member as PropertyInfo ??
                               throw new ArgumentException("Property expression expected.", nameof(property));

            // make sure the property expression refers to current instance type, to any of its base classes, or to an interface it implements
            if (!propertyInfo.DeclaringType.IsAssignableFrom(GetType()))
            {
                throw new ArgumentException("The property expression must refer to a member of the current instance.", nameof(property));
            }

            return propertyInfo;
        }

        protected static DotMemberAttributeKeyLookup CreateAttributeKeyLookupForMembersOf(Type entityAttributesType, bool readOnly = true)
        {
            var lookup = new DotMemberAttributeKeyLookup();
            UpdateAttributeKeyLookupForMembersOf(lookup, entityAttributesType);
            return readOnly ? lookup.ToReadOnly() : lookup;
        }

        protected static void UpdateAttributeKeyLookupForMembersOf(DotMemberAttributeKeyLookup output, Type entityAttributesType)
        {
            UpdateAttributeKeyLookupForMembersOf(output, entityAttributesType, typeof(TIEntityAttributeProperties));
        }

        protected static void UpdateAttributeKeyLookupForMembersOf(DotMemberAttributeKeyLookup output, Type entityAttributesType, Type entityAttributePropertiesInterfaceType)
        {
            var interfaceProperties = entityAttributePropertiesInterfaceType.GetProperties(AttributeKeyPropertyBindingFlags);
            var interfaceMap = entityAttributesType.GetInterfaceMap(entityAttributePropertiesInterfaceType);

            var propertiesDeclaringTypes = interfaceMap
               .TargetMethods
               .Select(accessor => accessor.DeclaringType)
               .Distinct();

            var propertiesDeclaringTypesLookup = new DotMemberAttributeKeyLookup();
            foreach (var propertyDeclaringType in propertiesDeclaringTypes)
            {
                UpdateAttributeKeyLookupWithDeclaredPropertyAccessorsOf(propertiesDeclaringTypesLookup, propertyDeclaringType);
            }

            foreach (var targetMethod in interfaceMap.TargetMethods)
            {
                var key = propertiesDeclaringTypesLookup.GetKey(targetMethod);
                output.Set(targetMethod.GetRuntimeBaseDefinition(), key);
            }

            foreach (var interfaceProperty in interfaceProperties)
            {
                var interfacePropertyAccessor = interfaceProperty.GetMethod ?? interfaceProperty.SetMethod;
                var interfacePropertyAccessorIndex = Array.FindIndex(interfaceMap.InterfaceMethods, method => method.Equals(interfacePropertyAccessor));
                var implementationPropertyAccessor = interfaceMap.TargetMethods[interfacePropertyAccessorIndex];

                var key = propertiesDeclaringTypesLookup.GetKey(implementationPropertyAccessor);
                output.Set(interfaceProperty, key);
            }
        }

        protected static void UpdateAttributeKeyLookupWithDeclaredPropertyAccessorsOf(DotMemberAttributeKeyLookup lookup, Type entityAttributesType)
        {
            var properties = entityAttributesType.GetProperties(BindingFlags.DeclaredOnly | AttributeKeyPropertyBindingFlags);

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
    }
}