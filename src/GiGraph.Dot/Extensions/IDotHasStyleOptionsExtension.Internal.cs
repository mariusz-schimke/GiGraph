using System.Diagnostics.Contracts;
using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.EnumHelpers;

namespace GiGraph.Dot.Extensions;

public static partial class IDotHasStyleOptionsExtension
{
    internal static void SetStyleOption<TStyles>(this IDotHasStyleOptions<TStyles> owner, TStyles option, bool? value)
        where TStyles : struct, Enum
    {
        switch (value)
        {
            case true:
                owner.SetStyleOption(option);
                break;
            case false:
                owner.ResetStyleOption(option);
                break;
            default:
                owner.RemoveStyleOption(option);
                break;
        }
    }

    /// <summary>
    ///     Includes the specified option in the style.
    /// </summary>
    internal static void SetStyleOption<TStyles>(this IDotHasStyleOptions<TStyles> owner, TStyles option)
        where TStyles : struct, Enum
    {
        owner.Style = EnumHelper.SetFlag(owner.Style, option);
    }

    /// <summary>
    ///     Resets the specified style option in the style. If the style isn't set yet (is null), it will be set to the default value.
    /// </summary>
    internal static void ResetStyleOption<TStyles>(this IDotHasStyleOptions<TStyles> owner, TStyles option)
        where TStyles : struct, Enum
    {
        owner.Style = EnumHelper.ResetFlag(owner.Style, option);
    }

    /// <summary>
    ///     Removes the specified style option from the style. If the style isn't set yet, it will remain unset (null). If the result of
    ///     the removal is the default style, the style will be nullified.
    /// </summary>
    internal static void RemoveStyleOption<TStyles>(this IDotHasStyleOptions<TStyles> owner, TStyles option)
        where TStyles : struct, Enum
    {
        var result = EnumHelper.ResetFlag(owner.Style, option);
        owner.SetStyleOrNullIfDefault(result);
    }

    [Pure]
    internal static bool? HasStyleOption<TStyles>(this IDotHasStyleOptions<TStyles> owner, TStyles option)
        where TStyles : struct, Enum => owner.Style?.HasFlag(option);

    internal static void SetPartialStyleOption<TPartialStyle, TCompleteStyle>(this IDotHasStyleOptions<TCompleteStyle> owner, TPartialStyle? option)
        where TPartialStyle : struct, Enum
        where TCompleteStyle : struct, Enum
    {
        var currentStyle = owner.Style.GetValueOrDefault(default(TCompleteStyle));

        if (option.HasValue)
        {
            owner.Style = DotPartialEnumMapper.ReplacePartialFlags(option.Value, currentStyle);
        }
        else
        {
            var result = DotPartialEnumMapper.ClearPartialFlags<TPartialStyle, TCompleteStyle>(currentStyle);
            owner.SetStyleOrNullIfDefault(result);
        }
    }

    [Pure]
    internal static TPartialStyle? GetPartialStyleOption<TPartialStyle, TCompleteStyle>(this IDotHasStyleOptions<TCompleteStyle> owner)
        where TPartialStyle : struct, Enum
        where TCompleteStyle : struct, Enum
        =>
            owner.Style.HasValue
                ? DotPartialEnumMapper.ExtractPartialFlags<TPartialStyle, TCompleteStyle>(owner.Style.Value)
                : null;

    internal static void SetStyleOrNullIfDefault<TStyles>(this IDotHasStyleOptions<TStyles> owner, TStyles style)
        where TStyles : struct, Enum
    {
        owner.Style = EnumHelper.IsDefault(style) ? null : style;
    }
}