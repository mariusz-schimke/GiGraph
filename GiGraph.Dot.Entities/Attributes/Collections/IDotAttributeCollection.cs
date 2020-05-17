using System;
using System.Collections.Generic;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public interface IDotAttributeCollection : IDotEntity, ICollection<DotAttribute>
    {
        /// <summary>
        /// Adds or replaces the specified attribute in the collection.
        /// </summary>
        /// <param name="attribute">The attribute to include in the collection.</param>
        void Set(DotAttribute attribute);

        /// <summary>
        /// Adds or replaces the specified attribute in the collection.
        /// <para>
        ///     When necessary, the value specified will be rendered escaped in the generated graph, so it can be displayed properly when visualized.
        ///     If you want the value to be rendered as is, without any further processing, use the <see cref="SetCustom"/> method instead.
        /// </para>
        /// </summary>
        /// <param name="key">The key of the attribute to include in the collection.</param>
        /// <param name="value">The value of the attribute to include in the collection.</param>
        void Set(string key, string value);

        /// <summary>
        /// Adds or replaces the specified double value attribute in the collection.
        /// </summary>
        /// <param name="key">The key of the attribute to include in the collection.</param>
        /// <param name="value">The value of the attribute to include in the collection.</param>
        void Set(string key, double value);

        /// <summary>
        /// Adds or replaces the specified boolean value attribute in the collection.
        /// </summary>
        /// <param name="key">The key of the attribute to include in the collection.</param>
        /// <param name="value">The value of the attribute to include in the collection.</param>
        void Set(string key, bool value);

        /// <summary>
        /// Adds or replaces the specified custom attribute in the collection.
        /// <para>
        ///     The value provided will be rendered in the generated graph exactly the way it is provided here,
        ///     without any further processing (escaping). Therefore, it has to follow the DOT language syntax rules.
        /// </para>
        /// </summary>
        /// <param name="key">The key of the attribute to include in the collection.</param>
        /// <param name="value">The value of the attribute to include in the collection.</param>
        void SetCustom(string key, string value);

        /// <summary>
        /// Checks if an attribute with the specified key exists in the collection, and returns it as the specified type.
        /// If the attribute is found, but cannot be cast as the specified type, an exception is thrown.
        /// </summary>
        /// <typeparam name="T">The type to return the attribute as.</typeparam>
        /// <param name="key">The key of the attribute to get.</param>
        T GetAs<T>(string key) where T : DotAttribute;

        /// <summary>
        /// Checks if an attribute with the specified key exists in the collection, and returns it as the specified type.
        /// If the attribute is found, but cannot be cast as the specified type, returns false.
        /// </summary>
        /// <typeparam name="T">The type to return the attribute as.</typeparam>
        /// <param name="key">The key of the attribute to get.</param>
        /// <param name="value">The attribute if found and valid, or null otherwise.</param>
        bool TryGetAs<T>(string key, out T attribute) where T : DotAttribute;

        /// <summary>
        /// Checks if an attribute with the specified key exists in the collection, and returns its value as the specified type.
        /// If the attribute is found, but its value cannot be cast as the specified type, returns false.
        /// </summary>
        /// <typeparam name="T">The type to return the attribute value as.</typeparam>
        /// <param name="key">The key of the attribute to get.</param>
        /// <param name="value">The value of the attribute if found and valid, or null otherwise.</param>
        bool TryGetValueAs<T>(string key, out T value);

        /// <summary>
        /// Removes the specified attribute from the collection.
        /// </summary>
        /// <param name="key">The key of the attribute to remove.</param>
        bool Remove(string key);

        /// <summary>
        /// Removes all attributes matching the specified criteria from the collection.
        /// </summary>
        /// <param name="match">The predicate to use for matching attributes.</param>
        int RemoveAll(Predicate<DotAttribute> match);
    }
}