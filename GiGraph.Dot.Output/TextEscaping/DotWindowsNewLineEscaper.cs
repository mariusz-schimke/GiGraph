namespace GiGraph.Dot.Output.TextEscaping
{
    /// <summary>
    ///     Escapes the carriage return + line feed character sequence (CRLF == \x000D\x000A == \r\n).
    /// </summary>
    public class DotWindowsNewLineEscaper : IDotTextEscaper
    {
        string IDotTextEscaper.Escape(string value)
        {
            return Escape(value);
        }

        public static string Escape(string value)
        {
            return value?.Replace(DotNewLine.Windows, "\\n");
        }
    }
}