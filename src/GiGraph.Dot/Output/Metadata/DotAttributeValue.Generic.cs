using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GiGraph.Dot.Output.EnumHelpers;

namespace GiGraph.Dot.Output.Metadata;

/// <summary>
///     Provides methods for reading a DOT value associated with an enumeration value.
/// </summary>
public static class DotAttributeValue<TAttribute>
    where TAttribute : Attribute, IDotAttributeValueAttribute
{
    private const BindingFlags FieldBindingFlags = BindingFlags.Static | BindingFlags.Public;

    /// <summary>
    ///     If the specified enumeration type is marked with a <typeparamref name="TFlagsAttribute" /> returns its individual flags
    ///     joined with a separator specified by the attribute. If the enumeration does not contain the attribute, returns false.
    /// </summary>
    /// <param name="flags">
    ///     The enumeration to convert to DOT attribute flags.
    /// </param>
    /// <param name="dotFlags">
    ///     The returned DOT attribute flags.
    /// </param>
    /// <param name="sort">
    ///     Determines whether the flags of the enumeration should be sorted when possible.
    /// </param>
    /// <typeparam name="TFlagsAttribute">
    ///     The type of attribute that provides metadata for the specified flags enumeration.
    /// </typeparam>
    public static bool TryGetAsFlags<TFlagsAttribute>(Enum flags, out string dotFlags, bool sort)
        where TFlagsAttribute : Attribute, IDotJoinableTypeAttribute
    {
        var enumType = flags.GetType();
        if (enumType.GetCustomAttribute<TFlagsAttribute>() is not { } attribute)
        {
            dotFlags = null;
            return false;
        }

        var enumValues = new DotEnumMetadata(enumType).GetNonCompoundValues();
        var mapping = GetMapping(enumType);

        var dotFlagsEnumerable = enumValues
           .Where(flags.HasFlag)
           .Select(flag => mapping.TryGetValue(flag, out var value)
                ? value
                : throw new ArgumentException($"The value '{flag}' of the {enumType.Name} enumeration is not annotated with a {typeof(TAttribute).Name} attribute.", nameof(flags))
            )
           .Where(value => value is not null);

        dotFlags = string.Join(
            attribute.Separator,
            attribute.Sort && sort
                ? dotFlagsEnumerable.OrderBy(flag => flag, StringComparer.InvariantCulture)
                : dotFlagsEnumerable
        );
        return true;
    }

    /// <summary>
    ///     If the specified enumeration type is marked with a <typeparamref name="TFlagsAttribute" /> returns its individual flags
    ///     joined with a separator specified by the attribute. If the enumeration does not contain the attribute, throws an exception.
    /// </summary>
    /// <param name="flags">
    ///     The enumeration to convert to DOT attribute flags.
    /// </param>
    /// <param name="sort">
    ///     Determines whether the flags of the enumeration should be sorted when possible.
    /// </param>
    /// <typeparam name="TFlagsAttribute">
    ///     The type of attribute that provides metadata for the specified flags enumeration.
    /// </typeparam>
    public static string GetAsFlags<TFlagsAttribute>(Enum flags, bool sort)
        where TFlagsAttribute : Attribute, IDotJoinableTypeAttribute =>
        TryGetAsFlags<TFlagsAttribute>(flags, out var dotFlags, sort)
            ? dotFlags
            : throw new ArgumentException($"The {flags.GetType().Name} enumeration is not annotated with a {typeof(TFlagsAttribute).Name} attribute.", nameof(flags));

    /// <summary>
    ///     Tries to get a DOT attribute value associated with the specified enumeration value.
    /// </summary>
    /// <param name="value">
    ///     The enumeration value whose associated DOT value to return.
    /// </param>
    /// <param name="dotValue">
    ///     The returned DOT attribute value if available.
    /// </param>
    public static bool TryGet(Enum value, out string dotValue)
    {
        var enumMember = value.GetType().GetMember(value.ToString()).FirstOrDefault();

        if (enumMember?.GetCustomAttribute<TAttribute>() is { } attribute)
        {
            dotValue = attribute.Value;
            return true;
        }

        dotValue = null;
        return false;
    }

    /// <summary>
    ///     Gets a DOT attribute value associated with the specified enumeration value.
    /// </summary>
    /// <param name="value">
    ///     The enumeration value whose associated DOT value to return.
    /// </param>
    public static string Get(Enum value) => TryGet(value, out var result)
        ? result
        : throw new ArgumentException($"The value '{value}' is not a member of the {value.GetType().Name} enumeration or is not annotated with a {typeof(TAttribute).Name} attribute.", nameof(value));

    /// <summary>
    ///     Tries to get an enumeration value associated with the specified DOT attribute value.
    /// </summary>
    /// <param name="value">
    ///     The returned enumeration value if found.
    /// </param>
    /// <param name="dotValue">
    ///     The DOT attribute value whose associated enumeration value to return.
    /// </param>
    /// <typeparam name="TEnum">
    ///     The type of the enumeration whose value to search.
    /// </typeparam>
    public static bool TryGet<TEnum>(string dotValue, out TEnum value)
        where TEnum : Enum
    {
        var result = TryGet(typeof(TEnum), dotValue, out var enumValue);
        value = result ? (TEnum) enumValue : default(TEnum);
        return result;
    }

    /// <summary>
    ///     Tries to get an enumeration value associated with the specified DOT attribute value.
    /// </summary>
    /// <param name="enumType">
    ///     The type of the enumeration whose value to search.
    /// </param>
    /// <param name="value">
    ///     The returned enumeration value if found.
    /// </param>
    /// <param name="dotValue">
    ///     The DOT attribute value whose associated enumeration value to return.
    /// </param>
    public static bool TryGet(Type enumType, string dotValue, out Enum value)
    {
        var match = enumType
           .GetFields(FieldBindingFlags)
           .FirstOrDefault(field => field.GetCustomAttribute<TAttribute>()?.Value is { } fieldDotValue && fieldDotValue == dotValue);

        if (match is not null)
        {
            value = (Enum) match.GetValue(null);
            return true;
        }

        value = default(Enum);
        return false;
    }

    /// <summary>
    ///     Gets an enumeration value associated with the specified DOT attribute value.
    /// </summary>
    /// <param name="dotValue">
    ///     The DOT attribute value whose associated enumeration value to return.
    /// </param>
    /// <typeparam name="TEnum">
    ///     The type of the enumeration whose value to search.
    /// </typeparam>
    public static TEnum Get<TEnum>(string dotValue)
        where TEnum : Enum =>
        (TEnum) Get(typeof(TEnum), dotValue);

    /// <summary>
    ///     Gets an enumeration value associated with the specified DOT attribute value.
    /// </summary>
    /// <param name="enumType">
    ///     The type of the enumeration whose value to search.
    /// </param>
    /// <param name="dotValue">
    ///     The DOT attribute value whose associated enumeration value to return.
    /// </param>
    public static Enum Get(Type enumType, string dotValue) => TryGet(enumType, dotValue, out var result)
        ? result
        : throw new ArgumentException($"The '{dotValue}' value is invalid or is not mapped to any value of the {enumType.Name} enumeration by a {typeof(TAttribute).Name} attribute.", nameof(dotValue));

    /// <summary>
    ///     Gets a dictionary where each key has a DOT attribute value assigned. Enumeration values that are not marked with the
    ///     <typeparamref name="TAttribute" /> attribute are ignored.
    /// </summary>
    /// <typeparam name="TEnum">
    ///     The type of the enumeration whose value mapping to get.
    /// </typeparam>
    public static Dictionary<TEnum, string> GetMapping<TEnum>()
        where TEnum : Enum
    {
        return GetMappingEnumerable(typeof(TEnum))
           .ToDictionary(
                item => (TEnum) item.Key,
                item => item.Value
            );
    }

    /// <summary>
    ///     Gets a dictionary where each key has a DOT attribute value assigned. Enumeration values that are not marked with the
    ///     <typeparamref name="TAttribute" /> attribute are ignored.
    /// </summary>
    /// <param name="enumType">
    ///     The type of the enumeration whose value mapping to get.
    /// </param>
    public static Dictionary<Enum, string> GetMapping(Type enumType)
    {
        return GetMappingEnumerable(enumType)
           .ToDictionary(
                item => item.Key,
                item => item.Value
            );
    }

    private static IEnumerable<(Enum Key, string Value)> GetMappingEnumerable(Type enumType)
    {
        return enumType
           .GetFields(FieldBindingFlags)
           .Select(field =>
            (
                Attribute: field.GetCustomAttribute<TAttribute>(),
                EnumValue: (Enum) field.GetValue(null)
            ))
           .Where(result => result.Attribute is not null)
           .Select(item =>
            (
                Key: item.EnumValue,
                item.Attribute.Value
            ));
    }
}