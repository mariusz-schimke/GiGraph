using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;

namespace GiGraph.Dot.Entities.Attributes.Properties.Accessors;

/// <summary>
///     Provides access to attributes through property expressions.
/// </summary>
public class DotEntityAttributesAccessor<TIEntityAttributeProperties, TEntityAttributeProperties> : DotEntityAttributesAccessor
    where TEntityAttributeProperties : DotEntityAttributes, TIEntityAttributeProperties
{
    protected static readonly Type InterfaceType = typeof(TIEntityAttributeProperties);

    static DotEntityAttributesAccessor()
    {
        if (!InterfaceType.IsInterface)
        {
            throw new ArgumentException($"The type {InterfaceType.Name} specified as the type parameter is not an interface.", nameof(TIEntityAttributeProperties));
        }
    }

    public DotEntityAttributesAccessor(TEntityAttributeProperties attributes)
        : base(attributes)
    {
    }

    internal TEntityAttributeProperties Implementation => (TEntityAttributeProperties) _attributes;

    protected override Type GetInterfaceType() => InterfaceType;

    /// <summary>
    ///     Gets the specified attribute from the collection. If it is not defined, returns null.
    /// </summary>
    /// <param name="property">
    ///     The property to get an attribute for.
    /// </param>
    /// <typeparam name="TProperty">
    ///     The type returned by the property.
    /// </typeparam>
    public virtual DotAttribute? Get<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
    {
        var key = GetKey(property);
        return _attributes.Collection.GetValueOrDefault(key);
    }

    /// <summary>
    ///     Gets the value of the specified attribute from the collection. If it is not defined, returns null.
    /// </summary>
    /// <param name="property">
    ///     The property to get an attribute for.
    /// </param>
    /// <typeparam name="TProperty">
    ///     The type returned by the property.
    /// </typeparam>
    public virtual TProperty? GetValue<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
    {
        var propertyInfo = GetProperty(property);
        return (TProperty?) propertyInfo.GetValue(_attributes);
    }

    /// <summary>
    ///     Assigns a value to the specified property and returns the actual attribute added to the collection.
    /// </summary>
    /// <param name="property">
    ///     The property whose value to set.
    /// </param>
    /// <param name="value">
    ///     The value to assign to the property.
    /// </param>
    /// <typeparam name="TProperty">
    ///     The type returned by the property.
    /// </typeparam>
    [return: NotNullIfNotNull(nameof(value))]
    public virtual DotAttribute? SetValue<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property, TProperty value)
    {
        var propertyInfo = GetProperty(property);
        propertyInfo.SetValue(_attributes, value);

        var key = _attributes.GetKey(propertyInfo);
        return _attributes.Collection.Get(key);
    }

    /// <summary>
    ///     Assigns a raw value to the specified property and returns the actual attribute added to the collection. The value is rendered
    ///     AS IS in the output DOT script, so it has to escaped appropriately when necessary (see
    ///     <see href="https://www.graphviz.org/doc/info/lang.html">
    ///         documentation
    ///     </see>
    ///     ).
    /// </summary>
    /// <param name="property">
    ///     The property whose value to set.
    /// </param>
    /// <param name="value">
    ///     The value to assign to the property.
    /// </param>
    /// <typeparam name="TProperty">
    ///     The type returned by the property.
    /// </typeparam>
    public virtual DotRawAttribute SetRawValue<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property, string value)
    {
        var key = GetKey(property);
        return _attributes.Collection.SetRaw(key, value);
    }

    /// <summary>
    ///     Removes the specified attribute from the collection.
    /// </summary>
    /// <param name="property">
    ///     The property by which to remove an associated attribute from the collection.
    /// </param>
    /// <typeparam name="TProperty">
    ///     The type returned by the property.
    /// </typeparam>
    public virtual bool Remove<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
    {
        var key = GetKey(property);
        return _attributes.Collection.Remove(key);
    }

    /// <summary>
    ///     Determines whether the collection contains the specified attribute.
    /// </summary>
    /// <param name="property">
    ///     The property to check.
    /// </param>
    /// <typeparam name="TProperty">
    ///     The type returned by the property.
    /// </typeparam>
    public virtual bool Contains<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
    {
        var key = GetKey(property);
        return _attributes.Collection.ContainsKey(key);
    }

    /// <summary>
    ///     Determines whether the collection contains the specified attribute with a null value assigned.
    /// </summary>
    /// <param name="property">
    ///     The property to check.
    /// </param>
    /// <typeparam name="TProperty">
    ///     The type returned by the property to check.
    /// </typeparam>
    public virtual bool IsNullified<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
    {
        var key = GetKey(property);
        return _attributes.Collection.IsNullified(key);
    }

    /// <summary>
    ///     Adds an attribute with a null value to the collection.
    /// </summary>
    /// <param name="property">
    ///     The property to add a null value attribute for.
    /// </param>
    /// <typeparam name="TProperty">
    ///     The type returned by the property.
    /// </typeparam>
    public virtual DotNullAttribute Nullify<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
    {
        var key = GetKey(property);
        return _attributes.Collection.Nullify(key);
    }

    // todo: posprzątać tu, czyli usunąć mapowanie accessorów w słowniku
    
    /// <summary>
    ///     Gets the DOT key of the attribute the specified property provides access to.
    /// </summary>
    /// <param name="property">
    ///     The property to get the DOT attribute key for.
    /// </param>
    /// <typeparam name="TProperty">
    ///     The type returned by the property.
    /// </typeparam>
    public virtual string GetKey<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
    {
        var propertyInfo = GetProperty(property);
        return _attributes.GetKey(propertyInfo);
    }

    protected virtual PropertyInfo GetProperty<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
    {
        var propertyInfo = (property.Body as MemberExpression)?.Member as PropertyInfo ??
            throw new ArgumentException("Property expression expected.", nameof(property));

        // make sure the property expression refers to entity attributes instance type, to any of its base classes, or to an interface it implements
        if (propertyInfo.DeclaringType is null || !propertyInfo.DeclaringType.IsInstanceOfType(_attributes))
        {
            throw new ArgumentException($"The expression has to specify a property of the {InterfaceType.Name} interface.", nameof(property));
        }

        return propertyInfo;
    }
}