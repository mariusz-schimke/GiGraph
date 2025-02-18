using System.Diagnostics.CodeAnalysis;

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
    public virtual bool GetValueAs<T>(string key, [MaybeNullWhen(false)] out T value)
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
}