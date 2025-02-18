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
        where T : DotAttribute =>
        TryGetValue(key, out var attribute)
            ? attribute as T ?? throw new InvalidCastException($"The '{key}' attribute of type {attribute.GetType().Name} cannot be accessed as {typeof(T).Name}.")
            : null;

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns it as the specified type. If the
    ///     attribute is not found, or cannot be cast as the specified type, returns false.
    /// </summary>
    /// <typeparam name="T">
    ///     The type to return the attribute as.
    /// </typeparam>
    /// <param name="key">
    ///     The key of the attribute to get.
    /// </param>
    /// <param name="attribute">
    ///     The matching attribute.
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
    ///     Checks if an attribute with the specified key exists in the collection, and if it does, returns its value as the specified
    ///     type. If the attribute is found, but its value cannot be cast as the specified type, an exception is thrown.
    /// </summary>
    /// <typeparam name="T">
    ///     The type to return the attribute value as.
    /// </typeparam>
    /// <param name="key">
    ///     The key of the attribute to get.
    /// </param>
    /// <param name="value">
    ///     The output value.
    /// </param>
    public virtual bool GetValueAs<T>(string key, [MaybeNullWhen(false)] out T value)
    {
        if (TryGetValue(key, out var attribute))
        {
            return attribute.GetValueAs(out value);
        }

        value = default(T?);
        return false;
    }

    /// <summary>
    ///     Checks if an attribute with the specified key exists in the collection, and returns its value as the specified type. If the
    ///     attribute is not found, or its value cannot be cast as the specified type, returns false.
    /// </summary>
    /// <typeparam name="T">
    ///     The type to return the attribute value as.
    /// </typeparam>
    /// <param name="key">
    ///     The key of the attribute to get.
    /// </param>
    /// <param name="value">
    ///     The value of the matching attribute.
    /// </param>
    public virtual bool TryGetValueAs<T>(string key, [MaybeNullWhen(false)] out T value)
    {
        if (TryGetValue(key, out var attribute))
        {
            return attribute.TryGetValueAs(out value);
        }

        value = default(T?);
        return false;
    }
}