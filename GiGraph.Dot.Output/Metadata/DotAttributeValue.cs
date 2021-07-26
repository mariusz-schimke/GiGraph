using System;
using System.Collections.Generic;

namespace GiGraph.Dot.Output.Metadata
{
    /// <summary>
    ///     Provides methods for reading a DOT value associated with an enumeration value.
    /// </summary>
    public static class DotAttributeValue
    {
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
            return DotAttributeValue<DotAttributeValueAttribute>.TryGet(value, out dotValue);
        }

        /// <summary>
        ///     Gets a DOT attribute value associated with the specified enumeration value.
        /// </summary>
        /// <param name="value">
        ///     The enumeration value whose associated DOT value to return.
        /// </param>
        public static string Get(Enum value)
        {
            return DotAttributeValue<DotAttributeValueAttribute>.Get(value);
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
            return DotAttributeValue<DotAttributeValueAttribute>.TryGet(dotValue, out value);
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
            return DotAttributeValue<DotAttributeValueAttribute>.Get<TEnum>(dotValue);
        }

        /// <summary>
        ///     Gets a dictionary where the key is a DOT attribute value, and the value is a corresponding enumeration value.
        /// </summary>
        /// <typeparam name="TEnum">
        ///     The type of the enumeration whose value mapping to get.
        /// </typeparam>
        public static Dictionary<string, TEnum> GetMapping<TEnum>()
            where TEnum : Enum
        {
            return DotAttributeValue<DotAttributeValueAttribute>.GetMapping<TEnum>();
        }
    }
}