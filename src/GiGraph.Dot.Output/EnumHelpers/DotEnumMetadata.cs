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
        ///     Gets all non-compound values of the enumeration.
        /// </summary>
        public virtual Enum[] GetNonCompoundValues()
        {
            return GetValues().Where(v => !IsCompoundValue(v)).ToArray();
        }

        /// <summary>
        ///     Gets all compound (multi-flag) values of the enumeration.
        /// </summary>
        public virtual Enum[] GetCompoundValues()
        {
            return GetValues().Where(IsCompoundValue).ToArray();
        }

        /// <summary>
        ///     Gets set flags of the enumeration.
        /// </summary>
        public virtual Enum[] GetSetFlags(Enum flags)
        {
            return GetValues()
               .Where(v => !IsCompoundValue(v))
               .Where(v => (int) (object) v != 0)
               .Where(flags.HasFlag)
               .ToArray();
        }

        /// <summary>
        ///     Checks the number of flags set in the specified enumeration value. Some enum member values may be helpers that are a result
        ///     of a binary or operation of multiple other values (flags) of that enumeration. The method indicates if this is the case.
        /// </summary>
        /// <param name="value">
        ///     The enum value to check.
        /// </param>
        public virtual bool IsCompoundValue(Enum value)
        {
            return GetValues()
               .Where(v => !Equals(v, value))
               .Where(v => (int) (object) v != 0)
               .Any(value.HasFlag);
        }
    }
}