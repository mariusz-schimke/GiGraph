using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                throw new Exception($"The following attributes are not supposed to be supported by [{element}]: {string.Join(", ", result)}");
            }
        }

        [Theory]
        [MemberData(nameof(ElementAttributesMetadata))]
        public void element_supports_all_required_attribute_keys(DotElementSupport element, Dictionary<string, DotAttributePropertyMetadata> elementAttributesMetadata)
        {
            var validKeys = GetSupportedKeysFor(element);

            var result = validKeys
               .Except(elementAttributesMetadata.Keys.Intersect(validKeys))
               .ToArray();

            if (result.Any())
            {
                throw new Exception($"The following attributes must be supported by [{element}]: {string.Join(", ", result)}");
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
            return typeof(DotAttributeKeys)
               .GetFields(BindingFlags.Static | BindingFlags.Public)
               .Select(property => new
                {
                    Key = (string) property.GetValue(null),
                    Metadata = property.GetCustomAttribute<DotAttributeSupportAttribute>()
                })
               .Where(item => item.Metadata.Elements.HasFlag(elementSupport))
               .Where(item => item.Metadata.IsImplemented)
               .Select(item => item.Key)
               .ToArray();
        }
    }
}