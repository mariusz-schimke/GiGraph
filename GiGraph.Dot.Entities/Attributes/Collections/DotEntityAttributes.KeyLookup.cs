using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Types.Attributes;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public abstract partial class DotEntityAttributes<TIEntityAttributeProperties>
    {
        protected const BindingFlags AttributeKeyPropertyBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        protected readonly DotMemberAttributeKeyLookup _propertyAttributeKeyLookup;

        public virtual string GetAttributeKey<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
        {
            var propertyInfo = GetProperty(property);
            return GetAttributeKey(propertyInfo);
        }

        protected virtual string GetAttributeKey(MethodBase accessor)
        {
            return _propertyAttributeKeyLookup.TryGetKey(accessor, out var key)
                ? key
                : throw new KeyNotFoundException($"No attribute key is defined for the '{accessor}' property accessor of the {accessor.DeclaringType} type.");
        }

        protected virtual string GetAttributeKey(PropertyInfo property)
        {
            return _propertyAttributeKeyLookup.TryGetKey(property, out var key)
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

        protected static DotMemberAttributeKeyLookup CreateMemberAttributeKeyLookupFor(Type entityAttributesType, bool readOnly = true)
        {
            var lookup = new DotMemberAttributeKeyLookup();
            UpdateAttributeKeyLookupWithPropertyAccessorsOf(lookup, entityAttributesType);
            UpdateAttributeKeyLookupWithInterfacePropertiesFor(lookup, lookup, entityAttributesType);

            return readOnly ? lookup.ToReadOnly() : lookup;
        }

        protected static void UpdateAttributeKeyLookupWithPropertyAccessorsOf(DotMemberAttributeKeyLookup lookup, Type entityAttributesType)
        {
            var type = entityAttributesType;
            do
            {
                UpdateAttributeKeyLookupWithDeclaredPropertyAccessorsOf(lookup, type);

                if (type == typeof(DotEntityAttributes<TIEntityAttributeProperties>))
                {
                    break;
                }

                type = type.BaseType;
            } while (type is {});
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

        protected static void UpdateAttributeKeyLookupWithInterfacePropertiesFor(
            DotMemberAttributeKeyLookup output,
            DotMemberAttributeKeyLookup propertyAccessorsAttributeKeyLookup,
            Type entityAttributesType
        )
        {
            UpdateAttributeKeyLookupWithInterfacePropertiesFor(
                output,
                propertyAccessorsAttributeKeyLookup,
                entityAttributesType,
                typeof(TIEntityAttributeProperties)
            );
        }

        protected static void UpdateAttributeKeyLookupWithInterfacePropertiesFor(
            DotMemberAttributeKeyLookup output,
            DotMemberAttributeKeyLookup propertyAccessorsAttributeKeyLookup,
            Type entityAttributesType,
            Type entityAttributePropertiesInterfaceType
        )
        {
            var interfaceProperties = entityAttributePropertiesInterfaceType.GetProperties(AttributeKeyPropertyBindingFlags);
            var interfaceMap = entityAttributesType.GetInterfaceMap(entityAttributePropertiesInterfaceType);

            foreach (var interfaceProperty in interfaceProperties)
            {
                var interfacePropertyAccessor = interfaceProperty.GetMethod ?? interfaceProperty.SetMethod;
                var interfacePropertyAccessorIndex = Array.FindIndex(interfaceMap.InterfaceMethods, method => method.Equals(interfacePropertyAccessor));
                var implementationPropertyAccessor = interfaceMap.TargetMethods[interfacePropertyAccessorIndex];

                // it is assumed that the attribute collection accessor is already present in the lookup
                if (propertyAccessorsAttributeKeyLookup.TryGetKey(implementationPropertyAccessor, out var key))
                {
                    output.Set(interfaceProperty, key);
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