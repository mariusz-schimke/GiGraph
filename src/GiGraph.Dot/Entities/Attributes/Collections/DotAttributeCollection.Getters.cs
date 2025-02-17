using System.Diagnostics.CodeAnalysis;
using System.Drawing;
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
    public virtual DotAttribute? Get(string key) => TryGetValue(key, out var attribute) ? attribute : null;

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
    public virtual T? GetAs<T>(string key)
        where T : DotAttribute
    {
        if (!TryGetValue(key, out var attribute))
        {
            return null;
        }

        return attribute as T ?? throw new InvalidCastException($"The '{key}' attribute of type {attribute.GetType().Name} cannot be accessed as {typeof(T).Name}.");
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
    public virtual bool TryGetAs<T>(string key, [MaybeNullWhen(false)] out T attribute)
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
    public virtual bool GetValue<T>(string key, [MaybeNullWhen(false)] out T value)
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

        throw new InvalidCastException($"The '{key}' attribute value '{attributeValue}' of type {attributeValue.GetType().Name} cannot be accessed as {typeof(T).Name}.");
    }

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
    public virtual bool TryGetValueAs<T>(string key, [MaybeNullWhen(false)] out T value)
    {
        if (TryGetValue(key, out var attribute) && attribute.GetValue() is T output)
        {
            value = output;
            return true;
        }

        value = default(T);
        return false;
    }

    // todo: te metody nie są wołane, bo niesłusznie wywoływany jest generyczny ich wariant
    
    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as <see cref="int" />. If the
    ///     attribute is found, but its value cannot be cast nor converted to the specified type, an exception is thrown.
    /// </summary>
    public virtual bool GetValue(string key, out int value) => GetValue<int>(key, out value);

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as <see cref="double" />. If
    ///     the attribute is found, but its value cannot be cast nor converted to the returned type, an exception is thrown.
    /// </summary>
    public virtual bool GetValue(string key, out double value)
    {
        if (TryGetValueAs(key, out value))
        {
            return true;
        }

        if (TryGetValueAs<int>(key, out var integer))
        {
            value = integer;
            return true;
        }

        return false;
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as <see cref="bool" />. If the
    ///     attribute is found, but its value cannot be cast nor converted to the returned type, an exception is thrown.
    /// </summary>
    public virtual bool GetValue(string key, out bool value) => GetValue<bool>(key, out value);

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as <see cref="DotPoint" />. If
    ///     the attribute is found, but its value cannot be cast nor converted to the returned type, an exception is thrown.
    /// </summary>
    public virtual bool GetValue(string key, [MaybeNullWhen(false)] out DotPoint value) => GetValue<DotPoint>(key, out value);

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as <see cref="DotColor" />. If
    ///     the attribute is found, but its value cannot be cast nor converted to the returned type, an exception is thrown.
    /// </summary>
    public virtual bool GetValue(string key, [MaybeNullWhen(false)] out DotColor value)
    {
        if (TryGetValueAs(key, out value))
        {
            return true;
        }

        if (TryGetValueAs<Color>(key, out var color))
        {
            value = new(color);
            return true;
        }

        return false;
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as
    ///     <see cref="DotColorDefinition" />. If the attribute is found, but its value cannot be cast nor converted to the returned
    ///     type, an exception is thrown.
    /// </summary>
    public virtual bool GetValue(string key, [MaybeNullWhen(false)] out DotColorDefinition value)
    {
        if (TryGetValueAs(key, out value))
        {
            return true;
        }

        if (TryGetValueAs<Color>(key, out var color))
        {
            value = new DotColor(color);
            return true;
        }

        return false;
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as <see cref="string" />. If
    ///     the attribute is found, but its value cannot be cast nor converted to the returned type, an exception is thrown.
    /// </summary>
    public virtual bool GetValue(string key, [MaybeNullWhen(false)] out string value) => GetValue<string>(key, out value);

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as
    ///     <see cref="DotEscapeString" />. If the attribute is found, but its value cannot be cast nor converted to the returned type,
    ///     an exception is thrown.
    /// </summary>
    public virtual bool GetValue(string key, [MaybeNullWhen(false)] out DotEscapeString value)
    {
        if (TryGetValueAs(key, out value))
        {
            return true;
        }

        if (TryGetValueAs<string>(key, out var s))
        {
            value = (DotEscapedString) s;
            return true;
        }

        return false;
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as <see cref="DotLabel" />. If
    ///     the attribute is found, but its value cannot be cast nor converted to the returned type, an exception is thrown.
    /// </summary>
    public virtual bool GetValue(string key, [MaybeNullWhen(false)] out DotLabel value)
    {
        if (TryGetValueAs(key, out value))
        {
            return true;
        }

        if (TryGetValueAs<string>(key, out var s))
        {
            value = (DotEscapedString) s;
            return true;
        }

        return false;
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as
    ///     <see cref="DotArrowheadDefinition" />. If the attribute is found, but its value cannot be cast nor converted to the returned
    ///     type, an exception is thrown.
    /// </summary>
    public virtual bool GetValue(string key, [MaybeNullWhen(false)] out DotArrowheadDefinition value)
    {
        if (TryGetValueAs(key, out value))
        {
            return true;
        }

        if (TryGetValueAs<DotArrowheadShape>(key, out var shape))
        {
            value = shape;
            return true;
        }

        return false;
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as
    ///     <see cref="DotPackingDefinition" />. If the attribute is found, but its value cannot be cast nor converted to the returned
    ///     type, an exception is thrown.
    /// </summary>
    public virtual bool GetValue(string key, [MaybeNullWhen(false)] out DotPackingDefinition value)
    {
        if (TryGetValueAs(key, out value))
        {
            return true;
        }

        if (TryGetValueAs<bool>(key, out var toggle))
        {
            value = toggle;
            return true;
        }

        return false;
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as
    ///     <see cref="DotPackingModeDefinition" />. If the attribute is found, but its value cannot be cast nor converted to the
    ///     returned type, an exception is thrown.
    /// </summary>
    public virtual bool GetValue(string key, [MaybeNullWhen(false)] out DotPackingModeDefinition value)
    {
        if (TryGetValueAs(key, out value))
        {
            return true;
        }

        if (TryGetValueAs<DotPackingGranularity>(key, out var toggle))
        {
            value = toggle;
            return true;
        }

        return false;
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as
    ///     <see cref="DotRankSeparationDefinition" />. If the attribute is found, but its value cannot be cast nor converted to the
    ///     returned type, an exception is thrown.
    /// </summary>
    public virtual bool GetValue(string key, [MaybeNullWhen(false)] out DotRankSeparationDefinition value)
    {
        if (TryGetValueAs(key, out value))
        {
            return true;
        }

        if (TryGetValueAs<int>(key, out var rankSeparationInt))
        {
            value = rankSeparationInt;
            return true;
        }

        if (TryGetValueAs<double>(key, out var rankSeparationDouble))
        {
            value = rankSeparationDouble;
            return true;
        }

        if (TryGetValueAs<double[]>(key, out var radialRankSeparation))
        {
            value = radialRankSeparation;
            return true;
        }

        return false;
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as
    ///     <see cref="DotGraphScalingDefinition" />. If the attribute is found, but its value cannot be cast nor converted to the
    ///     returned type, an exception is thrown.
    /// </summary>
    public virtual bool GetValue(string key, [MaybeNullWhen(false)] out DotGraphScalingDefinition value)
    {
        if (TryGetValueAs(key, out value))
        {
            return true;
        }

        if (TryGetValueAs<int>(key, out var scalingAspectRatioInt))
        {
            value = scalingAspectRatioInt;
            return true;
        }

        if (TryGetValueAs<double>(key, out var scalingAspectRatioDouble))
        {
            value = scalingAspectRatioDouble;
            return true;
        }

        if (TryGetValueAs<DotGraphScaling>(key, out var scalingOption))
        {
            value = scalingOption;
            return true;
        }

        return false;
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as
    ///     <see cref="DotEndpointPort" />. If the attribute is found, but its value cannot be cast nor converted to the returned type,
    ///     an exception is thrown.
    /// </summary>
    public virtual bool GetValue(string key, [MaybeNullWhen(false)] out DotEndpointPort value)
    {
        if (TryGetValueAs(key, out value))
        {
            return true;
        }

        if (TryGetValueAs<DotCompassPoint>(key, out var compassPoint))
        {
            value = compassPoint;
            return true;
        }

        if (TryGetValueAs<string>(key, out var s))
        {
            value = s;
            return true;
        }

        return false;
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as <see cref="DotId" />. If the
    ///     attribute is found, but its value cannot be cast nor converted to the returned type, an exception is thrown.
    /// </summary>
    public virtual bool GetValue(string key, [MaybeNullWhen(false)] out DotId value)
    {
        if (TryGetValueAs(key, out value))
        {
            return true;
        }

        if (TryGetValueAs<string>(key, out var s))
        {
            value = s;
            return true;
        }

        return false;
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as <see cref="DotClusterId" />.
    ///     If the attribute is found, but its value cannot be cast nor converted to the returned type, an exception is thrown.
    /// </summary>
    public virtual bool GetValue(string key, [MaybeNullWhen(false)] out DotClusterId value)
    {
        if (TryGetValueAs(key, out value))
        {
            return true;
        }

        if (TryGetValueAs<string>(key, out var s))
        {
            value = s;
            return true;
        }

        return false;
    }
}