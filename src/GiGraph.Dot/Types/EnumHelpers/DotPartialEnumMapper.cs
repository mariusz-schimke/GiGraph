using System;
using System.Linq;

namespace GiGraph.Dot.Types.EnumHelpers;

public static class DotPartialEnumMapper
{
    /// <summary>
    ///     Gets a bitmask composed of only those bits from the complete bitmask that the partial bitmask enum is able to set.
    /// </summary>
    /// <param name="complete">
    ///     The complete type to strip off with bits outside the range of the partial type.
    /// </param>
    /// <typeparam name="TComplete">
    ///     The complete bitmask enum type.
    /// </typeparam>
    /// <typeparam name="TPartial">
    ///     The partial bitmask enum type.
    /// </typeparam>
    public static TPartial ToPartial<TComplete, TPartial>(TComplete complete)
        where TComplete : struct, Enum
        where TPartial : struct, Enum
    {
        var partialMask = GetMask<TPartial>();
        var completeInt = Convert.ToInt32(complete);

        return (TPartial) Convert.ChangeType(
            partialMask & completeInt,
            Enum.GetUnderlyingType(typeof(TPartial))
        );
    }

    /// <summary>
    ///     Merges the partial bitmask enum into the complete bitmask by overwriting the bits of the complete type, that exist as values
    ///     of the partial bitmask enum. Returns the merged complete value.
    /// </summary>
    /// <param name="partial">
    ///     The partial type to merge into the complete one.
    /// </param>
    /// <param name="complete">
    ///     The complete value whose selection of bits to overwrite with those set in the partial type enum.
    /// </param>
    /// <typeparam name="TPartial">
    ///     The partial bitmask enum type.
    /// </typeparam>
    /// <typeparam name="TComplete">
    ///     The complete bitmask enum type.
    /// </typeparam>
    public static TComplete ToComplete<TPartial, TComplete>(TPartial partial, TComplete complete)
        where TPartial : struct, Enum
        where TComplete : struct, Enum
    {
        var partialMask = GetMask<TPartial>();
        var partialInt = Convert.ToInt32(partial);
        var completeInt = Convert.ToInt32(complete);

        return (TComplete) Convert.ChangeType(
            partialInt | (~partialMask & completeInt),
            Enum.GetUnderlyingType(typeof(TComplete))
        );
    }

    private static int GetMask<TEnum>()
        where TEnum : struct, Enum
    {
        return Enum.GetValues(typeof(TEnum))
            .Cast<int>()
            .Aggregate(0, (current, value) => current | value);
    }
}