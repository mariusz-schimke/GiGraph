using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Output.Qualities;

/// <summary>
///     Represents a type that can be converted to an HTML string.
/// </summary>
public interface IDotHtmlEncodable
{
    /// <summary>
    ///     Converts the entity to an HTML string.
    /// </summary>
    /// <param name="options">
    ///     The syntax options to apply.
    /// </param>
    /// <param name="syntaxRules">
    ///     The syntax rules to apply.
    /// </param>
    string? ToHtml(DotSyntaxOptions options, DotSyntaxRules syntaxRules);
}