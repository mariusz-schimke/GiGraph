using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Types.Attributes;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public abstract partial class DotEntityAttributes<TIEntityAttributeProperties>
    {
        // TODO: czy metody na poziomie bazowym powinny mieć te same nazwy co w kontekście grupy attrybutów, np. Font?

        public virtual string GetAttributeKey<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
        {
            var propertyInfo = GetProperty(property);
            return GetAttributeKey(propertyInfo);
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
            var entityAttributePropertiesInterfaceTypes = typeof(TIEntityAttributeProperties).GetInterfaces()
               .Concat(new[] { typeof(TIEntityAttributeProperties) });

            foreach (var interfaceType in entityAttributePropertiesInterfaceTypes)
            {
                UpdateAttributeKeyLookupForMembersOf(output, entityAttributesType, interfaceType);
            }
        }

        protected static void UpdateAttributeKeyLookupForMembersOf(DotMemberAttributeKeyLookup output, Type entityAttributesType, Type entityAttributePropertiesInterfaceType)
        {
            var interfaceProperties = entityAttributePropertiesInterfaceType.GetProperties(AttributeKeyPropertyBindingFlags);
            var interfaceMap = entityAttributesType.GetInterfaceMap(entityAttributePropertiesInterfaceType);

            var propertiesDeclaringTypes = interfaceMap
               .TargetMethods
               .Select(accessor => accessor.DeclaringType)
               .Distinct();

            // build a temporary lookup for all types the implemented properties are declared by
            var propertiesDeclaringTypesLookup = new DotMemberAttributeKeyLookup();
            foreach (var propertyDeclaringType in propertiesDeclaringTypes)
            {
                UpdateAttributeKeyLookupWithDeclaredPropertyAccessorsOf(propertiesDeclaringTypesLookup, propertyDeclaringType);
            }

            // based on the previously created lookup, include base definitions of all implemented property accessors
            foreach (var targetMethod in interfaceMap.TargetMethods)
            {
                var key = propertiesDeclaringTypesLookup.GetKey(targetMethod);
                output.Set(targetMethod.GetRuntimeBaseDefinition(), key);
            }

            // include interface properties
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