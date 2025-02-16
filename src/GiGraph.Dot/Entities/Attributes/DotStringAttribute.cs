using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Attributes;

/// <summary>
///     A string attribute. The value is rendered as is in the output DOT script, so the attribute can be used for any type of value,
///     not only for strings.
/// </summary>
public class DotStringAttribute : DotAttribute<string>
{
    /// <summary>
    ///     Creates a new instance of a string attribute.
    /// </summary>
    /// <param name="key">
    ///     The key of the attribute.
    /// </param>
    /// <param name="value">
    ///     The value of the attribute.
    /// </param>
    public DotStringAttribute(string key, string value)
        : base(key, value)
    {
    }

    protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules) =>
        syntaxRules.Attributes.StringValueEscaper.Escape(Value);
}