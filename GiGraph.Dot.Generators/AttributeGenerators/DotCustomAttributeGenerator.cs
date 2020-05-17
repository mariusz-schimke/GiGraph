using GiGraph.Dot.Core;
using GiGraph.Dot.Core.TextEscaping;
using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Generators.Options;
using GiGraph.Dot.Generators.Providers;

namespace GiGraph.Dot.Generators.AttributeGenerators
{
    public class DotCustomAttributeGenerator : DotAttributeGenerator<DotCustomAttribute>
    {
        protected DotCustomAttributeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, TextEscapingPipeline identifierEscaper = null, TextEscapingPipeline valueEscaper = null)
            : base(syntaxRules, options, entityGenerators, identifierEscaper, valueEscaper ?? TextEscapingPipeline.CreateNone())
        {
        }

        public DotCustomAttributeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : this(syntaxRules, options, entityGenerators, identifierEscaper: null, valueEscaper: null)
        {
        }
    }
}
