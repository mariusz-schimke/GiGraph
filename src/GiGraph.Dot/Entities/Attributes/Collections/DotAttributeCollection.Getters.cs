using System;
using System.Drawing;
using System.Linq;
using GiGraph.Dot.Entities.Labels;
using GiGraph.Dot.Types.Arrowheads;
using GiGraph.Dot.Types.Clusters;
using GiGraph.Dot.Types.Colors;
using GiGraph.Dot.Types.Edges;
using GiGraph.Dot.Types.EscapeString;
using GiGraph.Dot.Types.Geometry;
using GiGraph.Dot.Types.Graphs;
using GiGraph.Dot.Types.Identifiers;
using GiGraph.Dot.Types.Packing;
using GiGraph.Dot.Types.Ranks;

namespace GiGraph.Dot.Entities.Attributes.Collections;

public partial class DotAttributeCollection
{
    /// <summary>
    ///     Gets an attribute with the specified key or null if it does not exist in the collection.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute to get.
    /// </param>
    public virtual DotAttribute Get(string key) => TryGetValue(key, out var attribute) ? attribute : null;

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns it as the specified type. If the
    ///     attribute is found, but cannot be cast as the specified type, an exception is thrown.
    /// </summary>
    /// <typeparam name="T">
    ///     The type to return the attribute as.
    /// </typeparam>
    /// <param name="key">
    ///     The key of the attribute to get.
    /// </param>
    public virtual T GetAs<T>(string key)
        where T : DotAttribute
    {
        if (!TryGetValue(key, out var attribute) || attribute is null)
        {
            return null;
        }

        return attribute is T output
            ? output
            : throw new InvalidCastException($"The '{key}' attribute of type {attribute.GetType().Name} cannot be accessed as {typeof(T).Name}.");
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns it as the specified type. If the
    ///     attribute is found, but cannot be cast as the specified type, returns false.
    /// </summary>
    /// <typeparam name="T">
    ///     The type to return the attribute as.
    /// </typeparam>
    /// <param name="key">
    ///     The key of the attribute to get.
    /// </param>
    /// <param name="attribute">
    ///     The attribute if found and valid, or null otherwise.
    /// </param>
    public virtual bool TryGetAs<T>(string key, out T attribute)
        where T : DotAttribute
    {
        if (TryGetValue(key, out var output))
        {
            attribute = output as T;
            return attribute is not null;
        }

        attribute = null;
        return false;
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as the specified type. If the
    ///     attribute is found, but its value cannot be cast as the specified type, an exception is thrown.
    /// </summary>
    /// <typeparam name="T">
    ///     The type to return the attribute value as.
    /// </typeparam>
    /// <param name="key">
    ///     The key of the attribute to get.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute if found and valid, or null if not found.
    /// </param>
    public virtual bool GetValueAs<T>(string key, out T value) => GetValueAs(key, out value, converters: null);

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as the specified type. If the
    ///     attribute is found, but its value cannot be cast as the specified type, returns false.
    /// </summary>
    /// <typeparam name="T">
    ///     The type to return the attribute value as.
    /// </typeparam>
    /// <param name="key">
    ///     The key of the attribute to get.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute if found and valid, or null otherwise.
    /// </param>
    public virtual bool TryGetValueAs<T>(string key, out T value)
    {
        if (TryGetValue(key, out var attribute) && attribute.GetValue() is T output)
        {
            value = output;
            return true;
        }

        value = default(T);
        return false;
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as the specified type. If the
    ///     attribute is found, but its value cannot be cast as the specified type, and converted using any of the specified converters,
    ///     an exception is thrown.
    /// </summary>
    /// <typeparam name="T">
    ///     The type to return the attribute value as.
    /// </typeparam>
    /// <param name="key">
    ///     The key of the attribute to get.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute if found and valid, or null if not found.
    /// </param>
    /// <param name="converters">
    ///     The converters to try to use when the value of the attribute is of a different type than specified by the
    ///     <typeparamref name="T" /> parameter.
    /// </param>
    public virtual bool GetValueAs<T>(string key, out T value, params Func<object, (bool IsValid, T Result)>[] converters)
    {
        if (!TryGetValue(key, out var attribute) || attribute.GetValue() is not { } attributeValue)
        {
            value = default(T);
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

        throw new InvalidCastException($"The '{key}' attribute value '{attributeValue}' of type {attributeValue.GetType().Name} cannot be accessed as {typeof(T).Name}.");
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as <see cref="int" />. If the
    ///     attribute is found, but its value cannot be cast nor converted to the specified type, an exception is thrown.
    /// </summary>
    public virtual int? GetValueAsInt(string key) => GetValueAs<int>(key, out var value) ? value : null;

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as <see cref="double" />. If
    ///     the attribute is found, but its value cannot be cast nor converted to the returned type, an exception is thrown.
    /// </summary>
    public virtual double? GetValueAsDouble(string key)
    {
        return GetValueAs<double>
        (
            key,
            out var value,
            v => v is int i ? (true, i) : (false, default(int))
        )
            ? value
            : null;
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as <see cref="bool" />. If the
    ///     attribute is found, but its value cannot be cast nor converted to the returned type, an exception is thrown.
    /// </summary>
    public virtual bool? GetValueAsBool(string key) => GetValueAs<bool>(key, out var result) ? result : null;

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as <see cref="DotPoint" />. If
    ///     the attribute is found, but its value cannot be cast nor converted to the returned type, an exception is thrown.
    /// </summary>
    public virtual DotPoint GetValueAsPoint(string key) => GetValueAs<DotPoint>(key, out var result) ? result : null;

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as <see cref="DotColor" />. If
    ///     the attribute is found, but its value cannot be cast nor converted to the returned type, an exception is thrown.
    /// </summary>
    public virtual DotColor GetValueAsColor(string key)
    {
        return GetValueAs
        (
            key,
            out var value,
            v => v is Color c ? (true, new DotColor(c)) : (false, null)
        )
            ? value
            : null;
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as
    ///     <see cref="DotColorDefinition" />. If the attribute is found, but its value cannot be cast nor converted to the returned
    ///     type, an exception is thrown.
    /// </summary>
    public virtual DotColorDefinition GetValueAsColorDefinition(string key)
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

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as <see cref="string" />. If
    ///     the attribute is found, but its value cannot be cast nor converted to the returned type, an exception is thrown.
    /// </summary>
    public virtual string GetValueAsString(string key) => GetValueAs<string>(key, out var result) ? result : null;

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as
    ///     <see cref="DotEscapeString" />. If the attribute is found, but its value cannot be cast nor converted to the returned type,
    ///     an exception is thrown.
    /// </summary>
    public virtual DotEscapeString GetValueAsEscapeString(string key)
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

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as <see cref="DotLabel" />. If
    ///     the attribute is found, but its value cannot be cast nor converted to the returned type, an exception is thrown.
    /// </summary>
    public virtual DotLabel GetValueAsLabel(string key)
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

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as
    ///     <see cref="DotArrowheadDefinition" />. If the attribute is found, but its value cannot be cast nor converted to the returned
    ///     type, an exception is thrown.
    /// </summary>
    public virtual DotArrowheadDefinition GetValueAsArrowheadDefinition(string key)
    {
        return GetValueAs<DotArrowheadDefinition>
        (
            key,
            out var value,
            v => v is DotArrowheadShape s ? (true, new DotArrowhead(s)) : (false, null)
        )
            ? value
            : null;
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as
    ///     <see cref="DotPackingDefinition" />. If the attribute is found, but its value cannot be cast nor converted to the returned
    ///     type, an exception is thrown.
    /// </summary>
    public virtual DotPackingDefinition GetValueAsPackingDefinition(string key)
    {
        return GetValueAs<DotPackingDefinition>
        (
            key,
            out var value,
            v => v is int i ? (true, new DotPackingMargin(i)) : (false, null),
            v => v is bool b ? (true, new DotPackingToggle(b)) : (false, null)
        )
            ? value
            : null;
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as
    ///     <see cref="DotPackingModeDefinition" />. If the attribute is found, but its value cannot be cast nor converted to the
    ///     returned type, an exception is thrown.
    /// </summary>
    public virtual DotPackingModeDefinition GetValueAsPackingModeDefinition(string key)
    {
        return GetValueAs<DotPackingModeDefinition>
        (
            key,
            out var value,
            v => v is DotPackingGranularity g ? (true, new DotGranularPackingMode(g)) : (false, null)
        )
            ? value
            : null;
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as
    ///     <see cref="DotRankSeparationDefinition" />. If the attribute is found, but its value cannot be cast nor converted to the
    ///     returned type, an exception is thrown.
    /// </summary>
    public virtual DotRankSeparationDefinition GetValueAsRankSeparationDefinition(string key)
    {
        return GetValueAs<DotRankSeparationDefinition>
        (
            key,
            out var value,
            v => v is int i ? (true, new DotRankSeparation(i)) : (false, null),
            v => v is double d ? (true, new DotRankSeparation(d)) : (false, null),
            v => v is double[] da ? (true, new DotRadialRankSeparation(da)) : (false, null)
        )
            ? value
            : null;
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as
    ///     <see cref="DotGraphScalingDefinition" />. If the attribute is found, but its value cannot be cast nor converted to the
    ///     returned type, an exception is thrown.
    /// </summary>
    public virtual DotGraphScalingDefinition GetValueAsGraphScalingDefinition(string key)
    {
        return GetValueAs<DotGraphScalingDefinition>
        (
            key,
            out var value,
            v => v is int i ? (true, new DotGraphScalingAspectRatio(i)) : (false, null),
            v => v is double d ? (true, new DotGraphScalingAspectRatio(d)) : (false, null),
            v => v is DotGraphScaling s ? (true, new DotGraphScalingOption(s)) : (false, null)
        )
            ? value
            : null;
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as
    ///     <see cref="DotEndpointPort" />. If the attribute is found, but its value cannot be cast nor converted to the returned type,
    ///     an exception is thrown.
    /// </summary>
    public virtual DotEndpointPort GetValueAsEndpointPort(string key)
    {
        return GetValueAs
        (
            key,
            out var value,
            v => v is DotCompassPoint cp ? (true, new DotEndpointPort(cp)) : (false, null),
            v => v is string s ? (true, new DotEndpointPort(s)) : (false, null)
        )
            ? value
            : null;
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as <see cref="DotId" />. If the
    ///     attribute is found, but its value cannot be cast nor converted to the returned type, an exception is thrown.
    /// </summary>
    public virtual DotId GetValueAsId(string key)
    {
        return GetValueAs
        (
            key,
            out var value,
            v => v is string s ? (true, new DotId(s)) : (false, null)
        )
            ? value
            : null;
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as <see cref="DotClusterId" />.
    ///     If the attribute is found, but its value cannot be cast nor converted to the returned type, an exception is thrown.
    /// </summary>
    public virtual DotClusterId GetValueAsClusterId(string key)
    {
        return GetValueAs
        (
            key,
            out var value,
            v => v is string s ? (true, new DotClusterId(s)) : (false, null)
        )
            ? value
            : null;
    }
}