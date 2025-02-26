namespace GiGraph.Dot.Output.Metadata;

/// <summary>
///     Assigns a DOT attribute value to an enumeration value.
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
public class DotAttributeValueAttribute : Attribute, IDotAttributeValueAttribute
{
    /// <summary>
    ///     Creates a new attribute instance.
    /// </summary>
    /// <param name="value">
    ///     The value of the DOT attribute.
    /// </param>
    public DotAttributeValueAttribute(string? value)
    {
        Value = value;
    }

    /// <inheritdoc cref="IDotAttributeValueAttribute.Value" />
    public string? Value { get; }
}