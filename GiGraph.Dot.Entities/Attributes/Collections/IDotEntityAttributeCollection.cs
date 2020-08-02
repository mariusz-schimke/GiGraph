using System;
using System.Linq.Expressions;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public interface IDotEntityAttributeCollection<TExposedEntityAttributes>
    {
        /// <summary>
        ///     Gets the DOT key of the attribute the specified property provides access to.
        /// </summary>
        /// <param name="property">
        ///     The property to get the DOT attribute key for.
        /// </param>
        /// <typeparam name="TProperty">
        ///     The type that provides access to the property.
        /// </typeparam>
        string GetAttributeKey<TProperty>(Expression<Func<TExposedEntityAttributes, TProperty>> property);

        /// <summary>
        ///     Checks whether the collection contains a DOT key of the attribute the specified property provides access to.
        /// </summary>
        /// <param name="property">
        ///     The property to check the key for.
        /// </param>
        /// <typeparam name="TProperty">
        ///     The type that provides access to the property.
        /// </typeparam>
        bool Contains<TProperty>(Expression<Func<TExposedEntityAttributes, TProperty>> property);

        /// <summary>
        ///     Removes the attribute the specified property provides access to.
        /// </summary>
        /// <param name="property">
        ///     The property to get the DOT attribute key for.
        /// </param>
        /// <typeparam name="TProperty">
        ///     The type that provides access to the property.
        /// </typeparam>
        bool Remove<TProperty>(Expression<Func<TExposedEntityAttributes, TProperty>> property);
    }
}