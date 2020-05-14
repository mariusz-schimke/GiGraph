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
            WriteEntityKeyword(writer);
            WriteAttributes(defaults, writer);
        }

        protected virtual void WriteEntityKeyword(IDotEntityDefaultsWriter writer)
        {
            writer.WriteEntityKeyword();
        }
    }
}
