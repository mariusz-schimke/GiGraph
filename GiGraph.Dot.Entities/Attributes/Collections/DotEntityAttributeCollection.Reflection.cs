using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public abstract partial class DotEntityAttributeCollection<TIEntityAttributeProperties>
    {
        public virtual string GetKey<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
        {
            return _attributes.GetAttributeKey(property);
        }

        public virtual DotNullAttribute Nullify<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
        {
            return _attributes.Nullify(property);
        }

        public virtual DotAttribute Get<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
        {
            return _attributes.GetAttribute(property);
        }

        public virtual DotAttribute Set<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property, TProperty value)
        {
            return _attributes.SetAttribute(property, value);
        }

        public virtual bool Remove<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
        {
            return _attributes.RemoveAttribute(property);
        }

        public virtual bool Contains<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
        {
            return _attributes.HasAttribute(property);
        }

        public virtual bool IsNullified<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
        {
            return _attributes.HasNullified(property);
        }

        public virtual string GetPropertyPathByKey(string key)
        {
            return GetPropertyKeyMapping().TryGetValue(key, out var property)
                ? property
                : null;
        }

        public virtual Dictionary<string, string> GetPropertyKeyMapping()
        {
            var properties = GetPathsOfEntityAttributeProperties();

            return properties
               .Select(path => new
                {
                    Key = _entityAttributePropertiesInterfaceKeyLookup.TryGetKey(path.Last(), out var key) ? key : null,
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
                : throw new KeyNotFoundException($"No attribute key is defined for the '{accessor}' property accessor of the {accessor.DeclaringType} type.");
        }

        public virtual string GetKey(PropertyInfo property)
        {
            return _entityAttributePropertiesInterfaceKeyLookup.TryGetKey(property, out var key)
                ? key
                : throw new KeyNotFoundException($"No attribute key is defined for the '{property}' property of the {property.DeclaringType} type.");
        }

        protected virtual PropertyInfo[][] GetPathsOfEntityAttributeProperties()
        {
            var result = new List<PropertyInfo[]>();
            GetPathsOfEntityAttributeProperties(typeof(TIEntityAttributeProperties), GetType(), result, new PropertyInfo[0]);
            return result.ToArray();
        }

        protected virtual void GetPathsOfEntityAttributeProperties(Type entityAttributesInterfaceType, Type attributeCollectionType, List<PropertyInfo[]> result, PropertyInfo[] path)
        {
            var properties = entityAttributesInterfaceType.GetProperties(AttributeKeyPropertyBindingFlags);

            foreach (var property in properties)
            {
                var currentPath = path.Append(property).ToArray();

                if (IsAttributeGroupingProperty(property, attributeCollectionType))
                {
                    GetPathsOfEntityAttributeProperties(property.PropertyType, attributeCollectionType, result, currentPath);
                }
                else
                {
                    result.Add(currentPath);
                }
            }
        }

        protected static bool IsAttributeGroupingProperty(PropertyInfo property, Type attributeCollectionType)
        {
            return property.PropertyType.IsInterface &&
                   property.PropertyType.IsAssignableFrom(attributeCollectionType);
        }
    }
}