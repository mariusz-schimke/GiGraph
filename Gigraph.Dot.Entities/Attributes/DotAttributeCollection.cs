using System;
using System.Collections;
using System.Collections.Generic;

namespace Gigraph.Dot.Entities.Attributes
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

        public T TryGet<T>(string key)
            where T : DotAttribute
        {
            if (TryGet<T>(key, out var result))
            {
                return result;
            }

            return null;
        }

        public bool TryGet<T>(string key, out T attribute)
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
