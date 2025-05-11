using GiGraph.Dot.Types.EnumHelpers;

namespace GiGraph.Dot.Entities.Attributes.Properties.Common.Style;

internal static class DotStyleOptionsHelper
{
    /// <summary>
    ///     Returns <paramref name="option"/> when <paramref name="state"/> is true, default when <paramref name="state"/> is false, and
    ///     null when <paramref name="state"/> is null.
    /// </summary>
    public static TStyleOption? BoolToOption<TStyleOption>(TStyleOption option, bool? state)
        where TStyleOption : struct, Enum =>
        state.HasValue
            ? DotEnumHelper.FlagOrDefault(option, state.Value)
            : null;

    /// <summary>
    ///     Extracts non-null values from the specified collection and returns them as an array.
    /// </summary>
    public static Enum[] CompactOptions(params IEnumerable<Enum?> options) => options.OfType<Enum>().ToArray();
}