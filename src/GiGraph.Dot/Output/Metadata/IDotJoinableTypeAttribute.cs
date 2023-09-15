namespace GiGraph.Dot.Output.Metadata;

/// <summary>
///     A common interface for flag enumerations and array types that can be joined with a separator.
/// </summary>
public interface IDotJoinableTypeAttribute
{
    /// <summary>
    ///     Gets the separator to use in order to join the enumeration flags or array items.
    /// </summary>
    string Separator { get; }

    /// <summary>
    ///     Determines whether the values should be ordered before joining.
    /// </summary>
    bool Sort { get; }
}