using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Types.Graphs.Layout.Packing;

/// <summary>
///     Used as the size, in points, of a margin around each graph part being packed.
/// </summary>
/// <param name="margin">
///     The size, in points, of a margin around each graph part being packed.
/// </param>
public class DotPackingMargin(int margin) : DotPackingDefinition
{
    /// <summary>
    ///     The size, in points, of a margin around each graph part being packed.
    /// </summary>
    public int Margin { get; } = margin;

    protected override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => Margin.ToString(syntaxRules.Culture);
}