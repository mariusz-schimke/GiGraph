using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace GiGraph.Dot.Output.Metadata;

/// <summary>
///     Provides methods for reading a DOT value associated with an enumeration value.
/// </summary>
public static class DotAttributeValue
{
    /// <summary>
    ///     If the specified enumeration type is marked with a <see cref="DotJoinableTypeAttribute" /> returns its individual flags
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
    public static bool TryGetAsFlags(Enum flags, [MaybeNullWhen(false)] out string dotFlags, bool sort = true) =>
        DotAttributeValue<DotAttributeValueAttribute>.TryGetAsFlags<DotJoinableTypeAttribute>(flags, out dotFlags, sort);

    /// <summary>
    ///     If the specified enumeration type is marked with a <see cref="DotJoinableTypeAttribute" /> returns its individual flags
    ///     joined with a separator specified by the attribute. If the enumeration does not contain the attribute, throws an exception.
    /// </summary>
    /// <param name="flags">
    ///     The enumeration to convert to DOT attribute flags.
    /// </param>
    /// <param name="sort">
    ///     Determines whether the flags of the enumeration should be sorted when possible.
    /// </param>
    public static string GetAsFlags(Enum flags, bool sort = true) =>
        DotAttributeValue<DotAttributeValueAttribute>.GetAsFlags<DotJoinableTypeAttribute>(flags, sort);

    /// <summary>
    ///     Tries to get a DOT attribute value associated with the specified enumeration value.
    /// </summary>
    /// <param name="value">
    ///     The enumeration value whose associated DOT value to return.
    /// </param>
    /// <param name="dotValue">
    ///     The returned DOT attribute value if available.
    /// </param>
    public static bool TryGet(Enum value, [MaybeNullWhen(false)] out string dotValue) =>
        DotAttributeValue<DotAttributeValueAttribute>.TryGet(value, out dotValue);

    /// <summary>
    ///     Gets a DOT attribute value associated with the specified enumeration value.
    /// </summary>
    /// <param name="value">
    ///     The enumeration value whose associated DOT value to return.
    /// </param>
    public static string? Get(Enum value) => DotAttributeValue<DotAttributeValueAttribute>.Get(value);

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
    public static bool TryGet<TEnum>(string dotValue, [MaybeNullWhen(false)] out TEnum value)
        where TEnum : Enum => DotAttributeValue<DotAttributeValueAttribute>.TryGet(dotValue, out value);

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
    public static bool TryGet(Type enumType, string dotValue, [MaybeNullWhen(false)] out Enum value) =>
        DotAttributeValue<DotAttributeValueAttribute>.TryGet(enumType, dotValue, out value);

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
        where TEnum : Enum => DotAttributeValue<DotAttributeValueAttribute>.Get<TEnum>(dotValue);

    /// <summary>
    ///     Gets an enumeration value associated with the specified DOT attribute value.
    /// </summary>
    /// <param name="enumType">
    ///     The type of the enumeration whose value to search.
    /// </param>
    /// <param name="dotValue">
    ///     The DOT attribute value whose associated enumeration value to return.
    /// </param>
    public static Enum Get(Type enumType, string dotValue) => DotAttributeValue<DotAttributeValueAttribute>.Get(enumType, dotValue);

    /// <summary>
    ///     Gets a dictionary where each key has a DOT attribute value assigned. Enumeration values that are not marked with the
    ///     <see cref="DotAttributeValueAttribute" /> attribute are ignored.
    /// </summary>
    /// <typeparam name="TEnum">
    ///     The type of the enumeration whose value mapping to get.
    /// </typeparam>
    public static Dictionary<TEnum, string?> GetMapping<TEnum>()
        where TEnum : Enum => DotAttributeValue<DotAttributeValueAttribute>.GetMapping<TEnum>();

    /// <summary>
    ///     Gets a dictionary where each key has a DOT attribute value assigned. Enumeration values that are not marked with the
    ///     <see cref="DotAttributeValueAttribute" /> attribute are ignored.
    /// </summary>
    /// <param name="enumType">
    ///     The type of the enumeration whose value mapping to get.
    /// </param>
    public static Dictionary<Enum, string?> GetMapping(Type enumType) => DotAttributeValue<DotAttributeValueAttribute>.GetMapping(enumType);
}