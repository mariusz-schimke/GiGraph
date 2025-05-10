namespace GiGraph.Dot.Types.EnumHelpers;

internal class EnumHelper
{
    public static TResult ConvertTo<TResult>(object source)
        where TResult : struct, Enum =>
        (TResult) Convert.ChangeType(
            source,
            Enum.GetUnderlyingType(typeof(TResult))
        );

    public static TEnum SetFlag<TEnum>(TEnum? input, TEnum flag)
        where TEnum : struct, Enum
    {
        var result = Convert.ToInt32(input.GetValueOrDefault(flag)) | Convert.ToInt32(flag);
        return ConvertTo<TEnum>(result);
    }

    public static TEnum ResetFlag<TEnum>(TEnum? input, TEnum flag)
        where TEnum : struct, Enum
    {
        var result = Convert.ToInt32(input.GetValueOrDefault(flag)) & ~Convert.ToInt32(flag);
        return ConvertTo<TEnum>(result);
    }

    public static bool IsDefault<TEnum>(TEnum input)
        where TEnum : struct, Enum =>
        Convert.ToInt32(input) == Convert.ToInt32(default(TEnum));
}