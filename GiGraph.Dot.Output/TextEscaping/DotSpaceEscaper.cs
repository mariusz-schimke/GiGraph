namespace GiGraph.Dot.Output.TextEscaping
{
    /// <summary>
    /// Escapes spaces ( ). Use for escaping text of record node fields.
    /// </summary>
    public class DotSpaceEscaper : IDotTextEscaper
    {
        public virtual string Escape(string value)
        {
            return value?.Replace(" ", @"\ ");
        }
    }
}