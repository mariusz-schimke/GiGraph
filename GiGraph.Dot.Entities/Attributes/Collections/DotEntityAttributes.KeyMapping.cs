using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GiGraph.Dot.Entities.Types.Attributes;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public abstract partial class DotEntityAttributes
    {
        // TODO: move to top-level attributes only
        public virtual Dictionary<string, string> GetAttributeKeyMapping()
        {
            var properties = GetPathsOfEntityAttributeProperties();

            return properties
               .Select(path =>
                {
                    var actual = path.Last();
                    return new
                    {
                        Key = actual.EntityAttributes.GetAttributeKey(actual.Property),
                        Path = string.Join(".", path.Select(item => item.Property.Name))
                    };
                })
               .ToDictionary(
                    key => key.Key,
                    value => value.Path
                );
        }

        protected virtual (DotEntityAttributes EntityAttributes, PropertyInfo Property)[][] GetPathsOfEntityAttributeProperties()
        {
            var result = new List<Tuple<DotEntityAttributes, PropertyInfo>[]>();
            GetPathsOfEntityAttributePropertiesRecursively(result, new Tuple<DotEntityAttributes, PropertyInfo>[0]);

            return result.Select(item =>
                item.Select(x => x.ToValueTuple()).ToArray()
            ).ToArray();
        }

        protected virtual void GetPathsOfEntityAttributePropertiesRecursively(
            List<Tuple<DotEntityAttributes, PropertyInfo>[]> result,
            Tuple<DotEntityAttributes, PropertyInfo>[] basePath
        )
        {
            var properties = GetType().GetProperties(AttributeKeyPropertyBindingFlags);

            foreach (var property in properties)
            {
                var currentPath = basePath
                   .Append(new Tuple<DotEntityAttributes, PropertyInfo>(this, property))
                   .ToArray();

                if (typeof(DotEntityAttributes).IsAssignableFrom(property.PropertyType))
                {
                    var next = (DotEntityAttributes) property.GetValue(this);
                    next.GetPathsOfEntityAttributePropertiesRecursively(result, currentPath);
                }
                else if (property.GetCustomAttribute<DotAttributeKeyAttribute>() is {})
                {
                    result.Add(currentPath);
                }
            }
        }
    }
}