using System.Diagnostics.Contracts;
using GiGraph.Dot.Entities.Qualities;
using GiGraph.Dot.Types.EnumHelpers;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.Style;

internal static class DotStyleOptionsExtension
{
    [Pure]
    public static bool HasStyleOption<TStyles>(this IDotHasStyleOptions<TStyles> entity, TStyles option)
        where TStyles : struct, Enum => entity.Style?.HasFlag(option) ?? false;

    [Pure]
    public static TPartialStyle GetPartialStyleOption<TPartialStyle, TCompleteStyle>(this IDotHasStyleOptions<TCompleteStyle> entity)
        where TPartialStyle : struct, Enum
        where TCompleteStyle : struct, Enum
    {
        var style = entity.Style.GetValueOrDefault();
        return DotPartialEnumMapper.ExtractPartialFlags<TCompleteStyle, TPartialStyle>(style);
    }
}