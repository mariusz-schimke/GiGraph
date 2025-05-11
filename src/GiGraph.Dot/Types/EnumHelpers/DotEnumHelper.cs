using System.Diagnostics.Contracts;

namespace GiGraph.Dot.Types.EnumHelpers;

internal class DotEnumHelper
{
    /// <summary>
    ///     Sets the specified enum flag. If the input is null, <paramref name="flag"/> will be returned.
    /// </summary>
    [Pure]
    public static TEnum SetFlag<TEnum>(TEnum input, TEnum flag)
        where TEnum : struct, Enum
    {
        var result = Convert.ToInt32(input) | Convert.ToInt32(flag);
        return ConvertTo<TEnum>(result);
    }

    /// <summary>
    ///     Sets the specified enum flag. If the input is null, <paramref name="flag"/> will be returned when <paramref name="value"/> is
    ///     true, and a default of <typeparamref name="TEnum"/> will be returned when it's false.
    /// </summary>
    [Pure]
    public static TEnum SetFlag<TEnum>(TEnum input, TEnum flag, bool value)
        where TEnum : struct, Enum =>
        value ? SetFlag(input, flag) : ResetFlag(input, flag);

    /// <summary>
    ///     Resets the specified flag in the enum. If the enum is null, it will be set to the default value.
    /// </summary>
    [Pure]
    public static TEnum ResetFlag<TEnum>(TEnum input, TEnum flag)
        where TEnum : struct, Enum
    {
        var result = Convert.ToInt32(input) & ~Convert.ToInt32(flag);
        return ConvertTo<TEnum>(result);
    }

    /// <summary>
    ///     Determines if the <paramref name="input"/> has a default value (0).
    /// </summary>
    [Pure]
    public static bool IsDefault<TEnum>(TEnum input)
        where TEnum : struct, Enum =>
        Convert.ToInt32(input) == Convert.ToInt32(default(TEnum));

    /// <summary>
    ///     If the <paramref name="input"/> has a default value (0), returns null. Otherwise, <paramref name="input"/> is returned.
    /// </summary>
    [Pure]
    public static TEnum? NullIfDefault<TEnum>(TEnum input)
        where TEnum : struct, Enum =>
        IsDefault(input) ? null : input;

    /// <summary>
    ///     Converts the specified <paramref name="source"/> object to the <typeparamref name="TResult"/> enumeration.
    /// </summary>
    [Pure]
    public static TResult ConvertTo<TResult>(object source)
        where TResult : struct, Enum =>
        (TResult) Convert.ChangeType(
            source,
            Enum.GetUnderlyingType(typeof(TResult))
        );
}