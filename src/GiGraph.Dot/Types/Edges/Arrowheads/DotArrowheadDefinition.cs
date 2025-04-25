using System.Diagnostics.CodeAnalysis;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Types.Edges.Arrowheads;

/// <summary>
///     Represents an arrowhead as either a single shape (<see cref="DotArrowhead" />) or as a composition of multiple shapes (
///     <see cref="DotCompositeArrowhead" />).
/// </summary>
public abstract class DotArrowheadDefinition : IDotEncodable
{
    string IDotEncodable.GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => GetDotEncoded(options, syntaxRules);

    protected internal abstract string GetDotEncoded(DotSyntaxOptions options, DotSyntaxRules syntaxRules);

    [return: NotNullIfNotNull(nameof(shape))]
    public static implicit operator DotArrowheadDefinition?(DotArrowheadShape? shape) => (DotArrowhead?) shape;

    [return: NotNullIfNotNull(nameof(shapes))]
    public static implicit operator DotArrowheadDefinition?(DotArrowheadShape[]? shapes) => shapes is not null ? new DotCompositeArrowhead(shapes) : null;

    [return: NotNullIfNotNull(nameof(arrows))]
    public static implicit operator DotArrowheadDefinition?(DotArrowhead[]? arrows) => arrows is not null ? new DotCompositeArrowhead(arrows) : null;
}