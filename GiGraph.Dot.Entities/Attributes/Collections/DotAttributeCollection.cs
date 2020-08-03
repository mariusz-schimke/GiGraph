using System;
using System.Collections.Generic;
using System.Linq;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public partial class DotAttributeCollection : SortedList<string, DotAttribute>, IDotAttributeCollection
    {
        public virtual string Annotation { get; set; }

        public virtual int RemoveAll(Predicate<DotAttribute> match)
        {
            var result = 0;
            var matches = Values.Where(a => match(a)).ToArray();

            foreach (var attribute in matches)
            {
                result += Remove(attribute.Key) ? 1 : 0;
            }

            return result;
        }

        void IDictionary<string, DotAttribute>.Add(string key, DotAttribute attribute)
        {
            if (key != attribute.Key)
            {
                throw new ArgumentException($"The key specified (\"{key}\") has to match the attribute key (\"{attribute.Key}\").", nameof(key));
            }

            Add(key, attribute);
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

        protected virtual void AddOrRemove<TAttribute, TValue>(string key, TValue value, Func<string, TValue, TAttribute> newAttribute)
            where TAttribute : DotAttribute
        {
            AddOrRemove(key, value is null ? null : newAttribute(key, value));
        }
    }
}