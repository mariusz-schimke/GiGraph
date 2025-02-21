using System.Linq;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Properties;
using GiGraph.Dot.Entities.Attributes.Properties.Accessors;
using GiGraph.Dot.Output.Metadata;
using Xunit;

namespace GiGraph.Dot.Entities.Tests.Attributes.Helpers;

internal static class DotPropertyTreeFactory
{
    /// <summary>
    ///     Gets all properties that represent DOT attributes with the objects they belong to.
    /// </summary>
    /// <param name="targetRootObject">
    ///     The top-level object of the attribute tree structure.
    /// </param>
    /// <param name="attributes">
    ///     Paths to all properties (leaves) of the attribute tree.
    /// </param>
    public static ILookup<DotEntityAttributes, PropertyInfo> GetFlattenedPropertyTreeByMetadata(IDotEntityAttributesAccessor targetRootObject, DotAttributePropertyMetadata[] attributes)
    {
        Assert.NotEmpty(attributes);

        return attributes
            .Select(attribute =>
            {
                var targetObject = targetRootObject.Implementation;
                var targetPropertyPath = attribute.GetPropertyInfoPath();
                var targetProperty = targetPropertyPath.Last();

                // get the target object by path
                targetObject = targetPropertyPath
                    .Take(targetPropertyPath.Length - 1)
                    .Aggregate(targetObject, (current, property) => (DotEntityAttributes) property.GetValue(current)!);

                return new
                {
                    TargetObject = targetObject,
                    TargetProperty = targetProperty
                };
            })
            .ToLookup(x => x.TargetObject, x => x.TargetProperty);
    }
}