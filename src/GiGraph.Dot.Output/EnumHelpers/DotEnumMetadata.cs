using System;
using System.Linq;

namespace GiGraph.Dot.Output.EnumHelpers
{
    /// <summary>
    ///     Provides enumeration metadata.
    /// </summary>
    public class DotEnumMetadata
    {
        protected readonly Type _enumType;
        protected readonly Lazy<Enum[]> _enumValues;

        /// <summary>
        ///     Initializes a new instance.
        /// </summary>
        /// <param name="enumType">
        ///     The type of enumeration to provide metadata for.
        /// </param>
        public DotEnumMetadata(Type enumType)
        {
            _enumType = enumType;
            _enumValues = new Lazy<Enum[]>(() => Enum.GetValues(_enumType).Cast<Enum>().ToArray());
        }

        /// <summary>
        ///     Gets all values of the enumeration.
        /// </summary>
        public virtual Enum[] GetValues()
        {
            return _enumValues.Value;
        }

        /// <summary>
        ///     Gets all single-flag values of the enumeration.
        /// </summary>
        public virtual Enum[] GetSingleFlagValues()
        {
            return GetValues().Where(IsSingleFlagValue).ToArray();
        }

        /// <summary>
        ///     Checks the number of flags set in the specified enumeration value. Some enum member values may be helpers that are a result
        ///     of a binary or operation of multiple other values (flags) of that enumeration. The method indicates if this is not the case.
        /// </summary>
        /// <param name="value">
        ///     The enum value to check.
        /// </param>
        public virtual bool IsSingleFlagValue(Enum value)
        {
            return !GetValues()
               .Where(v => !Equals(v, value))
               .Any(value.HasFlag);
        }
    }
}