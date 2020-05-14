using Gigraph.Dot.Core;
using Gigraph.Dot.Entities.Attributes.Collections;
using Gigraph.Dot.Generators.CommonEntityGenerators;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Generators.Providers;
using Gigraph.Dot.Writers.NodeWriters;

namespace Gigraph.Dot.Generators.NodeGenerators
{
    public class DotNodeDefaultsGenerator : DotEntityDefaultsGenerator<IDotNodeDefaultsWriter>
    {
        public DotNodeDefaultsGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override void WriteKeyword(DotAttributeCollection defaults, IDotNodeDefaultsWriter writer)
        {
            writer.WriteNodeKeyword();
        }
    }
}
