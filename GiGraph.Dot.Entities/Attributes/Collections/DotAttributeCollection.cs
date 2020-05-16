using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public class DotAttributeCollection : IDotEntity, IDotAttributeCollection
    {
        protected readonly IDictionary<string, DotAttribute> _attributes = new Dictionary<string, DotAttribute>(StringComparer.InvariantCulture);

        public virtual int Count => _attributes.Count;
        bool ICollection<DotAttribute>.IsReadOnly => false;

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

        public virtual bool Contains(DotAttribute attribute)
        {
            return _attributes.Values.Contains(attribute);
        }

        public virtual bool Contains(string key)
        {
            return _attributes.ContainsKey(key);
        }

        /// <summary>
        /// Removes the specified attribute from the collection.
        /// </summary>
        /// <param name="attribute">The attribute to remove.</param>
        public virtual bool Remove(DotAttribute attribute)
        {
            return Remove(((IDotAttribute)attribute).Key);
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
        public virtual T Get<T>(string key)
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
                attribute = result as T;
                return attribute is { };
            }

            attribute = null;
            return false;
        }

        protected virtual void AddOrRemove<T>(string key, T attribute)
            where T : DotAttribute
        {
            if (attribute is null)
            {
                Remove(key);
            }
            else
            {
                Set(attribute);
            }
        }

        protected virtual void AddOrRemove<TAttribute, TValue>(string key, TValue value, Func<TValue, TAttribute> attribute)
            where TAttribute : DotAttribute
        {
            AddOrRemove(key, value is null ? null : attribute(value));
        }

        public virtual IEnumerator<DotAttribute> GetEnumerator()
        {
            return _attributes.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        void ICollection<DotAttribute>.Add(DotAttribute attribute)
        {
            Set(attribute);
        }

        void ICollection<DotAttribute>.CopyTo(DotAttribute[] array, int arrayIndex)
        {
            _attributes.Values.CopyTo(array, arrayIndex);
        }
    }
}
