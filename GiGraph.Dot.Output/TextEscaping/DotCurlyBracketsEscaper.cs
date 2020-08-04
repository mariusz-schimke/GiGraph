namespace GiGraph.Dot.Output.TextEscaping
{
    /// <summary>
    ///     Escapes curly brackets ({, }). Use for escaping text of record node fields.
    /// </summary>
    public class DotCurlyBracketsEscaper : IDotTextEscaper
    {
        string IDotTextEscaper.Escape(string value)
        {
            return Escape(value);
        }

        public static string Escape(string value)
        {
            return value
              ?.Replace("{", @"\{")
              ?.Replace("}", @"\}");
        }
    }
}