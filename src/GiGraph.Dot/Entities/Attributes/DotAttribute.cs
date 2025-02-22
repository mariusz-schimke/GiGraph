using System.Diagnostics.CodeAnalysis;
using GiGraph.Dot.Helpers;
using GiGraph.Dot.Output.Entities;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Entities.Attributes;

public abstract class DotAttribute : IDotEntity, IDotAnnotatable, IDotEncodable, IDotOrderable
{
    protected DotAttribute(string key)
    {
        Key = key ?? throw new ArgumentNullException(nameof(key), "Attribute key must not be null.");
    }

    /// <summary>
    ///     Gets the key of the attribute.
    /// </summary>
    public string Key { get; }

    public virtual bool HasValue => GetValue() is not null;

    /// <inheritdoc cref="IDotAnnotatable.Annotation" />
    public virtual string? Annotation { get; set; }

    string? IDotEncodable.GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => GetDotEncodedValue(options, syntaxRules);

    string IDotOrderable.OrderingKey => Key;

    /// <summary>
    ///     Gets the value of the attribute.
    /// </summary>
    public abstract object? GetValue();

    /// <summary>
    ///     Gets the value of the attribute in a format understood by DOT graph renderer.
    /// </summary>
    /// <param name="options">
    ///     The DOT generation options to use.
    /// </param>
    /// <param name="syntaxRules">
    ///     The DOT syntax rules to use.
    /// </param>
    protected internal abstract string? GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules);

    /// <summary>
    ///     Checks if the attribute has the specified key. The comparison is made based on Graphviz syntax rules (where the keys are case
    ///     sensitive).
    /// </summary>
    /// <param name="key">
    ///     The key to check.
    /// </param>
    public bool HasKey(string key) => string.Equals(Key, key, StringComparison.Ordinal);

    /// <summary>
    ///     Returns the value of the attribute as the specified type. If the value cannot be cast as the specified type, an exception is
    ///     thrown.
    /// </summary>
    /// <typeparam name="T">
    ///     The type to return the attribute value as.
    /// </typeparam>
    /// <param name="value">
    ///     The output value.
    /// </param>
    public virtual bool GetValueAs<T>([MaybeNullWhen(false)] out T value)
    {
        if (GetValue() is not { } attributeValue)
        {
            value = default(T?);
            return false;
        }

        // if not null and of a matching type, return it
        if (attributeValue is T output)
        {
            value = output;
            return true;
        }

        throw new InvalidCastException($"The value of type {attributeValue.GetType().Name} cannot be accessed as {TypeHelper.GetDisplayName<T>()}.");
    }

    /// <summary>
    ///     Returns the value of the attribute as the specified type. If the value is null, or cannot be cast as the specified type,
    ///     returns false.
    /// </summary>
    /// <typeparam name="T">
    ///     The type to return the attribute value as.
    /// </typeparam>
    /// <param name="value">
    ///     The output value.
    /// </param>
    public virtual bool TryGetValueAs<T>([MaybeNullWhen(false)] out T value)
    {
        if (GetValue() is T output)
        {
            value = output;
            return true;
        }

        value = default(T?);
        return false;
    }
}