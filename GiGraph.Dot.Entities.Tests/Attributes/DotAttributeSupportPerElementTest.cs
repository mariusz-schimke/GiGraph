using System;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Entities.Metadata;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes
{
    public class DotAttributeSupportPerElementTest
    {
        public static IEnumerable<object[]> ElementAttributesMetadata =>
            DotElementAttributesMetadataFactory.Create().Select(x => new object[]
            {
                x.Element,
                x.Attributes
            });

        [Theory]
        [MemberData(nameof(ElementAttributesMetadata))]
        public void element_supports_correct_attribute_keys(DotElementSupport element, Dictionary<string, DotAttributePropertyMetadata> elementAttributesMetadata)
        {
            var validKeys = GetSupportedKeysFor(element);

            var result = elementAttributesMetadata.Keys
               .Except(validKeys.Intersect(elementAttributesMetadata.Keys))
               .ToArray();

            if (result.Any())
            {
                throw new Exception($"Incorrect attributes supported by {element}: {string.Join(", ", result)}");
            }
        }

        [Fact]
        public void attribute_key_is_supported_by_all_required_elements_or_by_none()
        {
            // get all supported keys per entity type
            var entityKeys = DotElementAttributesMetadataFactory.Create()
               .GroupBy(
                    key => key.Element,
                    element => element.Attributes.Keys.Select(key => key).ToArray()
                )
               .ToLookup(
                    key => key.Key,
                    element => element.SelectMany(x => x).ToArray()
                );

            // for all valid keys check if any of them is supported by any entity, and if so,
            // then it must be supported by all entities that the mapping indicates 
            foreach (var attribute in DotAttributeKeys.MetadataDictionary)
            {
                var supportedByOtherEntities = false;

                foreach (var entityType in Enum.GetValues(typeof(DotElementSupport)).Cast<DotElementSupport>())
                {
                    if (attribute.Value.ElementSupport.HasFlag(entityType))
                    {
                        if (entityKeys[entityType].First().Contains(attribute.Key))
                        {
                            supportedByOtherEntities = true;
                        }
                        else if (supportedByOtherEntities)
                        {
                            throw new Exception($"The '{attribute.Key}' attribute is not supported by {entityType} (expected support by: {attribute.Value.ElementSupport})");
                        }
                    }
                }
            }
        }

        [Fact]
        public void property_key_mappings_are_compliant_with_the_documentation()
        {
            var attributesMetadata = DotElementAttributesMetadataFactory.Create();

            var keyLookup = attributesMetadata
               .SelectMany(metadata => metadata.Attributes.Select(attribute => new
                {
                    metadata.Element,
                    attribute.Key,
                    attribute.Value.PropertyPath
                }))
               .ToLookup(
                    key => key.Key,
                    element => element
                )
               .ToDictionary(
                    key => key.Key,
                    element =>
                    {
                        return element
                           .GroupBy(
                                groupKey => groupKey.PropertyPath,
                                groupElement => groupElement.Element
                            )
                           .Select(property => $"{property.Key} [{property.Aggregate((current, value) => current | value)}]")
                           .ToArray();
                    }
                );

            Snapshot.Match(new SortedDictionary<string, string[]>(keyLookup), "attribute_property_key_map");
        }

        private static string[] GetSupportedKeysFor(DotElementSupport elementSupport)
        {
            return DotAttributeKeys.MetadataDictionary
               .Where(item => item.Value.ElementSupport.HasFlag(elementSupport))
               .Select(item => item.Key)
               .ToArray();
        }
    }
}