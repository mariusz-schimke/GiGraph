using GiGraph.Dot.Output.Text.Escaping;

namespace GiGraph.Dot.Output
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