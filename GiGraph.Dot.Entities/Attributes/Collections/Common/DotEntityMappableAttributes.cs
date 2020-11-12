using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;
using GiGraph.Dot.Entities.Metadata;

namespace GiGraph.Dot.Entities.Attributes.Collections.Common
{
    public abstract class DotEntityMappableAttributes<TIEntityAttributeProperties> : DotEntityAttributes<TIEntityAttributeProperties>
    {
        protected DotEntityMappableAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        /// <summary>
        ///     Gets a dictionary where the key is a DOT attribute, and the value is attribute metadata.
        /// </summary>
        public virtual Dictionary<string, DotAttributePropertyMetadata> GetKeyMapping()
        {
            var attributesMetadata = DotAttributeKeys.GetMetadataDictionary();
            var properties = GetPathsOfEntityAttributeProperties();

            return properties
               .Select(path =>
                {
                    var property = path.Last();
                    var key = property.Property.GetCustomAttribute<DotAttributeKeyAttribute>().Key;
                    var metadata = attributesMetadata[key];

                    return new DotAttributePropertyMetadata(
                        key,
                        metadata.ElementSupport,
                        metadata.LayoutEngineSupport,
                        metadata.OutputFormatSupport,
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