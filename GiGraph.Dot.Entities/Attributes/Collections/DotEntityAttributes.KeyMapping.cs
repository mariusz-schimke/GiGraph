using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public abstract partial class DotEntityAttributes<TIEntityAttributeProperties>
    {
        // TODO: move to top-level attributes only
        public virtual Dictionary<string, string> GetAttributeKeyMapping()
        {
            var properties = GetPathsOfEntityAttributeProperties();

            return properties
               .Select(path => new
                {
                    Key = _attributeKeyLookup.TryGetKey(path.Last(), out var key) ? key : null,
                    Path = string.Join(".", path.Select(property => property.Name))
                })
               .Where(result => result.Key is {})
               .ToDictionary(
                    key => key.Key,
                    value => value.Path
                );
        }

        protected virtual PropertyInfo[][] GetPathsOfEntityAttributeProperties()
        {
            var result = new List<PropertyInfo[]>();
            GetPathsOfEntityAttributeProperties(GetType(), result, new PropertyInfo[0]);
            return result.ToArray();
        }

        protected virtual void GetPathsOfEntityAttributeProperties(Type attributeCollectionType, List<PropertyInfo[]> result, PropertyInfo[] path)
        {
            var properties = attributeCollectionType.GetProperties(AttributeKeyPropertyBindingFlags);

            foreach (var property in properties)
            {
                var currentPath = path.Append(property).ToArray();

                if (IsAttributeGroupingProperty(property, attributeCollectionType))
                {
                    //GetPathsOfEntityAttributeProperties(property.PropertyType, attributeCollectionType, result, currentPath);
                }
                else
                {
                    result.Add(currentPath);
                }
            }
        }

        protected static bool IsAttributeGroupingProperty(PropertyInfo property, Type attributeCollectionType)
        {
            return property.PropertyType == typeof(DotEntityAttributes<>).GetGenericTypeDefinition();
        }
    }
}