using System;
using System.Drawing;
using System.Linq;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Edges.Enums;
using GiGraph.Dot.Entities.Types.Arrows;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Edges;
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

        public virtual bool GetValueAs<T>(string key, out T value, params Func<object, (bool IsValid, T Result)>[] converters)
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

        public virtual int? GetValueAsInt(string key)
        {
            return GetValueAs<int>(key, out var value) ? value : (int?) null;
        }

        public virtual double? GetValueAsDouble(string key)
        {
            return GetValueAs<double>
            (
                key,
                out var value,
                v => v is int i ? (true, i) : (false, default)
            )
                ? value
                : (double?) null;
        }

        public virtual bool? GetValueAsBool(string key)
        {
            return GetValueAs<bool>(key, out var result) ? result : (bool?) null;
        }

        public virtual DotPoint GetValueAsPoint(string key)
        {
            return GetValueAs<DotPoint>(key, out var result) ? result : null;
        }

        public virtual DotColor GetValueAsColor(string key)
        {
            return GetValueAs
            (
                key,
                out var value,
                v => v is Color c ? (true, new DotColor(c)) : (false, default)
            )
                ? value
                : null;
        }

        public virtual DotColorDefinition GetValueAsColorDefinition(string key)
        {
            return GetValueAs<DotColorDefinition>
            (
                key,
                out var value,
                v => v is Color c ? (true, new DotColor(c)) : (false, default)
            )
                ? value
                : null;
        }

        public virtual string GetValueAsString(string key)
        {
            return GetValueAs<string>(key, out var result) ? result : null;
        }

        public virtual DotEscapeString GetValueAsEscapeString(string key)
        {
            return GetValueAs<DotEscapeString>
            (
                key,
                out var value,
                v => v is string s ? (true, (DotEscapedString) s) : (false, default)
            )
                ? value
                : null;
        }

        public virtual DotLabel GetValueAsLabel(string key)
        {
            return GetValueAs<DotLabel>
            (
                key,
                out var value,
                v => v is DotEscapeString s ? (true, s) : (false, default),
                v => v is string s ? (true, (DotEscapedString) s) : (false, default)
            )
                ? value
                : null;
        }

        public virtual DotArrowheadDefinition GetValueAsArrowheadDefinition(string key)
        {
            return GetValueAs<DotArrowheadDefinition>
            (
                key,
                out var value,
                v => v is DotArrowheadShape s ? (true, new DotArrowhead(s)) : (false, default)
            )
                ? value
                : null;
        }

        public virtual DotEndpointPort GetValueAsEndpointPort(string key)
        {
            return GetValueAs
            (
                key,
                out var value,
                v => v is DotCompassPoint cp ? (true, new DotEndpointPort(cp)) : (false, default),
                v => v is string s ? (true, new DotEndpointPort(s)) : (false, default)
            )
                ? value
                : null;
        }
    }
}