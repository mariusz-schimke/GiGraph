using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;
using GiGraph.Dot.Types.EscapeString;

namespace GiGraph.Dot.Entities.Attributes;

/// <summary>
///     A string attribute whose value is escaped on DOT script rendering when <see cref="DotUnescapedString" /> is used, or is
///     assumed to already be escaped when <see cref="DotEscapedString" /> is used.
/// </summary>
public record DotEscapeStringAttribute : DotAttribute<DotEscapeString>
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
    public DotEscapeStringAttribute(string key, DotEscapeString value)
        : base(key, value)
    {
    }

    protected internal override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
    {
        return ((IDotEscapable) Value)?.GetEscaped(syntaxRules.Attributes.EscapeStringValueEscaper);
    }
}