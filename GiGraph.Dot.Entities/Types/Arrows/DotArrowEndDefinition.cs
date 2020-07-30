using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Arrows
{
    /// <summary>
    ///     Represents an arrow end as either a single shape (<see cref="DotArrowShape" />) or as a composition of multiple shapes (
    ///     <see cref="DotCompositeArrowEnd" />).
    /// </summary>
    public abstract class DotArrowEndDefinition : IDotEncodable
    {
        string IDotEncodable.GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return GetDotEncoded(options, syntaxRules);
        }

        protected internal abstract string GetDotEncoded(DotGenerationOptions options, DotSyntaxRules syntaxRules);

        public static implicit operator DotArrowEndDefinition(DotArrowShape? shape)
        {
            return (DotArrowEnd) shape;
        }

        public static implicit operator DotArrowEndDefinition(DotArrowShape[] shapes)
        {
            return shapes is {} ? new DotCompositeArrowEnd(shapes) : null;
        }

        public static implicit operator DotArrowEndDefinition(DotArrowEnd[] arrows)
        {
            return arrows is {} ? new DotCompositeArrowEnd(arrows) : null;
        }
    }
}