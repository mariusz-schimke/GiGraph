using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Arrows
{
    /// <summary>
    ///     Represents an arrowhead as either a single shape (<see cref="DotArrowhead" />) or as a composition of multiple shapes (
    ///     <see cref="DotCompositeArrowhead" />).
    /// </summary>
    public abstract class DotArrowheadDefinition : IDotEncodable
    {
        string IDotEncodable.GetDotEncodedValue(DotSyntaxOptions options, DotSyntaxRules syntaxRules)
        {
            return GetDotEncoded(options, syntaxRules);
        }

        protected internal abstract string GetDotEncoded(DotSyntaxOptions options, DotSyntaxRules syntaxRules);

        public static implicit operator DotArrowheadDefinition(DotArrowheadShape? shape)
        {
            return (DotArrowhead) shape;
        }

        public static implicit operator DotArrowheadDefinition(DotArrowheadShape[] shapes)
        {
            return shapes is { } ? new DotCompositeArrowhead(shapes) : null;
        }

        public static implicit operator DotArrowheadDefinition(DotArrowhead[] arrows)
        {
            return arrows is { } ? new DotCompositeArrowhead(arrows) : null;
        }
    }
}