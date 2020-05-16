using Gigraph.Dot.Core;
using Gigraph.Dot.Entities.Attributes.Collections;
using Gigraph.Dot.Generators.CommonEntityGenerators;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Generators.Providers;
using Gigraph.Dot.Writers.NodeWriters;

namespace Gigraph.Dot.Generators.NodeGenerators
{
    public class DotNodeDefaultsGenerator : DotEntityWithAttributeListGenerator<DotAttributeCollection, IDotNodeDefaultsWriter>
    {
        public DotNodeDefaultsGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotAttributeCollection defaults, IDotNodeDefaultsWriter writer)
        {
            WriteNodeKeyword(writer);
            WriteAttributes(defaults, writer);
        }

        protected virtual void WriteNodeKeyword(IDotNodeDefaultsWriter writer)
        {
            writer.WriteNodeKeyword();
        }
    }
}
