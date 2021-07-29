using System;
using System.Linq.Expressions;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;

namespace GiGraph.Dot.Entities.Attributes.Properties
{
    public abstract class DotEntityAttributes<TIEntityAttributeProperties> : DotEntityAttributes
    {
        protected DotEntityAttributes(DotAttributeCollection attributes, DotMemberAttributeKeyLookup attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        /// <summary>
        ///     Gets the specified attribute from the collection. If it is not defined, returns null.
        /// </summary>
        /// <param name="property">
        ///     The property to get an attribute for.
        /// </param>
        /// <typeparam name="TProperty">
        ///     The type returned by the property.
        /// </typeparam>
        public virtual DotAttribute Get<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
        {
            var key = GetKey(property);
            return _attributes.TryGetValue(key, out var result) ? result : null;
        }

        /// <summary>
        ///     Assigns a value to the specified property, and returns the actual attribute added to the collection.
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
        public virtual DotAttribute Set<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property, TProperty value)
        {
            var propertyInfo = GetProperty(property);
            propertyInfo.SetValue(this, value);

            var key = GetKey(propertyInfo);
            return TryGetAttribute(key);
        }

        /// <summary>
        ///     Assigns a custom value to the specified property, and returns the actual attribute added to the collection. The value is
        ///     rendered AS IS in the output DOT script, so it has to escaped appropriately when necessary (see
        ///     <see href="https://graphviz.org/doc/info/lang.html" />).
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
        public virtual DotAttribute SetCustomValue<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property, string value)
        {
            var key = GetKey(property);
            _attributes.SetCustom(key, value);
            return TryGetAttribute(key);
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
            return _attributes.Remove(key);
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
        public virtual bool IsSet<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
        {
            var key = GetKey(property);
            return _attributes.ContainsKey(key);
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
            return _attributes.IsNullified(key);
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
        public virtual DotAttribute Nullify<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
        {
            var key = GetKey(property);
            _attributes.Nullify(key);
            return TryGetAttribute(key);
        }

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
            return GetKey(propertyInfo);
        }

        protected virtual PropertyInfo GetProperty<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
        {
            var propertyInfo = (property.Body as MemberExpression)?.Member as PropertyInfo ??
                throw new ArgumentException("Property expression expected.", nameof(property));

            // make sure the property expression refers to current instance type, to any of its base classes, or to an interface it implements
            if (propertyInfo.DeclaringType is null || !propertyInfo.DeclaringType.IsAssignableFrom(GetType()))
            {
                throw new ArgumentException("The property expression must refer to a member of the current instance.", nameof(property));
            }

            return propertyInfo;
        }

        protected virtual DotAttribute TryGetAttribute(string key)
        {
            return _attributes.TryGetValue(key, out var attribute) ? attribute : null;
        }
    }
}