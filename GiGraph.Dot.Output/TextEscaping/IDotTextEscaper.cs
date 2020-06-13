namespace GiGraph.Dot.Output.TextEscaping
{
    /// <summary>
    /// Escapes text.
    /// </summary>
    public interface IDotTextEscaper
    {
        /// <summary>
        /// Escapes the specified text.
        /// </summary>
        /// <param name="value">The text to escape.</param>
        string Escape(string value);
    }
}
