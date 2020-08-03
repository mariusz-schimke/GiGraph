using System;
using System.Linq;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public partial class DotAttributeCollection
    {
        public virtual T GetAs<T>(string key)
            where T : DotAttribute
        {
            if (TryGetValue(key, out var result))
            {
                return (T) result;
            }

            return null;
        }

        public virtual bool TryGetAs<T>(string key, out T attribute)
            where T : DotAttribute
        {
            if (TryGetValue(key, out var result))
            {
                attribute = result as T;
                return attribute is { };
            }

            attribute = null;
            return false;
        }

        public virtual bool GetValueAs<T>(string key, out T value)
        {
            return GetValueAs(key, out value, converters: null);
        }

        public virtual bool TryGetValueAs<T>(string key, out T value)
        {
            if (TryGetValue(key, out var attribute) && attribute.GetValue() is T output)
            {
                value = output;
                return true;
            }

            value = default;
            return false;
        }

        protected virtual bool GetValueAs<T>(string key, out T value, params Func<object, (bool IsValid, T Result)>[] converters)
        {
            if (!TryGetValue(key, out var attribute) ||
                !(attribute.GetValue() is {} attributeValue))
            {
                value = default;
                return false;
            }

            // if not null and of a matching type, return it
            if (attributeValue is T output)
            {
                value = output;
                return true;
            }

            // otherwise try to convert it
            if (true == converters?.Any())
            {
                var converted = converters
                   .Select(c => c(attributeValue))
                   .FirstOrDefault(c => c.IsValid);

                if (converted.IsValid)
                {
                    value = converted.Result;
                    return true;
                }
            }

            throw new InvalidCastException($"The '{key}' attribute of type {attributeValue.GetType().FullName} cannot be accessed as {typeof(T).FullName}.");
        }
    }
}