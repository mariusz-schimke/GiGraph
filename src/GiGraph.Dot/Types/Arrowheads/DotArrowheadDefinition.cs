using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Qualities;

namespace GiGraph.Dot.Types.Arrowheads;

/// <summary>
///     Represents an arrowhead as either a single shape (<see cref="DotArrowhead" />) or as a composition of multiple shapes (
///     <see cref="DotCompositeArrowhead" />).
/// </summary>
public abstract record DotArrowheadDefinition : IDotEncodable
{
    string IDotEncodable.GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules) => GetDotEncoded(options, syntaxRules);

    protected internal abstract string GetDotEncoded(DotSyntaxOptions options, DotSyntaxRules syntaxRules);

    public static implicit operator DotArrowheadDefinition(DotArrowheadShape? shape) => (DotArrowhead) shape;

    public static implicit operator DotArrowheadDefinition(DotArrowheadShape[] shapes) => shapes is not null ? new DotCompositeArrowhead(shapes) : null;

    public static implicit operator DotArrowheadDefinition(DotArrowhead[] arrows) => arrows is not null ? new DotCompositeArrowhead(arrows) : null;
}