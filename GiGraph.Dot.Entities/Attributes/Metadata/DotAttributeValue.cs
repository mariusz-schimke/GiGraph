using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GiGraph.Dot.Entities.Attributes.Metadata
{
    /// <summary>
    ///     Provides methods for reading a DOT value associated with an enumeration value.
    /// </summary>
    public static class DotAttributeValue
    {
        private const BindingFlags FieldBindingFlags = BindingFlags.Static | BindingFlags.Public;

        /// <summary>
        ///     Tries to get a DOT attribute value associated with the specified enumeration value.
        /// </summary>
        /// <param name="value">
        ///     The enumeration value whose associated DOT value to return.
        /// </param>
        /// <param name="dotValue">
        ///     The returned DOT attribute value if available.
        /// </param>
        /// <typeparam name="TEnum">
        ///     The type of the enumeration whose attribute value to search.
        /// </typeparam>
        public static bool TryGet<TEnum>(TEnum value, out string dotValue)
            where TEnum : Enum
        {
            var enumMember = typeof(TEnum).GetMember(value.ToString()).FirstOrDefault();

            if (enumMember?.GetCustomAttribute<DotAttributeValueAttribute>() is { } attribute)
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
        /// <typeparam name="TEnum">
        ///     The type of the enumeration whose attribute value to search.
        /// </typeparam>
        public static string Get<TEnum>(TEnum value)
            where TEnum : Enum
        {
            return TryGet(value, out var result)
                ? result
                : throw new ArgumentException($"The specified '{value}' value of the {typeof(TEnum).Name} enumeration has no associated DOT attribute value.", nameof(value));
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
            var match = typeof(TEnum)
               .GetFields(FieldBindingFlags)
               .FirstOrDefault(field => field.GetCustomAttribute<DotAttributeValueAttribute>()?.Value is { } fieldDotValue && fieldDotValue == dotValue);

            if (match is { })
            {
                value = (TEnum) match.GetValue(null);
                return true;
            }

            value = default;
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
            where TEnum : Enum
        {
            return TryGet<TEnum>(dotValue, out var result)
                ? result
                : throw new ArgumentException($"The specified DOT attribute value '{dotValue}' has no equivalent on the {typeof(TEnum).Name} enumeration.", nameof(dotValue));
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
            return typeof(TEnum)
               .GetFields(FieldBindingFlags)
               .Select(field => new
                {
                    Attribute = field.GetCustomAttribute<DotAttributeValueAttribute>(),
                    Field = field
                })
               .Where(result => result.Attribute is { })
               .Where(result => result.Attribute.Value is { })
               .ToDictionary(
                    key => key.Attribute.Value,
                    element => (TEnum) element.Field.GetValue(null)
                );
        }
    }
}