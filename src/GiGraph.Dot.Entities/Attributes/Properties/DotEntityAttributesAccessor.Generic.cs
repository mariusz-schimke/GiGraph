using System;
using System.Linq.Expressions;
using System.Reflection;

namespace GiGraph.Dot.Entities.Attributes.Properties
{
    public class DotEntityAttributesAccessor<TIEntityAttributeProperties, TEntityAttributeProperties> : DotEntityAttributesAccessor
        where TEntityAttributeProperties : DotEntityAttributes, TIEntityAttributeProperties
    {
        protected readonly TEntityAttributeProperties _implementation;

        static DotEntityAttributesAccessor()
        {
            if (!typeof(TIEntityAttributeProperties).IsInterface)
            {
                throw new ArgumentException($"The type {typeof(TIEntityAttributeProperties).Name} specified as the type parameter is not an interface.", nameof(TIEntityAttributeProperties));
            }
        }

        public DotEntityAttributesAccessor(TEntityAttributeProperties implementation)
            : base(implementation)
        {
            _implementation = implementation;
        }

        /// <summary>
        ///     Gets the underlying attribute properties implementation.
        /// </summary>
        internal TEntityAttributeProperties Implementation => _implementation;

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
        ///     Gets the value of the specified attribute from the collection. If it is not defined, returns null.
        /// </summary>
        /// <param name="property">
        ///     The property to get an attribute for.
        /// </param>
        /// <typeparam name="TProperty">
        ///     The type returned by the property.
        /// </typeparam>
        public virtual TProperty GetValue<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
        {
            var propertyInfo = GetProperty(property);
            return (TProperty) propertyInfo.GetValue(_implementation);
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
        public virtual DotAttribute SetValue<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property, TProperty value)
        {
            var propertyInfo = GetProperty(property);
            propertyInfo.SetValue(_implementation, value);

            var key = GetPropertyKey(propertyInfo);
            return _attributes.Get(key);
        }

        /// <summary>
        ///     Assigns a custom value to the specified property and returns the actual attribute added to the collection. The value is
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
            return _attributes.Get(key);
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
        public virtual bool Contains<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
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
            return _attributes.Get(key);
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
            return GetPropertyKey(propertyInfo);
        }

        protected virtual PropertyInfo GetProperty<TProperty>(Expression<Func<TIEntityAttributeProperties, TProperty>> property)
        {
            var propertyInfo = (property.Body as MemberExpression)?.Member as PropertyInfo ??
                throw new ArgumentException("Property expression expected.", nameof(property));

            // make sure the property expression refers to entity attributes instance type, to any of its base classes, or to an interface it implements
            if (propertyInfo.DeclaringType is null || !propertyInfo.DeclaringType.IsInstanceOfType(_implementation))
            {
                throw new ArgumentException($"The expression has to specify a property of the {typeof(TIEntityAttributeProperties).Name} interface.", nameof(property));
            }

            return propertyInfo;
        }
    }
}