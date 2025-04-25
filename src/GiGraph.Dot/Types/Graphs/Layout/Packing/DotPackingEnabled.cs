using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Types.Graphs.Layout.Packing;

/// <summary>
///     Determines whether graph packing is enabled or disabled.
/// </summary>
/// <param name="enabled">
///     If true, each connected component of the graph is laid out separately, and then the graphs are packed together. If false, the
///     entire graph is laid out together.
/// </param>
public class DotPackingEnabled(bool enabled) : DotPackingDefinition
{
    /// <summary>
    ///     If true, each connected component of the graph is laid out separately, and then the graphs are packed together. If false, the
    ///     entire graph is laid out together.
    /// </summary>
    public bool Enabled { get; } = enabled;

    protected override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => Enabled ? "true" : "false";
}