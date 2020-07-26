using GiGraph.Dot.Output.TextEscaping;

namespace GiGraph.Dot.Entities
{
    public interface IDotEscapable
    {
        /// <summary>
        ///     Gets the escaped text.
        /// </summary>
        /// <param name="textEscaper">
        ///     The text escaper to use.
        /// </param>
        string GetEscaped(IDotTextEscaper textEscaper);
    }
}