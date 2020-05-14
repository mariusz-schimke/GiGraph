using Gigraph.Dot.Core;
using Gigraph.Dot.Entities.Attributes.Collections;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Generators.Providers;
using Gigraph.Dot.Writers.CommonEntityWriters;

namespace Gigraph.Dot.Generators.CommonEntityGenerators
{
    public class DotEntityDefaultsGenerator : DotEntityWithAttributeListGenerator<DotAttributeCollection, IDotEntityDefaultsWriter>
    {
        public DotEntityDefaultsGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotAttributeCollection defaults, IDotEntityDefaultsWriter writer)
        {
            WriteEntityKeyword(defaults, writer);
            WriteAttributes(defaults, writer);
        }

        protected virtual void WriteEntityKeyword(DotAttributeCollection defaults, IDotEntityDefaultsWriter writer)
        {
            writer.WriteEntityKeyword();
        }
    }
}
