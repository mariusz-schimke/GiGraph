using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using GiGraph.Dot.Entities.Types.Attributes;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public abstract partial class DotEntityAttributeCollection<TExposedEntityAttributes>
    {
        protected const BindingFlags PropertyBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        public virtual string GetKey<TProperty>(Expression<Func<TExposedEntityAttributes, TProperty>> property)
        {
            var propertyInfo = GetImplementationProperty(property);
            return GetKey(propertyInfo);
        }

        public virtual DotNullAttribute SetNull<TProperty>(Expression<Func<TExposedEntityAttributes, TProperty>> property)
        {
            var key = GetKey(property);
            return SetNull(key);
        }

        public virtual DotAttribute Get<TProperty>(Expression<Func<TExposedEntityAttributes, TProperty>> property)
        {
            var key = GetKey(property);
            return TryGetValue(key, out var result) ? result : null;
        }

        public virtual bool Remove<TProperty>(Expression<Func<TExposedEntityAttributes, TProperty>> property)
        {
            var key = GetKey(property);
            return Remove(key);
        }

        public virtual bool Contains<TProperty>(Expression<Func<TExposedEntityAttributes, TProperty>> property)
        {
            var key = GetKey(property);
            return ContainsKey(key);
        }

        public virtual bool IsNullified<TProperty>(Expression<Func<TExposedEntityAttributes, TProperty>> property)
        {
            var key = GetKey(property);
            return IsNullified(key);
        }

        public virtual DotAttribute Set<TProperty>(Expression<Func<TExposedEntityAttributes, TProperty>> property, TProperty value)
        {
            var propertyInfo = GetImplementationProperty(property);
            var key = GetKey(propertyInfo);

            propertyInfo.SetValue(this, value);

            return TryGetValue(key, out var attribute) ? attribute : null;
        }

        public virtual PropertyInfo GetPropertyByKey(string key)
        {
            return GetPropertyKeyMapping().TryGetValue(key, out var property)
                ? property
                : null;
        }

        public virtual Dictionary<string, PropertyInfo> GetPropertyKeyMapping()
        {
            return GetExposedProperties()
               .Select(property => new
                {
                    Attribute = property.GetCustomAttribute<DotAttributeKeyAttribute>(),
                    Property = property
                })
               .Where(result => result.Attribute is {})
               .ToDictionary(
                    key => key.Attribute.Key,
                    value => value.Property
                );
        }

        protected virtual IEnumerable<PropertyInfo> GetExposedProperties()
        {
            var currentType = GetType();
            var interfaceMap = currentType.GetInterfaceMap(typeof(TExposedEntityAttributes));

            return interfaceMap.TargetMethods
               .Select(method => GetPropertyByAccessor(method, currentType))
               .Distinct();
        }

        protected virtual string GetKey(MethodBase propertyMethod)
        {
            return GetKey(propertyMethod, propertyMethod.DeclaringType);
        }

        protected virtual string GetKey(MethodBase propertyMethod, Type declaringType)
        {
            var property = GetPropertyByAccessor(propertyMethod, declaringType);
            return GetKey(property);
        }

        protected virtual string GetKey(PropertyInfo property)
        {
            return property.GetCustomAttribute<DotAttributeKeyAttribute>()?.Key ??
                   throw new KeyNotFoundException("The specified property has no DOT attribute key assigned.");
        }

        protected virtual PropertyInfo GetImplementationProperty<TProperty>(Expression<Func<TExposedEntityAttributes, TProperty>> property)
        {
            var propertyInfo = (property.Body as MemberExpression)?.Member as PropertyInfo ??
                               throw new ArgumentException("Property expression expected.", nameof(property));

            // make sure the property expression refers to current instance type, to any of its base classes, or to an interface it implements
            if (!propertyInfo.DeclaringType.IsAssignableFrom(GetType()))
            {
                throw new ArgumentException("The property expression must refer to a member of the current instance.", nameof(property));
            }

            return GetImplementationProperty(propertyInfo);
        }

        protected virtual PropertyInfo GetImplementationProperty(PropertyInfo propertyInfo)
        {
            var currentType = GetType();

            if (propertyInfo.DeclaringType.IsInterface)
            {
                // get the get method (property expression is impossible for write-only properties)
                // include non-public methods (interface may be implemented explicitly)
                var propertyMethod = propertyInfo.GetGetMethod(nonPublic: true);

                var interfaceMap = currentType.GetInterfaceMap(propertyInfo.DeclaringType);
                var interfaceMethodIndex = Array.FindIndex(interfaceMap.InterfaceMethods, method => method.Equals(propertyMethod));
                var targetMethod = interfaceMap.TargetMethods[interfaceMethodIndex];

                return GetPropertyByAccessor(targetMethod, currentType);
            }

            return propertyInfo;
        }

        protected virtual PropertyInfo GetPropertyByAccessor(MethodBase propertyAccessor, Type declaringType)
        {
            var property = declaringType
              ?.GetProperties(PropertyBindingFlags)
              ?.FirstOrDefault(propertyInfo => propertyAccessor.Equals(propertyInfo.GetSetMethod(nonPublic: true)) ||
                                               propertyAccessor.Equals(propertyInfo.GetGetMethod(nonPublic: true)));

            if (property is null)
            {
                throw new ArgumentException("The specified method must be a property setter or getter.", nameof(propertyAccessor));
            }

            return property;
        }
    }
}