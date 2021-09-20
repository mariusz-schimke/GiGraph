using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Types.Packing
{
    /// <summary>
    ///     Determines whether graph packing is enabled or disabled.
    /// </summary>
    /// <param name="Enabled">
    ///     If true, each connected component of the graph is laid out separately, and then the graphs are packed together. If false, the
    ///     entire graph is laid out together.
    /// </param>
    public record DotPackingToggle(bool Enabled) : DotPackingDefinition
    {
        protected override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return Enabled ? "true" : "false";
        }
    }
}