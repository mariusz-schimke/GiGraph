using GiGraph.Dot.Entities.Attributes.Enums;
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

        public virtual void Set(DotAttribute attribute)
        {
            _attributes[((IDotAttribute)attribute).Key] = attribute;
        }

        public virtual void Set(string key, string value)
        {
            _attributes[key] = new DotStringAttribute(key, value);
        }

        public virtual void SetHtml(string key, string value)
        {
            _attributes[key] = new DotHtmlAttribute(key, value);
        }

        public virtual void Set(string key, double value)
        {
            _attributes[key] = new DotDoubleAttribute(key, value);
        }

        public virtual void Set(string key, bool value)
        {
            _attributes[key] = new DotBoolAttribute(key, value);
        }

        public virtual void Set(string key, DotShape value)
        {
            _attributes[key] = new DotShapeAttribute(key, value);
        }

        public virtual void Set(string key, DotArrowType value)
        {
            _attributes[key] = new DotArrowTypeAttribute(key, value);
        }

        public virtual void Set(string key, DotArrowDirection value)
        {
            _attributes[key] = new DotArrowDirectionAttribute(key, value);
        }

        public virtual void SetCustom(string key, string value)
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

        public virtual bool Remove(DotAttribute attribute)
        {
            return Remove(((IDotAttribute)attribute).Key);
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

        public virtual T GetAs<T>(string key)
            where T : DotAttribute
        {
            if (_attributes.TryGetValue(key, out var result))
            {
                return (T)result;
            }

            return null;
        }

        public virtual bool TryGetAs<T>(string key, out T attribute)
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

        public virtual bool TryGetValueAs<T>(string key, out T value)
        {
            if (_attributes.TryGetValue(key, out var attribute) && attribute is DotAttribute<T> attributeWithValue)
            {
                value = attributeWithValue.Value;
                return true;
            }

            value = default;
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
