using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GiGraph.Dot.Entities.Types.Attributes;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public abstract partial class DotEntityAttributes
    {
        protected virtual (DotEntityAttributes EntityAttributes, PropertyInfo Property)[][] GetPathsOfEntityAttributeProperties()
        {
            var result = new List<Tuple<DotEntityAttributes, PropertyInfo>[]>();
            GetPathsOfEntityAttributeProperties(result, new Tuple<DotEntityAttributes, PropertyInfo>[0]);

            return result.Select(item =>
                item.Select(x => x.ToValueTuple()).ToArray()
            ).ToArray();
        }

        protected virtual void GetPathsOfEntityAttributeProperties(
            List<Tuple<DotEntityAttributes, PropertyInfo>[]> output,
            Tuple<DotEntityAttributes, PropertyInfo>[] basePath
        )
        {
            var properties = GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach (var property in properties)
            {
                var currentPath = basePath
                   .Append(new Tuple<DotEntityAttributes, PropertyInfo>(this, property))
                   .ToArray();

                if (typeof(DotEntityAttributes).IsAssignableFrom(property.PropertyType))
                {
                    var next = (DotEntityAttributes) property.GetValue(this);
                    next.GetPathsOfEntityAttributeProperties(output, currentPath);
                }
                else if (property.GetCustomAttribute<DotAttributeKeyAttribute>() is {})
                {
                    output.Add(currentPath);
                }
            }
        }
    }
}