using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Entities.Attributes.Properties
{
    public abstract class DotEntityAttributesWithMetadata<TIEntityAttributeProperties> : DotEntityAttributes<TIEntityAttributeProperties>
    {
        protected DotEntityAttributesWithMetadata(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        /// <summary>
        ///     Gets metadata of the DOT attribute the specified property provides access to.
        /// </summary>
        /// <param name="property">
        ///     The property to get attribute metadata for.
        /// </param>
        /// <typeparam name="TProperty">
        ///     The type returned by the property.
        /// </typeparam>
        public virtual DotAttributeMetadata GetMetadata<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
        {
            var key = GetKey(property);
            return DotAttributeKeys.MetadataDictionary[key];
        }

        /// <summary>
        ///     Gets a dictionary where the key is a DOT attribute, and the value is attribute metadata in the context of the current
        ///     element.
        /// </summary>
        public virtual Dictionary<string, DotAttributePropertyMetadata> GetMetadataDictionary()
        {
            var properties = GetPathsOfEntityAttributeProperties();

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
               .ToDictionary(
                    key => key.Key,
                    element => element
                );
        }
    }
}