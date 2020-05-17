using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Core;
using GiGraph.Dot.Generators.CommonEntityGenerators;
using GiGraph.Dot.Generators.Options;
using GiGraph.Dot.Generators.Providers;
using GiGraph.Dot.Writers.NodeWriters;

namespace GiGraph.Dot.Generators.NodeGenerators
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
