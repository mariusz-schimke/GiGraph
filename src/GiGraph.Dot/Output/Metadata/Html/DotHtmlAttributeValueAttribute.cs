namespace GiGraph.Dot.Output.Metadata.Html;

/// <summary>
///     Assigns an HTML attribute value to an enumeration value.
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
public class DotHtmlAttributeValueAttribute : Attribute, IDotAttributeValueAttribute
{
    /// <summary>
    ///     Creates a new attribute instance.
    /// </summary>
    /// <param name="value">
    ///     The value of the HTML attribute.
    /// </param>
    public DotHtmlAttributeValueAttribute(string value)
    {
        Value = value;
    }

    /// <inheritdoc cref="IDotAttributeValueAttribute.Value" />
    public string Value { get; }
}