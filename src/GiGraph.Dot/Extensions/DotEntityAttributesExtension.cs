using System.Linq.Expressions;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.Accessors;
using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Extensions;

public static class DotEntityAttributesExtension
{
    /// <summary>
    ///     Gets the metadata of the DOT attribute specified by the property expression.
    /// </summary>
    /// <param name="accessor">
    ///     The current attribute collection context whose property to get the metadata for.
    /// </param>
    /// <param name="property">
    ///     The property to get attribute metadata for.
    /// </param>
    /// <typeparam name="TProperty">
    ///     The type returned by the property.
    /// </typeparam>
    /// <typeparam name="TInterface">
    ///     An interface that provides access to properties that represent DOT attributes.
    /// </typeparam>
    /// <typeparam name="TImplementation">
    ///     The implementation of the <typeparamref name="TInterface"/> interface.
    /// </typeparam>
    public static DotAttributeMetadata GetMetadata<TInterface, TImplementation, TProperty>(
        this DotEntityAttributesAccessor<TInterface, TImplementation> accessor,
        Expression<Func<TInterface, TProperty>> property
    )
        where TImplementation : DotEntityAttributesWithMetadata<TInterface, TImplementation>, TInterface
    {
        var key = accessor.GetKey(property);
        return DotAttributeKeys.MetadataDictionary[key];
    }

    /// <summary>
    ///     Gets a dictionary where the key is a DOT attribute, and the value is the attribute's metadata in the context of the current
    ///     element.
    /// </summary>
    /// <param name="accessor">
    ///     The current attribute collection context to get the metadata dictionary for.
    /// </param>
    public static Dictionary<string, DotAttributePropertyMetadata> GetMetadataDictionary<TInterface, TImplementation>(
        this DotEntityAttributesAccessor<TInterface, TImplementation> accessor
    )
        where TImplementation : DotEntityAttributesWithMetadata<TInterface, TImplementation>, TInterface
    {
        var propertyPathDictionary = accessor.GetPathsToAttributeProperties();

        return propertyPathDictionary
            .Select(item =>
                {
                    var metadata = DotAttributeKeys.MetadataDictionary[item.Key];

                    return new DotAttributePropertyMetadata(
                        item.Key,
                        metadata.CompatibleElements,
                        metadata.CompatibleLayoutEngines,
                        metadata.CompatibleOutputs,
                        item.Value.Select(propertyInfo => propertyInfo).ToArray()
                    );
                }
            )
            .ToDictionary(key => key.Key, element => element);
    }

    private static IDictionary<string, PropertyInfo[]> GetPathsToAttributeProperties(this IDotEntityAttributesAccessor accessor)
    {
        var output = new Dictionary<string, PropertyInfo[]>();
        accessor.GetPathsToAttributeProperties(output, basePath: []);
        return output;
    }

    private static void GetPathsToAttributeProperties(this IDotEntityAttributesAccessor accessor, IDictionary<string, PropertyInfo[]> output, PropertyInfo[] basePath)
    {
        // get component interfaces and the properties of each of them
        var interfaceProperties = accessor.InterfaceType
            .GetInterfaces()
            .Concat([accessor.InterfaceType])
            .SelectMany(i => i.GetProperties(BindingFlags.Instance | BindingFlags.Public));

        // add the properties to the output asserting that each of them represents an attribute
        foreach (var interfaceProperty in interfaceProperties)
        {
            output.Add(
                accessor.GetPropertyKey(interfaceProperty),
                basePath.Append(interfaceProperty).ToArray()
            );
        }

        // now get all nested property groups
        var nestedAttributesProperties = accessor.Implementation
            .GetType()
            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Where(property => typeof(DotEntityAttributes).IsAssignableFrom(property.PropertyType));

        foreach (var nestedAttributesProperty in nestedAttributesProperties)
        {
            var currentPath = basePath.Append(nestedAttributesProperty).ToArray();

            var nested = (IDotEntityAttributes) nestedAttributesProperty.GetValue(accessor.Implementation)!;
            nested.Accessor.GetPathsToAttributeProperties(output, currentPath);
        }
    }
}