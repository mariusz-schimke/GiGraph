using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Gigraph.Dot.Entities.Attributes
{
    public class DotAttributeCollection : IDotEntity, IEnumerable<DotAttribute>
    {
        protected IDictionary<string, DotAttribute> _attributes { get; } = new Dictionary<string, DotAttribute>(StringComparer.InvariantCulture);

        public virtual void AddOrReplace(DotAttribute attribute)
        {
            _attributes[((IDotAttribute)attribute).Key] = attribute;
        }

        public virtual void Remove(DotAttribute attribute)
        {
            Remove(((IDotAttribute)attribute).Key);
        }

        public virtual bool Remove(string key)
        {
            return _attributes.Remove(key);
        }

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

        public virtual void Clear()
        {
            _attributes.Clear();
        }

        public virtual T TryGet<T>(string key)
            where T : DotAttribute
        {
            if (TryGet<T>(key, out var result))
            {
                return result;
            }

            return null;
        }

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
