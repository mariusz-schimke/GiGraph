using Dotless.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Dotless.Core
{
    public class AttributeCollection : IEntity, IEnumerable<IAttribute>
    {
        protected IDictionary<string, IAttribute> _attributes { get; } = new Dictionary<string, IAttribute>(StringComparer.OrdinalIgnoreCase);

        public void Clear()
        {
            _attributes.Clear();
        }

        public void Include<T>(IAttribute<T> attribute)
        {
            _attributes[attribute.Key] = attribute;
        }

        public bool Remove(string key)
        {
            return _attributes.Remove(key);
        }

        public IAttribute? TryGet<T>(string key)
            where T : IAttribute
        {
            if (_attributes.TryGetValue(key, out var result))
            {
                return (T)result;
            }

            return null;
        }

        public ICollection<IAttribute> ToList()
        {
            return _attributes.Values;
        }

        public IEnumerator<IAttribute> GetEnumerator()
        {
            return _attributes.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
