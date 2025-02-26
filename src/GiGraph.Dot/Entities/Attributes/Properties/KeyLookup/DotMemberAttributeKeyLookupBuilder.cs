using System.Diagnostics.Contracts;
using System.Reflection;
using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;

/// <summary>
///     Builds a lookup for property accessors.
/// </summary>
/// <typeparam name="TEntityAttributes">
///     The entity attributes type.
/// </typeparam>
/// <typeparam name="TIEntityAttributeProperties">
///     The interface that exposes entity-specific attributes of the <typeparamref name="TEntityAttributes" /> type.
/// </typeparam>
public class DotMemberAttributeKeyLookupBuilder<TEntityAttributes, TIEntityAttributeProperties>
    where TEntityAttributes : DotEntityAttributes, TIEntityAttributeProperties
{
    /// <summary>
    ///     Builds lazily a lookup for properties and property accessors.
    /// </summary>
    /// <param name="seal">
    ///     Determines whether the built lookup should be read only.
    /// </param>
    [Pure]
    public virtual Lazy<DotMemberAttributeKeyLookup> BuildLazy(bool seal = true) => new(() => Build(seal));

    /// <summary>
    ///     Builds a lookup for properties and property accessors.
    /// </summary>
    /// <param name="seal">
    ///     Determines whether the built lookup should be read only.
    /// </param>
    [Pure]
    public virtual DotMemberAttributeKeyLookup Build(bool seal = true)
    {
        var result = new DotMemberAttributeKeyLookup();

        var entityAttributePropertiesInterfaceTypes = typeof(TIEntityAttributeProperties).GetInterfaces()
            .Concat([typeof(TIEntityAttributeProperties)]);

        foreach (var interfaceType in entityAttributePropertiesInterfaceTypes)
        {
            AddPropertyAccessors(result, interfaceType);
        }

        return seal ? result.Seal() : result;
    }

    protected virtual void AddPropertyAccessors(DotMemberAttributeKeyLookup output, Type entityAttributePropertiesInterfaceType)
    {
        var interfaceMap = typeof(TEntityAttributes).GetInterfaceMap(entityAttributePropertiesInterfaceType);

        for (var index = 0; index < interfaceMap.TargetMethods.Length; index++)
        {
            var interfaceMethod = interfaceMap.InterfaceMethods[index];
            var targetMethod = interfaceMap.TargetMethods[index];

            if (interfaceMethod.ReturnType != typeof(void))
            {
                continue;
            }

            var attribute = targetMethod.GetCustomAttribute<DotAttributeKeyAttribute>()
             ?? throw new KeyNotFoundException($"No {nameof(DotAttributeKeyAttribute)} is specified for the property accessor " +
                    $"{targetMethod.Name} of {targetMethod.DeclaringType?.Name}.");

            output.SetPropertyAccessorKey(interfaceMethod, attribute.Key);
        }
    }
}