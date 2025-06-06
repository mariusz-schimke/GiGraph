using System.Diagnostics.Contracts;

namespace GiGraph.Dot.Types.EnumHelpers;

public static class DotPartialEnumMapper
{
    /// <summary>
    ///     Returns a partial enum value by taking only the bits allowed by the partial enum type from a complete enum value. All other
    ///     bits are cleared. It is assumed that <typeparamref name="TPartial"/> partially overlaps <typeparamref name="TComplete"/>.
    /// </summary>
    /// <param name="complete">
    ///     The full enum value that may have more bits than the partial enum supports.
    /// </param>
    /// <typeparam name="TComplete">
    ///     The full enum type.
    /// </typeparam>
    /// <typeparam name="TPartial">
    ///     The partial enum type that defines which bits are valid.
    /// </typeparam>
    /// <returns>
    ///     A value of the partial enum type, containing only the valid bits from the complete value.
    /// </returns>
    [Pure]
    public static TPartial ExtractPartialFlags<TComplete, TPartial>(TComplete complete)
        where TPartial : struct, Enum
        where TComplete : struct, Enum
    {
        var partialBitMask = GetBitMaskOf<TPartial>();
        var completeInt = Convert.ToInt32(complete);
        return DotEnumHelper.ConvertTo<TPartial>(partialBitMask & completeInt);
    }

    /// <summary>
    ///     Updates a complete enum value with bits from a partial enum value. Bits defined by the partial enum type are replaced; all
    ///     other bits in the complete value stay unchanged. It is assumed that <typeparamref name="TPartial"/> partially overlaps
    ///     <typeparamref name="TComplete"/>.
    /// </summary>
    /// <param name="partial">
    ///     The partial enum value to apply.
    /// </param>
    /// <param name="complete">
    ///     The full enum value to update.
    /// </param>
    /// <typeparam name="TComplete">
    ///     The full enum type.
    /// </typeparam>
    /// <typeparam name="TPartial">
    ///     The partial enum type, defining which bits should be updated.
    /// </typeparam>
    /// <returns>
    ///     A new complete enum value with bits from the partial value merged into it.
    /// </returns>
    [Pure]
    public static TComplete ReplacePartialFlags<TComplete, TPartial>(TComplete complete, TPartial partial)
        where TComplete : struct, Enum
        where TPartial : struct, Enum
    {
        var partialInt = Convert.ToInt32(partial);
        return ReplacePartialFlags<TComplete, TPartial>(complete, partialInt);
    }

    /// <summary>
    ///     Clears (sets to 0) only the bits in the complete enum value that are defined by the partial enum type. All other bits remain
    ///     unchanged. It is assumed that <typeparamref name="TPartial"/> partially overlaps <typeparamref name="TComplete"/>.
    /// </summary>
    /// <param name="complete">
    ///     The full enum value to clear bits from.
    /// </param>
    /// <typeparam name="TComplete">
    ///     The full enum type.
    /// </typeparam>
    /// <typeparam name="TPartial">
    ///     The partial enum type defining which bits should be cleared.
    /// </typeparam>
    /// <returns>
    ///     A new complete enum value with the specified bits cleared.
    /// </returns>
    [Pure]
    public static TComplete ClearPartialFlags<TComplete, TPartial>(TComplete complete)
        where TComplete : struct, Enum
        where TPartial : struct, Enum
        =>
            ReplacePartialFlags<TComplete, TPartial>(complete, partial: 0);

    /// <summary>
    ///     Merges the specified partial enums into one, complete enum. It is assumed that all specified partial enums partially overlap
    ///     <typeparamref name="TComplete"/>.
    /// </summary>
    /// <param name="partialEnums">
    ///     The partial enums to merge.
    /// </param>
    /// <typeparam name="TComplete">
    ///     The output value to convert the merged enums to.
    /// </typeparam>
    [Pure]
    public static TComplete MergePartialFlags<TComplete>(params IEnumerable<Enum> partialEnums)
        where TComplete : struct, Enum
    {
        var complete = partialEnums.Select(Convert.ToInt32)
            .Aggregate(0, (accumulate, source) => accumulate | source);

        return DotEnumHelper.ConvertTo<TComplete>(complete);
    }

    private static TComplete ReplacePartialFlags<TComplete, TPartial>(TComplete complete, int partial)
        where TComplete : struct, Enum
        where TPartial : struct, Enum
    {
        var partialMask = GetBitMaskOf<TPartial>();
        var completeInt = Convert.ToInt32(complete);

        return DotEnumHelper.ConvertTo<TComplete>(partial | (~partialMask & completeInt));
    }

    private static int GetBitMaskOf<TEnum>()
        where TEnum : struct, Enum =>
        Enum.GetValues(typeof(TEnum))
            .Cast<int>()
            .Aggregate(0, (accumulate, source) => accumulate | source);
}