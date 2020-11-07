using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.Options;

namespace GiGraph.Dot.Output.Generators.Attributes
{
    public class DotAttributeGenerator : DotAttributeGenerator<DotAttribute>
    {
        public DotAttributeGenerator(DotSyntaxRules syntaxRules, DotSyntaxOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }
    }
}