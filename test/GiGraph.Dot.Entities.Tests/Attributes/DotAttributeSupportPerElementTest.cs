using System.Reflection;
using GiGraph.Dot.Entities.Tests.Attributes.Factories;
using GiGraph.Dot.Helpers;
using GiGraph.Dot.Output.Metadata;
using Snapshooter.Xunit;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes;

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
    public void element_supports_correct_attribute_keys(DotCompatibleElements element, Dictionary<string, DotAttributePropertyMetadata> elementAttributesMetadata)
    {
        var validKeys = GetCompatibleKeysFor(element);

        var result = elementAttributesMetadata.Keys
            .Except(validKeys.Intersect(elementAttributesMetadata.Keys))
            .ToArray();

        if (result.Length > 0)
        {
            throw new Exception($"The following attributes are not supposed to be supported by [{element}] or are marked as unimplemented: {string.Join(", ", result)}");
        }
    }

    [Theory]
    [MemberData(nameof(ElementAttributesMetadata))]
    public void element_supports_all_required_attribute_keys(DotCompatibleElements element, Dictionary<string, DotAttributePropertyMetadata> elementAttributesMetadata)
    {
        var validKeys = GetCompatibleKeysFor(element);

        var result = validKeys
            .Except(elementAttributesMetadata.Keys.Intersect(validKeys))
            .ToArray();

        if (result.Length > 0)
        {
            throw new Exception($"The following attributes have to be supported by [{element}]: {string.Join(", ", result)}");
        }
    }

    [Fact]
    public void property_key_mappings_are_compliant_with_the_documentation()
    {
        var attributesMetadata = DotElementAttributesMetadataFactory.Create();

        var keyMap = attributesMetadata
            .SelectMany(metadata => metadata.Attributes
                .Select(attribute => new
                {
                    metadata.Element,
                    attribute.Key,
                    attribute.Value.PropertyPath,
                    Property = attribute.Value.GetPropertyInfoPath().Last()
                })
            )
            .GroupBy(item => item.Key)
            .ToDictionary(
                group => group.Key,
                group => new SortedDictionary<DotCompatibleElements, string>(
                    group.ToDictionary(
                        g => g.Element,
                        g => $"{g.PropertyPath}: {TypeHelper.GetDisplayName(g.Property.PropertyType)}"
                    ))
            );

        var sortedKeyMap = new SortedDictionary<string, SortedDictionary<DotCompatibleElements, string>>(keyMap);
        Snapshot.Match(sortedKeyMap, "attribute_property_key_map");
    }

    private static string[] GetCompatibleKeysFor(DotCompatibleElements compatibleElements)
    {
        return typeof(DotAttributeKeys)
            .GetFields(BindingFlags.Static | BindingFlags.Public)
            .Select(property => new
            {
                Key = (string) property.GetValue(null)!,
                Metadata = property.GetCustomAttribute<DotAttributeMetadataAttribute>()!
            })
            .Where(item => item.Metadata.CompatibleElements.HasFlag(compatibleElements))
            .Where(item => item.Metadata.IsImplemented)
            .Select(item => item.Key)
            .ToArray();
    }
}