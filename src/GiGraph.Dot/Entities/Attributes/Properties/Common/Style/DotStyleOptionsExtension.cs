using System.Diagnostics.Contracts;
using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.EnumHelpers;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.Style;

internal static class DotStyleOptionsExtension
{
    public static void SetStyleOption<TStyles>(this IDotHasStyleOptions<TStyles> @this, TStyles option, bool? value)
        where TStyles : struct, Enum
    {
        var style = DotEnumHelper.SetFlag(@this.Style.GetValueOrDefault(), option, value.GetValueOrDefault(false));

        // if the value is null, the intention is to remove the style when the result is a default value
        @this.Style = value.HasValue ? style : DotEnumHelper.NullIfDefault(style);
    }

    [Pure]
    public static bool? HasStyleOption<TStyles>(this IDotHasStyleOptions<TStyles> @this, TStyles option)
        where TStyles : struct, Enum => @this.Style?.HasFlag(option);

    public static void SetPartialStyleOption<TPartialStyle, TCompleteStyle>(this IDotHasStyleOptions<TCompleteStyle> @this, TPartialStyle? option)
        where TPartialStyle : struct, Enum
        where TCompleteStyle : struct, Enum
    {
        var style = @this.Style.GetValueOrDefault();

        if (option.HasValue)
        {
            @this.Style = DotPartialEnumMapper.ReplacePartialFlags(option.Value, style);
        }
        else
        {
            style = DotPartialEnumMapper.ClearPartialFlags<TPartialStyle, TCompleteStyle>(style);
            @this.Style = DotEnumHelper.NullIfDefault(style);
        }
    }

    [Pure]
    public static TPartialStyle? GetPartialStyleOption<TPartialStyle, TCompleteStyle>(this IDotHasStyleOptions<TCompleteStyle> @this)
        where TPartialStyle : struct, Enum
        where TCompleteStyle : struct, Enum
        =>
            @this.Style.HasValue
                ? DotPartialEnumMapper.ExtractPartialFlags<TPartialStyle, TCompleteStyle>(@this.Style.Value)
                : null;
}