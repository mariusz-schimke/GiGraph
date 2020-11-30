using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities
{
    public interface IDotEncodable
    {
        /// <summary>
        ///     Gets a DOT-encoded value.
        /// </summary>
        /// <param name="options">
        ///     The DOT generation options to use.
        /// </param>
        /// <param name="syntaxRules">
        ///     The DOT syntax rules to use.
        /// </param>
        string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules);
    }
}