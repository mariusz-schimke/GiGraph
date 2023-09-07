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
    string Escape(string value);
}