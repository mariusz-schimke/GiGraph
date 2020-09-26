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
        protected static Dictionary<MethodBase, string> _attributeKeyCache = new Dictionary<MethodBase, string>();
        protected static object _attributeKeyCacheReplacementLock = new object();

        static DotEntityAttributeCollection()
        {
            CacheAttributeKeys(typeof(DotEntityAttributeCollection<>));
        }

        public virtual string GetKey<TProperty>(Expression<Func<TExposedEntityAttributes, TProperty>> property)
        {
            var propertyInfo = GetProperty(property);
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
            var propertyInfo = GetProperty(property);
            propertyInfo.SetValue(this, value);

            var key = GetKey(propertyInfo);
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

        protected virtual PropertyInfo[] GetExposedProperties()
        {
            return GetExposedProperties(typeof(TExposedEntityAttributes), GetType());
        }

        protected virtual PropertyInfo[] GetExposedProperties(Type interfaceType, Type implementationType)
        {
            // var interfaceMap = implementationType.GetInterfaceMap(interfaceType);
            //
            // return interfaceMap.TargetMethods
            //    .SelectMany(implementationMethod =>
            //     {
            //         var property = GetPropertyByAccessor(implementationMethod, implementationType);
            //
            //         // attribute grouping properties are exposed as interfaces
            //         return property.PropertyType.IsInterface
            //             ? GetExposedProperties(property.PropertyType, implementationType)
            //             : new[] { property };
            //     })
            //    .Distinct()
            //    .ToArray();
            return null;
        }

        protected virtual string GetKey(MethodBase accessor)
        {
            return _attributeKeyCache.TryGetValue(accessor, out var key)
                ? key
                : throw new ArgumentException(
                    $"The specified {accessor.Name} method must be a property setter or getter implemented by the {GetType().FullName} type.",
                    nameof(accessor)
                );
        }

        protected virtual string GetKey(PropertyInfo property)
        {
            if (!property.DeclaringType.IsInterface)
            {
                return property.GetCustomAttribute<DotAttributeKeyAttribute>()?.Key ??
                       throw new KeyNotFoundException("The specified property has no DOT attribute key assigned.");
            }

            // get the get method (property expression is impossible for write-only properties)
            var propertyGetter = property.GetMethod;

            var interfaceMap = GetType().GetInterfaceMap(property.DeclaringType);
            var interfaceMethodIndex = Array.FindIndex(interfaceMap.InterfaceMethods, method => method.Equals(propertyGetter));
            var implementationMethod = interfaceMap.TargetMethods[interfaceMethodIndex];

            return GetKey(implementationMethod);
        }

        protected virtual PropertyInfo GetProperty<TProperty>(Expression<Func<TExposedEntityAttributes, TProperty>> property)
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

        protected static void CacheAttributeKeys(Type attributeCollectionType)
        {
            const BindingFlags propertyBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

            var attributeKeyCache = new Dictionary<MethodBase, DotAttributeKeyAttribute>();
            var properties = attributeCollectionType.GetProperties(propertyBindingFlags);

            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttribute<DotAttributeKeyAttribute>();
                if (attribute is null)
                {
                    continue;
                }

                if (property.GetMethod is {} getter)
                {
                    attributeKeyCache[getter] = attribute;
                }

                if (property.SetMethod is {} setter)
                {
                    attributeKeyCache[setter] = attribute;
                }
            }

            ReplaceAttributeKeyCache(attributeKeyCache);
        }

        protected static void ReplaceAttributeKeyCache(Dictionary<MethodBase, DotAttributeKeyAttribute> attributeKeyCache)
        {
            lock (_attributeKeyCacheReplacementLock)
            {
                var attributeKeyCacheCopy = new Dictionary<MethodBase, string>(_attributeKeyCache);

                foreach (var cacheItem in attributeKeyCache)
                {
                    attributeKeyCacheCopy[cacheItem.Key] = cacheItem.Value.Key;
                }

                _attributeKeyCache = attributeKeyCacheCopy;
            }
        }
    }
}