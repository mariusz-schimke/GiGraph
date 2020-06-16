namespace GiGraph.Dot.Output.TextEscaping
{
    /// <summary>
    /// Escapes curly brackets ({, }). Use for escaping text of record node fields.
    /// </summary>
    public class DotCurlyBracketsEscaper : IDotTextEscaper
    {
        public virtual string Escape(string value)
        {
            return value
                 ?.Replace("{", @"\{")
                 ?.Replace("}", @"\}");
        }
    }
}