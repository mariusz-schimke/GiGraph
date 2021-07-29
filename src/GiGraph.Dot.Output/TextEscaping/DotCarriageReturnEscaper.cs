namespace GiGraph.Dot.Output.TextEscaping
{
    /// <summary>
    ///     Escapes carriage return characters (CR == \x000D == \r).
    /// </summary>
    public class DotCarriageReturnEscaper : IDotTextEscaper
    {
        string IDotTextEscaper.Escape(string value)
        {
            return Escape(value);
        }

        public static string Escape(string value)
        {
            return value?.Replace("\r", "\\n");
        }
    }
}