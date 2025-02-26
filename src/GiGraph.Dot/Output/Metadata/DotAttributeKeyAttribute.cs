namespace GiGraph.Dot.Output.Metadata;

/// <summary>
///     Assigns a DOT attribute key to a property.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Method)]
public class DotAttributeKeyAttribute : Attribute
{
    /// <summary>
    ///     Creates a new attribute instance.
    /// </summary>
    /// <param name="key">
    ///     The key of the DOT attribute.
    /// </param>
    public DotAttributeKeyAttribute(string key)
    {
        Key = key;
    }

    /// <summary>
    ///     Gets the key of the DOT attribute.
    /// </summary>
    public string Key { get; }
}