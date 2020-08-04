namespace GiGraph.Dot.Output.TextEscaping
{
    /// <summary>
    ///     Escapes line break sequence (CRLF), and individual CR and LF characters. Use for identifiers and attributes that support
    ///     escaped text.
    /// </summary>
    public class DotLineBreakEscaper : IDotTextEscaper
    {
        protected static readonly char CR = '\r';
        protected static readonly char LF = '\n';

        string IDotTextEscaper.Escape(string value)
        {
            return Escape(value);
        }

        public static string Escape(string value)
        {
            return value
              ?.Replace($"{CR}{LF}", @"\n")
              ?.Replace($"{CR}", @"\n")
              ?.Replace($"{LF}", @"\n");
        }
    }
}