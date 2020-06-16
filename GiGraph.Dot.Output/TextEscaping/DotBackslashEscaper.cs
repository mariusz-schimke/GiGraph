namespace GiGraph.Dot.Output.TextEscaping
{
    /// <summary>
    /// Escapes backslash. Use for identifiers and attributes that support escaped text.
    /// </summary>
    public class DotBackslashEscaper : IDotTextEscaper
    {
        public virtual string Escape(string value)
        {
            return value?.Replace(@"\", @"\\");
        }
    }
}
