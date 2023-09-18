using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Types.Packing;

/// <summary>
///     Used as the size, in points, of a margin around each graph part being packed.
/// </summary>
/// <param name="Size">
///     The size, in points, of a margin around each graph part being packed.
/// </param>
public record DotPackingMargin(int Size) : DotPackingDefinition
{
    protected override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => Size.ToString(syntaxRules.Culture);
}