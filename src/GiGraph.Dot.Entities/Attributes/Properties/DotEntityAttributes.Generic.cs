using System;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.Accessors;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;

namespace GiGraph.Dot.Entities.Attributes.Properties;

public abstract class DotEntityAttributes<TIEntityAttributeProperties, TEntityAttributeProperties> : DotEntityAttributes
    where TEntityAttributeProperties : DotEntityAttributes<TIEntityAttributeProperties, TEntityAttributeProperties>, TIEntityAttributeProperties
{
    static DotEntityAttributes()
    {
        if (!typeof(TIEntityAttributeProperties).IsInterface)
        {
            throw new ArgumentException($"The type {typeof(TIEntityAttributeProperties).Name} specified as the type parameter is not an interface.", nameof(TIEntityAttributeProperties));
        }
    }

    protected DotEntityAttributes(DotAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
        : base(attributes, attributeKeyLookup)
    {
        if (this is not TEntityAttributeProperties implementation)
        {
            throw new ArgumentException($"The type {GetType().Name} is not assignable to the {typeof(TEntityAttributeProperties).Name} type specified as the type parameter.", nameof(TEntityAttributeProperties));
        }

        Attributes = new DotEntityAttributesAccessor<TIEntityAttributeProperties, TEntityAttributeProperties>(implementation);
    }

    /// <summary>
    ///     Provides access to individual attributes in the current context.
    /// </summary>
    public DotEntityAttributesAccessor<TIEntityAttributeProperties, TEntityAttributeProperties> Attributes { get; }

    protected override DotEntityAttributesAccessor GetAccessor() => Attributes;
}