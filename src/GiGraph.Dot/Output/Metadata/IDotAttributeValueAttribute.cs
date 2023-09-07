namespace GiGraph.Dot.Output.Metadata;

/// <summary>
///     A common interface for enumeration member attributes that provide a DOT attribute value.
/// </summary>
public interface IDotAttributeValueAttribute
{
    /// <summary>
    ///     Gets the value of the DOT attribute.
    /// </summary>
    string Value { get; }
}