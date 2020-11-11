using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GiGraph.Dot.Entities.Metadata
{
    /// <summary>
    ///     Assigns a DOT attribute value to an enumeration value.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class DotAttributeValueAttribute : Attribute
    {
        protected const BindingFlags FieldBindingFlags = BindingFlags.Static | BindingFlags.Public;

        /// <summary>
        ///     Creates a new attribute instance.
        /// </summary>
        /// <param name="value">
        ///     The value of the DOT attribute.
        /// </param>
        public DotAttributeValueAttribute(string value)
        {
            Value = value;
        }

        /// <summary>
        ///     Gets the value of the DOT attribute.
        /// </summary>
        public virtual string Value { get; }

        /// <summary>
        ///     Gets a DOT attribute value associated with the specified enumeration value.
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
        public static bool TryGetValue<TEnum>(TEnum value, out string dotValue)
            where TEnum : Enum
        {
            var enumMember = typeof(TEnum).GetMember(value.ToString()).FirstOrDefault();

            if (enumMember?.GetCustomAttribute<DotAttributeValueAttribute>() is {} attribute)
            {
                dotValue = attribute.Value;
                return true;
            }

            dotValue = null;
            return false;
        }

        /// <summary>
        ///     Gets an enumeration value associated with the specified DOT attribute value.
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
        public static bool TryGetValue<TEnum>(string dotValue, out TEnum value)
            where TEnum : Enum
        {
            var match = typeof(TEnum)
               .GetFields(FieldBindingFlags)
               .FirstOrDefault(field => field.GetCustomAttribute<DotAttributeValueAttribute>()?.Value is {} fieldDotValue && fieldDotValue == dotValue);

            if (match is {})
            {
                value = (TEnum) match.GetValue(null);
                return true;
            }

            value = default;
            return false;
        }

        /// <summary>
        ///     Gets a dictionary where the key is a DOT attribute value, and the value is a corresponding enumeration value.
        /// </summary>
        /// <typeparam name="TEnum">
        ///     The type of the enumeration whose value mapping to get.
        /// </typeparam>
        public static Dictionary<string, TEnum> GetValueMapping<TEnum>()
            where TEnum : Enum
        {
            return typeof(TEnum)
               .GetFields(FieldBindingFlags)
               .Select(field => new
                {
                    Attribute = field.GetCustomAttribute<DotAttributeValueAttribute>(),
                    Field = field
                })
               .Where(result => result.Attribute is {})
               .Where(result => result.Attribute.Value is {})
               .ToDictionary(
                    key => key.Attribute.Value,
                    value => (TEnum) value.Field.GetValue(null)
                );
        }
    }
}