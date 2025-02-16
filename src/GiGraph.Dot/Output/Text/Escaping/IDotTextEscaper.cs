using System.Diagnostics.CodeAnalysis;

namespace GiGraph.Dot.Output.Text.Escaping;

/// <summary>
///     Escapes text.
/// </summary>
public interface IDotTextEscaper
{
    /// <summary>
    ///     Escapes the specified text.
    /// </summary>
    /// <param name="value">
    ///     The text to escape.
    /// </param>
    [return: NotNullIfNotNull(nameof(value))]
    string? Escape(string? value);
}