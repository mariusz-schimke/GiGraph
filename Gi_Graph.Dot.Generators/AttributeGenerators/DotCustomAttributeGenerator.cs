using GiGraph.Dot.Core;
using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Generators.Options;
using GiGraph.Dot.Generators.Providers;

namespace GiGraph.Dot.Generators.AttributeGenerators
{
    public class DotCustomAttributeGenerator : DotAttributeGenerator<DotAttribute>
    {
        public DotCustomAttributeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }
    }
}
