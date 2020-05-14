using Gigraph.Dot.Core;
using Gigraph.Dot.Entities.Attributes.Collections;
using Gigraph.Dot.Generators.CommonEntityGenerators;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Generators.Providers;
using Gigraph.Dot.Writers.EdgeWriters;

namespace Gigraph.Dot.Generators.EdgeGenerators
{
    public class DotEdgeDefaultsGenerator : DotEntityDefaultsGenerator<IDotEdgeDefaultsWriter>
    {
        public DotEdgeDefaultsGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override void WriteKeyword(DotAttributeCollection defaults, IDotEdgeDefaultsWriter writer)
        {
            writer.WriteEdgeKeyword();
        }
    }
}
