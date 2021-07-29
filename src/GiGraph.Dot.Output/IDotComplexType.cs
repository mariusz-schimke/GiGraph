using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Output
{
    /// <summary>
    ///     Represents a type that can be encoded as string into a format accepted by layout engines.
    /// </summary>
    public interface IDotComplexType
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