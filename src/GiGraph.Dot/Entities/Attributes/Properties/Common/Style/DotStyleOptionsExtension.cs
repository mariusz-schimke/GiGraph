using System.Diagnostics.Contracts;
using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.EnumHelpers;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.Style;

internal static class DotStyleOptionsExtension
{
    [Pure]
    public static bool HasStyleOption<TStyles>(this IDotHasStyleOptions<TStyles> @this, TStyles option)
        where TStyles : struct, Enum => @this.Style?.HasFlag(option) ?? false;

    [Pure]
    public static TPartialStyle GetPartialStyleOption<TPartialStyle, TCompleteStyle>(this IDotHasStyleOptions<TCompleteStyle> @this)
        where TPartialStyle : struct, Enum
        where TCompleteStyle : struct, Enum
    {
        var style = @this.Style.GetValueOrDefault();
        return DotPartialEnumMapper.ExtractPartialFlags<TPartialStyle, TCompleteStyle>(style);
    }
}