using GiGraph.Dot.Entities.Attributes.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GiGraph.Dot.Entities.Attributes.Colors;
using GiGraph.Dot.Output.TextEscaping;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public class DotCommonAttributeCollection : SortedList<string, DotCommonAttribute>, IDotAttributeCollection
    {
        public virtual T Set<T>(T attribute)
            where T : DotCommonAttribute
        {
            this[attribute.Key] = attribute;
            return attribute;
        }

        public virtual void SetRange(IEnumerable<DotCommonAttribute> attributes)
        {
            foreach (var attribute in attributes)
            {
                Set(attribute);
            }
        }

        public virtual DotStringAttribute Set(string key, string value)
        {
            return Set(new DotStringAttribute(key, value));
        }

        public virtual DotHtmlAttribute SetHtml(string key, string value)
        {
            return Set(new DotHtmlAttribute(key, value));
        }

        public virtual DotIntAttribute Set(string key, int value)
        {
            return Set(new DotIntAttribute(key, value));
        }

        public virtual DotDoubleAttribute Set(string key, double value)
        {
            return Set(new DotDoubleAttribute(key, value));
        }

        public virtual DotBoolAttribute Set(string key, bool value)
        {
            return Set(new DotBoolAttribute(key, value));
        }

        public virtual DotColorAttribute Set(string key, Color value)
        {
            return Set(new DotColorAttribute(key, value));
        }

        public virtual DotShapeAttribute Set(string key, DotShape value)
        {
            return Set(new DotShapeAttribute(key, value));
        }

        public virtual DotStyleAttribute Set(string key, DotStyle value)
        {
            return Set(new DotStyleAttribute(key, value));
        }

        public virtual DotArrowTypeAttribute Set(string key, DotArrowType value)
        {
            return Set(new DotArrowTypeAttribute(key, value));
        }

        public virtual DotArrowDirectionAttribute Set(string key, DotArrowDirection value)
        {
            return Set(new DotArrowDirectionAttribute(key, value));
        }

        public virtual DotRankAttribute Set(string key, DotRank value)
        {
            return Set(new DotRankAttribute(key, value));
        }

        public virtual DotRankDirectionAttribute Set(string key, DotRankDirection value)
        {
            return Set(new DotRankDirectionAttribute(key, value));
        }

        public virtual DotCustomAttribute SetCustom(string key, string value)
        {
            return Set(new DotCustomAttribute(key, value));
        }

        public virtual DotCustomAttribute SetCustom(string key, string value, IDotTextEscaper valueEscaper)
        {
            return Set(new DotCustomAttribute(key, value, valueEscaper));
        }

        public virtual T GetAs<T>(string key)
            where T : DotCommonAttribute
        {
            if (base.TryGetValue(key, out var result))
            {
                return (T) result;
            }

            return null;
        }

        public virtual bool TryGetAs<T>(string key, out T attribute)
            where T : DotCommonAttribute
        {
            if (base.TryGetValue(key, out var result))
            {
                attribute = result as T;
                return attribute is { };
            }

            attribute = null;
            return false;
        }

        public virtual bool TryGetValueAs<T>(string key, out T value)
        {
            if (base.TryGetValue(key, out var attribute) && attribute is DotCommonAttribute<T> attributeWithValue)
            {
                value = attributeWithValue.Value;
                return true;
            }

            value = default;
            return false;
        }

        public virtual int RemoveAll(Predicate<DotCommonAttribute> match)
        {
            var result = 0;
            var matches = Values.Where(a => match(a)).ToArray();

            foreach (var attribute in matches)
            {
                result += Remove(attribute.Key) ? 1 : 0;
            }

            return result;
        }

        protected virtual void AddOrRemove<T>(string key, T attribute)
            where T : DotCommonAttribute
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
            where TAttribute : DotCommonAttribute
        {
            AddOrRemove(key, value is null ? null : attribute(value));
        }

        void IDictionary<string, DotCommonAttribute>.Add(string key, DotCommonAttribute attribute)
        {
            if (key != attribute.Key)
            {
                throw new ArgumentException($"The key specified (\"{key}\") has to match attribute key (\"{attribute.Key}\").", nameof(key));
            }

            Add(key, attribute);
        }
    }
}