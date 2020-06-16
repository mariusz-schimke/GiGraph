namespace GiGraph.Dot.Output.TextEscaping
{
    /// <summary>
    /// Escapes angle brackets (&lt;, &gt;). Use for escaping text of record node fields.
    /// </summary>
    public class DotAngleBracketsEscaper : IDotTextEscaper
    {
        public virtual string Escape(string value)
        {
            return value
                 ?.Replace("<", @"\<")
                 ?.Replace(">", @"\>");
        }
    }
}