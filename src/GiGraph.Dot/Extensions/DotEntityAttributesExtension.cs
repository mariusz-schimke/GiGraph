using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Extensions
{
    public static class DotEntityAttributesExtension
    {
        /// <summary>
        ///     Gets metadata of the DOT attribute the specified property provides access to.
        /// </summary>
        /// <param name="this">
        ///     The current attribute collection context whose property to get the metadata for.
        /// </param>
        /// <param name="property">
        ///     The property to get attribute metadata for.
        /// </param>
        /// <typeparam name="TProperty">
        ///     The type returned by the property.
        /// </typeparam>
        /// <typeparam name="TProperties">
        ///     Provides access to properties that represent DOT attributes.
        /// </typeparam>
        public static DotAttributeMetadata GetMetadata<TProperties, TProperty>(this DotEntityAttributes<TProperties> @this, Expression<Func<TProperties, TProperty>> property)
        {
            var key = @this.GetKey(property);
            return DotAttributeKeys.MetadataDictionary[key];
        }

        /// <summary>
        ///     Gets a dictionary where the key is a DOT attribute, and the value is attribute metadata in the context of the current
        ///     element.
        /// </summary>
        /// <param name="this">
        ///     The current attribute collection context to get the metadata dictionary for.
        /// </param>
        public static Dictionary<string, DotAttributePropertyMetadata> GetMetadataDictionary<TProperties>(this DotEntityAttributes<TProperties> @this)
        {
            var properties = ((IDotEntityAttributes) @this).GetPathsToAttributeProperties();

            return properties
               .Select(path =>
                {
                    var property = path.Last();
                    var key = property.Property.GetCustomAttribute<DotAttributeKeyAttribute>().Key;
                    var metadata = DotAttributeKeys.MetadataDictionary[key];

                    return new DotAttributePropertyMetadata(
                        key,
                        metadata.CompatibleElements,
                        metadata.CompatibleLayoutEngines,
                        metadata.CompatibleOutputs,
                        path.Select(item => item.Property).ToArray()
                    );
                })
               .ToDictionary(key => key.Key, element => element);
        }
    }
}