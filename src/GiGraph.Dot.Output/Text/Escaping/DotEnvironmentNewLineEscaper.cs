namespace GiGraph.Dot.Output.Text.Escaping
{
    /// <summary>
    ///     Escapes the environment new line character or sequence (system-dependent).
    /// </summary>
    public class DotEnvironmentNewLineEscaper : IDotTextEscaper
    {
        string IDotTextEscaper.Escape(string value)
        {
            return Escape(value);
        }

        public static string Escape(string value)
        {
            return value?.Replace(DotNewLine.SystemDefault, "\\n");
        }
    }
}