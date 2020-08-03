using System;
using System.Drawing;
using System.Linq;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Points;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections
{
    public partial class DotAttributeCollection
    {
        public virtual T GetAs<T>(string key)
            where T : DotAttribute
        {
            if (!TryGetValue(key, out var attribute) || attribute is null)
            {
                return null;
            }

            return attribute is T output
                ? output
                : throw new InvalidCastException($"The '{key}' attribute of type {attribute.GetType().FullName} cannot be accessed as {typeof(T).FullName}.");
        }

        public virtual bool TryGetAs<T>(string key, out T attribute)
            where T : DotAttribute
        {
            if (TryGetValue(key, out var output))
            {
                attribute = output as T;
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
            if (!TryGetValue(key, out var attribute) || !(attribute.GetValue() is {} attributeValue))
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
                   .Select(convert => convert(attributeValue))
                   .FirstOrDefault(result => result.IsValid);

                if (converted.IsValid)
                {
                    value = converted.Result;
                    return true;
                }
            }

            throw new InvalidCastException($"The '{key}' attribute value of type {attributeValue.GetType().FullName} cannot be accessed as {typeof(T).FullName}.");
        }

        protected virtual double? GetValueAsDouble(string key)
        {
            return GetValueAs
            (
                key,
                out var value,
                v => v is int i ? (true, i) : (false, default)
            )
                ? value
                : (double?) null;
        }

        protected virtual DotPoint GetValueAsPoint(string key)
        {
            return GetValueAs<DotPoint>(key, out var result) ? result : null;
        }

        protected virtual DotColorDefinition GetValueAsColorDefinition(string key)
        {
            return GetValueAs<DotColorDefinition>
            (
                key,
                out var value,
                v => v is Color c ? (true, new DotColor(c)) : (false, null)
            )
                ? value
                : null;
        }

        protected virtual DotEscapeString GetValueAsEscapeString(string key)
        {
            return GetValueAs<DotEscapeString>
            (
                key,
                out var value,
                v => v is string s ? (true, (DotEscapedString) s) : (false, null)
            )
                ? value
                : null;
        }

        protected virtual DotLabel GetValueAsLabel(string key)
        {
            return GetValueAs<DotLabel>
            (
                key,
                out var value,
                v => v is DotEscapeString s ? (true, s) : (false, null),
                v => v is string s ? (true, (DotEscapedString) s) : (false, null)
            )
                ? value
                : null;
        }
    }
}