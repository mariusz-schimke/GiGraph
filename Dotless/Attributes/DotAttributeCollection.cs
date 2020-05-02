using Dotless.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Dotless.Core
{
    public abstract class DotAttributeCollection : IDotEntity, IEnumerable<IDotAttribute>
    {
        protected IDictionary<string, IDotAttribute> _attributes { get; } = new Dictionary<string, IDotAttribute>(StringComparer.OrdinalIgnoreCase);

        public void Clear()
        {
            _attributes.Clear();
        }

        public void Include(IDotAttribute attribute)
        {
            _attributes[attribute.Key] = attribute;
        }

        public bool Remove(string key)
        {
            return _attributes.Remove(key);
        }

        public IDotAttribute? TryGet<T>(string key)
            where T : IDotAttribute
        {
            if (_attributes.TryGetValue(key, out var result))
            {
                return (T)result;
            }

            return null;
        }

        public IEnumerator<IDotAttribute> GetEnumerator()
        {
            return _attributes.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
