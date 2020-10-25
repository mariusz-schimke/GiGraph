using System;
using System.Collections.Generic;
using System.Linq;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public partial class DotAttributeCollection : SortedList<string, DotAttribute>, IDotAttributeCollection
    {
        protected internal virtual string Annotation { get; set; }

        string IDotAnnotatable.Annotation
        {
            get => Annotation;
            set => Annotation = value;
        }

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

        public virtual bool IsNullified(string key)
        {
            return TryGetValue(key, out var result) && result.GetValue() is null;
        }
    }
}