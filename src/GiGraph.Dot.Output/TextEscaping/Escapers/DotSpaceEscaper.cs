namespace GiGraph.Dot.Output.TextEscaping.Escapers
{
    /// <summary>
    ///     Escapes spaces.
    /// </summary>
    public class DotSpaceEscaper : IDotTextEscaper
    {
        string IDotTextEscaper.Escape(string value)
        {
            return Escape(value);
        }

        public static string Escape(string value)
        {
            return value?.Replace(" ", "\\ ");
        }
    }
}