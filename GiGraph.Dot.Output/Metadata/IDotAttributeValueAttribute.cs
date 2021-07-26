namespace GiGraph.Dot.Output.Metadata
{
    /// <summary>
    ///     A common interface for attributes that provide a value.
    /// </summary>
    public interface IDotAttributeValueAttribute
    {
        /// <summary>
        ///     Gets the value of the DOT attribute.
        /// </summary>
        string Value { get; }
    }
}