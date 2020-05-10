using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Gigraph.Dot.Entities.Attributes
{
    public class DotAttributeCollection : IDotEntity, IEnumerable<DotAttribute>
    {
        protected IDictionary<string, DotAttribute> _attributes { get; } = new Dictionary<string, DotAttribute>(StringComparer.InvariantCulture);

        /// <summary>
        /// Adds or replaces the specified attribute in the collection.
        /// </summary>
        /// <param name="attribute">The attribute to include in the collection.</param>
        public virtual void Set(DotAttribute attribute)
        {
            _attributes[((IDotAttribute)attribute).Key] = attribute;
        }

        /// <summary>
        /// Adds or replaces the specified custom attribute in the collection.
        /// </summary>
        /// <param name="key">The key of the attribute to include in the collection.</param>
        /// <param name="value">The value of the attribute to include in the collection.</param>
        public virtual void Set(string key, string value)
        {
            _attributes[key] = new DotCustomAttribute(key, value);
        }

        /// <summary>
        /// Removes the specified attribute from the collection.
        /// </summary>
        /// <param name="attribute">The attribute to remove.</param>
        public virtual void Remove(DotAttribute attribute)
        {
            Remove(((IDotAttribute)attribute).Key);
        }

        /// <summary>
        /// Removes the specified attribute from the collection.
        /// </summary>
        /// <param name="key">The key of the attribute to remove.</param>
        public virtual bool Remove(string key)
        {
            return _attributes.Remove(key);
        }

        /// <summary>
        /// Removes all attributes matching the specified criteria from the collection.
        /// </summary>
        /// <param name="match">The predicate to use for matching attributes.</param>
        public virtual int RemoveAll(Predicate<DotAttribute> match)
        {
            var result = 0;
            var matches = _attributes.Values.Where(a => match(a)).ToList();

            foreach (IDotAttribute attribute in matches)
            {
                result += _attributes.Remove(attribute.Key) ? 1 : 0;
            }

            return result;
        }

        /// <summary>
        /// Clears the collection.
        /// </summary>
        public virtual void Clear()
        {
            _attributes.Clear();
        }

        /// <summary>
        /// Checks if an attribute with the specified key exists in the collection, and returns it.
        /// </summary>
        /// <typeparam name="T">The type to return the attribute as.</typeparam>
        /// <param name="key">The key of the attribute to get.</param>
        public virtual T TryGet<T>(string key)
            where T : DotAttribute
        {
            if (TryGet<T>(key, out var result))
            {
                return result;
            }

            return null;
        }

        /// <summary>
        /// Checks if an attribute with the specified key exists in the collection, and returns it.
        /// </summary>
        /// <typeparam name="T">The type to return the attribute as.</typeparam>
        /// <param name="key">The key of the attribute to get.</param>
        /// <param name="attribute">The attribute if found or null otherwise.</param>
        public virtual bool TryGet<T>(string key, out T attribute)
            where T : DotAttribute
        {
            if (_attributes.TryGetValue(key, out var result))
            {
                attribute = (T)result;
                return true;
            }

            attribute = null;
            return false;
        }

        public virtual IEnumerator<DotAttribute> GetEnumerator()
        {
            return _attributes.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
