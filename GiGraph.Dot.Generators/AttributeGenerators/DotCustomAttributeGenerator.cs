using GiGraph.Dot.Core;
using GiGraph.Dot.Entities.Attributes;
using GiGraph.Dot.Generators.Options;
using GiGraph.Dot.Generators.Providers;

namespace GiGraph.Dot.Generators.AttributeGenerators
{
    public class DotCustomAttributeGenerator : DotAttributeGenerator<DotCustomAttribute>
    {
        public DotCustomAttributeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override string EscapeValue(string value)
        {
            // don't escape the value (it is assumed that the custom attribute provides a value that should be used as is)
            return value;
        }
    }
}
