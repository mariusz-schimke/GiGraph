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
    /// <typeparam name="TPartial">
    ///     The partial enum type that defines which bits are valid.
    /// </typeparam>
    /// <typeparam name="TComplete">
    ///     The full enum type.
    /// </typeparam>
    /// <returns>
    ///     A value of the partial enum type, containing only the valid bits from the complete value.
    /// </returns>
    public static TPartial ExtractPartialFlags<TPartial, TComplete>(TComplete complete)
        where TPartial : struct, Enum
        where TComplete : struct, Enum
    {
        var partialMask = GetMask<TPartial>();
        var completeInt = Convert.ToInt32(complete);

        return (TPartial) Convert.ChangeType(
            partialMask & completeInt,
            Enum.GetUnderlyingType(typeof(TPartial))
        );
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
    /// <typeparam name="TPartial">
    ///     The partial enum type, defining which bits should be updated.
    /// </typeparam>
    /// <typeparam name="TComplete">
    ///     The full enum type.
    /// </typeparam>
    /// <returns>
    ///     A new complete enum value with bits from the partial value merged into it.
    /// </returns>
    public static TComplete ReplacePartialFlags<TPartial, TComplete>(TPartial partial, TComplete complete)
        where TPartial : struct, Enum
        where TComplete : struct, Enum
    {
        var partialInt = Convert.ToInt32(partial);
        return ReplacePartialFlags<TPartial, TComplete>(partialInt, complete);
    }

    /// <summary>
    ///     Clears (sets to 0) only the bits in the complete enum value that are defined by the partial enum type. All other bits remain
    ///     unchanged. It is assumed that <typeparamref name="TPartial"/> partially overlaps <typeparamref name="TComplete"/>.
    /// </summary>
    /// <param name="complete">
    ///     The full enum value to clear bits from.
    /// </param>
    /// <typeparam name="TPartial">
    ///     The partial enum type defining which bits should be cleared.
    /// </typeparam>
    /// <typeparam name="TComplete">
    ///     The full enum type.
    /// </typeparam>
    /// <returns>
    ///     A new complete enum value with the specified bits cleared.
    /// </returns>
    public static TComplete ClearPartialFlags<TPartial, TComplete>(TComplete complete)
        where TPartial : struct, Enum
        where TComplete : struct, Enum =>
        ReplacePartialFlags<TPartial, TComplete>(partial: 0, complete);

    private static TComplete ReplacePartialFlags<TPartial, TComplete>(int partial, TComplete complete)
        where TPartial : struct, Enum
        where TComplete : struct, Enum
    {
        var partialMask = GetMask<TPartial>();
        var completeInt = Convert.ToInt32(complete);

        return (TComplete) Convert.ChangeType(
            partial | (~partialMask & completeInt),
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