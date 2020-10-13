using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public interface IDotEntityAttributes<TIEntityAttributeProperties>
    {
        /// <summary>
        ///     Gets the DOT attribute the specified property provides access to.
        /// </summary>
        /// <param name="property">
        ///     The property to get the DOT attribute key for.
        /// </param>
        /// <typeparam name="TProperty">
        ///     The type returned by the property.
        /// </typeparam>
        DotAttribute GetAttribute<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property);

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
        DotAttribute SetAttribute<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property, TProperty value);

        /// <summary>
        ///     Removes the attribute the specified property provides access to.
        /// </summary>
        /// <param name="property">
        ///     The property to get the DOT attribute key for.
        /// </param>
        /// <typeparam name="TProperty">
        ///     The type returned by the property.
        /// </typeparam>
        bool RemoveAttribute<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property);

        /// <summary>
        ///     Sets a null value for the specified attribute key.
        /// </summary>
        /// <param name="property">
        ///     The property by which to get the DOT attribute key to set a value for.
        /// </param>
        /// <typeparam name="TProperty">
        ///     The type returned by the property.
        /// </typeparam>
        DotNullAttribute Nullify<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property);

        /// <summary>
        ///     Checks whether the collection contains a DOT key of the attribute the specified property provides access to.
        /// </summary>
        /// <param name="property">
        ///     The property to check the key for.
        /// </param>
        /// <typeparam name="TProperty">
        ///     The type returned by the property.
        /// </typeparam>
        bool HasAttribute<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property);

        /// <summary>
        ///     Determines whether the collection contains an attribute with the specified key, whose value is null.
        /// </summary>
        /// <param name="property">
        ///     The property by which to get the DOT key of the attribute whose value to check.
        /// </param>
        /// <typeparam name="TProperty">
        ///     The type returned by the property to check.
        /// </typeparam>
        bool HasNullified<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property);

        /// <summary>
        ///     Gets the DOT key of the attribute the specified property provides access to.
        /// </summary>
        /// <param name="property">
        ///     The property to get the DOT attribute key for.
        /// </param>
        /// <typeparam name="TProperty">
        ///     The type returned by the property.
        /// </typeparam>
        string GetAttributeKey<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property);

        /// <summary>
        ///     Gets a dictionary where the key is a DOT attribute, and the value is a path to a property that exposes it.
        /// </summary>
        Dictionary<string, string> GetAttributeKeyMapping();
    }
}