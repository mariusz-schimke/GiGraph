using System.Diagnostics.Contracts;
using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.EnumHelpers;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.Style;

internal static class DotStyleOptionsExtension
{
    public static void SetStyleOption<TStyles>(this IDotHasStyleOptions<TStyles> @this, TStyles option, bool value)
        where TStyles : struct, Enum
    {
        @this.Style = DotEnumHelper.SetFlag(@this.Style.GetValueOrDefault(), option, value);
    }

    [Pure]
    public static bool HasStyleOption<TStyles>(this IDotHasStyleOptions<TStyles> @this, TStyles option)
        where TStyles : struct, Enum => @this.Style?.HasFlag(option) ?? false;

    public static void SetPartialStyleOption<TPartialStyle, TCompleteStyle>(this IDotHasStyleOptions<TCompleteStyle> @this, TPartialStyle option)
        where TPartialStyle : struct, Enum
        where TCompleteStyle : struct, Enum
    {
        var style = @this.Style.GetValueOrDefault();
        @this.Style = DotPartialEnumMapper.ReplacePartialFlags(option, style);
    }

    [Pure]
    public static TPartialStyle GetPartialStyleOption<TPartialStyle, TCompleteStyle>(this IDotHasStyleOptions<TCompleteStyle> @this)
        where TPartialStyle : struct, Enum
        where TCompleteStyle : struct, Enum
        =>
            @this.Style.HasValue
                ? DotPartialEnumMapper.ExtractPartialFlags<TPartialStyle, TCompleteStyle>(@this.Style.Value)
                : default(TPartialStyle);
}