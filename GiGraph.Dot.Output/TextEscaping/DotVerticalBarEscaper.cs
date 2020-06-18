namespace GiGraph.Dot.Output.TextEscaping
{
    /// <summary>
    /// Escapes vertical bars (|). Use for escaping text of record node fields.
    /// </summary>
    public class DotVerticalBarEscaper : IDotTextEscaper
    {
        public static string Escape(string value)
        {
            return value?.Replace("|", @"\|");
        }

        string IDotTextEscaper.Escape(string value) => Escape(value);
    }
}