namespace GiGraph.Dot.Output.Metadata
{
    /// <summary>
    ///     A common interface for flag enumerations that provide DOT attribute values.
    /// </summary>
    public interface IDotFlagsAttribute
    {
        /// <summary>
        ///     Gets the separator to use in order to join the flags of the enumeration.
        /// </summary>
        string Separator { get; }
    }
}