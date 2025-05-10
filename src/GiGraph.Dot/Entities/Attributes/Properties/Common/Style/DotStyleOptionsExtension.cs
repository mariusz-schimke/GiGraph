using System.Diagnostics.Contracts;
using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.EnumHelpers;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.Style;

internal static class DotStyleOptionsExtension
{
    public static void SetStyleOption<TStyles>(this IDotHasStyleOptions<TStyles> @this, TStyles option, bool? value)
        where TStyles : struct, Enum
    {
        switch (value)
        {
            case true:
                @this.SetStyleOption(option);
                break;
            case false:
                @this.ResetStyleOption(option);
                break;
            default:
                @this.RemoveStyleOption(option);
                break;
        }
    }

    /// <summary>
    ///     Includes the specified option in the style.
    /// </summary>
    private static void SetStyleOption<TStyles>(this IDotHasStyleOptions<TStyles> @this, TStyles option)
        where TStyles : struct, Enum
    {
        @this.Style = EnumHelper.SetFlag(@this.Style, option);
    }

    /// <summary>
    ///     Resets the specified style option in the style. If the style isn't set yet (is null), it will be set to the default value.
    /// </summary>
    private static void ResetStyleOption<TStyles>(this IDotHasStyleOptions<TStyles> @this, TStyles option)
        where TStyles : struct, Enum
    {
        @this.Style = EnumHelper.ResetFlag(@this.Style, option);
    }

    /// <summary>
    ///     Removes the specified style option from the style. If the style isn't set yet, it will remain unset (null). If the result of
    ///     the removal is the default style, the style will be nullified.
    /// </summary>
    private static void RemoveStyleOption<TStyles>(this IDotHasStyleOptions<TStyles> @this, TStyles option)
        where TStyles : struct, Enum
    {
        var result = EnumHelper.ResetFlag(@this.Style, option);
        @this.SetStyleOrNullIfDefault(result);
    }

    [Pure]
    public static bool? HasStyleOption<TStyles>(this IDotHasStyleOptions<TStyles> @this, TStyles option)
        where TStyles : struct, Enum => @this.Style?.HasFlag(option);

    public static void SetPartialStyleOption<TPartialStyle, TCompleteStyle>(this IDotHasStyleOptions<TCompleteStyle> @this, TPartialStyle? option)
        where TPartialStyle : struct, Enum
        where TCompleteStyle : struct, Enum
    {
        var currentStyle = @this.Style.GetValueOrDefault(default(TCompleteStyle));

        if (option.HasValue)
        {
            @this.Style = DotPartialEnumMapper.ReplacePartialFlags(option.Value, currentStyle);
        }
        else
        {
            var result = DotPartialEnumMapper.ClearPartialFlags<TPartialStyle, TCompleteStyle>(currentStyle);
            @this.SetStyleOrNullIfDefault(result);
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

    private static void SetStyleOrNullIfDefault<TStyles>(this IDotHasStyleOptions<TStyles> @this, TStyles style)
        where TStyles : struct, Enum
    {
        @this.Style = EnumHelper.IsDefault(style) ? null : style;
    }
}