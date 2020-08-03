using System;
using System.Linq.Expressions;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public interface IDotEntityAttributeCollection<TExposedEntityAttributes>
    {
        /// <summary>
        ///     Sets an empty value for the specified attribute key.
        /// </summary>
        /// <param name="property">
        ///     The property by which to get the DOT attribute key to set a value for.
        /// </param>
        /// <typeparam name="TProperty">
        ///     The type returned by the property.
        /// </typeparam>
        DotNullAttribute SetNull<TProperty>(Expression<Func<TExposedEntityAttributes, TProperty>> property);

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
    }
}