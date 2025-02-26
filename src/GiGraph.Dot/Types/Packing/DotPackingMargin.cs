using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Types.Packing;

/// <summary>
///     Used as the size, in points, of a margin around each graph part being packed.
/// </summary>
/// <param name="size">
///     The size, in points, of a margin around each graph part being packed.
/// </param>
public class DotPackingMargin(int size) : DotPackingDefinition
{
    /// <summary>
    ///     The size, in points, of a margin around each graph part being packed.
    /// </summary>
    public int Size { get; } = size;

    protected override string GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => Size.ToString(syntaxRules.Culture);
}