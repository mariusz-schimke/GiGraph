using System.Diagnostics.Contracts;
using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.EnumHelpers;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.Style;

internal static class DotStyleOptionsExtension
{
    /// <summary>
    ///     <para>
    ///         This method is used rather than setting style options one by one, because otherwise the resulting value is out of
    ///         control. If we set two style options where the first one has its default value and the second one is null, the result
    ///         would be null. This is because the last option nullifies the style since at that point the resulting style has the
    ///         default value from the previously processed option. But if the first option is null and the second one is default, the
    ///         result would be default, because the last option would override the null.
    ///     </para>
    ///     <para>
    ///         The intention here is to make the result consistent. If the collection is empty, the style will be null. If it contains
    ///         only default values, the style will be set to its default value. When it contains any non-default style options, the
    ///         resulting style will be merged from the options.
    ///     </para>
    /// </summary>
    public static void SetStyleOptions<TStyles>(this IDotHasStyleOptions<TStyles> @this, Enum[] options)
        where TStyles : struct, Enum
    {
        @this.Style = options.Any()
            ? DotPartialEnumMapper.MergePartialFlags<TStyles>(options)
            : null;
    }

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