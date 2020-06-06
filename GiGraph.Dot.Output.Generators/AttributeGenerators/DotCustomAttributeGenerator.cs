using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Generators.TextEscaping;

namespace GiGraph.Dot.Output.Generators.AttributeGenerators
{
    public class DotCustomAttributeGenerator : DotAttributeGenerator<DotCustomAttribute>
    {
        protected DotCustomAttributeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, TextEscapingPipeline identifierEscaper = null, TextEscapingPipeline valueEscaper = null)
            : base(syntaxRules, options, entityGenerators, identifierEscaper, valueEscaper ?? TextEscapingPipeline.None())
        {
        }

        public DotCustomAttributeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : this(syntaxRules, options, entityGenerators, identifierEscaper: null, valueEscaper: null)
        {
        }
    }
}
