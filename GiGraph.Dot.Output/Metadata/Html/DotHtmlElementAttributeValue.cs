using System;
using System.Collections.Generic;

namespace GiGraph.Dot.Output.Metadata.Html
{
    /// <summary>
    ///     Provides methods for reading an HTML attribute value associated with an enumeration value.
    /// </summary>
    public static class DotHtmlElementAttributeValue
    {
        /// <summary>
        ///     If the specified enumeration type is marked with a <see cref="DotHtmlElementFlagsAttribute" /> returns its individual flags
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
        public static bool TryGetAsFlags(Enum flags, out string dotFlags, bool sort = true)
        {
            return DotAttributeValue<DotHtmlElementAttributeValueAttribute>.TryGetAsFlags<DotHtmlElementFlagsAttribute>(flags, out dotFlags, sort);
        }

        /// <summary>
        ///     If the specified enumeration type is marked with a <see cref="DotHtmlElementFlagsAttribute" /> returns its individual flags
        ///     joined with a separator specified by the attribute. If the enumeration does not contain the attribute, throws an exception.
        /// </summary>
        /// <param name="flags">
        ///     The enumeration to convert to DOT attribute flags.
        /// </param>
        /// <param name="sort">
        ///     Determines whether the flags of the enumeration should be sorted when possible.
        /// </param>
        public static string GetAsFlags(Enum flags, bool sort = true)
        {
            return DotAttributeValue<DotHtmlElementAttributeValueAttribute>.GetAsFlags<DotHtmlElementFlagsAttribute>(flags, sort);
        }

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
            return DotAttributeValue<DotHtmlElementAttributeValueAttribute>.TryGet(value, out dotValue);
        }

        /// <summary>
        ///     Gets a DOT attribute value associated with the specified enumeration value.
        /// </summary>
        /// <param name="value">
        ///     The enumeration value whose associated DOT value to return.
        /// </param>
        public static string Get(Enum value)
        {
            return DotAttributeValue<DotHtmlElementAttributeValueAttribute>.Get(value);
        }

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
            return DotAttributeValue<DotHtmlElementAttributeValueAttribute>.TryGet(dotValue, out value);
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
            return DotAttributeValue<DotHtmlElementAttributeValueAttribute>.TryGet(enumType, dotValue, out value);
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
            where TEnum : Enum
        {
            return DotAttributeValue<DotHtmlElementAttributeValueAttribute>.Get<TEnum>(dotValue);
        }

        /// <summary>
        ///     Gets an enumeration value associated with the specified DOT attribute value.
        /// </summary>
        /// <param name="enumType">
        ///     The type of the enumeration whose value to search.
        /// </param>
        /// <param name="dotValue">
        ///     The DOT attribute value whose associated enumeration value to return.
        /// </param>
        public static Enum Get(Type enumType, string dotValue)
        {
            return DotAttributeValue<DotHtmlElementAttributeValueAttribute>.Get(enumType, dotValue);
        }

        /// <summary>
        ///     Gets a dictionary where each key has a DOT attribute value assigned. Enumeration values that are not marked with the
        ///     <see cref="DotHtmlElementAttributeValueAttribute" /> attribute are ignored.
        /// </summary>
        /// <typeparam name="TEnum">
        ///     The type of the enumeration whose value mapping to get.
        /// </typeparam>
        public static Dictionary<TEnum, string> GetMapping<TEnum>()
            where TEnum : Enum
        {
            return DotAttributeValue<DotHtmlElementAttributeValueAttribute>.GetMapping<TEnum>();
        }

        /// <summary>
        ///     Gets a dictionary where each key has a DOT attribute value assigned. Enumeration values that are not marked with the
        ///     <see cref="DotHtmlElementAttributeValueAttribute" /> attribute are ignored.
        /// </summary>
        /// <param name="enumType">
        ///     The type of the enumeration whose value mapping to get.
        /// </param>
        public static Dictionary<Enum, string> GetMapping(Type enumType)
        {
            return DotAttributeValue<DotHtmlElementAttributeValueAttribute>.GetMapping(enumType);
        }
    }
}