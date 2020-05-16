using Gigraph.Dot.Core;
using Gigraph.Dot.Entities.Attributes.Collections;
using Gigraph.Dot.Generators.CommonEntityGenerators;
using Gigraph.Dot.Generators.Options;
using Gigraph.Dot.Generators.Providers;
using Gigraph.Dot.Writers.EdgeWriters;

namespace Gigraph.Dot.Generators.EdgeGenerators
{
    public class DotEdgeDefaultsGenerator : DotEntityWithAttributeListGenerator<DotAttributeCollection, IDotEdgeDefaultsWriter>
    {
        public DotEdgeDefaultsGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotAttributeCollection defaults, IDotEdgeDefaultsWriter writer)
        {
            WriteEdgeKeyword(writer);
            WriteAttributes(defaults, writer);
        }

        protected virtual void WriteEdgeKeyword(IDotEdgeDefaultsWriter writer)
        {
            writer.WriteEdgeKeyword();
        }
    }
}
