using Dotless.Core;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Dotless.Attributes
{
    public class DotAttributeCollection : IDotEntity, IEnumerable<DotAttribute>
    {
        protected IDictionary<string, DotAttribute> _attributes { get; } = new Dictionary<string, DotAttribute>(StringComparer.OrdinalIgnoreCase);

        public void Clear()
        {
            _attributes.Clear();
        }

        public void SetAttribute(DotAttribute attribute)
        {
            _attributes[((IDotAttribute)attribute).Key] = attribute;
        }

        public bool Remove(string key)
        {
            return _attributes.Remove(key);
        }

        public DotAttribute? TryGet<T>(string key)
            where T : DotAttribute
        {
            if (_attributes.TryGetValue(key, out var result))
            {
                return (T)result;
            }

            return null;
        }

        public IEnumerator<DotAttribute> GetEnumerator()
        {
            return _attributes.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
