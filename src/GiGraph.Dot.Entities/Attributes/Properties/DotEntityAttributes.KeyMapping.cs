using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Entities.Attributes.Properties
{
    public abstract partial class DotEntityAttributes : IDotEntityAttributes
    {
        /// <summary>
        ///     The binding flags describing the properties of the class that may have a DOT attribute key assigned by the
        ///     <see cref="DotAttributeKeyAttribute" /> property attribute.
        /// </summary>
        internal static readonly BindingFlags AttributeKeyPropertyBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        (DotEntityAttributes EntityAttributes, PropertyInfo Property)[][] IDotEntityAttributes.GetPathsToAttributeProperties()
        {
            var result = new List<Tuple<DotEntityAttributes, PropertyInfo>[]>();
            GetPathsToAttributeProperties(result, Array.Empty<Tuple<DotEntityAttributes, PropertyInfo>>());

            return result.Select(item =>
                item.Select(x => x.ToValueTuple()).ToArray()
            ).ToArray();
        }

        protected virtual void GetPathsToAttributeProperties(
            List<Tuple<DotEntityAttributes, PropertyInfo>[]> output,
            Tuple<DotEntityAttributes, PropertyInfo>[] basePath
        )
        {
            var properties = GetType().GetProperties(AttributeKeyPropertyBindingFlags);

            foreach (var property in properties)
            {
                var currentPath = basePath
                   .Append(new Tuple<DotEntityAttributes, PropertyInfo>(this, property))
                   .ToArray();

                if (property.GetCustomAttribute<DotAttributeKeyAttribute>() is not null)
                {
                    output.Add(currentPath);
                }

                if (typeof(DotEntityAttributes).IsAssignableFrom(property.PropertyType))
                {
                    var next = (DotEntityAttributes) property.GetValue(this);
                    next.GetPathsToAttributeProperties(output, currentPath);
                }
            }
        }
    }
}