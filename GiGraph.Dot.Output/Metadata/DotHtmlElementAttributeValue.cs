using System;
using System.Collections.Generic;

namespace GiGraph.Dot.Output.Metadata
{
    /// <summary>
    ///     Provides methods for reading an HTML attribute value associated with an enumeration value.
    /// </summary>
    public static class DotHtmlElementAttributeValue
    {
        /// <summary>
        ///     Tries to get an HTML attribute value associated with the specified enumeration value.
        /// </summary>
        /// <param name="value">
        ///     The enumeration value whose associated HTML attribute value to return.
        /// </param>
        /// <param name="dotValue">
        ///     The returned HTML attribute value if available.
        /// </param>
        public static bool TryGet(Enum value, out string dotValue)
        {
            return DotAttributeValue<DotHtmlElementAttributeValueAttribute>.TryGet(value, out dotValue);
        }

        /// <summary>
        ///     Gets an HTML attribute value associated with the specified enumeration value.
        /// </summary>
        /// <param name="value">
        ///     The enumeration value whose associated HTML attribute value to return.
        /// </param>
        public static string Get(Enum value)
        {
            return DotAttributeValue<DotHtmlElementAttributeValueAttribute>.Get(value);
        }

        /// <summary>
        ///     Tries to get an enumeration value associated with the specified HTML attribute value.
        /// </summary>
        /// <param name="value">
        ///     The returned enumeration value if found.
        /// </param>
        /// <param name="dotValue">
        ///     The HTML attribute value whose associated enumeration value to return.
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
        ///     Gets an enumeration value associated with the specified HTML attribute value.
        /// </summary>
        /// <param name="dotValue">
        ///     The HTML attribute value whose associated enumeration value to return.
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
        ///     Gets a dictionary where the key is an HTML attribute value, and the value is a corresponding enumeration value.
        /// </summary>
        /// <typeparam name="TEnum">
        ///     The type of the enumeration whose value mapping to get.
        /// </typeparam>
        public static Dictionary<string, TEnum> GetMapping<TEnum>()
            where TEnum : Enum
        {
            return DotAttributeValue<DotHtmlElementAttributeValueAttribute>.GetMapping<TEnum>();
        }
    }
}