using System;
using System.Linq.Expressions;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public interface IDotEntityAttributes<TExposedEntityAttributes> : IDotAttributeCollection
        where TExposedEntityAttributes : IDotEntityAttributes<TExposedEntityAttributes>
    {
        /// <summary>
        ///     Gets the DOT key of the attribute the specified property provides access to.
        /// </summary>
        /// <param name="property">
        ///     The property to get the DOT attribute key for.
        /// </param>
        /// <typeparam name="T">
        ///     The type that provides access to the property.
        /// </typeparam>
        string GetAttributeKey<T>(Expression<Func<TExposedEntityAttributes, T>> property);

        /// <summary>
        ///     Checks whether the collection contains a DOT key of the attribute the specified property provides access to.
        /// </summary>
        /// <param name="property">
        ///     The property to check the key for.
        /// </param>
        /// <typeparam name="T">
        ///     The type that provides access to the property.
        /// </typeparam>
        bool ContainsKey<T>(Expression<Func<TExposedEntityAttributes, T>> property);

        /// <summary>
        ///     Removes the attribute the specified property provides access to.
        /// </summary>
        /// <param name="property">
        ///     The property to get the DOT attribute key for.
        /// </param>
        /// <typeparam name="T">
        ///     The type that provides access to the property.
        /// </typeparam>
        bool Remove<T>(Expression<Func<TExposedEntityAttributes, T>> property);
    }
}