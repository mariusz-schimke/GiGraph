namespace GiGraph.Dot.Output.Text.Escaping;

/// <summary>
///     Escapes quotation marks.
/// </summary>
public class DotQuotationMarkEscaper : IDotTextEscaper
{
    string IDotTextEscaper.Escape(string value) => Escape(value);

    public static string Escape(string value) => value?.Replace("\"", "\\\"");
}