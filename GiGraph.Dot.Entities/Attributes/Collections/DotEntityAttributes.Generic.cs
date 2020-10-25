using System;
using System.Linq.Expressions;
using GiGraph.Dot.Entities.Attributes.Collections.KeyLookup;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public abstract partial class DotEntityAttributes<TIEntityAttributeProperties> : DotEntityAttributes
    {
        protected DotEntityAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        /// <summary>
        ///     Gets the DOT attribute the specified property provides access to.
        /// </summary>
        /// <param name="property">
        ///     The property to get the DOT attribute key for.
        /// </param>
        /// <typeparam name="TProperty">
        ///     The type returned by the property.
        /// </typeparam>
        public virtual DotAttribute GetAttribute<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
        {
            var key = GetAttributeKey(property);
            return _attributes.TryGetValue(key, out var result) ? result : null;
        }

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
        public virtual DotAttribute SetAttribute<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property, TProperty value)
        {
            var propertyInfo = GetProperty(property);
            propertyInfo.SetValue(this, value);

            var key = GetAttributeKey(propertyInfo);
            return _attributes.TryGetValue(key, out var attribute) ? attribute : null;
        }

        /// <summary>
        ///     Removes the attribute the specified property provides access to.
        /// </summary>
        /// <param name="property">
        ///     The property to get the DOT attribute key for.
        /// </param>
        /// <typeparam name="TProperty">
        ///     The type returned by the property.
        /// </typeparam>
        public virtual bool RemoveAttribute<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
        {
            var key = GetAttributeKey(property);
            return _attributes.Remove(key);
        }

        /// <summary>
        ///     Checks whether the collection contains a DOT key of the attribute the specified property provides access to.
        /// </summary>
        /// <param name="property">
        ///     The property to check the key for.
        /// </param>
        /// <typeparam name="TProperty">
        ///     The type returned by the property.
        /// </typeparam>
        public virtual bool HasAttribute<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
        {
            var key = GetAttributeKey(property);
            return _attributes.ContainsKey(key);
        }

        /// <summary>
        ///     Determines whether the collection contains an attribute with the specified key, whose value is null.
        /// </summary>
        /// <param name="property">
        ///     The property by which to get the DOT key of the attribute whose value to check.
        /// </param>
        /// <typeparam name="TProperty">
        ///     The type returned by the property to check.
        /// </typeparam>
        public virtual bool HasNullified<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
        {
            var key = GetAttributeKey(property);
            return _attributes.IsNullified(key);
        }

        /// <summary>
        ///     Sets a null value for the specified attribute key.
        /// </summary>
        /// <param name="property">
        ///     The property by which to get the DOT attribute key to set a value for.
        /// </param>
        /// <typeparam name="TProperty">
        ///     The type returned by the property.
        /// </typeparam>
        public virtual DotNullAttribute Nullify<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
        {
            var key = GetAttributeKey(property);
            return _attributes.Nullify(key);
        }
    }
}