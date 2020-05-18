using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Generators.Options;
using GiGraph.Dot.Generators.Providers;
using GiGraph.Dot.Generators.TextEscaping;

namespace GiGraph.Dot.Generators.AttributeGenerators
{
    public class DotCommonAttributeGenerator : DotAttributeGenerator<DotAttribute>
    {
        protected DotCommonAttributeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, TextEscapingPipeline identifierEscaper = null, TextEscapingPipeline valueEscaper = null)
            : base(syntaxRules, options, entityGenerators, identifierEscaper, valueEscaper)
        {
        }

        public DotCommonAttributeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }
    }
}
