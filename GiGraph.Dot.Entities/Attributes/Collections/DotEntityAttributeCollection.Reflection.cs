using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using GiGraph.Dot.Entities.Types.Attributes;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public abstract partial class DotEntityAttributeCollection<TIExposedEntityAttributes>
    {
        public virtual string GetKey<TProperty>(Expression<Func<TIExposedEntityAttributes, TProperty>> property)
        {
            var propertyInfo = GetProperty(property);
            return GetKey(propertyInfo);
        }

        public virtual DotNullAttribute SetNull<TProperty>(Expression<Func<TIExposedEntityAttributes, TProperty>> property)
        {
            var key = GetKey(property);
            return SetNull(key);
        }

        public virtual DotAttribute Get<TProperty>(Expression<Func<TIExposedEntityAttributes, TProperty>> property)
        {
            var key = GetKey(property);
            return TryGetValue(key, out var result) ? result : null;
        }

        public virtual DotAttribute Set<TProperty>(Expression<Func<TIExposedEntityAttributes, TProperty>> property, TProperty value)
        {
            var propertyInfo = GetProperty(property);
            propertyInfo.SetValue(this, value);

            var key = GetKey(propertyInfo);
            return TryGetValue(key, out var attribute) ? attribute : null;
        }

        public virtual bool Remove<TProperty>(Expression<Func<TIExposedEntityAttributes, TProperty>> property)
        {
            var key = GetKey(property);
            return Remove(key);
        }

        public virtual bool Contains<TProperty>(Expression<Func<TIExposedEntityAttributes, TProperty>> property)
        {
            var key = GetKey(property);
            return ContainsKey(key);
        }

        public virtual bool IsNullified<TProperty>(Expression<Func<TIExposedEntityAttributes, TProperty>> property)
        {
            var key = GetKey(property);
            return IsNullified(key);
        }

        public virtual string GetPropertyPathByKey(string key)
        {
            return GetPropertyKeyMapping().TryGetValue(key, out var property)
                ? property
                : null;
        }

        public virtual Dictionary<string, string> GetPropertyKeyMapping()
        {
            var properties = GetExposedAttributePropertyPaths();
            
            return properties
               .Select(path => new
                {
                    Key = _exposedEntityAttributesKeyLookup.TryGetKey(path.Last(), out var key) ? key : null,
                    Path = string.Join(".", path.Select(property => property.Name))
                })
               .Where(result => result.Key is {})
               .ToDictionary(
                    key => key.Key,
                    value => value.Path
                );
        }

        protected virtual string GetKey(MethodBase accessor)
        {
            return _propertyAccessorsAttributeKeyLookup.TryGetKey(accessor, out var key)
                ? key
                : throw new ArgumentException($"No attribute key is defined for the '{accessor}' property accessor of the {accessor.DeclaringType} type.", nameof(accessor));
        }

        protected virtual string GetKey(PropertyInfo property)
        {
            return _exposedEntityAttributesKeyLookup.TryGetKey(property, out var key)
                ? key
                : throw new ArgumentException($"No attribute key is defined for the '{property}' property of the {property.DeclaringType} type.", nameof(property));
        }

        protected virtual PropertyInfo GetProperty<TProperty>(Expression<Func<TIExposedEntityAttributes, TProperty>> property)
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
        
        protected virtual PropertyInfo[][] GetExposedAttributePropertyPaths()
        {
            var result = new List<PropertyInfo[]>();
            GetExposedAttributePropertyPaths(typeof(TIExposedEntityAttributes), GetType(), result, new PropertyInfo[0]);

            return result.ToArray();
        }

        protected virtual void GetExposedAttributePropertyPaths(Type exposedAttributesInterfaceType, Type attributeCollectionType, List<PropertyInfo[]> result, PropertyInfo[] path)
        {
            var properties = exposedAttributesInterfaceType.GetProperties(PropertyBindingFlags);

            foreach (var property in properties)
            {
                var currentPath = path.Append(property).ToArray();

                if (IsAttributeGroupingInterface(property.PropertyType, attributeCollectionType))
                {
                    GetExposedAttributePropertyPaths(property.PropertyType, attributeCollectionType, result, currentPath);
                }
                else
                {
                    result.Add(currentPath);
                }
            }
        }

        protected static bool IsAttributeGroupingInterface(Type exposedAttributesInterfaceType, Type attributeCollectionType)
        {
            return exposedAttributesInterfaceType.IsInterface &&
                   exposedAttributesInterfaceType.IsAssignableFrom(attributeCollectionType);
        }
    }
}