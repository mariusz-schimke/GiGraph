namespace GiGraph.Dot.Output.Text.Escaping
{
    /// <summary>
    ///     Escapes line feed characters (LF == \x000A == \n).
    /// </summary>
    public class DotUnixNewLineEscaper : IDotTextEscaper
    {
        string IDotTextEscaper.Escape(string value)
        {
            return Escape(value);
        }

        public static string Escape(string value)
        {
            return value?.Replace(DotNewLine.Unix, "\\n");
        }
    }
}