using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Entities.Types.Arrows
{
    public abstract class DotArrowDefinition : IDotEncodable
    {
        string IDotEncodable.GetDotEncodedValue(DotGenerationOptions options, DotSyntaxRules syntaxRules)
        {
            return GetDotEncoded(options, syntaxRules);
        }

        protected internal abstract string GetDotEncoded(DotGenerationOptions options, DotSyntaxRules syntaxRules);

        public static implicit operator DotArrowDefinition(DotArrowShape? shape)
        {
            return (DotArrow) shape;
        }

        public static implicit operator DotArrowDefinition(DotArrowShape[] shapes)
        {
            return shapes is {} ? new DotMultiArrow(shapes) : null;
        }

        public static implicit operator DotArrowDefinition(DotArrow[] arrows)
        {
            return arrows is {} ? new DotMultiArrow(arrows) : null;
        }
    }
}