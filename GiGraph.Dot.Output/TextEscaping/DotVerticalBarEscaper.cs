namespace GiGraph.Dot.Output.TextEscaping
{
    /// <summary>
    /// Escapes vertical bars (|). Use for escaping text of record node fields.
    /// </summary>
    public class DotVerticalBarEscaper : IDotTextEscaper
    {
        public virtual string Escape(string value)
        {
            return value?.Replace("|", @"\|");
        }
    }
}