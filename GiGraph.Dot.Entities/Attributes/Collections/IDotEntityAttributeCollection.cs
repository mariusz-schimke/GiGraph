using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public interface IDotEntityAttributeCollection<TExposedEntityAttributes>
    {
        /// <summary>
        ///     Sets a null value for the specified attribute key.
        /// </summary>
        /// <param name="property">
        ///     The property by which to get the DOT attribute key to set a value for.
        /// </param>
        /// <typeparam name="TProperty">
        ///     The type returned by the property.
        /// </typeparam>
        DotNullAttribute SetNull<TProperty>(Expression<Func<TExposedEntityAttributes, TProperty>> property);

        /// <summary>
        ///     Assigns a value to the specified property, and returns the actual attribute added to the collection.
        /// </summary>
        /// <param name="property">
        ///     The property by which to get the DOT attribute key to set a value for.
        /// </param>
        /// <param name="value">
        ///     The value to assign to the property.
        /// </param>
        /// <typeparam name="TProperty">
        ///     The type returned by the property.
        /// </typeparam>
        DotAttribute Set<TProperty>(Expression<Func<TExposedEntityAttributes, TProperty>> property, TProperty value);

        /// <summary>
        ///     Determines whether the collection contains an attribute with the specified key, whose value is null.
        /// </summary>
        /// <param name="property">
        ///     The property by which to get the DOT key of the attribute whose value to check.
        /// </param>
        /// <typeparam name="TProperty">
        ///     The type returned by the property to check.
        /// </typeparam>
        bool IsNullified<TProperty>(Expression<Func<TExposedEntityAttributes, TProperty>> property);

        /// <summary>
        ///     Gets the DOT attribute the specified property provides access to.
        /// </summary>
        /// <param name="property">
        ///     The property to get the DOT attribute key for.
        /// </param>
        /// <typeparam name="TProperty">
        ///     The type returned by the property.
        /// </typeparam>
        DotAttribute Get<TProperty>(Expression<Func<TExposedEntityAttributes, TProperty>> property);

        /// <summary>
        ///     Gets the DOT key of the attribute the specified property provides access to.
        /// </summary>
        /// <param name="property">
        ///     The property to get the DOT attribute key for.
        /// </param>
        /// <typeparam name="TProperty">
        ///     The type returned by the property.
        /// </typeparam>
        string GetKey<TProperty>(Expression<Func<TExposedEntityAttributes, TProperty>> property);

        /// <summary>
        ///     Checks whether the collection contains a DOT key of the attribute the specified property provides access to.
        /// </summary>
        /// <param name="property">
        ///     The property to check the key for.
        /// </param>
        /// <typeparam name="TProperty">
        ///     The type returned by the property.
        /// </typeparam>
        bool Contains<TProperty>(Expression<Func<TExposedEntityAttributes, TProperty>> property);

        /// <summary>
        ///     Removes the attribute the specified property provides access to.
        /// </summary>
        /// <param name="property">
        ///     The property to get the DOT attribute key for.
        /// </param>
        /// <typeparam name="TProperty">
        ///     The type returned by the property.
        /// </typeparam>
        bool Remove<TProperty>(Expression<Func<TExposedEntityAttributes, TProperty>> property);

        /// <summary>
        ///     Gets property by attribute key. Useful when you are looking for a property that exposes a specific DOT attribute, or want to
        ///     check if a DOT attribute is exposed as a property.
        /// </summary>
        /// <param name="key">
        ///     The DOT attribute key to search.
        /// </param>
        PropertyInfo GetPropertyByKey(string key);

        /// <summary>
        ///     Gets a dictionary where the key is a DOT attribute, and the value is a property that exposes it.
        /// </summary>
        Dictionary<string, PropertyInfo> GetPropertyKeyMapping();
    }
}